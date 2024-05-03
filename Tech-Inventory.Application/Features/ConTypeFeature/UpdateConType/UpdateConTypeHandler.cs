using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ConTypeFeature.UpdateConType;

public class UpdateConTypeHandler : IRequestHandler<UpdateConTypeRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateConTypeHandler(ITechInventoryDB context, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _context = context;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(UpdateConTypeRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var id = 0;
            if (request.Type == ConnectionTypes.FTTX)
            {
                var oldFttx = await _context.FTTXs.Where(x=>x.ObyektId == request.ObyektId).FirstOrDefaultAsync();

                var fttx = _mapper.Map<FTTX>(request);

                if (oldFttx != null)
                {
                    oldFttx.NumberOfPort = request.NumberOfPort;
                    _context.FTTXs.Update(oldFttx);
                    await _unitOfWork.Save(cancellationToken);
                }
                else
                {
                    _context.FTTXs.Add(fttx);
                    await _unitOfWork.Save(cancellationToken);
                    id = fttx.Id;
                }

                var gpon = await _context.GPONs.Where(x => x.ObyektId == request.ObyektId).FirstOrDefaultAsync();
                var gsm = await _context.GSMs.Where(x => x.ObyektId == request.ObyektId).FirstOrDefaultAsync();

                if(gpon != null)
                {
                    _context.GPONs.Remove(gpon);
                    await _unitOfWork.Save(cancellationToken);
                }

                if (gsm != null)
                {
                    _context.GSMs.Remove(gsm);
                    await _unitOfWork.Save(cancellationToken);
                }

            }

            if (request.Type == ConnectionTypes.GPON)
            {
                var oldGpon = await _context.GPONs.Where(x => x.ObyektId == request.ObyektId).FirstOrDefaultAsync();

                var gpon = _mapper.Map<GPON>(request);

                if (oldGpon != null)
                {
                    oldGpon.NumberOfPort = request.NumberOfPort;
                    oldGpon.SerialNumber = request.SerialNumber;
                    _context.GPONs.Update(oldGpon);
                    await _unitOfWork.Save(cancellationToken);
                }
                else
                {
                    _context.GPONs.Add(gpon);
                    await _unitOfWork.Save(cancellationToken);
                    id = gpon.Id;
                }

                var fttx = await _context.FTTXs.Where(x => x.ObyektId == request.ObyektId).FirstOrDefaultAsync();
                var gsm = await _context.GSMs.Where(x => x.ObyektId == request.ObyektId).FirstOrDefaultAsync();

                if (fttx != null)
                {
                    _context.FTTXs.Remove(fttx);
                    await _unitOfWork.Save(cancellationToken);
                }

                if (gsm != null)
                {
                    _context.GSMs.Remove(gsm);
                    await _unitOfWork.Save(cancellationToken);
                }
            }

            if (request.Type == ConnectionTypes.GSM)
            {
                var oldGSM = await _context.GSMs.Where(x => x.ObyektId == request.ObyektId).FirstOrDefaultAsync();

                var gsm = _mapper.Map<GSM>(request);

                if (oldGSM != null)
                {
                    oldGSM.PhoneNumber = request.PhoneNumber;
                    _context.GSMs.Update(oldGSM);
                    await _unitOfWork.Save(cancellationToken);
                }
                else
                {
                    _context.GSMs.Add(gsm);
                    await _unitOfWork.Save(cancellationToken);
                    id = gsm.Id;
                }

                var fttx = await _context.FTTXs.Where(x => x.ObyektId == request.ObyektId).FirstOrDefaultAsync();
                var gpon = await _context.GPONs.Where(x => x.ObyektId == request.ObyektId).FirstOrDefaultAsync();

                if (fttx != null)
                {
                    _context.FTTXs.Remove(fttx);
                    await _unitOfWork.Save(cancellationToken);
                }

                if (gpon != null)
                {
                    _context.GPONs.Remove(gpon);
                    await _unitOfWork.Save(cancellationToken);
                }
            }

            return ResponseHandler.GetAppResponse(type, new UpdateConTypeResponse { Id = id, Message = "Connection type has updated" });
        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
