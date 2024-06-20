using Minio.DataModel.Args;
using Minio;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Application.Common.Helpers;

namespace Tech_Inventory.WebApi.Services;

public class MinioService : IMinioService
{
    private readonly IMinioClient _minioClient;

    private readonly string? _bucket = "tech-inventory-bucket";

    private Task<bool> IsBucketExists() =>
        _minioClient.BucketExistsAsync(new BucketExistsArgs().WithBucket(_bucket));

    private async Task<string> IsFileExists(string token)
    {
        var statObjectArgs = new StatObjectArgs()
            .WithBucket(_bucket)
            .WithObject(token);

        var status = await _minioClient.StatObjectAsync(statObjectArgs);
        if (status == null)
            throw new Exception("File not found or deleted");

        return status.ContentType;
    }

    public MinioService(IMinioClientFactory minioClientFactory)
    {
        _minioClient = minioClientFactory.CreateClient();
    }

    public async Task<string> PutObject(IFormFile file)
    {
        if (!await IsBucketExists())
            throw new Exception("NotFound");

        var filestream = new MemoryStream(await file.GetBytes());
        string filename = "";

        var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
        filename = DateTime.Now.Ticks.ToString() + extension;

        var putObjectArgs = new PutObjectArgs()
            .WithBucket(_bucket)
            .WithObject(filename)
            .WithStreamData(filestream)
            .WithObjectSize(filestream.Length)
            .WithContentType(file.ContentType);

        await _minioClient.PutObjectAsync(putObjectArgs);
        return filename;
    }

    public async Task<GetObjectDto> GetObject(string token)
    {
        if (!await IsBucketExists())
            throw new Exception("NotFound");

        var contentType = await IsFileExists(token);

        var destination = new MemoryStream();

        var getObjectArgs = new GetObjectArgs()
            .WithBucket(_bucket)
            .WithObject(token)
            .WithCallbackStream((stream) => { stream.CopyTo(destination); });
        await _minioClient.GetObjectAsync(getObjectArgs);

        return new GetObjectDto()
        {
            Bytes = destination.ToArray(),
            ContentType = contentType
        };
    }

    public async Task<bool> RemoveObject(string token)
    {
        if (!await IsBucketExists())
            throw new Exception("NotFound");
        try
        {
            RemoveObjectArgs args = new RemoveObjectArgs()
                .WithBucket(_bucket)
                .WithObject(token);

            await _minioClient.RemoveObjectAsync(args);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return true;
    }
}

public static class FormFileExtensions
{
    public static async Task<byte[]> GetBytes(this IFormFile formFile)
    {
        await using var memoryStream = new MemoryStream();
        await formFile.CopyToAsync(memoryStream);
        return memoryStream.ToArray();
    }
}