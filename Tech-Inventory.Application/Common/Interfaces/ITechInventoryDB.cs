using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Common.Interfaces;

public interface ITechInventoryDB
{
    public DbSet<Akumalator> Akumalators { get; set; }
    public DbSet<AspNetClaim> AspNetClaims { get; set; }
    public DbSet<Avtomat> Avtomats { get; set; }
    public DbSet<Attachment> Attachments { get; set; }
    public DbSet<Cabel> Cabels { get; set; }
    public DbSet<Camera> Cameras { get; set; }
    public DbSet<District> Districts { get; set; }
    public DbSet<Street> Streets { get; set; }
    public DbSet<NumberOfOrder> NumberOfOrders { get; set; }
    public DbSet<Obyekt> Obyekts { get; set; }
    public DbSet<Projector> Projectors { get; set; }
    public DbSet<Rack> Racks { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<Shelf> Shelves { get; set; }
    public DbSet<Socket> Sockets { get; set; }
    public DbSet<Stabilizer> Stabilizers { get; set; }
    public DbSet<SvetoforDetector> SvetoforDetectors { get; set; }
    public DbSet<Switch> Switches { get; set; }
    public DbSet<TerminalServer> TerminalServers { get; set; }
    public DbSet<Ups> Ups { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Stanchion> Stanchions { get; set; }
    public DbSet<SpeedChecking> SpeedCheckings { get; set; }
    public DbSet<ObjectClass> ObjectClasses { get; set; }
    public DbSet<ObjectClassType> ObjectClassTypes { get; set; }
    public DbSet<Model> Models { get; set; }
    public DbSet<FTTX> FTTXs { get; set; }
    public DbSet<GPON> GPONs { get; set; }
    public DbSet<GSM> GSMs { get; set; }
    public DbSet<Box> Boxes { get; set; }
    public DbSet<Bracket> Brackets { get; set; }
    public DbSet<Connector> Connectors { get; set; }
    public DbSet<Counter> Counters { get; set; }
    public DbSet<Freezer> Freezers { get; set; }
    public DbSet<GlueForNail> GlueForNails { get; set; }
    public DbSet<Hook> Hooks { get; set; }
    public DbSet<Nail> Nails { get; set; }
    public DbSet<Ribbon> Ribbons { get; set; }
    public DbSet<Server> Servers { get; set; }
    public DbSet<Shell> Shells { get; set; }
    public DbSet<VideoRecorder> VideoRecorders { get; set; }
    public DbSet<MountingBox> MountingBoxs { get; set; }
    public DbSet<UserToken> UserTokens { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

}
