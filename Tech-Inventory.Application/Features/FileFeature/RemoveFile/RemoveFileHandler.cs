using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Helpers;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.FileFeature.RemoveFile;

public class RemoveFileHandler : IRequestHandler<RemoveFileRequest, RemoveFileResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IUnitOfWork _unitOfWork;

    public RemoveFileHandler(ITechInventoryDB context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }
    public async Task<RemoveFileResponse> Handle(RemoveFileRequest request, CancellationToken cancellationToken)
    {
        var filepath = Path.Combine(Path.GetFullPath(FilesFolderURL.URL), request.FileName);
        FileInfo file = new FileInfo(filepath);
        var Message = "File doesn't exists";

        if (file.Exists)
        {
            file.Delete();
            Message = "File deleted successfully";
        }


        var attachment = await _context.Attachments.Where(x => x.ObyektId == request.Id && x.FileName == request.FileName).FirstOrDefaultAsync();

        if(attachment != null)
        {
            _context.Attachments.Remove(attachment);
            await _unitOfWork.Save(cancellationToken);
        }

        return new RemoveFileResponse { Message = Message };
    }
}
