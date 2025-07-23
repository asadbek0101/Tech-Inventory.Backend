using AutoMapper;
using Tech_Inventory.Application.Features.Products.CreateProducts;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ObyektFeature.CreateObyekt;

public class CreateObyektMapper : Profile
{
    public CreateObyektMapper()
    {
        CreateMap<CreateObyektRequest, Obyekt>();
        CreateMap<CreateAkumalator, Akumalator>();
        CreateMap<CreateAvtomat, Avtomat>();
        CreateMap<CreateBox, Box>();
        CreateMap<CreateBracket, Bracket>();
        CreateMap<CreateCabel, Cabel>();
        CreateMap<CreateCamera, Camera>();
        CreateMap<CreateConnector, Connector>();
        CreateMap<CreateCounter, Counter>();
        CreateMap<CreateFreezer, Freezer>();
        CreateMap<CreateGlue, GlueForNail>();
        CreateMap<CreateHook, Hook>();
        CreateMap<CreateMountingBox, MountingBox>();
        CreateMap<CreateNail, Nail>();
        CreateMap<CreateProjector, Projector>();
        CreateMap<CreateRack, Rack>();
        CreateMap<CreateRibbon, Ribbon>();
        CreateMap<CreateServer, Server>();
        CreateMap<CreateShelf, Shelf>();
        CreateMap<CreateShell, Shell>();
        CreateMap<CreateSocket, Socket>();
        CreateMap<CreateSpeedChecking, SpeedChecking>();
        CreateMap<CreateStabilizer, Stabilizer>();
        CreateMap<CreateStanchion, Stanchion>();
        CreateMap<CreateSvetafor, SvetoforDetector>();
        CreateMap<CreateSwitch, Switch>();
        CreateMap<CreateTerminalServer, TerminalServer>();
        CreateMap<CreateUps, Ups>();
        CreateMap<CreateVideoRecorder, VideoRecorder>();

        CreateMap<CreateObyektRequest, Obyekt>()
            .ForMember(dest => dest.Akumalators, opt => opt.Ignore())
            .ForMember(dest => dest.Avtomats, opt => opt.Ignore())
            .ForMember(dest => dest.Boxes, opt => opt.Ignore())
            .ForMember(dest => dest.Brackets, opt => opt.Ignore())
            .ForMember(dest => dest.Cabels, opt => opt.Ignore())
            .ForMember(dest => dest.Cameras, opt => opt.Ignore())
            .ForMember(dest => dest.Connectors, opt => opt.Ignore())
            .ForMember(dest => dest.Counters, opt => opt.Ignore())
            .ForMember(dest => dest.Freezers, opt => opt.Ignore())
            .ForMember(dest => dest.GlueForNails, opt => opt.Ignore())
            .ForMember(dest => dest.Hooks, opt => opt.Ignore())
            .ForMember(dest => dest.Nails, opt => opt.Ignore())
            .ForMember(dest => dest.Projectors, opt => opt.Ignore())
            .ForMember(dest => dest.Racks, opt => opt.Ignore())
            .ForMember(dest => dest.Ribbons, opt => opt.Ignore())
            .ForMember(dest => dest.Servers, opt => opt.Ignore())
            .ForMember(dest => dest.Shelves, opt => opt.Ignore())
            .ForMember(dest => dest.Shells, opt => opt.Ignore())
            .ForMember(dest => dest.Sockets, opt => opt.Ignore())
            .ForMember(dest => dest.SpeedCheckings, opt => opt.Ignore())
            .ForMember(dest => dest.Stabilizers, opt => opt.Ignore())
            .ForMember(dest => dest.Stanchions, opt => opt.Ignore())
            .ForMember(dest => dest.SvetoforDetectors, opt => opt.Ignore())
            .ForMember(dest => dest.Switches, opt => opt.Ignore())
            .ForMember(dest => dest.TerminalServers, opt => opt.Ignore())
            .ForMember(dest => dest.Ups, opt => opt.Ignore())
            .ForMember(dest => dest.VideoRecorders, opt => opt.Ignore())
            .ForMember(dest => dest.Attachments, opt => opt.Ignore())
            .ForMember(dest => dest.FTTXes, opt => opt.Ignore())
            .ForMember(dest => dest.GPONs, opt => opt.Ignore())
            .ForMember(dest => dest.GSMs, opt => opt.Ignore());
    }
}
