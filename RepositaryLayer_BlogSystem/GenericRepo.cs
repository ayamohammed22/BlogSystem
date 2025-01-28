using CoreLayer_BlogSystem.Repositories;
using Microsoft.EntityFrameworkCore;
using RepositaryLayer_BlogSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositaryLayer_BlogSystem
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly Context _dbcontext;

        public GenericRepo(Context dbcontext)
        {
           _dbcontext = dbcontext;
        }

        public async Task AddAsync(T item)
        {
            await _dbcontext.Set<T>().AddAsync(item);
        }

        public async Task<int> CompleteAsync()
        {
            return await _dbcontext.SaveChangesAsync();
        }

        public void Delete(T item)
        {
           _dbcontext.Set<T>().Remove(item);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
           return    await  _dbcontext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbcontext.Set<T>().FindAsync(id);

        }

        public async Task<T> GetbyIdwithIncludeAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            IQueryable <T>  query= _dbcontext.Set<T>();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
               if(predicate != null)
                return await query.FirstOrDefaultAsync(predicate);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllFilterAsync(Expression<Func<T, bool>>[] predicates , params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbcontext.Set<T>();
            if (includes.Any())
            {
                 foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
          
            if (predicates.Any())
            {
                foreach (var predicate in predicates)
                {
                    query = query.Where(predicate);
                }
            }
            return await query.ToListAsync();
        }

        public void Update(T item)
        {
            _dbcontext.Set<T>().Update(item);
        }
    }
}
