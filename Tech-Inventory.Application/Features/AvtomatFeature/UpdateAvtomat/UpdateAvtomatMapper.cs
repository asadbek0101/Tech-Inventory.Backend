using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.AvtomatFeature.UpdateAvtomat;

public class UpdateAvtomatMapper : Profile
{
    public UpdateAvtomatMapper()
    {
        CreateMap<UpdateAvtomatRequest, Avtomat>();
    }
}
