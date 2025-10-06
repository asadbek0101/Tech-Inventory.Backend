using MediatR;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Features.Products.CreateProducts;
using Tech_Inventory.Application.Features.Products.UpdateProducts;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ObyektFeature.UpdateObyekt;

public sealed record UpdateObyektRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
    public int RegionId { get; set; }
    public int DistrictId { get; set; }
    public int StreetId { get; set; }
    public int ProjectId { get; set; }
    public int NumberOfOrderId { get; set; }
    public int ObjectClassId { get; set; }
    public int ObjectClassTypeId { get; set; }
    public string NameAndAddress { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }
    public string? Info { get; set; }
    public ConnectionTypes ConnectionType { get; set; }

    public List<UpdateAkumalator> Akumalator { get; set; }
    public List<UpdateAvtomat> Avtomat { get; set; }
    public List<UpdateBox> Box { get; set; }
    public List<UpdateBracket> Bracket { get; set; }
    public List<UpdateCabel> UtpCabel { get; set; }
    public List<UpdateCabel> ElectrCabel { get; set; }
    public List<UpdateCamera> Camera { get; set; }
    public List<UpdateCamera> AnprCamera { get; set; }
    public List<UpdateCamera> SpeedCheckingCamera { get; set; }
    public List<UpdateCamera> PtzCamera { get; set; }
    public List<UpdateCamera> C327Camera { get; set; }
    public List<UpdateCamera> ChqbaCamera { get; set; }
    public List<UpdateCamera> C733Camera { get; set; }
    public List<UpdateConnector> Connector { get; set; }
    public List<UpdateCounter> Counter { get; set; }
    public List<UpdateFreezer> Freezer { get; set; }
    public List<UpdateGlue> GlueForNail { get; set; }
    public List<UpdateHook> CabelHook { get; set; }
    public List<UpdateHook> SipHook { get; set; }
    public List<UpdateNail> Nail { get; set; }
    public List<UpdateProjector> Projector { get; set; }
    public List<UpdateRack> OdfOpticRack { get; set; }
    public List<UpdateRack> MiniOpticRack { get; set; }
    public List<UpdateRibbon> Ribbon { get; set; }
    public List<UpdateServer> Server { get; set; }
    public List<UpdateShelf> CentralTelecomunicationShelf { get; set; }
    public List<UpdateShelf> MainTelecomunicationShelf { get; set; }
    public List<UpdateShelf> DistributionShelf { get; set; }
    public List<UpdateShelf> TelecomunicationShelf { get; set; }
    public List<UpdateShell> GofraShell { get; set; }
    public List<UpdateShell> PlasticShell { get; set; }
    public List<UpdateSocket> Socket { get; set; }
    public List<UpdateSpeedChecking> SpeedChecking { get; set; }
    public List<UpdateStabilizer> Stabilizer { get; set; }
    public List<UpdateStanchion> Stanchion { get; set; }
    public List<UpdateSvetafor> SvetaforDetektor { get; set; }
    public List<MountingBox> MountingBox { get; set; }
    public List<UpdateSvetafor> SvetaforDetektorForCamera { get; set; }
    public List<UpdateSwitch> SwitchPoe { get; set; }
    public List<UpdateSwitch> SwitchKombo { get; set; }
    public List<UpdateTerminalServer> TerminalServer { get; set; }
    public List<UpdateUps> Ups { get; set; }
    public List<UpdateVideoRecorder> VideoRecorder { get; set; }
}
