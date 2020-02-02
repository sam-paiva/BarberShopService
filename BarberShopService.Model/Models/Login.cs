using System;
using System.Collections.Generic;
using System.Text;

namespace BarberShopService.Model.Models
{
    public class Login
    {
        public int LoginId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public User User { get; set; }

    }
}
