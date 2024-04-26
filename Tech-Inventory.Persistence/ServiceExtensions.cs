using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Domain.IdentityEntities;

namespace Tech_Inventory.Persistence;

public static class ServiceExtensions
{
    public static IServiceCollection ConfigurePersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DBConnection");
        services.AddDbContext<TechInventoryDB>(opt => opt.UseNpgsql(connectionString));
        services.AddIdentityCore<ApplicationUser>(options => {
            options.SignIn.RequireConfirmedAccount = true;
            options.User.RequireUniqueEmail = true;
        }).AddRoles<ApplicationRole>()
            .AddEntityFrameworkStores<TechInventoryDB>();

        services.AddScoped<ITechInventoryDB, TechInventoryDB>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}
