using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.AvtomatFeature.CreateAvtomat;

public class CreateAvtomatMapper : Profile
{
    public CreateAvtomatMapper()
    {
        CreateMap<CreateAvtomatRequest, Avtomat>();
    }
}
