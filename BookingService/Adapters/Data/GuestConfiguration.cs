using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data;

public class GuestConfiguration : IEntityTypeConfiguration<Guest>
{
    public void Configure(EntityTypeBuilder<Guest> builder)
    {
        builder.OwnsOne(g => g.DocumentId, p =>
        {
            p.Property(p => p.IdNumber);
            p.Property(p => p.DocumentType);
        });
    }
}
