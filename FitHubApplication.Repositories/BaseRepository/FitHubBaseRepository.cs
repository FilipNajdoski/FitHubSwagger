using FitHubApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FitHubApplication.Repositories
{
    public abstract class FitHubBaseRepository<T> : IFitHubBaseRepository<T> where T : class
    {
        protected FitHubDbContext Context { get; set; }

        public FitHubBaseRepository(FitHubDbContext context)
        {
            Context = context;
        }

        public IQueryable<T> GetAll()
        {
            return Context.Set<T>().AsNoTracking();
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate).AsNoTracking();
        }

        public async Task<T> GetFirstWhere(Expression<Func<T, bool>> predicate)
        {
            return await Context.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public async Task Create(T entity)
        {
            Context.Set<T>().Add(entity);
            await Context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            Context.Set<T>().Update(entity);
            await Context.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
            await Context.SaveChangesAsync();
        }
    }
}
