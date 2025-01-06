using CoreLayer_BlogSystem.Repositories;
using Microsoft.EntityFrameworkCore;
using RepositaryLayer_BlogSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
           return    await  _dbcontext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbcontext.Set<T>().FirstAsync();

        }
    }
}
