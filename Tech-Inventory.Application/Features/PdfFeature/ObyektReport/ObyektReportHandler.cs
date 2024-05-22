using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.PdfFeature.ObyektReport;

public class ObyektReportHandler : IRequestHandler<ObyektReportRequest, ObyektReportResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;

    public ObyektReportHandler(ITechInventoryDB context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ObyektReportResponse> Handle(ObyektReportRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var obyekt = await _context
                .Obyekts
                .Include(x=>x.Region)
                .Include(x=>x.District)
                .Include(x=>x.Project)
                .Include(x=>x.NumberOfOrder)
                .Include(x=>x.ObjectClass)
                .Include(x=>x.ObjectClassType)
                .Where(x => x.Id == request.Id)
                .FirstOrDefaultAsync();

            if(obyekt == null)
            {
                return null;
            }

            var cameras = await _context.Cameras.Include(x => x.Model).Where(x => x.ObyektId == request.Id && x.CameraType == CameraTypes.Camera).ToListAsync();
            var radarCameras = await _context.Cameras.Include(x => x.Model).Where(x => x.ObyektId == request.Id && x.CameraType == CameraTypes.Radar).ToListAsync();
            var anprCameras = await _context.Cameras.Include(x => x.Model).Where(x => x.ObyektId == request.Id && x.CameraType == CameraTypes.ANPR).ToListAsync();
            var ptzCameras = await _context.Cameras.Include(x => x.Model).Where(x => x.ObyektId == request.Id && x.CameraType == CameraTypes.PTZ).ToListAsync();
            var c327Cameras = await _context.Cameras.Where(x => x.ObyektId == request.Id && x.CameraType == CameraTypes.C327).ToListAsync();
            var chqbaCameras = await _context.Cameras.Include(x => x.Model).Where(x => x.ObyektId == request.Id && x.CameraType == CameraTypes.CHQBA).ToListAsync();
            var c733Cameras = await _context.Cameras.Include(x => x.Model).Where(x => x.ObyektId == request.Id && x.CameraType == CameraTypes.C733).ToListAsync();
            var videoRecorders = await _context.VideoRecorders.Include(x => x.Model).Where(x => x.ObyektId == request.Id).ToListAsync();
            var servers = await _context.Servers.Where(x => x.ObyektId == request.Id).ToListAsync();
            var switchPoes = await _context.Switches.Include(x => x.Model).Where(x => x.ObyektId == request.Id && x.SwitchType == SwitchTypes.SwitchPoE).ToListAsync();
            var switchComboes = await _context.Switches.Include(x => x.Model).Where(x => x.ObyektId == request.Id && x.SwitchType == SwitchTypes.SwitchCombo).ToListAsync();
            var svetaforDetektors = await _context.SvetoforDetectors.Include(x => x.Model).Where(x => x.ObyektId == request.Id && x.SvetaforType == SvetaforTypes.SvetaforDetector).ToListAsync();
            var svetaforDetektorsForCamera = await _context.SvetoforDetectors.Include(x => x.Model).Where(x => x.ObyektId == request.Id && x.SvetaforType == SvetaforTypes.SvetaforDetectorForCamera).ToListAsync();
            var terminalServers = await _context.TerminalServers.Include(x => x.Model).Where(x => x.ObyektId == request.Id).ToListAsync();
            var stabilizers = await _context.Stabilizers.Include(x => x.Model).Where(x => x.ObyektId == request.Id).ToListAsync();
            var projectors = await _context.Projectors.Include(x => x.Model).Where(x => x.ObyektId == request.Id).ToListAsync();
            var akumlators = await _context.Akumalators.Where(x => x.ObyektId == request.Id).ToListAsync();
            var centralTelecomShelfs = await _context.Shelves.Include(x => x.Model).Where(x => x.ObyektId == request.Id && x.ShelfType == ShelfTypes.CentralTelecommunicationShelf).ToListAsync();
            var telecomShelfs = await _context.Shelves.Include(x => x.Model).Where(x => x.ObyektId == request.Id && x.ShelfType == ShelfTypes.TelecommunicationShelf).ToListAsync();
            var distrabutionShelfs = await _context.Shelves.Include(x => x.Model).Where(x => x.ObyektId == request.Id && x.ShelfType == ShelfTypes.DistributionShelf).ToListAsync();
            var mainElectronicShelfs = await _context.Shelves.Include(x => x.Model).Where(x => x.ObyektId == request.Id && x.ShelfType == ShelfTypes.MainElectronicShelf).ToListAsync();
            var upses = await _context.Ups.Include(x => x.Model).Where(x => x.ObyektId == request.Id).ToListAsync();
            var counters = await _context.Counters.Include(x => x.Model).Where(x => x.ObyektId == request.Id).ToListAsync();
            var utpCabels = await _context.Cabels.Include(x => x.Model).Where(x => x.ObyektId == request.Id && x.CabelType == CabelTypes.UTPable).ToListAsync();
            var elektrCabels = await _context.Cabels.Include(x => x.Model).Where(x => x.ObyektId == request.Id && x.CabelType == CabelTypes.ElectricCable).ToListAsync();
            var sockets = await _context.Sockets.Include(x => x.Model).Where(x => x.ObyektId == request.Id).ToListAsync();
            var odfOPpticRacks = await _context.Racks.Where(x => x.ObyektId == request.Id && x.RackType == RackTypes.ODFOpticRack).ToListAsync();
            var miniOpticRacks = await _context.Racks.Where(x => x.ObyektId == request.Id && x.RackType == RackTypes.MiniOpticRack).ToListAsync();
            var avtomats = await _context.Avtomats.Include(x => x.Model).Where(x => x.ObyektId == request.Id).ToListAsync();
            var stanchions = await _context.Stanchions.Include(x => x.Model).Where(x => x.ObyektId == request.Id).ToListAsync();
            var brackets = await _context.Brackets.Include(x => x.Model).Where(x => x.ObyektId == request.Id).ToListAsync();
            var connectors = await _context.Connectors.Where(x => x.ObyektId == request.Id).ToListAsync();
            var gofraShells = await _context.Shells.Where(x => x.ObyektId == request.Id && x.ShellType == ShellTypes.GofraShell).ToListAsync();
            var boxes = await _context.Boxes.Include(x => x.Model).Where(x => x.ObyektId == request.Id).ToListAsync();
            var mountingBoxes = await _context.MountingBoxs.Include(x => x.Model).Where(x => x.ObyektId == request.Id).ToListAsync();
            var freezers = await _context.Freezers.Where(x => x.ObyektId == request.Id).ToListAsync();
            var ribbons = await _context.Ribbons.Where(x => x.ObyektId == request.Id).ToListAsync();
            var sipHooks = await _context.Hooks.Where(x => x.ObyektId == request.Id && x.HookType == HookTypes.SipHook).ToListAsync();
            var nails = await _context.Nails.Where(x => x.ObyektId == request.Id).ToListAsync();
            var cabelHooks = await _context.Hooks.Where(x => x.ObyektId == request.Id && x.HookType == HookTypes.CabelHook).ToListAsync();
            var plasticShells = await _context.Shells.Where(x => x.ObyektId == request.Id && x.ShellType == ShellTypes.PlasticShell).ToListAsync();
            var gpons = await _context.GPONs.Include(x => x.Model).Where(x => x.ObyektId == request.Id).ToListAsync();
            var fttxs = await _context.FTTXs.Include(x => x.Model).Where(x => x.ObyektId == request.Id).ToListAsync();
            var gsms = await _context.GSMs.Where(x => x.ObyektId == request.Id).ToListAsync();

            var obyektResponse = _mapper.Map<ObyektReportResponse>(obyekt);

            obyektResponse.Cameras = _mapper.Map<List<ObyektReportCamera>>(cameras);
            obyektResponse.RaradCameras = _mapper.Map<List<ObyektReportCamera>>(radarCameras);
            obyektResponse.ANPRCameras = _mapper.Map<List<ObyektReportCamera>>(anprCameras);
            obyektResponse.PTZCameras = _mapper.Map<List<ObyektReportCamera>>(ptzCameras);
            obyektResponse.C327Cameras = _mapper.Map<List<ObyektReportCamera>>(c327Cameras);
            obyektResponse.C733Cameras = _mapper.Map<List<ObyektReportCamera>>(c733Cameras);
            obyektResponse.ChqbaCameras = _mapper.Map<List<ObyektReportCamera>>(chqbaCameras);
            obyektResponse.VideoRecorders = _mapper.Map<List<ObyektReportVideoRecorder>>(videoRecorders);
            obyektResponse.Servers = _mapper.Map<List<ObyektReportServer>>(servers);
            obyektResponse.SwitchPoes = _mapper.Map<List<ObyektReportSwitch>>(switchPoes);
            obyektResponse.SwitchKomboes = _mapper.Map<List<ObyektReportSwitch>>(switchComboes);
            obyektResponse.SvetaforDetektors = _mapper.Map<List<ObyektReportSvetafor>>(svetaforDetektors);
            obyektResponse.SvetaforDetektorsForCamera = _mapper.Map<List<ObyektReportSvetafor>>(svetaforDetektorsForCamera);
            obyektResponse.TerminalServers = _mapper.Map<List<ObyektReportTerminalServer>>(terminalServers);
            obyektResponse.Stabilizers = _mapper.Map<List<ObyektReportStabilizer>>(stabilizers);
            obyektResponse.Projectors = _mapper.Map<List<ObyektReportProjector>>(projectors);
            obyektResponse.Akumalators = _mapper.Map<List<ObyektReportAkumalator>>(akumlators);
            obyektResponse.TelecomShelfs = _mapper.Map<List<ObyektReportShef>>(telecomShelfs);
            obyektResponse.CentralTelecomShelfs = _mapper.Map<List<ObyektReportShef>>(centralTelecomShelfs);
            obyektResponse.MainElectryShelfs = _mapper.Map<List<ObyektReportShef>>(mainElectronicShelfs);
            obyektResponse.DistributionShelfs = _mapper.Map<List<ObyektReportShef>>(distrabutionShelfs);
            obyektResponse.Upses = _mapper.Map<List<ObyektReportUPS>>(upses);
            obyektResponse.Counters = _mapper.Map<List<ObyektReportCounter>>(counters);
            obyektResponse.UtpCabels = _mapper.Map<List<ObyektReportCabel>>(utpCabels);
            obyektResponse.ElektrCabels = _mapper.Map<List<ObyektReportCabel>>(elektrCabels);
            obyektResponse.Sockets = _mapper.Map<List<ObyektReportSocket>>(sockets);
            obyektResponse.ODFOpticRacks = _mapper.Map<List<ObyektReportRack>>(odfOPpticRacks);
            obyektResponse.MiniOpticRacks = _mapper.Map<List<ObyektReportRack>>(miniOpticRacks);
            obyektResponse.Avtomats = _mapper.Map<List<ObyektReportAvtomat>>(avtomats);
            obyektResponse.Stanchions = _mapper.Map<List<ObyektReportStanchion>>(stanchions);
            obyektResponse.Brackets = _mapper.Map<List<ObyektReportBracket>>(brackets);
            obyektResponse.Connectors = _mapper.Map<List<ObyektReportConnector>>(connectors);
            obyektResponse.GofraShells = _mapper.Map<List<ObyektReportShell>>(gofraShells);
            obyektResponse.Boxes = _mapper.Map<List<ObyektReportBox>>(boxes);
            obyektResponse.MountingBoxes = _mapper.Map<List<ObyektReportMountingBox>>(mountingBoxes);
            obyektResponse.Freezers = _mapper.Map<List<ObyektReportFreezer>>(freezers);
            obyektResponse.Ribbons = _mapper.Map<List<ObyektReportRibbon>>(ribbons);
            obyektResponse.SipHooks = _mapper.Map<List<ObyektReportHook>>(sipHooks);
            obyektResponse.Nails = _mapper.Map<List<ObyektReportNail>>(nails);
            obyektResponse.CabelHooks = _mapper.Map<List<ObyektReportHook>>(cabelHooks);
            obyektResponse.PlasticShells = _mapper.Map<List<ObyektReportShell>>(plasticShells);
            obyektResponse.GPONs = _mapper.Map<List<ObyektReportGPON>>(gpons);
            obyektResponse.FTTXs = _mapper.Map<List<ObyektReportFTTX>>(fttxs);
            obyektResponse.GSMs = _mapper.Map<List<ObyektReportGSM>>(gsms);

            return obyektResponse;
        }
        catch (Exception)
        {

            throw;
        }
    }
}
