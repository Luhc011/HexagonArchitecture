using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data;

public class RoomConfiguration : IEntityTypeConfiguration<Room>
{
    public  void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.OwnsOne(g => g.Price, p =>
        {
            p.Property(p => p.Currency);
            p.Property(p => p.Value);
        });
    }
}
