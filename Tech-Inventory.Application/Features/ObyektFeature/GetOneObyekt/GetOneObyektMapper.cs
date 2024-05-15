using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ObyektFeature.GetOneObyekt;

public class GetOneObyektMapper : Profile
{
    public GetOneObyektMapper()
    {
        CreateMap<Obyekt, GetOneObyektResponse>()
            .ForMember(x => x.Region, otp => otp.MapFrom(ex => ex.Region.Name))
            .ForMember(x => x.District, otp => otp.MapFrom(ex => ex.District.Name))
            .ForMember(x => x.Project, otp => otp.MapFrom(ex => ex.Project.Name))
            .ForMember(x => x.NumberOfOrder, otp => otp.MapFrom(ex => ex.NumberOfOrder.Number))
            .ForMember(x => x.ObjectClass, otp => otp.MapFrom(ex => ex.ObjectClass.Name))
            .ForMember(x => x.ObjectClassType, otp => otp.MapFrom(ex => ex.ObjectClassType.Name))
            .ForMember(x => x.ConnectionTypeId, otp => otp.MapFrom(ex => ex.ConnectionType))
            .ForMember(x => x.ConnectionType, otp => otp.MapFrom(ex => ex.ConnectionType.ToString()))
        ;

        CreateMap<Attachment, GetOneObyektFileResponse>()
            .ForMember(x => x.Name, opt => opt.MapFrom(x => x.FileName));
    }
}
