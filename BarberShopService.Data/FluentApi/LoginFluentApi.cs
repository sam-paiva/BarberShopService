using BarberShopService.Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarberShopService.Data.FluentApi
{
    public static class LoginFluentApi
    {
        public static void LoginModel(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Login>().HasKey(x => x.LoginId);
            modelbuilder.Entity<Login>().Property(x => x.LoginId).ValueGeneratedOnAdd();
            modelbuilder.Entity<Login>().Property(x => x.Email).HasMaxLength(50);
            modelbuilder.Entity<Login>().Property(x => x.Password).HasMaxLength(30);
        }
    }
}
