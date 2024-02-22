using Feminancials.Domain.Entities;
using Feminancials.Domain.Entities.UserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Feminancials.Infrastructure.Data.Configurations;

public class CollectiveConfiguration : IEntityTypeConfiguration<Collective>
{
    public void Configure(EntityTypeBuilder<Collective> builder)
    {
        builder.Property(t => t.Name)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(t => t.Description)
            .HasMaxLength(400);
    }
}
