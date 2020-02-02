using BarberShopService.Api.Interfaces;
using BarberShopService.Api.Repository;
using BarberShopService.Api.UnityOfWork;
using BarberShopService.Models.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BarberShopService.Api.Controllers
{
    [Route("api/[controller]")]
    public class BarberShopController : Controller
    {
        private readonly IUnityOfWork uow;

        public BarberShopController(IUnityOfWork _uow)
        {
            uow = _uow;
        }

       [HttpGet]
       [Route("topbarbershops")]
       public IActionResult GetTopBarberShops()
       {
            Expression<Func<BarberShop, bool>> func = v => v.Rating == 5;
            return Ok(uow.BarberShopRepository.GetAll(func));
       }

        [HttpGet]
        [Route("allbarbershops")]
        public IActionResult GetAllBarberShops()
        {
            return Ok( uow.BarberShopRepository.GetAll());
        }
    }
}
