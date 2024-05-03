using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ConnectorFeature.CreateConnector;

public class CreateConnectorMapper : Profile
{
    public CreateConnectorMapper()
    {
        CreateMap<CreateConnectorRequest, Connector>();
    }
}
