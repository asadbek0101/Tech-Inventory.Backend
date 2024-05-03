using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.BracketFeature.GetAllBrackets;

public class GetAllBracketsMapper : Profile
{
    public GetAllBracketsMapper()
    {
        CreateMap<Bracket, GetAllBracketsResponse>()
            .ForMember(x=>x.Model, otp=>otp.MapFrom(x=>x.Model.Name));
    }
}
