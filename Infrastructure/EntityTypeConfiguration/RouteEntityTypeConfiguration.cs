using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.EntityTypeConfiguration
{
    internal class RouteEntityTypeConfiguration : IEntityTypeConfiguration<Route>
    {
        public void Configure(EntityTypeBuilder<Route> builder)
        {
            builder.ToTable("Routes");
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Name).IsRequired().HasMaxLength(256);
            builder.HasIndex(r => r.Name).IsUnique();
            builder.Property(r => r.CreatedBy).HasMaxLength(256);
            builder.HasQueryFilter(r => !r.IsDeleted);

            builder.HasMany(r => r.StationRoutes)
                   .WithOne(sr => sr.Route)
                   .HasForeignKey(sr => sr.RouteId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
