using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Mapping
{
    public class AdministratorMap : IEntityTypeConfiguration<Administrator>
    {
        public void Configure(EntityTypeBuilder<Administrator> builder)
        {
            builder.ToTable("Administrator");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Email).IsUnique();
            builder.HasIndex(p => p.Cnpj).IsUnique();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(60);
            builder.Property(p => p.Cnpj).IsRequired().HasMaxLength(60);
            builder.Property(p => p.Password).IsRequired().HasMaxLength(08);
            builder.Property(p => p.Email).HasMaxLength(60);

            builder.HasMany(p => p.Bookings).WithOne(p => p.Administrator).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
