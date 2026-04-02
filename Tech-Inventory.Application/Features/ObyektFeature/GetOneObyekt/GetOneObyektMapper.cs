using AutoMapper;
using Tech_Inventory.Application.Features.Products.ProductsResponse;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ObyektFeature.GetOneObyekt;

public class GetOneObyektMapper : Profile
{
    public GetOneObyektMapper()
    {
        CreateMap<Obyekt, GetOneObyektResponse>()
            .ForMember(x => x.Region, otp => otp.MapFrom(ex => ex.Region.Name))
            .ForMember(x => x.District, otp => otp.MapFrom(ex => ex.District.Name))
            .ForMember(x => x.Street, otp => otp.MapFrom(ex => ex.Streett.Name))
            .ForMember(x => x.Project, otp => otp.MapFrom(ex => ex.Project.Name))
            .ForMember(x => x.NumberOfOrder, otp => otp.MapFrom(ex => ex.NumberOfOrder.Number))
            .ForMember(x => x.ObjectClass, otp => otp.MapFrom(ex => ex.ObjectClass.Name))
            .ForMember(x => x.ObjectClassType, otp => otp.MapFrom(ex => ex.ObjectClassType.Name))
            .ForMember(x => x.ConnectionTypeId, otp => otp.MapFrom(ex => ex.ConnectionType))
            .ForMember(x => x.ConnectionType, otp => otp.MapFrom(ex => ex.ConnectionType.ToString()))

            .ForMember(x => x.Akumalator, otp => otp.MapFrom(ex => ex.Akumalators))
            .ForMember(x => x.Avtomat, otp => otp.MapFrom(ex => ex.Avtomats))
            .ForMember(x => x.Box, otp => otp.MapFrom(ex => ex.Boxes))
            .ForMember(x => x.Bracket, otp => otp.MapFrom(ex => ex.Brackets))
            .ForMember(x => x.UtpCabel, otp => otp.MapFrom(ex => ex.Cabels.Where(x => x.CabelType == CabelTypes.UTPable)))
            .ForMember(x => x.ElectrCabel, otp => otp.MapFrom(ex => ex.Cabels.Where(x => x.CabelType == CabelTypes.ElectricCable)))
            .ForMember(x => x.Camera, otp => otp.MapFrom(ex => ex.Cameras.Where(x => x.CameraType == CameraTypes.Camera)))
            .ForMember(x => x.AnprCamera, otp => otp.MapFrom(ex => ex.Cameras.Where(x => x.CameraType == CameraTypes.ANPR)))
            .ForMember(x => x.SpeedCheckingCamera, otp => otp.MapFrom(ex => ex.Cameras.Where(x => x.CameraType == CameraTypes.Radar)))
            .ForMember(x => x.PtzCamera, otp => otp.MapFrom(ex => ex.Cameras.Where(x => x.CameraType == CameraTypes.PTZ)))
            .ForMember(x => x.C327Camera, otp => otp.MapFrom(ex => ex.Cameras.Where(x => x.CameraType == CameraTypes.C327)))
            .ForMember(x => x.ChqbaCamera, otp => otp.MapFrom(ex => ex.Cameras.Where(x => x.CameraType == CameraTypes.CHQBA)))
            .ForMember(x => x.C733Camera, otp => otp.MapFrom(ex => ex.Cameras.Where(x => x.CameraType == CameraTypes.C733)))
            .ForMember(x => x.VariofakalCamera, otp => otp.MapFrom(ex => ex.Cameras.Where(x => x.CameraType == CameraTypes.Variofakal)))
            .ForMember(x => x.Connector, otp => otp.MapFrom(ex => ex.Connectors))
            .ForMember(x => x.Counter, otp => otp.MapFrom(ex => ex.Counters))
            .ForMember(x => x.Freezer, otp => otp.MapFrom(ex => ex.Freezers))
            .ForMember(x => x.GlueForNail, otp => otp.MapFrom(ex => ex.GlueForNails))
            .ForMember(x => x.SipHook, otp => otp.MapFrom(ex => ex.Hooks.Where(x => x.HookType == HookTypes.SipHook)))
            .ForMember(x => x.CabelHook, otp => otp.MapFrom(ex => ex.Hooks.Where(x => x.HookType == HookTypes.CabelHook)))
            .ForMember(x => x.Nail, otp => otp.MapFrom(ex => ex.Nails))
            .ForMember(x => x.Projector, otp => otp.MapFrom(ex => ex.Projectors))
            .ForMember(x => x.MiniOpticRack, otp => otp.MapFrom(ex => ex.Racks.Where(x => x.RackType == RackTypes.MiniOpticRack)))
            .ForMember(x => x.OdfOpticRack, otp => otp.MapFrom(ex => ex.Racks.Where(x => x.RackType == RackTypes.ODFOpticRack)))
            .ForMember(x => x.Ribbon, otp => otp.MapFrom(ex => ex.Ribbons))
            .ForMember(x => x.Server, otp => otp.MapFrom(ex => ex.Servers))
            .ForMember(x => x.TelecomunicationShelf, otp => otp.MapFrom(ex => ex.Shelves.Where(x => x.ShelfType == ShelfTypes.TelecommunicationShelf)))
            .ForMember(x => x.MainTelecomunicationShelf, otp => otp.MapFrom(ex => ex.Shelves.Where(x => x.ShelfType == ShelfTypes.MainElectronicShelf)))
            .ForMember(x => x.CentralTelecomunicationShelf, otp => otp.MapFrom(ex => ex.Shelves.Where(x => x.ShelfType == ShelfTypes.CentralTelecommunicationShelf)))
            .ForMember(x => x.DistributionShelf, otp => otp.MapFrom(ex => ex.Shelves.Where(x => x.ShelfType == ShelfTypes.DistributionShelf)))
            .ForMember(x => x.GofraShell, otp => otp.MapFrom(ex => ex.Shells.Where(x => x.ShellType == ShellTypes.GofraShell)))
            .ForMember(x => x.PlasticShell, otp => otp.MapFrom(ex => ex.Shells.Where(x => x.ShellType == ShellTypes.PlasticShell)))
            .ForMember(x => x.Socket, otp => otp.MapFrom(ex => ex.Sockets))
            .ForMember(x => x.SpeedChecking, otp => otp.MapFrom(ex => ex.SpeedCheckings))
            .ForMember(x => x.Stabilizer, otp => otp.MapFrom(ex => ex.Stabilizers))
            .ForMember(x => x.Stanchion, otp => otp.MapFrom(ex => ex.Stanchions))
            .ForMember(x => x.SvetaforDetektor, otp => otp.MapFrom(ex => ex.SvetoforDetectors.Where(x => x.SvetaforType == SvetaforTypes.SvetaforDetector)))
            .ForMember(x => x.SvetaforDetektorForCamera, otp => otp.MapFrom(ex => ex.SvetoforDetectors.Where(x => x.SvetaforType == SvetaforTypes.SvetaforDetectorForCamera)))
            .ForMember(x => x.SwitchPoe, otp => otp.MapFrom(ex => ex.Switches.Where(x => x.SwitchType == SwitchTypes.SwitchPoE)))
            .ForMember(x => x.SwitchKombo, otp => otp.MapFrom(ex => ex.Switches.Where(x => x.SwitchType == SwitchTypes.SwitchCombo)))
            .ForMember(x => x.TerminalServer, otp => otp.MapFrom(ex => ex.TerminalServers))
            .ForMember(x => x.Ups, otp => otp.MapFrom(ex => ex.Ups))
            .ForMember(x => x.MountingBox, otp => otp.MapFrom(ex => ex.MountingBoxes))
            .ForMember(x => x.VideoRecorder, otp => otp.MapFrom(ex => ex.VideoRecorders));

        CreateMap<Attachment, GetOneObyektFileResponse>()
            .ForMember(x => x.Name, opt => opt.MapFrom(x => x.FileName));

        CreateMap<Akumalator, AkumalatorResponse>();
        CreateMap<Avtomat, AvtomatResponse>()
            .ForMember(x => x.Model, otp => otp.MapFrom(ex => ex.Model.Name));
        CreateMap<Box, BoxResponse>()
            .ForMember(x => x.Type, otp => otp.MapFrom(ex => ex.Model.Name));
        CreateMap<Bracket, BracketResponse>()
            .ForMember(x => x.Model, otp => otp.MapFrom(ex => ex.Model.Name));
        CreateMap<Cabel, CabelResponse>()
            .ForMember(x => x.Model, otp => otp.MapFrom(ex => ex.Model.Name));
        CreateMap<Camera, CameraResponse>()
            .ForMember(x => x.Model, otp => otp.MapFrom(ex => ex.Model.Name));
        CreateMap<Connector, ConnectorResponse>();
        CreateMap<Counter, CounterResponse>()
            .ForMember(x => x.Model, otp => otp.MapFrom(ex => ex.Model.Name));
        CreateMap<Freezer, FreezerResponse>();
        CreateMap<GlueForNail, GlueResponse>();
        CreateMap<Hook, HookResponse>();
        CreateMap<MountingBox, MountingBoxResponse>()
            .ForMember(x => x.Model, otp => otp.MapFrom(ex => ex.Model.Name));
        CreateMap<Nail, NailResponse>();
        CreateMap<Projector, Projector>()
            .ForMember(x => x.Model, otp => otp.MapFrom(ex => ex.Model.Name));
        CreateMap<Rack, RackResponse>();
        CreateMap<Ribbon, RibbonResponse>();
        CreateMap<Server, ServerResponse>();
        CreateMap<Shelf, ShelfResponse>()
            .ForMember(x => x.Brand, otp => otp.MapFrom(ex => ex.Model.Name));
        CreateMap<Shell, ShellResponse>();
        CreateMap<Socket, SocketResponse>()
            .ForMember(x => x.Model, otp => otp.MapFrom(ex => ex.Model.Name));
        CreateMap<SpeedChecking, SpeedCheckingResponse>();
        CreateMap<Stabilizer, StabilizerResponse>()
            .ForMember(x => x.Model, otp => otp.MapFrom(ex => ex.Model.Name));
        CreateMap<Stanchion, StanchionResponse>()
            .ForMember(x => x.StanchionType, otp => otp.MapFrom(ex => ex.Model.Name));
        CreateMap<SvetoforDetector, SvetaforResponse>()
            .ForMember(x => x.Model, otp => otp.MapFrom(ex => ex.Model.Name));
        CreateMap<Switch, SwitchResponse>()
            .ForMember(x => x.Model, otp => otp.MapFrom(ex => ex.Model.Name));
        CreateMap<TerminalServer, TerminalServerResponse>()
            .ForMember(x => x.Model, otp => otp.MapFrom(ex => ex.Model.Name));
        CreateMap<Ups, UpsResponse>()
            .ForMember(x => x.Model, otp => otp.MapFrom(ex => ex.Model.Name));
        CreateMap<VideoRecorder, VideoRecorderResponse>()
            .ForMember(x => x.Model, otp => otp.MapFrom(ex => ex.Model.Name));
    }
}
