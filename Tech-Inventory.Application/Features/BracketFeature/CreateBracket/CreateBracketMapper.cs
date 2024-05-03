using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.BracketFeature.CreateBracket;

public class CreateBracketMapper : Profile
{
    public CreateBracketMapper()
    {
        CreateMap<CreateBracketRequest, Bracket>();
    }
}
