using BarberShopService.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarberShopService.Data.FluentApi
{
    public static class BarberFluentApi
    {
        public static void BarberModel(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Barber>().HasKey(x => x.Id);
            modelbuilder.Entity<Barber>().Property(x => x.Id).HasColumnName("BarberId").ValueGeneratedOnAdd();
            modelbuilder.Entity<Barber>().Property(x => x.Name).HasMaxLength(100);
            modelbuilder.Entity<Barber>().Property(x => x.NumberCell).HasMaxLength(14);
            modelbuilder.Entity<Barber>().Property(x => x.PhotoPath).HasMaxLength(500);
            modelbuilder.Entity<Barber>().Property(x => x.Rating).HasColumnType("numeric(5,2)");
            modelbuilder.Entity<Barber>().Property(x => x.StartTime).HasMaxLength(2);
            modelbuilder.Entity<Barber>().Property(x => x.EndTime).HasMaxLength(2);
            modelbuilder.Entity<Barber>().Property(x => x.Available).HasColumnType("bit");
        }
    }
}
