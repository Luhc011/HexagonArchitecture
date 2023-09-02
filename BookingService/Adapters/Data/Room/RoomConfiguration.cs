using Entities = Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Room;

public class RoomConfiguration : IEntityTypeConfiguration<Entities.Room>
{
    public void Configure(EntityTypeBuilder<Entities.Room> builder)
    {
        builder.OwnsOne(g => g.Price, p =>
        {
            p.Property(p => p.Currency);
            p.Property(p => p.Value);
        });
    }
}
