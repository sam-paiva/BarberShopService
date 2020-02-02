using BarberShopService.Data.FluentApi;
using BarberShopService.Model.Models;
using BarberShopService.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace BarberShopService.Data
{
    public class BarberShopContext : DbContext
    {
        public BarberShopContext()
        {

        }

        public DbSet<Barber> Barbers { get; set; }
        public DbSet<BarberShop> BarberShops { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            BarberFluentApi.BarberModel(modelbuilder);
            BarberShopFluentApi.BarberShopModel(modelbuilder);
            LoginFluentApi.LoginModel(modelbuilder);
            UserFluentApi.UserModel(modelbuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=BarberShop;User Id=sa;password=sa12345;Trusted_Connection=True; MultipleActiveResultSets=true;");
        }
    }
}
