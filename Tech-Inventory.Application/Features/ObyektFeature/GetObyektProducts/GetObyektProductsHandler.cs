using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.ObyektFeature.GetObyektProducts;

public class GetObyektProductsHandler : IRequestHandler<GetObyektProductsRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;
    private readonly IPaginator _paginator;

    public GetObyektProductsHandler(ITechInventoryDB context, IMapper mapper, IPaginator paginator)
    {
        _context = context;
        _mapper = mapper;
        _paginator = paginator;
    }
    public async Task<ApiResponse> Handle(GetObyektProductsRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var obyektProducts = new List<GetObyektProductsResponse>();

            var akumalatorsCount = await _context.Akumalators.Where(x => x.ObyektId == request.ObyektId).CountAsync();

            if(akumalatorsCount > 0)
            {
                obyektProducts.Add(new GetObyektProductsResponse
                {
                    Name = "Akumalators",
                    Count = akumalatorsCount.ToString()
                });
            }

            var camerasCount = await _context.Cameras.Where(x => x.ObyektId == request.ObyektId).CountAsync();

            if (camerasCount > 0)
            {
                obyektProducts.Add(new GetObyektProductsResponse
                {
                    Name = "Cameras",
                    Count = camerasCount.ToString()
                });
            }

            var cabelsCount = await _context.Cabels.Where(x => x.ObyektId == request.ObyektId).CountAsync();

            if (cabelsCount > 0)
            {
                obyektProducts.Add(new GetObyektProductsResponse
                {
                    Name = "Cabels",
                    Count = cabelsCount.ToString()
                });
            }

            var attechmentsCount = await _context.Attachments.Where(x => x.ObyektId == request.ObyektId).CountAsync();

            if (attechmentsCount > 0)
            {
                obyektProducts.Add(new GetObyektProductsResponse
                {
                    Name = "Attachments",
                    Count = attechmentsCount.ToString()
                });
            }

            var avtomatsCount = await _context.Avtomats.Where(x => x.ObyektId == request.ObyektId).CountAsync();

            if (avtomatsCount > 0)
            {
                obyektProducts.Add(new GetObyektProductsResponse
                {
                    Name = "Avtomats",
                    Count = avtomatsCount.ToString()
                });
            }

            var projectorsCount = await _context.Projectors.Where(x => x.ObyektId == request.ObyektId).CountAsync();

            if (projectorsCount > 0)
            {
                obyektProducts.Add(new GetObyektProductsResponse
                {
                    Name = "Projectors",
                    Count = projectorsCount.ToString()
                });
            }

            var rackesCount = await _context.Racks.Where(x => x.ObyektId == request.ObyektId).CountAsync();

            if (rackesCount > 0)
            {
                obyektProducts.Add(new GetObyektProductsResponse
                {
                    Name = "Rackes",
                    Count = rackesCount.ToString()
                });
            }

            var switchesCount = await _context.Switches.Where(x => x.ObyektId == request.ObyektId).CountAsync();

            if (switchesCount > 0)
            {
                obyektProducts.Add(new GetObyektProductsResponse
                {
                    Name = "Switches",
                    Count = switchesCount.ToString()
                });
            }

            var shelvesCount = await _context.Shelves.Where(x => x.ObyektId == request.ObyektId).CountAsync();

            if (shelvesCount > 0)
            {
                obyektProducts.Add(new GetObyektProductsResponse
                {
                    Name = "Shelves",
                    Count = shelvesCount.ToString()
                });
            }

            var socketsCount = await _context.Sockets.Where(x => x.ObyektId == request.ObyektId).CountAsync();

            if (socketsCount > 0)
            {
                obyektProducts.Add(new GetObyektProductsResponse
                {
                    Name = "Sockets",
                    Count = socketsCount.ToString()
                });
            }

            var stabilizersCount = await _context.Stabilizers.Where(x => x.ObyektId == request.ObyektId).CountAsync();

            if (stabilizersCount > 0)
            {
                obyektProducts.Add(new GetObyektProductsResponse
                {
                    Name = "Stabilizers",
                    Count = stabilizersCount.ToString()
                });
            }

            var svetaforsCount = await _context.SvetoforDetectors.Where(x => x.ObyektId == request.ObyektId).CountAsync();

            if (svetaforsCount > 0)
            {
                obyektProducts.Add(new GetObyektProductsResponse
                {
                    Name = "Svetafors",
                    Count = svetaforsCount.ToString()
                });
            }

            var upsesCount = await _context.Ups.Where(x => x.ObyektId == request.ObyektId).CountAsync();

            if (upsesCount > 0)
            {
                obyektProducts.Add(new GetObyektProductsResponse
                {
                    Name = "Upses",
                    Count = upsesCount.ToString()
                });
            }

            var terminalServersCount = await _context.TerminalServers.Where(x => x.ObyektId == request.ObyektId).CountAsync();

            if (terminalServersCount > 0)
            {
                obyektProducts.Add(new GetObyektProductsResponse
                {
                    Name = "Terminal Servers",
                    Count = terminalServersCount.ToString()
                });
            }

            return ResponseHandler.GetAppResponse(type, obyektProducts);
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
