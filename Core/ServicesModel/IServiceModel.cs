using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.ServicesModel
{
    public interface IServiceModel<T> where T : class, IEntity 
    {
        Task<int> CountAsync(Expression<Func<T, bool>> predicate);
        Task<bool> AnyAsync(Expression<Func<T,bool>> predicate);
        Task AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task UpdateAsync(T entity);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        Task<IList<T>> GetListAsync(Expression<Func<T, bool>> predicate = null);
    }
}
