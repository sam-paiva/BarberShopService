using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarberShopService.Models.Models
{
    public class Barber
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string NumberCell { get; set; }
        public double Rating { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string PhotoPath { get; set; }
        public bool Available { get; set; }

        public BarberShop BarberShop { get; set; }
    }
}
