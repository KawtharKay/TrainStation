using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.EntityTypeConfiguration
{
    internal class BookingEntityTypeConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable("Bookings");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.ReferenceNo).IsRequired().HasMaxLength(50);
            builder.HasIndex(b => b.ReferenceNo).IsUnique();
            builder.Property(b => b.AmountPaid).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(b => b.Status).IsRequired().HasConversion<string>();
            builder.Property(b => b.CreatedBy).HasMaxLength(256);
            builder.HasQueryFilter(b => !b.IsDeleted);

            builder.HasOne(b => b.Passenger)
                   .WithMany(p => p.Bookings)
                   .HasForeignKey(b => b.PassengerId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(b => b.Trip)
                   .WithMany()
                   .HasForeignKey(b => b.TripId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(b => b.TripSeat)
                   .WithMany()
                   .HasForeignKey(b => b.TripSeatId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(b => b.TakeoffStation)
                   .WithMany()
                   .HasForeignKey(b => b.TakeoffStationId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(b => b.DestinationStation)
                   .WithMany()
                   .HasForeignKey(b => b.DestinationStationId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
