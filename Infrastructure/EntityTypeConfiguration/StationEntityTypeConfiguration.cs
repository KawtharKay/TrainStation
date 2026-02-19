using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.EntityTypeConfiguration
{
    internal class StationEntityTypeConfiguration : IEntityTypeConfiguration<Station>
    {
        public void Configure(EntityTypeBuilder<Station> builder)
        {
            builder.ToTable("Stations");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Name).IsRequired().HasMaxLength(256);
            builder.Property(s => s.City).IsRequired().HasMaxLength(100);
            builder.Property(s => s.State).IsRequired().HasMaxLength(100);
            builder.HasIndex(s => new { s.Name, s.City, s.State }).IsUnique();
            builder.Property(s => s.CreatedBy).HasMaxLength(256);
            builder.HasQueryFilter(s => !s.IsDeleted);

            builder.HasMany(s => s.StationRoutes)
                   .WithOne(sr => sr.Station)
                   .HasForeignKey(sr => sr.StationId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
