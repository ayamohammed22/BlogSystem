using CoreLayer_BlogSystem.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositaryLayer_BlogSystem.Data.configurations
{
    public class CommentConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Comment> builder)
        {
            builder.HasOne(C => C.Author)
                   .WithMany()
                   .HasForeignKey(C => C.AuthorId)
                   .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(C => C.Post)
                   .WithMany()
                   .HasForeignKey(C => C.PostId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
