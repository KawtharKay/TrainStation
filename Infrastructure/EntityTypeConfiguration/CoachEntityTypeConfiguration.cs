using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.EntityTypeConfiguration
{
    internal class CoachEntityTypeConfiguration : IEntityTypeConfiguration<Coach>
    {
        public void Configure(EntityTypeBuilder<Coach> builder)
        {
            builder.ToTable("Coaches");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.CoachNo).IsRequired().HasMaxLength(50);
            builder.HasIndex(c => new { c.TrainId, c.CoachNo }).IsUnique();
            builder.Property(c => c.CoachOrder).IsRequired();
            builder.Property(c => c.Capacity).IsRequired();
            builder.Property(c => c.BookingClass).IsRequired().HasConversion<string>();
            builder.Property(c => c.CreatedBy).HasMaxLength(256);
            builder.HasQueryFilter(c => !c.IsDeleted);

            builder.HasOne(c => c.Train)
                   .WithMany(t => t.Coaches)
                   .HasForeignKey(c => c.TrainId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.Seats)
                   .WithOne(s => s.Coach)
                   .HasForeignKey(s => s.CoachId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
