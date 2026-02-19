using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.EntityTypeConfiguration
{
    internal class TripEntityTypeConfiguration : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            builder.ToTable("Trips");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.DepartureDate).IsRequired();
            builder.Property(t => t.Status).IsRequired().HasConversion<string>();
            builder.Property(t => t.CreatedBy).HasMaxLength(256);
            builder.HasQueryFilter(t => !t.IsDeleted);

            builder.HasOne(t => t.Train)
                   .WithMany()
                   .HasForeignKey(t => t.TrainId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.Route)
                   .WithMany()
                   .HasForeignKey(t => t.RouteId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(t => t.TripSeats)
                   .WithOne(ts => ts.Trip)
                   .HasForeignKey(ts => ts.TripId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
