using CoreLayer_BlogSystem.Entities.Enums;
using CoreLayer_BlogSystem.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CoreLayer_BlogSystem.Entities
{
    public class BlogPost
    {
        //o Id(Primary Key)
        public int Id { get; set; }
        //o Title
        public string Title { get; set; }
        //o Content
        public string Content { get; set; }

        //o AuthorId(Foreign Key referencing User)
        public AppUser Author { get; set; }
        public string AuthorId { get; set; }
        //o CreatedAt
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        //o UpdatedAt
        public DateTime UpdateAt { get; set; }
        //o Status(Published, Draft, Archived)
        public BlogPostStatus Status { get; set; }
        //o Tags(Many-to-Many relationship with Tags)
        public List<Tag> Tags { get; set; } = new List<Tag>();
        //o CategoryId(Foreign Key referencing Category)
        public Category Category { get; set; }
        public int CategoryId { get; set; }
      

    }
}
