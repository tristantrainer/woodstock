using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Peanuts.Woodstock.Infrastructure.Data.Contexts;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        return services;
    }

    public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration) 
    {
        services
            .AddDbContextFactory<WoodstockContext>(options => options.UseNpgsql(configuration.GetConnectionString("Woodstock")));
        services
            .AddDbContext<WoodstockContext>(options => options.UseNpgsql(configuration.GetConnectionString("Woodstock")));
        return services;
    }
}
