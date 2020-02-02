using BarberShopService.Api.Interfaces;
using BarberShopService.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberShopService.Api.UnityOfWork
{
    public interface IUnityOfWork
    {
        IGenericRepository<Barber> BarberRepository { get; }
        IGenericRepository<BarberShop> BarberShopRepository { get; }
        void Commit();
    }
}
