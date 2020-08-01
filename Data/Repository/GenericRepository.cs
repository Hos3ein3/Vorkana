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
        protected readonly DBContext _dBContext;
        //public GenericRepository(DBContext dbContext)
        //{
        //    _dBContext = dbContext;
        //}
        //DBContext dBContext = new DBContext(null);
        public virtual T GetById(int id)
        {
            return _dBContext.Set<T>().Find(id);
        }
        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dBContext.Set<T>().FindAsync(id);
        }
        public virtual IQueryable<T> GetAll()
        {
            IQueryable<T> query = _dBContext.Set<T>();
            return query;
        }
        public async Task<int> SaveAsync()
        {
            return await _dBContext.SaveChangesAsync();
        }
        public int Save()
        {
            return _dBContext.SaveChanges();
        }
        public T Add(T entity)
        {
            _dBContext.Set<T>().Add(entity);
            return entity;
        }
        public void Update(T entity)
        {
            _dBContext.Entry(entity).State = EntityState.Modified;
        }
        public void Delete(T entity)
        {
            _dBContext.Set<T>().Remove(entity);
        }
    }
    #endregion
}
