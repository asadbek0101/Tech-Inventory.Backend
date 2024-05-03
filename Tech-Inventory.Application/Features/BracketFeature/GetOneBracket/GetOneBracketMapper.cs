using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.BracketFeature.GetOneBracket;

public class GetOneBracketMapper : Profile
{
    public GetOneBracketMapper()
    {
        CreateMap<Bracket, GetOneBracketResponse>();
    }
}
