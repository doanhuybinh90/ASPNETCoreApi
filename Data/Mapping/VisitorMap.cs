using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Mapping
{
    public class VisitorMap : IEntityTypeConfiguration<Visitor>
    {
        public void Configure(EntityTypeBuilder<Visitor> builder)
        {
            builder.ToTable("Visitor");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Email).IsUnique();
            builder.HasIndex(p => p.Cpf).IsUnique();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(60);
            builder.Property(p => p.Cpf).IsRequired().HasMaxLength(60);
            builder.Property(p => p.Password).IsRequired().HasMaxLength(08);
            builder.Property(p => p.Email).HasMaxLength(60);
        }
    }
}
