using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Helpers;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.FileFeature.UploadFile;

public class UploadFilesHandler : IRequestHandler<UploadFilesRequest, string>
{
    private readonly ITechInventoryDB _context;
    private readonly IUnitOfWork _unitOfWork;

    public UploadFilesHandler(ITechInventoryDB context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }

    public async Task<string> Handle(UploadFilesRequest request, CancellationToken cancellationToken)
    {
        var file = request.File;
        var url = FilesFolderURL.URL;
        string filename = "";

        var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
        filename = DateTime.Now.Ticks.ToString() + extension;

        var isHasFile = await _context.Attachments.Where(x => x.ObyektId == request.Id && x.FileName == file.FileName).FirstOrDefaultAsync();

            if (isHasFile == null)
            {

                var filepath = Path.Combine(Path.GetFullPath(url));

                if (!Directory.Exists(filepath))
                {
                    Directory.CreateDirectory(filepath);
                }

                var exactpath = Path.Combine(Path.GetFullPath(url), filename);

                using (var stream = new FileStream(exactpath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                    var _attachment = new Attachment
                    {
                        ObyektId = request.Id,
                        OriginalFileName = file.FileName,
                        FileName = filename,
                        FileSize = file.Length.ToString(),
                    };

                await _context.Attachments.AddAsync(_attachment);
                await _unitOfWork.Save(cancellationToken);
                }
            }


        return "File saved successfully";
    }
}
