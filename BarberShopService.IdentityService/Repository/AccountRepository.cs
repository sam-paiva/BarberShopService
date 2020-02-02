using BarberShopService.Data;
using BarberShopService.IdentityService.Configuration;
using BarberShopService.IdentityService.Interfaces;
using BarberShopService.IdentityService.ViewModels;
using BarberShopService.Model.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace BarberShopService.IdentityService.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BarberShopContext context;

        public AccountRepository(BarberShopContext _context)
        {
            context = _context;
        }

        public Login Find(string email)
        {
            var user = context.Logins.Where(c => c.Email == email).FirstOrDefault();

            return user;
        }

        public object ValidateLogin(LoginViewModel model, SigningConfigurations configurations, TokenConfiguration tokenConfiguration) 
        {
            Login login = new Login();
            bool credenciaisValidas = false;
            if (!String.IsNullOrWhiteSpace(model.Email) || String.IsNullOrWhiteSpace(model.Password))
            {
                login = Find(model.Email);
                credenciaisValidas = (login != null &&
                    model.Email == login.Email &&
                    model.Password == login.Password);
            }

            if (credenciaisValidas)
            {
               return VerifyCredentials(model, configurations, tokenConfiguration);  
            }
            else
            {
                return new
                {
                    authenticated = false,
                    message = "Falha ao autenticar"
                };
            }
        }


        public object VerifyCredentials(LoginViewModel model, SigningConfigurations signingConfigurations,
            TokenConfiguration tokenConfigurations)
        {
            ClaimsIdentity identity = new ClaimsIdentity(
                   new GenericIdentity(model.Email, "Login"),
                   new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, model.Email)
                   }
               );

            DateTime dataCriacao = DateTime.Now;
            DateTime dataExpiracao = dataCriacao +
            TimeSpan.FromSeconds(tokenConfigurations.Seconds);

            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = tokenConfigurations.Issuer,
                Audience = tokenConfigurations.Audience,
                SigningCredentials = signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = dataCriacao,
                Expires = dataExpiracao
            });
            var token = handler.WriteToken(securityToken);

            return new
            {
                authenticated = true,
                //user = user.UserId,
                created = dataCriacao.ToString("dd-MM-yyyy HH:mm:ss"),
                expiration = dataExpiracao.ToString("dd-MM-yyyy HH:mm:ss"),
                accessToken = token,
                message = "OK"
            };
        }

    }
}
