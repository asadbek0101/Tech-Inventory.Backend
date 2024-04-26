namespace Tech_Inventory.Domain.Entities;

public class Obyekt : BaseEntity
{
    public int RegionId { get; set; }
    public int ProjectId { get; set; }
    public int DistrictId { get; set; }
    public int ObjectClassId { get; set; }
    public int NumberOfOrderId { get; set; }
    public int ObjectClassTypeId { get; set; }

    public string Name { get; set; }
    public string Home { get; set; }
    public string Street { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }
    public string? Info { get; set; }
    public ConnectionTypes ConnectionType { get; set; }

    public Region Region { get; set; }
    public Project Project { get; set; }
    public District District { get; set; }
    public ObjectClass ObjectClass { get; set; }
    public NumberOfOrder NumberOfOrder { get; set; }
    public ObjectClassType ObjectClassType { get; set; }

    public List<Ups> Ups  { get; set; }
    public List<Rack> Racks { get; set; }
    public List<Cabel> Cabels { get; set; }
    public List<Shelf> Shelves { get; set; }
    public List<Socket> Sockets { get; set; }
    public List<Camera> Cameras { get; set; }
    public List<Switch> Switches { get; set; }
    public List<Avtomat> Avtomats { get; set; }
    public List<Projector> Projectors { get; set; }
    public List<Stanchion> Stanchions  { get; set; }
    public List<Attachment> Attachments { get; set; }
    public List<Stabilizer> Stabilizers { get; set; }
    public List<Akumalator> Akumalators { get; set; }
    public List<SpeedChecking> SpeedCheckings { get; set; }
    public List<TerminalServer> TerminalServers { get; set; }
    public List<SvetoforDetector> SvetoforDetectors { get; set; }

    public List<GPON> GPONs { get; set; }
    public List<FTTX> FTTXes { get; set; }
    public List<GSM> GSMs { get; set; }
}

public enum ConnectionTypes
{
    FTTX = 1,
    GPON = 2,
    GSM = 3
}