using AutoMapper;
using MediatR;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ObyektFeature.CreateObyekt;

public class CreateObyektHandler : IRequestHandler<CreateObyektRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CreateObyektHandler(ITechInventoryDB context, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _context = context;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(CreateObyektRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var obyekt = _mapper.Map<Obyekt>(request);

            _context.Obyekts.Add(obyekt);
            await _unitOfWork.Save(cancellationToken);

            // akumalators

            var akumalators = _mapper.Map<List<Akumalator>>(request.Akumalator);

            akumalators.ForEach(x =>
            {
                x.ObyektId = obyekt.Id;
            });

            _context.Akumalators.AddRange(akumalators);
            await _unitOfWork.Save(cancellationToken);

            // avtomats

            var avtomats = _mapper.Map<List<Avtomat>>(request.Avtomat);

            avtomats.ForEach(x =>
            {
                x.ObyektId = obyekt.Id;
            });

            _context.Avtomats.AddRange(avtomats);
            await _unitOfWork.Save(cancellationToken);

            // box

            var boxes = _mapper.Map<List<Box>>(request.Box);

            boxes.ForEach(x =>
            {
                x.ObyektId = obyekt.Id;
            });

            _context.Boxes.AddRange(boxes);
            await _unitOfWork.Save(cancellationToken);

            // brackets

            var brackets = _mapper.Map<List<Bracket>>(request.Bracket);

            brackets.ForEach(x =>
            {
                x.ObyektId = obyekt.Id;
            });

            _context.Brackets.AddRange(brackets);
            await _unitOfWork.Save(cancellationToken);

            // cabels

            var utpCabel = _mapper.Map<List<Cabel>>(request.UtpCabel);

            utpCabel.ForEach(x =>
            {
                x.ObyektId = obyekt.Id;
                x.CabelType = CabelTypes.UTPable;
            });

            _context.Cabels.AddRange(utpCabel);
            await _unitOfWork.Save(cancellationToken);
            
            // cabels

            var electrCabel = _mapper.Map<List<Cabel>>(request.ElectrCabel);

            electrCabel.ForEach(x =>
            {
                x.ObyektId = obyekt.Id;
                x.CabelType = CabelTypes.ElectricCable;
            });

            _context.Cabels.AddRange(electrCabel);
            await _unitOfWork.Save(cancellationToken);

            // camera

            var cameras = _mapper.Map<List<Camera>>(request.Camera);

            cameras.ForEach(x =>
            {
                x.ObyektId = obyekt.Id;
                x.CameraType = CameraTypes.Camera;
            });

            _context.Cameras.AddRange(cameras);
            await _unitOfWork.Save(cancellationToken);

            // camera

            var anprCamera = _mapper.Map<List<Camera>>(request.AnprCamera);

            anprCamera.ForEach(x =>
            {
                x.ObyektId = obyekt.Id;
                x.CameraType = CameraTypes.ANPR;
            });

            _context.Cameras.AddRange(anprCamera);
            await _unitOfWork.Save(cancellationToken);

            // camera

            var speedCheckingCamera = _mapper.Map<List<Camera>>(request.SpeedCheckingCamera);

            speedCheckingCamera.ForEach(x =>
            {
                x.ObyektId = obyekt.Id;
                x.CameraType = CameraTypes.Radar;
            });

            _context.Cameras.AddRange(speedCheckingCamera);
            await _unitOfWork.Save(cancellationToken);

            // camera

            var ptzCamera = _mapper.Map<List<Camera>>(request.PtzCamera);

            ptzCamera.ForEach(x =>
            {
                x.ObyektId = obyekt.Id;
                x.CameraType = CameraTypes.PTZ;
            });

            _context.Cameras.AddRange(ptzCamera);
            await _unitOfWork.Save(cancellationToken);

            // camera

            var c327Camera = _mapper.Map<List<Camera>>(request.C327Camera);

            c327Camera.ForEach(x =>
            {
                x.ObyektId = obyekt.Id;
                x.CameraType = CameraTypes.C327;
            });

            _context.Cameras.AddRange(c327Camera);
            await _unitOfWork.Save(cancellationToken);

            // camera

            var chqbaCamera = _mapper.Map<List<Camera>>(request.ChqbaCamera);

            chqbaCamera.ForEach(x =>
            {
                x.ObyektId = obyekt.Id;
                x.CameraType = CameraTypes.CHQBA;
            });

            _context.Cameras.AddRange(chqbaCamera);
            await _unitOfWork.Save(cancellationToken);

            // camera


            var c733Camera = _mapper.Map<List<Camera>>(request.C733Camera);

            c733Camera.ForEach(x =>
            {
                x.ObyektId = obyekt.Id;
                x.CameraType = CameraTypes.C733;
            });

            _context.Cameras.AddRange(c733Camera);
            await _unitOfWork.Save(cancellationToken);

            // connectors

            var connectors = _mapper.Map<List<Connector>>(request.Connector);

            connectors.ForEach(x =>
            {
                x.ObyektId = obyekt.Id;
            });

            _context.Connectors.AddRange(connectors);
            await _unitOfWork.Save(cancellationToken);

            // counters

            var counters = _mapper.Map<List<Counter>>(request.Counter);

            counters.ForEach(x =>
            {
                x.ObyektId = obyekt.Id;
            });

            _context.Counters.AddRange(counters);
            await _unitOfWork.Save(cancellationToken);

            // freezers

            var freezers = _mapper.Map<List<Freezer>>(request.Freezer);

            freezers.ForEach(x =>
            {
                x.ObyektId = obyekt.Id;
            });

            _context.Freezers.AddRange(freezers);
            await _unitOfWork.Save(cancellationToken);

            // glues

            var glues = _mapper.Map<List<GlueForNail>>(request.GlueForNail);

            glues.ForEach(x =>
            {
                x.ObyektId = obyekt.Id;
            });

            _context.GlueForNails.AddRange(glues);
            await _unitOfWork.Save(cancellationToken);

            // hooks

            var sipHook = _mapper.Map<List<Hook>>(request.SipHook);

            sipHook.ForEach(x =>
            {
                x.ObyektId = obyekt.Id;
                x.HookType = HookTypes.SipHook;
            });

            _context.Hooks.AddRange(sipHook);
            await _unitOfWork.Save(cancellationToken);

            // hooks

            var cabelHook = _mapper.Map<List<Hook>>(request.CabelHook);

            cabelHook.ForEach(x =>
            {
                x.ObyektId = obyekt.Id;
                x.HookType = HookTypes.CabelHook;
            });

            _context.Hooks.AddRange(cabelHook);
            await _unitOfWork.Save(cancellationToken);

            // mounting box

            var mountingBoxes = _mapper.Map<List<MountingBox>>(request.MountingBox);

            mountingBoxes.ForEach(x =>
            {
                x.ObyektId = obyekt.Id;
            });

            _context.MountingBoxes.AddRange(mountingBoxes);
            await _unitOfWork.Save(cancellationToken);

            // nail

            var nails = _mapper.Map<List<Nail>>(request.Nail);

            nails.ForEach(x =>
            {
                x.ObyektId = obyekt.Id;
            });

            _context.Nails.AddRange(nails);
            await _unitOfWork.Save(cancellationToken);

            // projector

            var projectors = _mapper.Map<List<Projector>>(request.Projector);

            projectors.ForEach(x =>
            {
                x.ObyektId = obyekt.Id;
            });

            _context.Projectors.AddRange(projectors);
            await _unitOfWork.Save(cancellationToken);

            // rack

            var odfOpticRack = _mapper.Map<List<Rack>>(request.OdfOpticRack);

            odfOpticRack.ForEach(x =>
            {
                x.ObyektId = obyekt.Id;
                x.RackType = RackTypes.ODFOpticRack;
            });

            _context.Racks.AddRange(odfOpticRack);
            await _unitOfWork.Save(cancellationToken);

            // rack

            var miniOptikRack = _mapper.Map<List<Rack>>(request.MiniOptikRack);

            miniOptikRack.ForEach(x =>
            {
                x.ObyektId = obyekt.Id;
                x.RackType = RackTypes.MiniOpticRack;
            });

            _context.Racks.AddRange(miniOptikRack);
            await _unitOfWork.Save(cancellationToken);

            // ribbon

            var ribbons = _mapper.Map<List<Ribbon>>(request.Ribbon);

            ribbons.ForEach(x =>
            {
                x.ObyektId = obyekt.Id;
            });

            _context.Ribbons.AddRange(ribbons);
            await _unitOfWork.Save(cancellationToken);

            // server

            var servers = _mapper.Map<List<Server>>(request.Server);

            servers.ForEach(x =>
            {
                x.ObyektId = obyekt.Id;
            });

            _context.Servers.AddRange(servers);
            await _unitOfWork.Save(cancellationToken);


            // shelf

            var centralTelecomunicationShelf = _mapper.Map<List<Shelf>>(request.CentralTelecomunicationShelf);

            centralTelecomunicationShelf.ForEach(x =>
            {
                x.ObyektId = obyekt.Id;
                x.ShelfType = ShelfTypes.CentralTelecommunicationShelf;
            });

            _context.Shelves.AddRange(centralTelecomunicationShelf);
            await _unitOfWork.Save(cancellationToken);

            // shelf

            var mainTelecomunicationShelf = _mapper.Map<List<Shelf>>(request.MainTelecomunicationShelf);

            mainTelecomunicationShelf.ForEach(x =>
            {
                x.ObyektId = obyekt.Id;
                x.ShelfType = ShelfTypes.MainElectronicShelf;
            });

            _context.Shelves.AddRange(mainTelecomunicationShelf);
            await _unitOfWork.Save(cancellationToken);

            // shelf

            var distributionShelf = _mapper.Map<List<Shelf>>(request.DistributionShelf);

            distributionShelf.ForEach(x =>
            {
                x.ObyektId = obyekt.Id;
                x.ShelfType = ShelfTypes.DistributionShelf;
            });

            _context.Shelves.AddRange(distributionShelf);
            await _unitOfWork.Save(cancellationToken);

            // shelf

            var telecomunicationShelf = _mapper.Map<List<Shelf>>(request.TelecomunicationShelf);

            telecomunicationShelf.ForEach(x =>
            {
                x.ObyektId = obyekt.Id;
                x.ShelfType = ShelfTypes.TelecommunicationShelf;
            });

            _context.Shelves.AddRange(telecomunicationShelf);
            await _unitOfWork.Save(cancellationToken);

            // shell

            var gofraShell = _mapper.Map<List<Shell>>(request.GofraShell);

            gofraShell.ForEach(x =>
            {
                x.ObyektId = obyekt.Id;
                x.ShellType = ShellTypes.GofraShell;
            });

            _context.Shells.AddRange(gofraShell);
            await _unitOfWork.Save(cancellationToken);

            // shell

            var plasticShell = _mapper.Map<List<Shell>>(request.PlasticShell);

            plasticShell.ForEach(x =>
            {
                x.ObyektId = obyekt.Id;
                x.ShellType = ShellTypes.PlasticShell;
            });

            _context.Shells.AddRange(plasticShell);
            await _unitOfWork.Save(cancellationToken);

            // socket

            var sockets = _mapper.Map<List<Socket>>(request.Socket);

            sockets.ForEach(x =>
            {
                x.ObyektId = obyekt.Id;
            });

            _context.Akumalators.AddRange(akumalators);
            await _unitOfWork.Save(cancellationToken);

            // speed checking

            var speedChecking = _mapper.Map<List<Akumalator>>(request.Akumalator);

            akumalators.ForEach(x =>
            {
                x.ObyektId = obyekt.Id;
            });

            _context.Akumalators.AddRange(akumalators);
            await _unitOfWork.Save(cancellationToken);

            // stabilizers

            var stabilizers = _mapper.Map<List<Stabilizer>>(request.Stabilizer);

            stabilizers.ForEach(x =>
            {
                x.ObyektId = obyekt.Id;
            });

            _context.Stabilizers.AddRange(stabilizers);
            await _unitOfWork.Save(cancellationToken);

            // stanchion

            var stanchions = _mapper.Map<List<Stanchion>>(request.Akumalator);

            stanchions.ForEach(x =>
            {
                x.ObyektId = obyekt.Id;
            });

            _context.Stanchions.AddRange(stanchions);
            await _unitOfWork.Save(cancellationToken);

            // svetafor

            var svetaforDetektor = _mapper.Map<List<SvetoforDetector>>(request.SvetaforDetektor);

            svetaforDetektor.ForEach(x =>
            {
                x.ObyektId = obyekt.Id;
                x.SvetaforType = SvetaforTypes.SvetaforDetector;
            });

            _context.SvetoforDetectors.AddRange(svetaforDetektor);
            await _unitOfWork.Save(cancellationToken);

            // svetafor

            var svetaforDetektorForCamera = _mapper.Map<List<SvetoforDetector>>(request.SvetaforDetektorForCamera);

            svetaforDetektorForCamera.ForEach(x =>
            {
                x.ObyektId = obyekt.Id;
                x.SvetaforType = SvetaforTypes.SvetaforDetectorForCamera;
            });

            _context.SvetoforDetectors.AddRange(svetaforDetektorForCamera);
            await _unitOfWork.Save(cancellationToken);

            // switch

            var switchPoe = _mapper.Map<List<Switch>>(request.SwitchPoe);

            switchPoe.ForEach(x =>
            {
                x.ObyektId = obyekt.Id;
                x.SwitchType = SwitchTypes.SwitchPoE;
            });

            _context.Switches.AddRange(switchPoe);
            await _unitOfWork.Save(cancellationToken);


            // switch

            var switchKombo = _mapper.Map<List<Switch>>(request.SwitchKombo);

            switchKombo.ForEach(x =>
            {
                x.ObyektId = obyekt.Id;
                x.SwitchType = SwitchTypes.SwitchCombo;
            });

            _context.Switches.AddRange(switchKombo);
            await _unitOfWork.Save(cancellationToken);

            // terminal server

            var terminalServers = _mapper.Map<List<TerminalServer>>(request.TerminalServer);

            terminalServers.ForEach(x =>
            {
                x.ObyektId = obyekt.Id;
            });

            _context.TerminalServers.AddRange(terminalServers);
            await _unitOfWork.Save(cancellationToken);

            // ups

            var upses = _mapper.Map<List<Ups>>(request.Ups);

            upses.ForEach(x =>
            {
                x.ObyektId = obyekt.Id;
            });

            _context.Ups.AddRange(upses);
            await _unitOfWork.Save(cancellationToken);

            // video recorder

            var videoRecorders = _mapper.Map<List<VideoRecorder>>(request.VideoRecorder);

            videoRecorders.ForEach(x =>
            {
                x.ObyektId = obyekt.Id;
            });

            _context.VideoRecorders.AddRange(videoRecorders);
            await _unitOfWork.Save(cancellationToken);


            return ResponseHandler.GetAppResponse(type, new CreateObyektResponse { Id = obyekt.Id, Message = "Obyekt has created" });
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
