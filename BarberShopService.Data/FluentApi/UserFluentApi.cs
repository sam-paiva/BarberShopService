using BarberShopService.Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarberShopService.Data.FluentApi
{
    public class UserFluentApi
    {
        public static void UserModel(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<User>().HasKey(x => x.UserId);
            modelbuilder.Entity<User>().Property(x => x.UserId).ValueGeneratedOnAdd();
            modelbuilder.Entity<User>().Property(x => x.LastName).HasMaxLength(50);
            modelbuilder.Entity<User>().Property(x => x.FirstName).HasMaxLength(50);
            modelbuilder.Entity<User>().Property(x => x.Email).HasMaxLength(30);
        }
    }
}
