using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.EntityTypeConfiguration
{
    internal class TrainEntityTypeConfiguration : IEntityTypeConfiguration<Train>
    {
        public void Configure(EntityTypeBuilder<Train> builder)
        {
            builder.ToTable("Trains");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.TrainNo).IsRequired().HasMaxLength(50);
            builder.HasIndex(t => t.TrainNo).IsUnique();
            builder.Property(t => t.EngineNo).IsRequired().HasMaxLength(50);
            builder.HasIndex(t => t.EngineNo).IsUnique();
            builder.Property(t => t.CreatedBy).HasMaxLength(256);
            builder.HasQueryFilter(t => !t.IsDeleted);

            builder.HasMany(t => t.Coaches)
                   .WithOne(c => c.Train)
                   .HasForeignKey(c => c.TrainId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
