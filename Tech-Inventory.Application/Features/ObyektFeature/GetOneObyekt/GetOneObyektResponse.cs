using Tech_Inventory.Application.Features.Products.ProductsResponse;

namespace Tech_Inventory.Application.Features.ObyektFeature.GetOneObyekt;

public sealed record GetOneObyektResponse
{
    public int Id { get; set; }
    public int CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public int RegionId { get; set; }
    public int DistrictId { get; set; }
    public int StreetId { get; set; }
    public int ProjectId { get; set; }
    public int NumberOfOrderId { get; set; }
    public int ObjectClassId { get; set; }
    public int ObjectClassTypeId { get; set; }
    public string Region { get; set; }
    public string District { get; set; }
    public string Street { get; set; }
    public string Project { get; set; }
    public string NumberOfOrder { get; set; }
    public string ObjectClass { get; set; }
    public string ObjectClassType { get; set; }
    public string NameAndAddress { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }
    public string Info { get; set; }
    public int ConnectionTypeId { get; set; }
    public string ConnectionType { get; set; }
    public string Model { get; set; }
    public int ModelId { get; set; }
    public string SerialNumber { get; set; }
    public string NumberOfPort { get; set; }
    public string PhoneNumber { get; set; }
    public List<GetOneObyektFileResponse>? Files { get; set; }

    public List<AkumalatorResponse> Akumalator { get; set; }
    public List<AvtomatResponse> Avtomat { get; set; }
    public List<BoxResponse> Box { get; set; }
    public List<BracketResponse> Bracket { get; set; }
    public List<CabelResponse> UtpCabel { get; set; }
    public List<CabelResponse> ElectrCabel { get; set; }
    public List<CameraResponse> Camera { get; set; }
    public List<CameraResponse> AnprCamera { get; set; }
    public List<CameraResponse> SpeedCheckingCamera { get; set; }
    public List<CameraResponse> PtzCamera { get; set; }
    public List<CameraResponse> C327Camera { get; set; }
    public List<CameraResponse> ChqbaCamera { get; set; }
    public List<CameraResponse> C733Camera { get; set; }
    public List<ConnectorResponse> Connector { get; set; }
    public List<CounterResponse> Counter { get; set; }
    public List<FreezerResponse> Freezer { get; set; }
    public List<GlueResponse> GlueForNail { get; set; }
    public List<HookResponse> SipHook { get; set; }
    public List<HookResponse> CabelHook { get; set; }
    public List<MountingBoxResponse> MountingBox { get; set; }
    public List<NailResponse> Nail { get; set; }
    public List<ProjectorResponse> Projector { get; set; }
    public List<RackResponse> OdfOpticRack { get; set; }
    public List<RackResponse> MiniOpticRack { get; set; }
    public List<RibbonResponse> Ribbon { get; set; }
    public List<ServerResponse> Server { get; set; }
    public List<ShelfResponse> CentralTelecomunicationShelf { get; set; }
    public List<ShelfResponse> MainTelecomunicationShelf { get; set; }
    public List<ShelfResponse> DistributionShelf { get; set; }
    public List<ShelfResponse> TelecomunicationShelf { get; set; }
    public List<ShellResponse> PlasticShell { get; set; }
    public List<ShellResponse> GofraShell { get; set; }
    public List<SocketResponse> Socket { get; set; }
    public List<SpeedCheckingResponse> SpeedChecking { get; set; }
    public List<StabilizerResponse> Stabilizer { get; set; }
    public List<StanchionResponse> Stanchion { get; set; }
    public List<SvetaforResponse> SvetaforDetektor { get; set; }
    public List<SvetaforResponse> SvetaforDetektorForCamera { get; set; }
    public List<SwitchResponse> SwitchPoe { get; set; }
    public List<SwitchResponse> SwitchKombo { get; set; }
    public List<TerminalServerResponse> TerminalServer { get; set; }
    public List<UpsResponse> Ups { get; set; }
    public List<VideoRecorderResponse> VideoRecorder { get; set; }
}
