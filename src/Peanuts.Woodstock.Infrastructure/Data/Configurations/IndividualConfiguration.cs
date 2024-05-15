using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peanuts.Woodstock.Domain.Entities;

namespace Peanuts.Woodstock.Infrastructure.Data.Configurations;

public class IndividualConfiguration : IEntityTypeConfiguration<Individual>
{
    public void Configure(EntityTypeBuilder<Individual> builder)
    {
        builder
            .ToTable("individuals")
            .HasKey((entity) => entity.Id);

        builder
            .Property(t => t.Id)
            .HasColumnName("id")
            .UseSerialColumn()
            .IsRequired();

        builder
            .Property(t => t.PublicId)
            .HasColumnName("public_id")
            .IsRequired();
    }
}
