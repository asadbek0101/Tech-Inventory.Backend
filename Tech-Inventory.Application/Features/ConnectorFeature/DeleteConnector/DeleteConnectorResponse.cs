namespace Tech_Inventory.Application.Features.ConnectorFeature.DeleteConnector;

public sealed record DeleteConnectorResponse
{
    public int Id { get; set; }
    public string Message { get; set; }
}
