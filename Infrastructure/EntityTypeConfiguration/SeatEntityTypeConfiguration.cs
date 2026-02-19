using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.EntityTypeConfiguration
{
    internal class SeatEntityTypeConfiguration : IEntityTypeConfiguration<Seat>
    {
        public void Configure(EntityTypeBuilder<Seat> builder)
        {
            builder.ToTable("Seats");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.SeatNo).IsRequired();
            builder.HasIndex(s => new { s.CoachId, s.SeatNo }).IsUnique();
            builder.Property(s => s.CreatedBy).HasMaxLength(256);
            builder.HasQueryFilter(s => !s.IsDeleted);

            builder.HasOne(s => s.Coach)
                   .WithMany(c => c.Seats)
                   .HasForeignKey(s => s.CoachId)
                   .OnDelete(DeleteBehavior.Cascade);

            //builder.HasMany(s => s.TripSeats)
            //       .WithOne(ts => ts.Seat)
            //       .HasForeignKey(ts => ts.SeatId)
            //       .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
