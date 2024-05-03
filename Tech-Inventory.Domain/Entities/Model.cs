namespace Tech_Inventory.Domain.Entities;

public class Model : BaseEntity
{
    public string Name { get; set; }
    public string? Info { get; set; }
    public ModelTypes Type { get; set; }

    public List<Switch> Switches { get; set; }
    public List<SvetoforDetector> Svetafors { get; set; }
    public List<TerminalServer> TerminalServers { get; set; }
    public List<Stabilizer> Stabilizers { get; set; }
    public List<Camera> Cameras { get; set; }
    public List<Projector> Projectors { get; set; }
    public List<Avtomat> Avtomats { get; set; }
    public List<Cabel> Cabels { get; set; }
    public List<Stanchion> Stanchions { get; set; }
    public List<Socket> Sockets { get; set; }
    public List<SpeedChecking> SpeedCheckings { get; set; }
    public List<Ups> Upses { get; set; }
    public List<FTTX> FTTXes { get; set; }
    public List<GPON> GPONs { get; set; }
    public List<Box> Boxes { get; set; }
    public List<Bracket> Brackets { get; set; }
    public List<Counter> Counters { get; set; }
    public List<VideoRecorder> VideoRecorders { get; set; }
}


public enum ModelTypes
{
    All = 1,
    Switch = 2,
    Svetafor = 3,
    TerminalServer = 4,
    Stabilizer = 5,
    Camera = 6,
    Projector = 7,
    Avtomat = 8,
    Cabel = 9,
    Stanchion = 10,
    Socket = 11,
    SpeedChecking = 12,
    Ups = 13,
    FTTX = 14,
    GPON = 15,
    Box = 16,
    Bracket = 17,
    Counter = 18,
    VideoRecorder = 19
}
