using CoreLayer_BlogSystem.Entities;
using CoreLayer_BlogSystem.Entities.Enums;
using CoreLayer_BlogSystem.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using RepositaryLayer_BlogSystem;
using RepositaryLayer_BlogSystem.Data;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer_BlogSystem
{
    public class PostService
    {
        private readonly Context _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly BlogPostRepo _blogPostRepo;

        public PostService(Context context , UserManager<AppUser> userManager , BlogPostRepo blogPostRepo) 
        {
            _context = context;
            _userManager = userManager;
            _blogPostRepo = blogPostRepo;
        }
        public async Task<BlogPost> CreateBlogPostAsync(string Author_Email , string content , string title , string category , List<string> tags)
        {
            var Post = new BlogPost()
            {
                Content = content,
                Title = title,
                Category = new Category { Name = category },
                Tags = tags.Select(T => new Tag { Name = T }).ToList(),
                Author = await _userManager.FindByEmailAsync(Author_Email) 
            };
            await _blogPostRepo.AddAsync(Post);
            await _blogPostRepo.CompleteAsync();

            return Post;
        }

        public async Task<BlogPost> UpdateBlogPostAsync(int id , string content, string title, string category, List<string> tags)
        {
            var Post = await _blogPostRepo.GetByIdAsync(id);
            Post.Title = title;
            Post.Category = new Category {Name = category};
            Post.Tags = tags.Select(T => new Tag {Name = T}).ToList();
            Post.UpdateAt = DateTime.Now;
            //await _blogPostRepo.AddAsync(Post);
            await _blogPostRepo.CompleteAsync();

            return Post;
        }

        public async Task DeletePostAsync (int id)
        {
            var post = await _blogPostRepo.GetByIdAsync(id);
             _blogPostRepo.Delete(post);
            await _blogPostRepo.CompleteAsync();
            return;
        }

        public async Task<BlogPost> GetBlogPostByIdAsync(int id)
        {
            var post = await _blogPostRepo.GetbyIdwithIncludeAsync(X => X.Id == id , x => x.Category , x => x.Tags);
           
            return post;
        }

        public async Task<IReadOnlyList<BlogPost>> GetAllPostsAsync (string? catagory , string ? status)
        {

            return await _blogPostRepo.GetAllFilterAsync(
                new Expression<Func<BlogPost, bool>>[]
                {
                x => (catagory == null ||x.Category.Name == catagory) &&
                (status == null || x.Status == (BlogPostStatus)Enum.Parse(typeof(BlogPostStatus), status))
                }, P => P.Category);

        }


    }
}
