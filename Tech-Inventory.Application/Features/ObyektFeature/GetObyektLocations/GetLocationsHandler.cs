using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.ObyektFeature.GetObyektLocations;

public class GetLocationsHandler : IRequestHandler<GetLocationsRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;

    public GetLocationsHandler(ITechInventoryDB context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetLocationsRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {

            var query = _context
                .Obyekts
                .AsQueryable();

            if (request.RegionId != 0)
            {
                query = query.Where(x => x.RegionId == request.RegionId);
            }

            if (request.DistrictId != 0)
            {
                query = query.Where(x => x.DistrictId == request.DistrictId);
            }

            if (request.StreetId != 0)
            {
                query = query.Where(x => x.StreetId == request.StreetId);
            }

            if (request.ProjectId != 0)
            {
                query = query.Where(x => x.ProjectId == request.ProjectId);
            }

            if (request.OrderId != 0)
            {
                query = query.Where(x => x.NumberOfOrderId == request.OrderId);
            }

            if (request.ClassTypeId != 0)
            {
                query = query.Where(x => x.ObjectClassTypeId == request.ClassTypeId);
            }

            if (request.ClassId != 0)
            {
                query = query.Where(x => x.ObjectClassId == request.ClassId);
            }

            if (!string.IsNullOrWhiteSpace(request.SearchValue))
            {
                query = query
                       .Where(x => x.NameAndAddress.ToUpper().Contains(request.SearchValue.ToUpper()) ||
                       x.Region.Name.ToUpper().Contains(request.SearchValue.ToUpper()) ||
                       x.Latitude.Contains(request.SearchValue) ||
                       x.Longitude.Contains(request.SearchValue));
            }

            var locations = await query
                .OrderBy(x => x.Id)
                .ToListAsync();

            var obyektsResponse = _mapper.Map<List<GetLocationsResponse>>(locations);

            return ResponseHandler.GetAppResponse(type, obyektsResponse);

        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
