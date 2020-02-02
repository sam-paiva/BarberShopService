using BarberShopService.IdentityService.Configuration;
using BarberShopService.IdentityService.ViewModels;
using BarberShopService.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberShopService.IdentityService.Interfaces
{
    public interface IAccountRepository
    {
        Login Find(string email);

        object ValidateLogin(LoginViewModel model, SigningConfigurations signingConfigurations, 
            TokenConfiguration tokenConfiguration);

        object VerifyCredentials(LoginViewModel model, SigningConfigurations signingConfigurations,
            TokenConfiguration tokenConfiguration);
    }
}
