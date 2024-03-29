﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FoodApp
{
    //To manage Migrations & create the DB go to console:
    //Add EF Core Tools: dotnet tool install --global dotnet-ef
    //dotnet restore
    //dotnet-ef migrations add MIGRATION-NAME
    //dotnet-ef database update

    public class FoodDBContext : DbContext 
    {
        public FoodDBContext(DbContextOptions<FoodDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<FoodItem> Food { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
                modelBuilder.Entity<FoodItem>()
                    .Property(p => p.Price)
                    .HasColumnType("decimal(18,4)");

            List<FoodItem> list = new List<FoodItem>
            {
                new FoodItem { ID = 1, Name = "Butter Chicken", InStock = 9, Price = 12 },
                new FoodItem { ID = 2, Name = "Pad Kra Pao", InStock = 12, Price = 9 },
                new FoodItem { ID = 3, Name = "Wiener Schnitzel", InStock = 23, Price = 18 }
            };           
            modelBuilder.Entity<FoodItem>().HasData(list.ToArray());
        }
    }
}