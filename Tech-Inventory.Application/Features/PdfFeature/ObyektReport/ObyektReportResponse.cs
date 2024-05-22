namespace Tech_Inventory.Application.Features.PdfFeature.ObyektReport;

public sealed record ObyektReportResponse
{
    public int Id { get; set; }
    public string Region { get; set; }
    public string District { get; set; }
    public string ProjectName { get; set; }
    public string NumberOfOrder { get; set; }
    public string ObjectClassType { get; set; }
    public string ObjectClass { get; set; }
    public string NameAndAddress { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }
    public string ConnectionType { get; set; }


    public List<ObyektReportCamera> Cameras { get; set; }
    public List<ObyektReportCamera> RaradCameras { get; set; }
    public List<ObyektReportCamera> PTZCameras { get; set; }
    public List<ObyektReportCamera> ANPRCameras { get; set; }
    public List<ObyektReportCamera> C327Cameras { get; set; }
    public List<ObyektReportCamera> C733Cameras { get; set; }
    public List<ObyektReportCamera> ChqbaCameras { get; set; }
    public List<ObyektReportVideoRecorder> VideoRecorders { get; set; }
    public List<ObyektReportServer> Servers { get; set; }
    public List<ObyektReportSwitch> SwitchPoes { get; set; }
    public List<ObyektReportSwitch> SwitchKomboes { get; set; }
    public List<ObyektReportSvetafor> SvetaforDetektors { get; set; }
    public List<ObyektReportSvetafor> SvetaforDetektorsForCamera { get; set; }
    public List<ObyektReportTerminalServer> TerminalServers { get; set; }
    public List<ObyektReportStabilizer> Stabilizers { get; set; }
    public List<ObyektReportProjector> Projectors { get; set; }
    public List<ObyektReportAkumalator> Akumalators { get; set; }
    public List<ObyektReportShef> MainElectryShelfs { get; set; }
    public List<ObyektReportShef> CentralTelecomShelfs { get; set; }
    public List<ObyektReportShef> TelecomShelfs { get; set; }
    public List<ObyektReportShef> DistributionShelfs { get; set; }
    public List<ObyektReportUPS> Upses { get; set; }
    public List<ObyektReportCounter> Counters { get; set; }
    public List<ObyektReportCabel> UtpCabels { get; set; }
    public List<ObyektReportCabel> ElektrCabels { get; set; }
    public List<ObyektReportSocket> Sockets { get; set; }
    public List<ObyektReportRack> ODFOpticRacks { get; set; }
    public List<ObyektReportRack> MiniOpticRacks { get; set; }
    public List<ObyektReportAvtomat> Avtomats { get; set; }
    public List<ObyektReportStanchion> Stanchions { get; set; }
    public List<ObyektReportBracket> Brackets { get; set; }
    public List<ObyektReportConnector> Connectors { get; set; }
    public List<ObyektReportShell> GofraShells { get; set; }
    public List<ObyektReportBox> Boxes { get; set; }
    public List<ObyektReportMountingBox> MountingBoxes { get; set; }
    public List<ObyektReportFreezer> Freezers { get; set; }
    public List<ObyektReportRibbon> Ribbons { get; set; }
    public List<ObyektReportHook> SipHooks { get; set; }
    public List<ObyektReportNail> Nails { get; set; }
    public List<ObyektReportHook> CabelHooks { get; set; }
    public List<ObyektReportShell> PlasticShells { get; set; }
    public List<ObyektReportGPON> GPONs { get; set; }
    public List<ObyektReportFTTX> FTTXs { get; set; }
    public List<ObyektReportGSM> GSMs { get; set; }
}
