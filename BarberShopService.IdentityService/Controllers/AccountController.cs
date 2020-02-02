using BarberShopService.IdentityService.Configuration;
using BarberShopService.IdentityService.Interfaces;
using BarberShopService.IdentityService.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BarberShopService.IdentityService.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IAccountRepository _repository;

        public AccountController(IAccountRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult ValidateLogin([FromBody]LoginViewModel login,
            [FromServices]SigningConfigurations signingConfigurations,
            [FromServices]TokenConfiguration tokenConfigurations)
        {
            object result = _repository.ValidateLogin(login, signingConfigurations, tokenConfigurations);

            return Ok(result);
        }
    }
}
