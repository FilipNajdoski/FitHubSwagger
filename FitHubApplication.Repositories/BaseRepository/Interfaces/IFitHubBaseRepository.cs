using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FitHubApplication.Repositories
{
    public interface IFitHubBaseRepository<T>
    {
        IQueryable<T> GetAll();

        IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate);

        Task<T> GetFirstWhere(Expression<Func<T, bool>> predicate);

        Task Create(T entity);

        Task CreateMultiple(List<T> entities);

        Task Update(T entity);

        Task UpdateMultiple(List<T> entities);

        Task Delete(T entity);

        Task DeleteMultiple(List<T> entities);
    }
}
