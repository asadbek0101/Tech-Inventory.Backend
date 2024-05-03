using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ConnectorFeature.UpdateConnector;

public class UpdateConnectorMapper : Profile
{
    public UpdateConnectorMapper()
    {
        CreateMap<UpdateConnectorRequest, Connector>();
    }
}
