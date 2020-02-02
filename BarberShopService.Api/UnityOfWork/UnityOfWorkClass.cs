using BarberShopService.Api.Interfaces;
using BarberShopService.Api.Repository;
using BarberShopService.Data;
using BarberShopService.Models.Models;
using System;

namespace BarberShopService.Api.UnityOfWork
{
    public class UnityOfWorkClass : IUnityOfWork, IDisposable
    {
        private readonly BarberShopContext context;
        private GenericRepository<Barber> barberReporitory = null;
        private GenericRepository<BarberShop> barberShopReporitory = null;
        private bool disposed = false;

        public UnityOfWorkClass(BarberShopContext _context)
        {
            context = _context;
        }

        public IGenericRepository<Barber> BarberRepository
        {
            get
            {
                if (barberReporitory == null)
                {
                    barberReporitory = new GenericRepository<Barber>(context);
                }
                return barberReporitory;
            }
        }

        public IGenericRepository<BarberShop> BarberShopRepository
        {
            get
            {
                if (barberShopReporitory == null)
                {
                    barberShopReporitory = new GenericRepository<BarberShop>(context);
                }
                return barberShopReporitory;
            }
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
