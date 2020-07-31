using Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    #region Dangerzone :)
    
    public class GenericRepository<T> where T : class
    {
        protected readonly DBContext dBContext;
        //public GenericRepository(DBContext _dbContext)
        //{
        //    dBContext = _dbContext;
        //}
        //DBContext dBContext = new DBContext(null);
        public virtual T GetById(int id)
        {
            return dBContext.Set<T>().Find(id);
        }
        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await dBContext.Set<T>().FindAsync(id);
        }
        public virtual IQueryable<T> GetAll()
        {
            IQueryable<T> query = dBContext.Set<T>();
            return query;
        }
        public async Task<int> SaveAsync()
        {
            return await dBContext.SaveChangesAsync();
        }
        public int Save()
        {
            return dBContext.SaveChanges();
        }
        public T Add(T entity)
        {
            dBContext.Set<T>().Add(entity);
            return entity;
        }
        public void Update(T entity)
        {
            dBContext.Entry(entity).State = EntityState.Modified;
        }
        public void Delete(T entity)
        {
            dBContext.Set<T>().Remove(entity);
        }
    }
    #endregion
}
