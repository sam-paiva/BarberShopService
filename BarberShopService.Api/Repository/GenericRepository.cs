using BarberShopService.Api.Interfaces;
using BarberShopService.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BarberShopService.Api.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T: class 
    {
        private readonly BarberShopContext m_Context;
        DbSet<T> m_DbSet;

        public GenericRepository(BarberShopContext _context)
        {
            m_Context = _context;
            m_DbSet = m_Context.Set<T>();
        }

        public void Add(T entity)
        {
            m_DbSet.Add(entity);
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return m_DbSet.FirstOrDefault(predicate);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return m_DbSet.Where(predicate);
            }

            return m_DbSet.AsEnumerable();
        }

        public void Update(T Entity)
        {
            m_DbSet.Attach(Entity);
            ((IObjectContextAdapter)m_Context).ObjectContext.ObjectStateManager.
                ChangeObjectState(Entity, System.Data.Entity.EntityState.Modified);
        }

        public void UpdateAvailable(int id)
        {
            var barber = m_Context.Barbers.Where(barber => barber.Id == id).FirstOrDefault();

            if(barber != null)
            {
                barber.Available = !barber.Available;
            }

            m_Context.Barbers.Update(barber);
            m_Context.SaveChanges();
        }
    }
}
