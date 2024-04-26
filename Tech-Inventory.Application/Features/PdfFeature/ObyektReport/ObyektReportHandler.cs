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
                .Include(x=>x.Project)
                .Include(x=>x.ObjectClass)
                .Include(x=>x.ObjectClassType)
                .Include(x=>x.NumberOfOrder)
                .Include(x=>x.District)
                .Where(x => x.Id == request.Id)
                .FirstOrDefaultAsync();

            if(obyekt == null)
            {
                return null;
            }

            var cameras = await _context.Cameras.Where(x => x.ObyektId == request.Id).ToListAsync();
            var elektrCabels = await _context.Cabels.Where(x => x.ObyektId == request.Id && x.CabelType == CabelTypes.ElectricCable).ToListAsync();
            var utpCabels = await _context.Cabels.Where(x => x.ObyektId == request.Id && x.CabelType == CabelTypes.UTPable).ToListAsync();
            var projectors = await _context.Projectors.Where(x => x.ObyektId == request.Id).ToListAsync();
            var switchComboes = await _context.Switches.Where(x => x.ObyektId == request.Id && x.SwitchType == SwitchTypes.SwitchCombo).ToListAsync();
            var switchPoes = await _context.Switches.Where(x => x.ObyektId == request.Id && x.SwitchType == SwitchTypes.SwitchPoE).ToListAsync();
            var avtomats = await _context.Avtomats.Where(x => x.ObyektId == request.Id).ToListAsync();
            var akumlators = await _context.Akumalators.Where(x => x.ObyektId == request.Id).ToListAsync();
            var stabilizers = await _context.Stabilizers.Where(x => x.ObyektId == request.Id).ToListAsync();
            var miniOpticRacks = await _context.Racks.Where(x => x.ObyektId == request.Id && x.RackType == RackTypes.MiniOpticRack).ToListAsync();
            var odfOPpticRacks = await _context.Racks.Where(x => x.ObyektId == request.Id && x.RackType == RackTypes.ODFOpticRack).ToListAsync();
            var sockets = await _context.Sockets.Where(x => x.ObyektId == request.Id).ToListAsync();
            var terminalServers = await _context.TerminalServers.Where(x => x.ObyektId == request.Id).ToListAsync();
            var centralTelecomShelfs = await _context.Shelves.Where(x => x.ObyektId == request.Id && x.ShelfType == ShelfTypes.CentralTelecommunicationShelf).ToListAsync();
            var telecomShelfs = await _context.Shelves.Where(x => x.ObyektId == request.Id && x.ShelfType == ShelfTypes.TelecommunicationShelf).ToListAsync();
            var distrabutionShelfs = await _context.Shelves.Where(x => x.ObyektId == request.Id && x.ShelfType == ShelfTypes.DistributionShelf).ToListAsync();
            var mainElectronicShelfs = await _context.Shelves.Where(x => x.ObyektId == request.Id && x.ShelfType == ShelfTypes.MainElectronicShelf).ToListAsync();
            var svetaforDetektors = await _context.SvetoforDetectors.Where(x => x.ObyektId == request.Id && x.SvetaforType == SvetaforTypes.SvetaforDetector).ToListAsync();
            var svetaforDetektorsForCamera = await _context.SvetoforDetectors.Where(x => x.ObyektId == request.Id && x.SvetaforType == SvetaforTypes.SvetaforDetectorForCamera).ToListAsync();

            var responseCameras = _mapper.Map<List<ObyektReportCamera>>(cameras);
            var responseElektrCabels = _mapper.Map<List<ObyektReportCabel>>(elektrCabels);
            var responseUtpCabels = _mapper.Map<List<ObyektReportCabel>>(utpCabels);
            var responseProjectors = _mapper.Map<List<ObyektReportProjector>>(projectors);
            var responseSwitchComboes = _mapper.Map<List<ObyektReportSwitch>>(switchComboes);
            var responseSwitchPoes = _mapper.Map<List<ObyektReportSwitch>>(switchPoes);
            var responseAvtomats = _mapper.Map<List<ObyektReportAvtomat>>(avtomats);
            var responseAkumalators = _mapper.Map<List<ObyektReportAkumalator>>(akumlators);
            var responseStabilizers = _mapper.Map<List<ObyektReportStabilizer>>(stabilizers);
            var responseMiniOpticRacks = _mapper.Map<List<ObyektReportRack>>(miniOpticRacks);
            var responseOdfOpticRacks = _mapper.Map<List<ObyektReportRack>>(odfOPpticRacks);
            var responseSockets = _mapper.Map<List<ObyektReportSocket>>(sockets);
            var responseTerminalServers = _mapper.Map<List<ObyektReportTerminalServer>>(terminalServers);
            var responseMainElekctrShelfs = _mapper.Map<List<ObyektReportShef>>(mainElectronicShelfs);
            var responseTelecomShelfs = _mapper.Map<List<ObyektReportShef>>(telecomShelfs);
            var responseCentralShelfs = _mapper.Map<List<ObyektReportShef>>(centralTelecomShelfs);
            var responseDistrbutionShelfs = _mapper.Map<List<ObyektReportShef>>(distrabutionShelfs);
            var responseSvetaforDetektros = _mapper.Map<List<ObyektReportSvetafor>>(svetaforDetektors);
            var responseSvetaforDetektrosForCamera = _mapper.Map<List<ObyektReportSvetafor>>(svetaforDetektorsForCamera);
            
            var obyektResponse = _mapper.Map<ObyektReportResponse>(obyekt);

            obyektResponse.Cameras = responseCameras;
            obyektResponse.ElektrCabels = responseElektrCabels;
            obyektResponse.UtpCabels = responseUtpCabels;
            obyektResponse.Projectors = responseProjectors;
            obyektResponse.SwitchKomboes = responseSwitchComboes;
            obyektResponse.SwitchPoes = responseSwitchPoes;
            obyektResponse.Avtomats = responseAvtomats;
            obyektResponse.Akumalators = responseAkumalators;
            obyektResponse.Stabilizers = responseStabilizers;
            obyektResponse.MiniOpticRacks = responseMiniOpticRacks;
            obyektResponse.ODFOpticRacks = responseOdfOpticRacks;
            obyektResponse.Sockets = responseSockets;
            obyektResponse.TerminalServers = responseTerminalServers;
            obyektResponse.TelecomShelfs = responseTelecomShelfs;
            obyektResponse.CentralTelecomShelfs = responseCentralShelfs;
            obyektResponse.MainElectryShelfs = responseMainElekctrShelfs;
            obyektResponse.DistributionShelfs = responseDistrbutionShelfs;
            obyektResponse.SvetaforDetektors = responseSvetaforDetektros;
            obyektResponse.SvetaforDetektorsForCamera = responseSvetaforDetektrosForCamera;
            
            return obyektResponse;
        }
        catch (Exception)
        {

            throw;
        }
    }
}
