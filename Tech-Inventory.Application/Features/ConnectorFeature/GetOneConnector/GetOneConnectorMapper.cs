using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ConnectorFeature.GetOneConnector;

public class GetOneConnectorMapper : Profile
{
    public GetOneConnectorMapper()
    {
        CreateMap<Connector, GetOneConnectorResponse>();
    }
}
