using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.EntityTypeConfiguration
{
    internal class PassengerEntityTypeConfiguration : IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            builder.ToTable("Passengers");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(256);
            builder.Property(p => p.Email).IsRequired().HasMaxLength(256);
            builder.HasIndex(p => p.Email).IsUnique();
            builder.Property(p => p.PhoneNumber).IsRequired().HasMaxLength(20);
            builder.Property(p => p.Wallet).HasColumnType("decimal(18,2)").HasDefaultValue(0);
            builder.Property(p => p.CreatedBy).HasMaxLength(256);
            builder.HasQueryFilter(p => !p.IsDeleted);

            builder.HasMany(p => p.Bookings)
                   .WithOne(b => b.Passenger)
                   .HasForeignKey(b => b.PassengerId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
