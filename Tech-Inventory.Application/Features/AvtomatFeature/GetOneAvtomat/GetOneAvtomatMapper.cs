using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.AvtomatFeature.GetOneAvtomat;

public class GetOneAvtomatMapper : Profile
{
    public GetOneAvtomatMapper()
    {
        CreateMap<Avtomat, GetOneAvtomatResponse>()
            .ForMember(x => x.Model, otp => otp.MapFrom(x => x.Model.Name));
    }
}
