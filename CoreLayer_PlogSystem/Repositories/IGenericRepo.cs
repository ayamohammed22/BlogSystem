using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer_BlogSystem.Repositories
{
    public interface IGenericRepo<T> where T : class
    {
       public  Task<IReadOnlyList<T>>  GetAllAsync();
       public  Task<T> GetByIdAsync(int id);
        public Task<T> GetbyIdwithIncludeAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);

        public Task<IReadOnlyList<T>> GetAllFilterAsync(Expression<Func<T, bool>>[] predicates, params Expression<Func<T, object>>[] includes);


       public Task AddAsync (T item);
       public void Update (T item); 
       public void Delete (T item);
        public Task<int> CompleteAsync();
       
       

    }
}
