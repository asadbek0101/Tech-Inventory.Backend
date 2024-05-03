using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ConnectorFeature.GetAllConnectors;

public class GetAllConnectorsMapper : Profile
{
    public GetAllConnectorsMapper()
    {
        CreateMap<Connector, GetAllConnectorsResponse>();
    }
}
