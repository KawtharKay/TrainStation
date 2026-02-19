using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.EntityTypeConfiguration
{
    internal class StationRouteEntityTypeConfiguration : IEntityTypeConfiguration<StationRoute>
    {
        public void Configure(EntityTypeBuilder<StationRoute> builder)
        {
            builder.ToTable("StationRoutes");
            builder.HasKey(sr => sr.Id);
            builder.HasIndex(sr => new { sr.RouteId, sr.StationId }).IsUnique();
            builder.HasIndex(sr => new { sr.RouteId, sr.StopOrder }).IsUnique();
            builder.Property(sr => sr.StopOrder).IsRequired();
            builder.Property(sr => sr.DistanceFromDeparture).IsRequired();

            builder.HasOne(sr => sr.Route)
                   .WithMany(r => r.StationRoutes)
                   .HasForeignKey(sr => sr.RouteId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(sr => sr.Station)
                   .WithMany(s => s.StationRoutes)
                   .HasForeignKey(sr => sr.StationId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
