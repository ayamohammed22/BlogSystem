using API_BlogSystem.DTOS;
using CoreLayer_BlogSystem.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ServiceLayer_BlogSystem;

namespace API_BlogSystem.Controllers
{
    
    public class BlogController : APIBaseController
    {
        private readonly PostService _postService;

        public  BlogController(PostService postService)
        {
            _postService = postService;
        }

        // Create post 
         
        [HttpPost("Create")]
        [Authorize(Roles = "Admin,Editor")]
        public async Task<IActionResult> CreatePost(BlogPostDTO blogPost)
        {
            var Author_Email = User.FindFirstValue(ClaimTypes.Email);
            if (Author_Email == null)
            {
                return Unauthorized();
            }
            var Post = await _postService.CreateBlogPostAsync(Author_Email,blogPost.Content, blogPost.Title, blogPost.Category,blogPost.Tags );
            return Ok(Post);

        }

        // Update post 
        [HttpPut("Update/{id}")]
        [Authorize(Roles = "Admin,Editor")]
        public async Task <IActionResult> UpdatePost (int id,BlogPostDTO blogPost)
        {
            var Post = await _postService.UpdateBlogPostAsync(id, blogPost.Content, blogPost.Title, blogPost.Category, blogPost.Tags);
            return Ok(Post);
        }

        // Delete Post 
        [HttpDelete("Delete/{id}")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> DeletePost (int id)
        {
            _postService.DeletePostAsync(id);
            return NoContent();
        }

        // get all post 

        [HttpGet]

        public async Task<IActionResult> GetAllPosts ([FromQuery] string ? catagory , [FromQuery] string ? status)
        {
            var posts = await _postService.GetAllPostsAsync(catagory, status);
            return Ok(posts);

        }


        //  get by id  

        [HttpGet("{id}")]
         
        public async Task<IActionResult> GetPostById (int id)
        {
            var post = await _postService.GetBlogPostByIdAsync(id);
            var PostDTO = new BlogPostDTO()
            {
                Title = post.Title,
                Content = post.Content,
                Category = post.Category.Name,
                Tags = post.Tags.Select(T => T.Name).ToList()
            };
            return Ok(PostDTO);
        }
    }
}
