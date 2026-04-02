using MediatR;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Features.Products.CreateProducts;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ObyektFeature.CreateObyekt;

public sealed record CreateObyektRequest : IRequest<ApiResponse>
{
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

    public List<CreateAkumalator>? Akumalator { get; set; }
    public List<CreateAvtomat>? Avtomat { get; set; }
    public List<CreateBox>? Box { get; set; }
    public List<CreateBracket>? Bracket { get; set; }
    public List<CreateCabel>? UtpCabel { get; set; }
    public List<CreateCabel>? ElectrCabel { get; set; }
    public List<CreateCamera>? Camera { get; set; }
    public List<CreateCamera>? AnprCamera { get; set; }
    public List<CreateCamera>? SpeedCheckingCamera { get; set; }
    public List<CreateCamera>? PtzCamera { get; set; }
    public List<CreateCamera>? C327Camera { get; set; }
    public List<CreateCamera>? ChqbaCamera { get; set; }
    public List<CreateCamera>? C733Camera { get; set; }
    public List<CreateCamera>? VariofakalCamera { get; set; }
    public List<CreateConnector>? Connector { get; set; }
    public List<CreateCounter>? Counter { get; set; }
    public List<CreateFreezer>? Freezer { get; set; }
    public List<CreateGlue>? GlueForNail { get; set; }
    public List<CreateHook>? CabelHook { get; set; }
    public List<CreateHook>? SipHook { get; set; }
    public List<CreateMountingBox>? MountingBox { get; set; }
    public List<CreateNail>? Nail { get; set; }
    public List<CreateProjector>? Projector { get; set; }
    public List<CreateRack>? OdfOpticRack { get; set; }
    public List<CreateRack>? MiniOptikRack { get; set; }
    public List<CreateRibbon>? Ribbon { get; set; }
    public List<CreateServer>? Server { get; set; }
    public List<CreateShelf>? CentralTelecomunicationShelf { get; set; }
    public List<CreateShelf>? MainTelecomunicationShelf { get; set; }
    public List<CreateShelf>? DistributionShelf { get; set; }
    public List<CreateShelf>? TelecomunicationShelf { get; set; }
    public List<CreateShell>? GofraShell { get; set; }
    public List<CreateShell>? PlasticShell { get; set; }
    public List<CreateSocket>? Socket { get; set; }
    public List<CreateSpeedChecking>? SpeedChecking { get; set; }
    public List<CreateStabilizer>? Stabilizer { get; set; }
    public List<CreateStanchion>? Stanchion { get; set; }
    public List<CreateSvetafor>? SvetaforDetektor { get; set; }
    public List<CreateSvetafor>? SvetaforDetektorForCamera { get; set; }
    public List<CreateSwitch>? SwitchPoe { get; set; }
    public List<CreateSwitch>? SwitchKombo { get; set; }
    public List<CreateTerminalServer>? TerminalServer { get; set; }
    public List<CreateUps>? Ups { get; set; }
    public List<CreateVideoRecorder>? VideoRecorder { get; set; }
}
