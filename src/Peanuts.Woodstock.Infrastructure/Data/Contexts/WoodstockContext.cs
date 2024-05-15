using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Peanuts.Woodstock.Domain.Entities;

namespace Peanuts.Woodstock.Infrastructure.Data.Contexts;

public class WoodstockContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Individual> Individuals { get; init; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
