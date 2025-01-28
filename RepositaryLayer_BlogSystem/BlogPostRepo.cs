using CoreLayer_BlogSystem.Entities;
using CoreLayer_BlogSystem.Entities.Enums;
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
    public class BlogPostRepo : GenericRepo<BlogPost>, IBlogPostRepo
    {
        private readonly Context _dbcontext;

        public BlogPostRepo(Context dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IReadOnlyList<BlogPost>> GetByCategoryAsync(int CategoryId)
        {
             return await _dbcontext.Set<BlogPost>().Where(B => B.CategoryId == CategoryId).ToListAsync();
        }

      

        public async Task<IReadOnlyList<BlogPost>> GetByStatusAsync(BlogPostStatus status )
        {
            return await _dbcontext.Set<BlogPost>().Where(B => B.Status == status).ToListAsync();
        }

       
    }
}
