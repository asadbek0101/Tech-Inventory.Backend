using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.BracketFeature.UpdateBracket;

public class UpdateBracketMapper : Profile
{
    public UpdateBracketMapper()
    {
        CreateMap<UpdateBracketRequest, Bracket>();
    }
}
