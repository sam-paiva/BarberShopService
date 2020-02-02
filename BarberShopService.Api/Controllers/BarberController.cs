using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BarberShopService.Api.Interfaces;
using BarberShopService.Api.Repository;
using BarberShopService.Api.UnityOfWork;
using BarberShopService.Models.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BarberShopService.Api.Controllers
{
    [Route("api/[controller]")]
    public class BarberController : Controller
    {
        private readonly IUnityOfWork uow;

        public BarberController(IUnityOfWork _uow)
        {
            uow = _uow;
        }


        [HttpGet]
        public IActionResult GetBarberByBarberShopId([FromQuery] int id)
        {
            Expression<Func<Barber, bool>> func = v => v.BarberShop.Id == id;
            IEnumerable<Barber> barbers =  uow.BarberRepository.GetAll(func);

            if (barbers == null)
                return NoContent();

            return Ok(barbers.ToList());
        }

        [HttpPut]
        public IActionResult MakeAppointment([FromQuery]int id)
        {
            if (id == 0)
                return NoContent();

            uow.BarberRepository.UpdateAvailable(id);

            return Ok();
        }
    }
}
