using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Domain.Entities;

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
            var utpCabelCount = await _context.Cabels
                .Where(x => x.ObyektId == request.ObyektId)
                .Where(x => x.CabelType == CabelTypes.UTPable)
                .CountAsync();

            var electrCabelCount = await _context.Cabels
                .Where(x => x.ObyektId == request.ObyektId)
                .Where(x => x.CabelType == CabelTypes.ElectricCable)
                .CountAsync();

            var swtichPoeCount = await _context.Switches
                .Where(x => x.ObyektId == request.ObyektId)
                .Where(x => x.SwitchType == SwitchTypes.SwitchPoE)
                .CountAsync();

            var swtichComboCount = await _context.Switches
                .Where(x => x.ObyektId == request.ObyektId)
                .Where(x => x.SwitchType == SwitchTypes.SwitchCombo)
                .CountAsync();

            var telecommunicationShelfCount = await _context.Shelves
                .Where(x => x.ObyektId == request.ObyektId)
                .Where(x => x.ShelfType == ShelfTypes.TelecommunicationShelf)
                .CountAsync();

            var centralTelecommunicationShelfCount = await _context.Shelves
                .Where(x => x.ObyektId == request.ObyektId)
                .Where(x => x.ShelfType == ShelfTypes.CentralTelecommunicationShelf)
                .CountAsync();

            var mainElectronicShelfCount = await _context.Shelves
                .Where(x => x.ObyektId == request.ObyektId)
                .Where(x => x.ShelfType == ShelfTypes.MainElectronicShelf)
                .CountAsync();

            var distributionShelfCount = await _context.Shelves
                .Where(x => x.ObyektId == request.ObyektId)
                .Where(x => x.ShelfType == ShelfTypes.DistributionShelf)
                .CountAsync();

            var odfOpticRackCount = await _context.Racks
                .Where(x => x.ObyektId == request.ObyektId)
                .Where(x => x.RackType == RackTypes.ODFOpticRack)
                .CountAsync();

            var miniOpticRackCount = await _context.Racks
                .Where(x => x.ObyektId == request.ObyektId)
                .Where(x => x.RackType == RackTypes.MiniOpticRack)
                .CountAsync();

            var svetaforDetectorCount = await _context.SvetoforDetectors
                .Where(x => x.ObyektId == request.ObyektId)
                .Where(x => x.SvetaforType == SvetaforTypes.SvetaforDetector)
                .CountAsync();

            var svetaforDetectorForCameraCount = await _context.SvetoforDetectors
                .Where(x => x.ObyektId == request.ObyektId)
                .Where(x => x.SvetaforType == SvetaforTypes.SvetaforDetectorForCamera)
                .CountAsync();

            var projectorCount = await _context.Projectors
                .Where(x => x.ObyektId == request.ObyektId)
                .CountAsync();

            var avtomatCount = await _context.Avtomats
                .Where(x => x.ObyektId == request.ObyektId)
                .CountAsync();

            var akumalatorCount = await _context.Akumalators
                .Where(x => x.ObyektId == request.ObyektId)
                .CountAsync();

            var upsCount = await _context.Ups
                .Where(x => x.ObyektId == request.ObyektId)
                .CountAsync();

            var terminalServerCount = await _context.TerminalServers
                .Where(x => x.ObyektId == request.ObyektId)
                .CountAsync();

            var socketCount = await _context.Sockets
                .Where(x => x.ObyektId == request.ObyektId)
                .CountAsync();

            var stabilizerCount = await _context.Stabilizers
                .Where(x => x.ObyektId == request.ObyektId)
                .CountAsync();

            var stanchionCount = await _context.Stanchions
                .Where(x => x.ObyektId == request.ObyektId)
                .CountAsync();

            var speedCheckingCount = await _context.SpeedCheckings
                .Where(x => x.ObyektId == request.ObyektId)
                .CountAsync();

            var cameraCount = await _context.Cameras
                .Where(x => x.ObyektId == request.ObyektId)
                .Where(x => x.CameraType == CameraTypes.Camera)
                .CountAsync();

            var speedCheckingCameraCount = await _context.Cameras
                .Where(x => x.ObyektId == request.ObyektId)
                .Where(x => x.CameraType == CameraTypes.Radar)
                .CountAsync();

            var ptzCameraCount = await _context.Cameras
                .Where(x => x.ObyektId == request.ObyektId)
                .Where(x => x.CameraType == CameraTypes.PTZ)
                .CountAsync();

            var anprCameraCount = await _context.Cameras
                .Where(x => x.ObyektId == request.ObyektId)
                .Where(x => x.CameraType == CameraTypes.ANPR)
                .CountAsync();

            var c327CameraCount = await _context.Cameras
                .Where(x => x.ObyektId == request.ObyektId)
                .Where(x => x.CameraType == CameraTypes.C327)
                .CountAsync();

            var chqbaCameraCount = await _context.Cameras
                .Where(x => x.ObyektId == request.ObyektId)
                .Where(x => x.CameraType == CameraTypes.CHQBA)
                .CountAsync();

            var c733CameraCount = await _context.Cameras
                .Where(x => x.ObyektId == request.ObyektId)
                .Where(x => x.CameraType == CameraTypes.C733)
                .CountAsync();

            var boxesCount = await _context.Boxes
                .Where(x => x.ObyektId == request.ObyektId)
                .CountAsync();

            var bracketCount = await _context.Brackets
                .Where(x => x.ObyektId == request.ObyektId)
                .CountAsync();
         
            var connectorCount = await _context.Connectors
                .Where(x => x.ObyektId == request.ObyektId)
                .CountAsync();

            var counterCount = await _context.Counters
                .Where(x => x.ObyektId == request.ObyektId)
                .CountAsync();

            var cabelHookCount = await _context.Hooks
                .Where(x => x.ObyektId == request.ObyektId)
                .Where(x => x.HookType == HookTypes.CabelHook)
                .CountAsync();

            var sipHookCount = await _context.Hooks
                .Where(x => x.ObyektId == request.ObyektId)
                .Where(x => x.HookType == HookTypes.SipHook)
                .CountAsync();

            var nailCount = await _context.Nails
                .Where(x => x.ObyektId == request.ObyektId)
                .CountAsync();

            var ribbonCount = await _context.Ribbons
                .Where(x => x.ObyektId == request.ObyektId)
                .CountAsync();

            var serverCount = await _context.Servers
                .Where(x => x.ObyektId == request.ObyektId)
                .CountAsync();

            var plasticShellCount = await _context.Shells
                .Where(x => x.ObyektId == request.ObyektId)
                .Where(x => x.ShellType == ShellTypes.PlasticShell)
                .CountAsync();

            var gofraShellCount = await _context.Shells
                .Where(x => x.ObyektId == request.ObyektId)
                .Where(x => x.ShellType == ShellTypes.GofraShell)
                .CountAsync();

            var videoRecorderCount = await _context.VideoRecorders
                .Where(x => x.ObyektId == request.ObyektId)
                .CountAsync();

            var freezerCount = await _context.Freezers
                .Where(x => x.ObyektId == request.ObyektId)
                .CountAsync();

            var glueOfNailCount = await _context.GlueForNails
                .Where(x => x.ObyektId == request.ObyektId)
                .CountAsync();

            var mountingBoxCount = await _context.MountingBoxs
                .Where(x => x.ObyektId == request.ObyektId)
                .CountAsync();

            var response = new GetObyektProductsResponse
            {
                UtpCabelCount = utpCabelCount,
                ElectrCabelCount = electrCabelCount,
                SwitchComboCount = swtichComboCount,
                SwitchPoeCount = swtichPoeCount,
                ProjectorCount = projectorCount,
                AvtomatCount = avtomatCount,
                AkumalatorCount = akumalatorCount,
                UpsCount = upsCount,
                TerminalServerCount = terminalServerCount,
                SocketCount = socketCount,
                StabilizerCount = stabilizerCount,
                StanchionCount = stanchionCount,
                SpeedCheckingCount = speedCheckingCount,
                MainElectronicShelfCount = mainElectronicShelfCount,
                DistributionShelfCount = distributionShelfCount,
                CentralTelecommunicationShelfCount = centralTelecommunicationShelfCount,
                TelecommunicationShelfCount = telecommunicationShelfCount,
                OdfOpticRackCount = odfOpticRackCount,
                MiniOpticRackCount = miniOpticRackCount,
                SvetaforDetectorCount = svetaforDetectorCount,
                SvetaforDetectorForCameraCount = svetaforDetectorForCameraCount,
                CameraCount = cameraCount,
                ANPRCameraCount = anprCameraCount,
                SpeedCheckingCameraCount = speedCheckingCameraCount,
                PTZCameraCount = ptzCameraCount,
                C327CameraCount = c327CameraCount,
                CHQBACameraCount = chqbaCameraCount,
                C733CameraCount = c733CameraCount,
                BoxCount = boxesCount,
                bracketCount = bracketCount,
                ConnectorCount = connectorCount,
                CounterCount = counterCount,
                CabelHookCount = cabelHookCount,
                SipHookCount = sipHookCount,
                GlueForNailCount = glueOfNailCount,
                NailCount = nailCount,
                RibbonCount = ribbonCount,
                ServerCount = serverCount,
                GofraShellCount = gofraShellCount,
                PlasticShellCount = plasticShellCount,
                VideoRecorderCount = videoRecorderCount,
                FreezerCount = freezerCount,
                MountingBoxCount = mountingBoxCount,
            };

            return ResponseHandler.GetAppResponse(type, response);
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
