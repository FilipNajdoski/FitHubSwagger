using FitHubApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        /// <summary>
        /// Returns <see cref="IQueryable{T}"/>
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> GetAll()
        {
            return Context.Set<T>().AsNoTracking();
        }

        /// <summary>
        /// Returns <see cref="IQueryable{T}"/> by given predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate).AsNoTracking();
        }

        /// <summary>
        /// Returns <see cref="T"/> by given predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<T> GetFirstWhere(Expression<Func<T, bool>> predicate)
        {
            return await Context.Set<T>().FirstOrDefaultAsync(predicate);
        }

        /// <summary>
        /// Creates multiple <see cref="T"/> in database
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public async Task CreateMultiple(List<T> entities)
        {
            await Context.Set<T>().AddRangeAsync(entities);
            await Context.SaveChangesAsync();
        }

        /// <summary>
        /// Creates <see cref="T"/> in database
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public async Task<T> Create(T entity)
        {
            await Context.Set<T>().AddAsync(entity);

            await Context.SaveChangesAsync();

            return entity;
        }

        /// <summary>
        /// Updates <see cref="T"/> to database
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public async Task Update(T entity)
        {
            Context.Set<T>().Update(entity);
            await Context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates multiple <see cref="T"/> to database
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public async Task UpdateMultiple(List<T> entities)
        {
            Context.Set<T>().UpdateRange(entities);
            await Context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes <see cref="T"/> in database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
            await Context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes multiple <see cref="T"/> in database
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public async Task DeleteMultiple(List<T> entities)
        {
            Context.Set<T>().RemoveRange(entities);
            await Context.SaveChangesAsync();
        }
    }
}
