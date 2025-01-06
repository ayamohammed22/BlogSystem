using CoreLayer_BlogSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositaryLayer_BlogSystem.Data.configurations
{
    public class BlogPostConfig : IEntityTypeConfiguration<BlogPost>
    {
        public void Configure(EntityTypeBuilder<BlogPost> builder)
        {
            builder.HasOne(P => P.Author)
                   .WithMany()
                   .HasForeignKey(U => U.AuthorId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(P => P.Category)
                  .WithMany()
                  .HasForeignKey(U => U.CategoryId);
            builder.HasMany(P => P.Tags)
                  .WithMany();
                
        }
    }
}
