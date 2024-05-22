using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.PdfFeature.ObyektReport;

public class ObyektReportMapper : Profile
{
    public ObyektReportMapper()
    {
        CreateMap<Obyekt, ObyektReportResponse>()
            .ForMember(x=>x.Region, otp => otp.MapFrom(ex => ex.Region.Name))
            .ForMember(x=>x.ProjectName, otp => otp.MapFrom(ex => ex.Project.Name))
            .ForMember(x=>x.NumberOfOrder, otp => otp.MapFrom(ex => ex.NumberOfOrder.Number))
            .ForMember(x=>x.ObjectClass, otp => otp.MapFrom(ex => ex.ObjectClass.Name))
            .ForMember(x=>x.ObjectClassType, otp => otp.MapFrom(ex => ex.ObjectClassType.Name))
            .ForMember(x=>x.District, otp=>otp.MapFrom(ex => ex.District.Name))
            .ForMember(x =>x.ConnectionType, otp => otp.MapFrom(x => x.ConnectionType.ToString())); 

        CreateMap<Camera, ObyektReportCamera>()
            .ForMember(x => x.Model, otp => otp.MapFrom(ex => ex.Model.Name)); 
        CreateMap<VideoRecorder, ObyektReportVideoRecorder>()
            .ForMember(x => x.Model, otp => otp.MapFrom(ex => ex.Model.Name)); 
        CreateMap<Switch, ObyektReportSwitch>()
            .ForMember(x => x.Model, otp => otp.MapFrom(ex => ex.Model.Name)); 
        CreateMap<SvetoforDetector, ObyektReportSvetafor>()
            .ForMember(x => x.Model, otp => otp.MapFrom(ex => ex.Model.Name)); 
        CreateMap<TerminalServer, ObyektReportTerminalServer>()
            .ForMember(x => x.Model, otp => otp.MapFrom(ex => ex.Model.Name)); 
        CreateMap<Stabilizer, ObyektReportStabilizer>()
            .ForMember(x => x.Model, otp => otp.MapFrom(ex => ex.Model.Name)); 
        CreateMap<Projector, ObyektReportProjector>()
            .ForMember(x => x.Model, otp => otp.MapFrom(ex => ex.Model.Name)); 
        CreateMap<Akumalator, ObyektReportAkumalator>(); 
        CreateMap<Shelf, ObyektReportShef>()
            .ForMember(x => x.Brand, otp => otp.MapFrom(ex => ex.Model.Name)); 
        CreateMap<Ups, ObyektReportUPS>()
            .ForMember(x => x.Model, otp => otp.MapFrom(ex => ex.Model.Name)); 
        CreateMap<Counter, ObyektReportCounter>()
            .ForMember(x => x.Model, otp => otp.MapFrom(ex => ex.Model.Name)); 
        CreateMap<Cabel, ObyektReportCabel>()
            .ForMember(x => x.Model, otp => otp.MapFrom(ex => ex.Model.Name)); 
        CreateMap<Socket, ObyektReportSocket>()
            .ForMember(x => x.Model, otp => otp.MapFrom(ex => ex.Model.Name)); 
        CreateMap<Rack, ObyektReportRack>(); 
        CreateMap<Avtomat, ObyektReportAvtomat>()
            .ForMember(x => x.Model, otp => otp.MapFrom(ex => ex.Model.Name)); 
        CreateMap<Stanchion, ObyektReportStanchion>()
            .ForMember(x => x.StanchionType, otp => otp.MapFrom(ex => ex.Model.Name)); 
        CreateMap<Bracket, ObyektReportBracket>()
            .ForMember(x => x.Model, otp => otp.MapFrom(ex => ex.Model.Name)); 
        CreateMap<Connector, ObyektReportConnector>(); 
        CreateMap<Shell, ObyektReportShell>(); 
        CreateMap<Box, ObyektReportBox>()
            .ForMember(x => x.Type, otp => otp.MapFrom(ex => ex.Model.Name)); 
        CreateMap<MountingBox, ObyektReportMountingBox>()
            .ForMember(x => x.Model, otp => otp.MapFrom(ex => ex.Model.Name)); 
        CreateMap<Freezer, ObyektReportFreezer>(); 
        CreateMap<Ribbon, ObyektReportRibbon>(); 
        CreateMap<Hook, ObyektReportHook>(); 
        CreateMap<Nail, ObyektReportNail>(); 
        CreateMap<GPON, ObyektReportGPON>()
            .ForMember(x => x.Model, otp => otp.MapFrom(ex => ex.Model.Name)); 
        CreateMap<FTTX, ObyektReportFTTX>()
            .ForMember(x => x.Model, otp => otp.MapFrom(ex => ex.Model.Name)); 
        CreateMap<GSM, ObyektReportGSM>(); 
    }
}
