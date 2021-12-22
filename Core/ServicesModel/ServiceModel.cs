using Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.ServicesModel
{
    public class ServiceModel<T> : IServiceModel<T>
         where T : class, IEntity
         
    {
        private readonly DbContext _context;
        public ServiceModel(DbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
           await _context.Set<T>().AddAsync(entity);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().AnyAsync(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().CountAsync(predicate);
        }

        public async Task DeleteAsync(T entity)
        {
            await Task.Run(() => { _context.Set<T>().Update(entity); }); 
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _context.Set<T>();
            if (predicate != null)
            {
                query = query.Where(predicate);

            }
        
            return await query.SingleOrDefaultAsync();

        }

        public async Task<IList<T>> GetListAsync(Expression<Func<T, bool>> predicate = null)
        {
            IQueryable<T> query = _context.Set<T>();
            if(predicate !=null)
            {
                query = query.Where(predicate);

            }
       
            return await query.ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
             
             await Task.Run(() => { _context.Set<T>().Update(entity); }); // Manuel Async
        }
    }
}

