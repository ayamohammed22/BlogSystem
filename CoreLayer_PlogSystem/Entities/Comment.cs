using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLayer_BlogSystem.Entities.Identity;

namespace CoreLayer_BlogSystem.Entities
{
    public class Comment
    {
        //o Id(Primary Key)
        public int Id { get; set; }
        //o Content
        public string Content { get; set; }
        //o CreatedAt
        public DateTime CreateAt { get; set; } = DateTime.Now;
        //o PostId(Foreign Key referencing BlogPost)
        public BlogPost Post { get; set; }
        public int PostId { get; set; }
        ////o AuthorId(Foreign Key referencing User)
        public AppUser Author { get; set; }
        public string AuthorId { get; set; }


    }
}
