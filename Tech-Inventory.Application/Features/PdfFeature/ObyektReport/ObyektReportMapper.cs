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
            .ForMember(x=>x.NumberOfOrder, otp => otp.MapFrom(ex => ex.NumberOfOrder.Name))
            .ForMember(x=>x.ObjectClass, otp => otp.MapFrom(ex => ex.ObjectClass.Name))
            .ForMember(x=>x.ObjectClassType, otp => otp.MapFrom(ex => ex.ObjectClassType.Name))
            .ForMember(x=>x.District, otp=>otp.MapFrom(ex => ex.District.Name)); 

        CreateMap<Camera, ObyektReportCamera>(); 
        CreateMap<Cabel, ObyektReportCabel>(); 
        CreateMap<Projector, ObyektReportProjector>(); 
        CreateMap<Switch, ObyektReportSwitch>(); 
        CreateMap<Avtomat, ObyektReportAvtomat>(); 
        CreateMap<Akumalator, ObyektReportAkumalator>(); 
        CreateMap<Stabilizer, ObyektReportStabilizer>(); 
        CreateMap<Rack, ObyektReportRack>(); 
        CreateMap<Socket, ObyektReportSocket>(); 
        CreateMap<TerminalServer, ObyektReportTerminalServer>(); 
        CreateMap<Shelf, ObyektReportShef>(); 
        CreateMap<SvetoforDetector, ObyektReportSvetafor>(); 
    }
}
