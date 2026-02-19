using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.EntityTypeConfiguration
{
    internal class TripSeatEntityTypeConfiguration : IEntityTypeConfiguration<TripSeat>
    {
        public void Configure(EntityTypeBuilder<TripSeat> builder)
        {
            builder.ToTable("TripSeats");
            builder.HasKey(ts => ts.Id);
            builder.HasIndex(ts => new { ts.TripId, ts.SeatId }).IsUnique();
            builder.Property(ts => ts.Status).IsRequired().HasConversion<string>();
            builder.Property(ts => ts.CreatedBy).HasMaxLength(256);
            builder.HasQueryFilter(ts => !ts.IsDeleted);

            builder.HasOne(ts => ts.Trip)
                   .WithMany(t => t.TripSeats)
                   .HasForeignKey(ts => ts.TripId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(ts => ts.Seat)
                   .WithMany(s => s.TripSeats)
                   .HasForeignKey(ts => ts.SeatId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
