using CoreLayer_BlogSystem.Repositories;
using RepositaryLayer_BlogSystem;
using ServiceLayer_BlogSystem;

namespace API_BlogSystem.Extensions
{
    public static class ApplicationServerExtention
    {
        public static IServiceCollection AppApplicationServer (this IServiceCollection Services)
        {
          
            Services.AddScoped(typeof(IGenericRepo<>),typeof(GenericRepo<>));
            // rigister for Postservices
            Services.AddScoped<PostService>(); 
            Services.AddScoped<CommentServices>(); 
            Services.AddScoped<BlogPostRepo>(); 
            return Services;
        }

    }
}
