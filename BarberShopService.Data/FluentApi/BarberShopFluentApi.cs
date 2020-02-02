using BarberShopService.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarberShopService.Data.FluentApi
{
    public static class BarberShopFluentApi
    {
        public static void BarberShopModel(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<BarberShop>().HasKey(x => x.Id);
            modelbuilder.Entity<BarberShop>().Property(x => x.Id).HasColumnName("BarberShopId").ValueGeneratedOnAdd();
            modelbuilder.Entity<BarberShop>().Property(x => x.Name).HasMaxLength(100);
            modelbuilder.Entity<BarberShop>().Property(x => x.imagePath);
            modelbuilder.Entity<BarberShop>().Property(x => x.OpeningTime).HasMaxLength(2);
            modelbuilder.Entity<BarberShop>().Property(x => x.Rating).HasColumnType("numeric(5,2)");
            modelbuilder.Entity<BarberShop>().Property(x => x.ClosingTime).HasMaxLength(2);
            modelbuilder.Entity<BarberShop>().Property(x => x.City).HasMaxLength(50);
            modelbuilder.Entity<BarberShop>().Property(x => x.Address).HasMaxLength(100);
            modelbuilder.Entity<BarberShop>().Property(x => x.Closed).HasColumnType("bit");
        }
    }
}
