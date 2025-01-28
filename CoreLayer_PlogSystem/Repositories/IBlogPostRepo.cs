using CoreLayer_BlogSystem.Entities;
using CoreLayer_BlogSystem.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer_BlogSystem.Repositories
{
     public interface IBlogPostRepo 
    {
        public Task<IReadOnlyList<BlogPost>> GetByCategoryAsync(int CategoryId);
        public Task<IReadOnlyList<BlogPost>> GetByStatusAsync(BlogPostStatus status);

    }
}
