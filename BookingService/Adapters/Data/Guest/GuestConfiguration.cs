using Entities = Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Guest;

public class GuestConfiguration : IEntityTypeConfiguration<Entities.Guest>
{
    public void Configure(EntityTypeBuilder<Entities.Guest> builder)
    {
        builder.OwnsOne(g => g.DocumentId, p =>
        {
            p.Property(p => p.IdNumber);
            p.Property(p => p.DocumentType);
        });
    }
}
