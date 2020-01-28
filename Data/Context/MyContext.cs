using Data.Mapping;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
            
        }

        public MyContext()
        {
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Server =.\\SQLEXPRESS;Database=apidb;Uid=sa;Password=root123");
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Visitor>(new VisitorMap().Configure);
            modelBuilder.Entity<Administrator>(new AdministratorMap().Configure);
            modelBuilder.Entity<Booking>(new BookingMap().Configure);
            base.OnModelCreating(modelBuilder);
        }
    }

}
