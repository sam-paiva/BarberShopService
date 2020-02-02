using System.Collections.Generic;

namespace BarberShopService.Models.Models
{
    public class BarberShop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string OpeningTime { get; set; }
        public string ClosingTime { get; set; }
        public string City { get; set; }
        public double Rating { get; set; }
        public string imagePath { get; set; }
        public bool Closed { get; set; }
        public ICollection<Barber> Barbers { get; set; }
    }
}
