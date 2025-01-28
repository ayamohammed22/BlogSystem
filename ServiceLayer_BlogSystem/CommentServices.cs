using CoreLayer_BlogSystem.Entities;
using CoreLayer_BlogSystem.Entities.Identity;
using CoreLayer_BlogSystem.Repositories;
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
      public  class CommentServices
      {
        private readonly Context _dbContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly PostService _postService;
        private readonly IGenericRepo<Comment> _commentRepo;

        public CommentServices(Context dbContext , UserManager<AppUser> userManager , PostService postService , IGenericRepo<Comment> commentRepo) 
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _postService = postService;
           _commentRepo = commentRepo;
        }

        public async Task<Comment> CreateCommentAsync(string Author_Email, string content , int post_id )
        {
            var comment = new Comment()
            {
                Author = await _userManager.FindByEmailAsync(Author_Email),
                Content = content,
                Post =await _postService.GetBlogPostByIdAsync(post_id)
            };

           await _commentRepo.AddAsync(comment);
           await  _commentRepo.CompleteAsync();
            return comment;

        }
        public async Task<IReadOnlyList<Comment>> GetCommentsAsync(int blogId)
        {
            return await _commentRepo.GetAllFilterAsync(
                new Expression<Func<Comment, bool>>[]
                {
                    X=>  X.PostId == blogId
                }
                );
        }
    }
}
