using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Context
{
    public class ContextFactory //: IDesignTimeDbContextFactory<MyContext>
    {
        /*public MyContext CreateDbContext(string[] args)
        {
            *//*var connectionString = "Server=127.0.0.1;Port=3306;Database=apidb;Uid=root;Password=root1234567";
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            optionsBuilder.UseMySql(connectionString);
            return new MyContext(optionsBuilder.Options);*//*
        }*/

        public MyContext CreateDbContext(string[] args)
        {
            var connectionString = "Server=.\\SQLEXPRESS;Database=apidb;Uid=sa;Password=root123";
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new MyContext(optionsBuilder.Options);
        }
    }
}
