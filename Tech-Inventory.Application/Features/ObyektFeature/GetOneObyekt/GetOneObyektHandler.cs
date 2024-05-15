using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ObyektFeature.GetOneObyekt;

public class GetOneObyektHandler : IRequestHandler<GetOneObyektRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;

    public GetOneObyektHandler(ITechInventoryDB context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetOneObyektRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var obyekt = await _context.Obyekts
                .Include(x=>x.Region)
                .Include(x=>x.District)
                .Include(x=>x.Project)
                .Include(x=>x.NumberOfOrder)
                .Include(x=>x.ObjectClassType)
                .Include(x=>x.ObjectClass)
                .Where(x => x.Id == request.Id)
                .FirstOrDefaultAsync();

            var obyektResponse = _mapper.Map<GetOneObyektResponse>(obyekt);

            var attachments = await _context.Attachments.Where(x => x.ObyektId == request.Id).ToListAsync();
            
            var responseAttachments = _mapper.Map<List<GetOneObyektFileResponse>>(attachments);

            obyektResponse.Files = responseAttachments;

            if (obyekt?.ConnectionType == ConnectionTypes.FTTX)
            {
               var connectionType = await _context.FTTXs
                    .Where(x => x.ObyektId == obyekt.Id)
                    .Include(x => x.Model)
                    .FirstOrDefaultAsync();

                obyektResponse.Model = connectionType?.Model?.Name;
                obyektResponse.ModelId = connectionType !=null ? connectionType.ModelId : 0;
                obyektResponse.NumberOfPort = connectionType?.NumberOfPort;
            }

            if (obyekt?.ConnectionType == ConnectionTypes.GPON)
            {
               var connectionType = await _context.GPONs
                    .Where(x => x.ObyektId == obyekt.Id)
                    .Include(x => x.Model)
                    .FirstOrDefaultAsync();

                obyektResponse.Model = connectionType?.Model?.Name;
                obyektResponse.ModelId = connectionType != null ? connectionType.ModelId : 0;
                obyektResponse.SerialNumber = connectionType?.SerialNumber;
                obyektResponse.NumberOfPort = connectionType?.NumberOfPort;
            }

            if (obyekt?.ConnectionType == ConnectionTypes.GSM)
            {
               var connectionType = await _context.GSMs
                    .Where(x => x.ObyektId == obyekt.Id)
                    .FirstOrDefaultAsync();

                obyektResponse.PhoneNumber = connectionType?.PhoneNumber;
            }

            return ResponseHandler.GetAppResponse(type, obyektResponse);
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
