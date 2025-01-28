using CoreLayer_BlogSystem.Entities.Enums;
using CoreLayer_BlogSystem.Entities.Identity;
using CoreLayer_BlogSystem.Entities;

namespace API_BlogSystem.DTOS
{
    public class BlogPostDTO
    {
        public string Title { get; set; }
    
        public string Content { get; set; }
        public List<string> Tags { get; set; } = new List<string>();
        public string Category { get; set; }
      
    }
}
