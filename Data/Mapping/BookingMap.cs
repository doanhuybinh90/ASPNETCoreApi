using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Mapping
{
    public class BookingMap : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable("Booking");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(60);
            builder.Property(p => p.Price).IsRequired().HasMaxLength(08);
            builder.Property(p => p.Description).HasMaxLength(100);
            builder.HasOne(p => p.Administrator).WithMany(p => p.Bookings);
            builder.HasOne(p => p.Visitor);
        }
    }
}
