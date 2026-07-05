using asERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace asERP.Persistence.Configurations;

public class ReturnShipmentItemSerialNumberConfiguration : IEntityTypeConfiguration<ReturnShipmentItemSerialNumber>
{
    public void Configure(EntityTypeBuilder<ReturnShipmentItemSerialNumber> builder)
    {
        builder.Property(e => e.SerialNumber)
            .IsRequired()
            .HasMaxLength(128);

        builder.HasIndex(e => e.ReturnShipmentItemId);

        builder.HasOne<ReturnShipmentItem>()
            .WithMany(i => i.SerialNumbers)
            .HasForeignKey(e => e.ReturnShipmentItemId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
