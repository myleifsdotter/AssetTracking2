using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking2
{
    internal class MyDbContext : DbContext
    {
        public DbSet<Office> Offices { get; set; } //migration creates a file based on this line
        //DbSet of type Office and the name is Offices, works like a property
        public DbSet<Asset> Assets { get; set; }

        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = Assets; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /* seeding office data */
            modelBuilder.Entity<Office>().HasData(new Office { Id = 1, Country = "Sweden", Currency = "SEK" });
            modelBuilder.Entity<Office>().HasData(new Office { Id = 2, Country = "Spain", Currency = "EUR" });
            modelBuilder.Entity<Office>().HasData(new Office { Id = 3, Country = "USA", Currency = "USD" });

            ///* seeding Asset data */
            modelBuilder.Entity<Asset>().HasData(new Asset { Id = 1, Type = "Mobile Phone", Brand = "iPhone", Model = "8", Purchasedate = Convert.ToDateTime("2019-11-05"), PriceUSD = 970, OfficeId = 2 });
            modelBuilder.Entity<Asset>().HasData(new Asset { Id = 2, Type = "Laptop Computer", Brand = "HP", Model = "Elitebook", Purchasedate = Convert.ToDateTime("2022-05-01"), PriceUSD = 1423, OfficeId = 2 });
            modelBuilder.Entity<Asset>().HasData(new Asset { Id = 3, Type = "Mobile Phone", Brand = "iPhone", Model = "11", Purchasedate = Convert.ToDateTime("2022-04-25"), PriceUSD = 990, OfficeId = 2 });
            modelBuilder.Entity<Asset>().HasData(new Asset { Id = 4, Type = "Mobile Phone", Brand = "iPhone", Model = "X", Purchasedate = Convert.ToDateTime("2019-08-05"), PriceUSD = 1245, OfficeId = 1 });
            modelBuilder.Entity<Asset>().HasData(new Asset { Id = 5, Type = "Mobile Phone", Brand = "Motorola", Model = "Razr", Purchasedate = Convert.ToDateTime("2019-09-06"), PriceUSD = 970, OfficeId = 1 });
            modelBuilder.Entity<Asset>().HasData(new Asset { Id = 6, Type = "Laptop Computer", Brand = "HP", Model = "Elitebook", Purchasedate = Convert.ToDateTime("2019-10-07"), PriceUSD = 588, OfficeId = 1 });
            modelBuilder.Entity<Asset>().HasData(new Asset { Id = 7, Type = "Laptop Computer", Brand = "Asus", Model = "W234", Purchasedate = Convert.ToDateTime("2019-07-21"), PriceUSD = 1200, OfficeId = 3 });
            modelBuilder.Entity<Asset>().HasData(new Asset { Id = 8, Type = "Laptop Computer", Brand = "Lenovo", Model = "Yoga 730", Purchasedate = Convert.ToDateTime("2019-09-28"), PriceUSD = 835, OfficeId = 3 });
            modelBuilder.Entity<Asset>().HasData(new Asset { Id = 9, Type = "Laptop Computer", Brand = "Lenovo", Model = "Yoga 530", Purchasedate = Convert.ToDateTime("2019-11-21"), PriceUSD = 1030, OfficeId = 3 });
            modelBuilder.Entity<Asset>().HasData(new Asset { Id = 10, Type = "Mobile Phone", Brand = "Samsung", Model = "Galaxy", Purchasedate = Convert.ToDateTime("2020-06-06"), PriceUSD = 1170, OfficeId = 3 });

        }
    }
}
