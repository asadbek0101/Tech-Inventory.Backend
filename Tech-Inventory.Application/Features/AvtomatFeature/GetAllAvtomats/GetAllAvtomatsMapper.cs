using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.AvtomatFeature.GetAllAvtomats;

public class GetAllAvtomatsMapper : Profile
{
    public GetAllAvtomatsMapper()
    {
        CreateMap<Avtomat, GetAllAvtomatsResponse>()
            .ForMember(x => x.Model, otp => otp.MapFrom(x => x.Model.Name));
    }
}
