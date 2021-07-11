using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Models.Warehouse
{
    public class WarehouseConfiguration : IEntityTypeConfiguration<Warehouse>
    {
        public void Configure(EntityTypeBuilder<Warehouse> builder)
        {
            builder
                .HasKey(w => w.Id);

            builder
                .HasMany(w => w.Cars)
                .WithOne(c => c.Warehouse)
                .HasForeignKey(c => c.WarehouseId)
                .IsRequired(true);
        }
    }
}