using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Domain.Entities;
using Tech_Inventory.Domain.IdentityEntities;
using Tech_Inventory.Persistence.Interceptors;

namespace Tech_Inventory.Persistence;

public class TechInventoryDB : IdentityDbContext<ApplicationUser, ApplicationRole, int>, ITechInventoryDB
{
    private readonly EntitySaveChangesInterceptor _entitySaveChangesInterceptor;
    public TechInventoryDB(DbContextOptions<TechInventoryDB> options, EntitySaveChangesInterceptor entitySaveChangesInterceptor) : base(options)
    {
        _entitySaveChangesInterceptor = entitySaveChangesInterceptor;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_entitySaveChangesInterceptor);
    }

    public DbSet<Akumalator> Akumalators { get; set; }
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
    public DbSet<SpeedChecking> SpeedCheckings { get; set; }
    public DbSet<AspNetClaim> AspNetClaims { get; set; }
    public DbSet<ObjectClass> ObjectClasses { get; set; }
    public DbSet<ObjectClassType> ObjectClassTypes { get; set; }
    public DbSet<Stanchion> Stanchions { get; set; }
    public DbSet<Model> Models { get; set; }
    public DbSet<FTTX> FTTXs { get; set; }
    public DbSet<GPON> GPONs { get; set; }
    public DbSet<GSM> GSMs { get; set; }
    //
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
    public DbSet<MountingBox> MountingBoxes { get; set; }
    public DbSet<UserToken> UserTokens { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Region>()
                    .HasMany(u => u.Obyekts)
                    .WithOne(c => c.Region)
                    .HasForeignKey(c => c.RegionId)
                    .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Region>()
                    .HasMany(u => u.NumberOfOrders)
                    .WithOne(c => c.Region)
                    .HasForeignKey(c => c.RegionId)
                    .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Region>()
                    .HasMany(u => u.Users)
                    .WithOne(c => c.Region)
                    .HasForeignKey(c => c.RegionId)
                    .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<District>()
                   .HasMany(u => u.Obyekts)
                   .WithOne(c => c.District)
                   .HasForeignKey(c => c.DistrictId)
                   .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<District>()
                    .HasMany(u => u.Streets)
                    .WithOne(c => c.District)
                    .HasForeignKey(c => c.DistrictId)
                    .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Region>()
                   .HasMany(u => u.Districts)
                   .WithOne(c => c.Region)
                   .HasForeignKey(c => c.RegionId)
                   .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Project>()
                   .HasMany(u => u.NumberOfOrders)
                   .WithOne(c => c.Project)
                   .HasForeignKey(c => c.ProjectId)
                   .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Project>()
                   .HasMany(u => u.Obyekts)
                   .WithOne(c => c.Project)
                   .HasForeignKey(c => c.ProjectId)
                   .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<NumberOfOrder>()
                   .HasMany(u => u.Obyekts)
                   .WithOne(c => c.NumberOfOrder)
                   .HasForeignKey(c => c.NumberOfOrderId)
                   .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ObjectClass>()
                   .HasMany(u => u.Obyekts)
                   .WithOne(c => c.ObjectClass)
                   .HasForeignKey(c => c.ObjectClassId)
                   .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ObjectClassType>()
                   .HasMany(u => u.Obyekts)
                   .WithOne(c => c.ObjectClassType)
                   .HasForeignKey(c => c.ObjectClassTypeId)
                   .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ObjectClassType>()
                   .HasMany(u => u.ObjectClasses)
                   .WithOne(c => c.ObjectClassType)
                   .HasForeignKey(c => c.ObjectClassTypeId)
                   .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Obyekt>()
                   .HasMany(u => u.Cabels)
                   .WithOne(c => c.Obyekt)
                   .HasForeignKey(c => c.ObyektId)
                   .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Obyekt>()
                   .HasMany(u => u.Cameras)
                   .WithOne(c => c.Obyekt)
                   .HasForeignKey(c => c.ObyektId)
                   .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Obyekt>()
                   .HasMany(u => u.Akumalators)
                   .WithOne(c => c.Obyekt)
                   .HasForeignKey(c => c.ObyektId)
                   .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Obyekt>()
                   .HasMany(u => u.Attachments)
                   .WithOne(c => c.Obyekt)
                   .HasForeignKey(c => c.ObyektId)
                   .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Obyekt>()
                  .HasMany(u => u.Avtomats)
                  .WithOne(c => c.Obyekt)
                  .HasForeignKey(c => c.ObyektId)
                  .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Obyekt>()
                  .HasMany(u => u.Projectors)
                  .WithOne(c => c.Obyekt)
                  .HasForeignKey(c => c.ObyektId)
                  .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Obyekt>()
                  .HasMany(u => u.Racks)
                  .WithOne(c => c.Obyekt)
                  .HasForeignKey(c => c.ObyektId)
                  .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Obyekt>()
                  .HasMany(u => u.Shelves)
                  .WithOne(c => c.Obyekt)
                  .HasForeignKey(c => c.ObyektId)
                  .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Obyekt>()
                 .HasMany(u => u.Sockets)
                 .WithOne(c => c.Obyekt)
                 .HasForeignKey(c => c.ObyektId)
                 .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Obyekt>()
                 .HasMany(u => u.Stabilizers)
                 .WithOne(c => c.Obyekt)
                 .HasForeignKey(c => c.ObyektId)
                 .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Obyekt>()
                 .HasMany(u => u.SvetoforDetectors)
                 .WithOne(c => c.Obyekt)
                 .HasForeignKey(c => c.ObyektId)
                 .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Obyekt>()
                 .HasMany(u => u.Switches)
                 .WithOne(c => c.Obyekt)
                 .HasForeignKey(c => c.ObyektId)
                 .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Obyekt>()
                 .HasMany(u => u.MountingBoxes)
                 .WithOne(c => c.Obyekt)
                 .HasForeignKey(c => c.ObyektId)
                 .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Obyekt>()
                 .HasMany(u => u.TerminalServers)
                 .WithOne(c => c.Obyekt)
                 .HasForeignKey(c => c.ObyektId)
                 .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Obyekt>()
                 .HasMany(u => u.Ups)
                 .WithOne(c => c.Obyekt)
                 .HasForeignKey(c => c.ObyektId)
                 .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Obyekt>()
                 .HasMany(u => u.SpeedCheckings)
                 .WithOne(c => c.Obyekt)
                 .HasForeignKey(c => c.ObyektId)
                 .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Obyekt>()
                 .HasMany(u => u.Stanchions)
                 .WithOne(c => c.Obyekt)
                 .HasForeignKey(c => c.ObyektId)
                 .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Obyekt>()
                 .HasMany(u => u.Boxes)
                 .WithOne(c => c.Obyekt)
                 .HasForeignKey(c => c.ObyektId)
                 .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Obyekt>()
                 .HasMany(u => u.Brackets)
                 .WithOne(c => c.Obyekt)
                 .HasForeignKey(c => c.ObyektId)
                 .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Obyekt>()
                 .HasMany(u => u.Connectors)
                 .WithOne(c => c.Obyekt)
                 .HasForeignKey(c => c.ObyektId)
                 .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Obyekt>()
                 .HasMany(u => u.Counters)
                 .WithOne(c => c.Obyekt)
                 .HasForeignKey(c => c.ObyektId)
                 .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Obyekt>()
                 .HasMany(u => u.Freezers)
                 .WithOne(c => c.Obyekt)
                 .HasForeignKey(c => c.ObyektId)
                 .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Obyekt>()
                 .HasMany(u => u.GlueForNails)
                 .WithOne(c => c.Obyekt)
                 .HasForeignKey(c => c.ObyektId)
                 .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Obyekt>()
                 .HasMany(u => u.Hooks)
                 .WithOne(c => c.Obyekt)
                 .HasForeignKey(c => c.ObyektId)
                 .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Obyekt>()
                 .HasMany(u => u.Nails)
                 .WithOne(c => c.Obyekt)
                 .HasForeignKey(c => c.ObyektId)
                 .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Obyekt>()
                 .HasMany(u => u.Ribbons)
                 .WithOne(c => c.Obyekt)
                 .HasForeignKey(c => c.ObyektId)
                 .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Obyekt>()
                 .HasMany(u => u.Servers)
                 .WithOne(c => c.Obyekt)
                 .HasForeignKey(c => c.ObyektId)
                 .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Obyekt>()
                 .HasMany(u => u.Shells)
                 .WithOne(c => c.Obyekt)
                 .HasForeignKey(c => c.ObyektId)
                 .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Obyekt>()
                 .HasMany(u => u.VideoRecorders)
                 .WithOne(c => c.Obyekt)
                 .HasForeignKey(c => c.ObyektId)
                 .OnDelete(DeleteBehavior.Cascade);

        // Product Types 

        modelBuilder.Entity<Model>()
                 .HasMany(u => u.Switches)
                 .WithOne(c => c.Model)
                 .HasForeignKey(c => c.ModelId)
                 .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Model>()
                 .HasMany(u => u.Shelves)
                 .WithOne(c => c.Model)
                 .HasForeignKey(c => c.BrandId)
                 .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Model>()
                 .HasMany(u => u.Svetafors)
                 .WithOne(c => c.Model)
                 .HasForeignKey(c => c.ModelId)
                 .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Model>()
                 .HasMany(u => u.TerminalServers)
                 .WithOne(c => c.Model)
                 .HasForeignKey(c => c.ModelId)
                 .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Model>()
                 .HasMany(u => u.Stabilizers)
                 .WithOne(c => c.Model)
                 .HasForeignKey(c => c.ModelId)
                 .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Model>()
                 .HasMany(u => u.Cameras)
                 .WithOne(c => c.Model)
                 .HasForeignKey(c => c.ModelId)
                 .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Model>()
                 .HasMany(u => u.Cabels)
                 .WithOne(c => c.Model)
                 .HasForeignKey(c => c.ModelId)
                 .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Model>()
                 .HasMany(u => u.Projectors)
                 .WithOne(c => c.Model)
                 .HasForeignKey(c => c.ModelId)
                 .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Model>()
                 .HasMany(u => u.Avtomats)
                 .WithOne(c => c.Model)
                 .HasForeignKey(c => c.ModelId)
                 .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Model>()
                 .HasMany(u => u.Stanchions)
                 .WithOne(c => c.Model)
                 .HasForeignKey(c => c.StanchionTypeId)
                 .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Model>()
                 .HasMany(u => u.Sockets)
                 .WithOne(c => c.Model)
                 .HasForeignKey(c => c.ModelId)
                 .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Model>()
                 .HasMany(u => u.SpeedCheckings)
                 .WithOne(c => c.Model)
                 .HasForeignKey(c => c.ModelId)
                 .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Model>()
                 .HasMany(u => u.Upses)
                 .WithOne(c => c.Model)
                 .HasForeignKey(c => c.ModelId)
                 .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Model>()
                 .HasMany(u => u.FTTXes)
                 .WithOne(c => c.Model)
                 .HasForeignKey(c => c.ModelId)
                 .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Model>()
                 .HasMany(u => u.GPONs)
                 .WithOne(c => c.Model)
                 .HasForeignKey(c => c.ModelId)
                 .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Model>()
                 .HasMany(u => u.Boxes)
                 .WithOne(c => c.Model)
                 .HasForeignKey(c => c.TypeId)
                 .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Model>()
                 .HasMany(u => u.Brackets)
                 .WithOne(c => c.Model)
                 .HasForeignKey(c => c.ModelId)
                 .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Model>()
                 .HasMany(u => u.Counters)
                 .WithOne(c => c.Model)
                 .HasForeignKey(c => c.ModelId)
                 .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Model>()
                 .HasMany(u => u.VideoRecorders)
                 .WithOne(c => c.Model)
                 .HasForeignKey(c => c.ModelId)
                 .OnDelete(DeleteBehavior.Cascade);

        // Connection Types

        modelBuilder.Entity<Obyekt>()
                 .HasMany(u => u.GSMs)
                 .WithOne(c => c.Obyekt)
                 .HasForeignKey(c => c.ObyektId)
                 .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Obyekt>()
                 .HasMany(u => u.GPONs)
                 .WithOne(c => c.Obyekt)
                 .HasForeignKey(c => c.ObyektId)
                 .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Obyekt>()
                 .HasMany(u => u.FTTXes)
                 .WithOne(c => c.Obyekt)
                 .HasForeignKey(c => c.ObyektId)
                 .OnDelete(DeleteBehavior.Cascade);

        // User Regions

        modelBuilder.Entity<Region>()
                 .HasMany(u => u.UserRegions)
                 .WithOne(c => c.Region)
                 .HasForeignKey(c => c.RegionId)
                 .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ApplicationUser>()
                 .HasMany(u => u.UserRegions)
                 .WithOne(c => c.User)
                 .HasForeignKey(c => c.UserId)
                 .OnDelete(DeleteBehavior.Cascade);


        var hasher = new PasswordHasher<ApplicationUser>();

        modelBuilder.Entity<Region>().HasData(
            new Region() { Id = 1, Name = "Qoraqalpog‘iston Respublikasi", Info = "test", CreatedBy = 1 },
            new Region() { Id = 2, Name = "Andijon viloyati", Info = "test", CreatedBy = 1 },
            new Region() { Id = 3, Name = "Buxoro viloyati", Info = "test", CreatedBy = 1 },
            new Region() { Id = 4, Name = "Jizzax viloyati", Info = "test", CreatedBy = 1 },
            new Region() { Id = 5, Name = "Qashqadaryo viloyati", Info = "test", CreatedBy = 1 },
            new Region() { Id = 6, Name = "Navoiy viloyati", Info = "test", CreatedBy = 1 },
            new Region() { Id = 7, Name = "Namangan viloyati", Info = "test", CreatedBy = 1 },
            new Region() { Id = 8, Name = "Samarqand viloyati", Info = "test", CreatedBy = 1 },
            new Region() { Id = 9, Name = "Surxondaryo viloyati", Info = "test", CreatedBy = 1 },
            new Region() { Id = 10, Name = "Sirdaryo viloyati", Info = "test", CreatedBy = 1 },
            new Region() { Id = 11, Name = "Toshkent viloyati", Info = "test", CreatedBy = 1 },
            new Region() { Id = 12, Name = "Farg‘ona viloyati", Info = "test", CreatedBy = 1 },
            new Region() { Id = 13, Name = "Xorazm viloyati", Info = "test", CreatedBy = 1 },
            new Region() { Id = 14, Name = "Toshkent shahri", Info = "test", CreatedBy = 1 }
            );

        modelBuilder.Entity<District>().HasData(
            new District() { Id = 1, RegionId = 1, Name = "Nukus shahri", Info = "test", CreatedBy = 1 },
            new District() { Id = 2, RegionId = 1, Name = "Amudaryo tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 3, RegionId = 1, Name = "Beruniy tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 4, RegionId = 1, Name = "Kegeyli tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 5, RegionId = 1, Name = "Qanliko‘l tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 6, RegionId = 1, Name = "Qorao‘zak tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 7, RegionId = 1, Name = "Qo‘ng‘irot tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 8, RegionId = 1, Name = "Mo‘ynoq tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 9, RegionId = 1, Name = "Nukus tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 10, RegionId = 1, Name = "Taxiatosh tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 11, RegionId = 1, Name = "Taxtako‘pir tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 12, RegionId = 1, Name = "To‘rtko‘l tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 13, RegionId = 1, Name = "Xo‘jayli tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 14, RegionId = 1, Name = "Chimboy tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 15, RegionId = 1, Name = "Sho‘manoy tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 16, RegionId = 1, Name = "Ellikqal’a tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 17, RegionId = 2, Name = "Andijon shahri", Info = "test", CreatedBy = 1 },
            new District() { Id = 18, RegionId = 2, Name = "Xonabod shahri", Info = "test", CreatedBy = 1 },
            new District() { Id = 19, RegionId = 2, Name = "Andijon tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 20, RegionId = 2, Name = "Asaka tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 21, RegionId = 2, Name = "Baliqchi tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 22, RegionId = 2, Name = "Bo‘z tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 23, RegionId = 2, Name = "Buloqboshi tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 24, RegionId = 2, Name = "Jalaquduq tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 25, RegionId = 2, Name = "Izboskan tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 26, RegionId = 2, Name = "Qo‘rg‘ontepa tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 27, RegionId = 2, Name = "Marhamat tumani.", Info = "test", CreatedBy = 1 },
            new District() { Id = 28, RegionId = 2, Name = "Oltinko‘l tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 29, RegionId = 2, Name = "Paxtaobod tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 30, RegionId = 2, Name = "Ulug‘nor tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 31, RegionId = 2, Name = "Xo‘jaobod tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 32, RegionId = 2, Name = "Shahrixon tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 33, RegionId = 3, Name = "Buxoro shahri", Info = "test", CreatedBy = 1 },
            new District() { Id = 34, RegionId = 3, Name = "Kogon shahri", Info = "test", CreatedBy = 1 },
            new District() { Id = 35, RegionId = 3, Name = "Buxoro tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 36, RegionId = 3, Name = "Vobkent tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 37, RegionId = 3, Name = "Jondor tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 38, RegionId = 3, Name = "Kogon tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 39, RegionId = 3, Name = "Olot tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 40, RegionId = 3, Name = "Peshku tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 41, RegionId = 3, Name = "Romitan tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 42, RegionId = 3, Name = "Shofirkon tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 43, RegionId = 3, Name = "Qorovulbozor tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 44, RegionId = 3, Name = "Qorako‘l tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 45, RegionId = 3, Name = "G‘ijduvon tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 46, RegionId = 4, Name = "Jizzax shahri", Info = "test", CreatedBy = 1 },
            new District() { Id = 47, RegionId = 4, Name = "Arnasoy tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 48, RegionId = 4, Name = "Baxmal tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 49, RegionId = 4, Name = "Do‘stlik tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 50, RegionId = 4, Name = "Zarbdor tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 51, RegionId = 4, Name = "Zafarobod tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 52, RegionId = 4, Name = "Zomin tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 53, RegionId = 4, Name = "Mirzacho‘l tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 54, RegionId = 4, Name = "Paxtakor tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 55, RegionId = 4, Name = "Forish tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 56, RegionId = 4, Name = "Sharof Rashidov tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 57, RegionId = 4, Name = "G‘allaorol tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 58, RegionId = 4, Name = "Yangiobod tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 59, RegionId = 5, Name = "Qarshi shahri", Info = "test", CreatedBy = 1 },
            new District() { Id = 60, RegionId = 5, Name = "Shahrisabz shahri", Info = "test", CreatedBy = 1 },
            new District() { Id = 61, RegionId = 5, Name = "Dehqonobod tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 62, RegionId = 5, Name = "Kasbi tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 63, RegionId = 5, Name = "Kitob tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 64, RegionId = 5, Name = "Koson tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 65, RegionId = 5, Name = "Mirishkor tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 66, RegionId = 5, Name = "Muborak tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 67, RegionId = 5, Name = "Nishon tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 68, RegionId = 5, Name = "Chiroqchi tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 69, RegionId = 5, Name = "Shahrisabz tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 70, RegionId = 5, Name = "Yakkabog‘ tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 71, RegionId = 5, Name = "Qamashi tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 72, RegionId = 5, Name = "Qarshi tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 73, RegionId = 5, Name = "G‘uzor tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 74, RegionId = 6, Name = "Navoiy shahri", Info = "test", CreatedBy = 1 },
            new District() { Id = 75, RegionId = 6, Name = "Zarafshon shahri", Info = "test", CreatedBy = 1 },
            new District() { Id = 76, RegionId = 6, Name = "Karmana tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 77, RegionId = 6, Name = "Konimex tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 78, RegionId = 6, Name = "Navbahor tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 79, RegionId = 6, Name = "Nurota tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 80, RegionId = 6, Name = "Tomdi tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 81, RegionId = 6, Name = "Uchquduq tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 82, RegionId = 6, Name = "Xatirchi tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 83, RegionId = 6, Name = "Qiziltepa tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 84, RegionId = 7, Name = "Namangan shahri", Info = "test", CreatedBy = 1 },
            new District() { Id = 85, RegionId = 7, Name = "Kosonsoy tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 86, RegionId = 7, Name = "Mingbuloq tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 87, RegionId = 7, Name = "Namangan tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 88, RegionId = 7, Name = "Norin tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 89, RegionId = 7, Name = "Pop tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 90, RegionId = 7, Name = "To‘raqo‘rg‘on tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 91, RegionId = 7, Name = "Uychi tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 92, RegionId = 7, Name = "Uchqo‘rg‘on tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 93, RegionId = 7, Name = "Chortoq tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 94, RegionId = 7, Name = "Chust tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 95, RegionId = 7, Name = "Yangiqo‘rg‘on tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 96, RegionId = 8, Name = "Samarqand shahri", Info = "test", CreatedBy = 1 },
            new District() { Id = 97, RegionId = 8, Name = "Kattaqo‘rg‘on shahri", Info = "test", CreatedBy = 1 },
            new District() { Id = 98, RegionId = 8, Name = "Bulung‘ur tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 99, RegionId = 8, Name = "Jomboy tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 100, RegionId = 8, Name = "Ishtixon tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 101, RegionId = 8, Name = "Kattaqo‘rg‘on tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 102, RegionId = 8, Name = "Narpay tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 103, RegionId = 8, Name = "Nurobod tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 104, RegionId = 8, Name = "Oqdaryo tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 105, RegionId = 8, Name = "Payariq tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 106, RegionId = 8, Name = "Pastdarg‘om tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 107, RegionId = 8, Name = "Paxtachi tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 108, RegionId = 8, Name = "Samarqand tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 109, RegionId = 8, Name = "Toyloq tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 110, RegionId = 8, Name = "Urgut tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 111, RegionId = 8, Name = "Qo‘shrabot tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 112, RegionId = 9, Name = "Termiz shahri", Info = "test", CreatedBy = 1 },
            new District() { Id = 113, RegionId = 9, Name = "Angor tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 114, RegionId = 9, Name = "Boysun tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 115, RegionId = 9, Name = "Denov tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 116, RegionId = 9, Name = "Jarqo‘rg‘on tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 117, RegionId = 9, Name = "Muzrobod tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 118, RegionId = 9, Name = "Oltinsoy tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 119, RegionId = 9, Name = "Sariosiyo tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 120, RegionId = 9, Name = "Termiz tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 121, RegionId = 9, Name = "Uzun tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 122, RegionId = 9, Name = "Sherobod tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 123, RegionId = 9, Name = "Sho‘rchi tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 124, RegionId = 9, Name = "Qiziriq tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 125, RegionId = 9, Name = "Qumqo‘rg‘on tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 126, RegionId = 10, Name = "Guliston shahri", Info = "test", CreatedBy = 1 },
            new District() { Id = 127, RegionId = 10, Name = "Yangiyer shahri", Info = "test", CreatedBy = 1 },
            new District() { Id = 128, RegionId = 10, Name = "Shirin shahri", Info = "test", CreatedBy = 1 },
            new District() { Id = 129, RegionId = 10, Name = "Boyovut tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 130, RegionId = 10, Name = "Guliston tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 131, RegionId = 10, Name = "Mirzaobod tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 132, RegionId = 10, Name = "Oqoltin tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 133, RegionId = 10, Name = "Sardoba tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 134, RegionId = 10, Name = "Sayxunobod tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 135, RegionId = 10, Name = "Sirdaryo tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 136, RegionId = 10, Name = "Xovos tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 137, RegionId = 11, Name = "Nurafshon shahri", Info = "test", CreatedBy = 1 },
            new District() { Id = 138, RegionId = 11, Name = "Angren shahri", Info = "test", CreatedBy = 1 },
            new District() { Id = 139, RegionId = 11, Name = "Bekobod shahri", Info = "test", CreatedBy = 1 },
            new District() { Id = 140, RegionId = 11, Name = "Olmaliq shahri", Info = "test", CreatedBy = 1 },
            new District() { Id = 141, RegionId = 11, Name = "Ohangaron shahri", Info = "test", CreatedBy = 1 },
            new District() { Id = 142, RegionId = 11, Name = "Chirchiq shahri", Info = "test", CreatedBy = 1 },
            new District() { Id = 143, RegionId = 11, Name = "Yangiyo‘l shahri", Info = "test", CreatedBy = 1 },
            new District() { Id = 144, RegionId = 11, Name = "Bekobod tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 145, RegionId = 11, Name = "Bo‘ka tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 146, RegionId = 11, Name = "Bo‘stonliq tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 147, RegionId = 11, Name = "Zangiota tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 148, RegionId = 11, Name = "Qibray tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 149, RegionId = 11, Name = "Quyichirchiq tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 150, RegionId = 11, Name = "Oqqo‘rg‘on tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 151, RegionId = 11, Name = "Ohangaron tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 152, RegionId = 11, Name = "Parkent tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 153, RegionId = 11, Name = "Piskent tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 154, RegionId = 11, Name = "Toshkent tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 155, RegionId = 11, Name = "O‘rtachirchiq tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 156, RegionId = 11, Name = "Chinoz tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 157, RegionId = 11, Name = "21. Yuqorichirchiq tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 158, RegionId = 11, Name = "22. Yangiyo‘l tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 159, RegionId = 12, Name = "Farg‘ona shahri", Info = "test", CreatedBy = 1 },
            new District() { Id = 160, RegionId = 12, Name = "Marg‘ilon shahri", Info = "test", CreatedBy = 1 },
            new District() { Id = 161, RegionId = 12, Name = "Quvasoy shahri", Info = "test", CreatedBy = 1 },
            new District() { Id = 162, RegionId = 12, Name = "Qo‘qon shahri", Info = "test", CreatedBy = 1 },
            new District() { Id = 163, RegionId = 12, Name = "Beshariq tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 164, RegionId = 12, Name = "Bog‘dod tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 165, RegionId = 12, Name = "Buvayda tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 166, RegionId = 12, Name = "Dang‘ara tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 167, RegionId = 12, Name = "Yozyovon tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 168, RegionId = 12, Name = "Quva tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 169, RegionId = 12, Name = "Qo‘shtepa tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 170, RegionId = 12, Name = "Oltiariq tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 171, RegionId = 12, Name = "Rishton tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 172, RegionId = 12, Name = "So‘x tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 173, RegionId = 12, Name = "Toshloq tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 174, RegionId = 12, Name = "O‘zbekiston tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 175, RegionId = 12, Name = "Uchko‘prik tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 176, RegionId = 12, Name = "Farg‘ona tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 177, RegionId = 12, Name = "Furqat tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 178, RegionId = 13, Name = "Urganch shahri", Info = "test", CreatedBy = 1 },
            new District() { Id = 179, RegionId = 13, Name = "Xiva shahri", Info = "test", CreatedBy = 1 },
            new District() { Id = 180, RegionId = 13, Name = "Bog‘ot tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 181, RegionId = 13, Name = "Gurlan tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 182, RegionId = 13, Name = "Urganch tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 183, RegionId = 13, Name = "Xiva tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 184, RegionId = 13, Name = "Xonqa tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 185, RegionId = 13, Name = "Hazorasp tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 186, RegionId = 13, Name = "Shovot tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 187, RegionId = 13, Name = "Yangiariq tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 188, RegionId = 13, Name = "Yangibozor tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 189, RegionId = 13, Name = "Qo‘shko‘pir tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 190, RegionId = 14, Name = "Bektemir tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 191, RegionId = 14, Name = "Mirzo Ulug‘bek tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 192, RegionId = 14, Name = "Mirobod tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 193, RegionId = 14, Name = "Olmazor tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 194, RegionId = 14, Name = "Sirg‘ali tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 195, RegionId = 14, Name = "Uchtepa tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 196, RegionId = 14, Name = "Chilonzor tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 197, RegionId = 14, Name = "Shayxontohur tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 198, RegionId = 14, Name = "Yunusobod tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 199, RegionId = 14, Name = "Yakkasaroy tumani", Info = "test", CreatedBy = 1 },
            new District() { Id = 200, RegionId = 14, Name = "Yashnobod tumani", Info = "test", CreatedBy = 1 }
            );

        modelBuilder.Entity<ApplicationUser>().HasData(

            new ApplicationUser()
            {
                Id = 1,
                FirstName = "Asadbek",
                LastName = "Rejabboyev",
                MiddleName = "Boqijonovich",
                RoleName = "Dasturchi",
                UserName = "Asadbek",
                NormalizedUserName = "ASADBEK",
                Email = "asad@gmail.com",
                NormalizedEmail = "ASAD@GMAIL.COM",
                PhoneNumber = "998996906901",
                SecurityStamp = Guid.NewGuid().ToString("D"),
                PasswordHash = hasher.HashPassword(null, "Asadbek2001!"),
                RegionId = 7,
            }
           );

        modelBuilder.Entity<ObjectClassType>().HasData(
            new ObjectClassType() { Id = 1, Name = "Ijtimoiy obyektlar" },
            new ObjectClassType() { Id = 2, Name = "PDD" }
            );

        modelBuilder.Entity<ObjectClass>().HasData(
            new ObjectClass() { Id = 1, Name = "Maktab", ObjectClassTypeId = 1 },
            new ObjectClass() { Id = 2, Name = "Bog'cha", ObjectClassTypeId = 1 },
            new ObjectClass() { Id = 3, Name = "Magazin", ObjectClassTypeId = 1 },
            new ObjectClass() { Id = 4, Name = "OTM", ObjectClassTypeId = 1 },
            new ObjectClass() { Id = 5, Name = "Supermarket", ObjectClassTypeId = 1 },
            new ObjectClass() { Id = 6, Name = "Masjid", ObjectClassTypeId = 1 },
            new ObjectClass() { Id = 7, Name = "Istirohat bo'gi", ObjectClassTypeId = 1 },
            new ObjectClass() { Id = 8, Name = "Jamoat maskanlari", ObjectClassTypeId = 1 },

            new ObjectClass() { Id = 9, Name = "Chorraxa", ObjectClassTypeId = 2 },
            new ObjectClass() { Id = 10, Name = "Radar", ObjectClassTypeId = 2 },
            new ObjectClass() { Id = 11, Name = "3.27 yo'l beligisi", ObjectClassTypeId = 2 }
            );

        modelBuilder.Entity<ApplicationRole>().HasData(
            new ApplicationRole() { Id = 1, Name = "Programmer", NormalizedName = "PROGRAMMER", RoleLabel = "Dasturchi" },
            new ApplicationRole() { Id = 2, Name = "ChiefSpecialist", NormalizedName = "CHIEFSPECIALIST", RoleLabel = "Bosh mutaxassis" },
            new ApplicationRole() { Id = 3, Name = "SeniorSpecialist", NormalizedName = "SENIORSPECIALIST", RoleLabel = "Katta mutaxassis" },
            new ApplicationRole() { Id = 4, Name = "LeadingExpert", NormalizedName = "LEADINGEXPERT", RoleLabel = "Yetakchi mutaxassis" },
            new ApplicationRole() { Id = 5, Name = "DepartmentHead", NormalizedName = "DEPARTMENTHEAD", RoleLabel = "Bo'lim boshlig'i" }
            );

        modelBuilder.Entity<AspNetClaim>().HasData(
            new AspNetClaim() { Id = 1, ClaimName = "Obyekt yaratish", ClaimType = "createObyekt", ClaimValue = "CreateObyekt" },
            new AspNetClaim() { Id = 2, ClaimName = "Hamma obyektlarni ko'rish", ClaimType = "readAllObyekts", ClaimValue = "readAllObyekts" },
            new AspNetClaim() { Id = 3, ClaimName = "Bitta obyektni ko'rish", ClaimType = "readOneObyekt", ClaimValue = "ReadOneObyekt" },
            new AspNetClaim() { Id = 4, ClaimName = "Obyektni yangilash", ClaimType = "updateObyekt", ClaimValue = "UpdateObyekt" },
            new AspNetClaim() { Id = 5, ClaimName = "Obyektni o'chirish", ClaimType = "deleteObyekt", ClaimValue = "DeleteObyekt" }
      );
    }
}