using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer_BlogSystem.Repositories
{
    public interface IGenericRepo<T> where T : class
    {
        Task<IReadOnlyList<T>>  GetAllAsync();
        Task<T> GetByIdAsync(int id);

    }
}
