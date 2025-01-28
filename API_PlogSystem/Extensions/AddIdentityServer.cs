using CoreLayer_BlogSystem.Entities.Identity;
using CoreLayer_BlogSystem.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using RepositaryLayer_BlogSystem.Data;
using ServiceLayer_BlogSystem;
using System.Text;

namespace API_BlogSystem.Extensions
{
    public static class AddIdentityServer
    {
        public static IServiceCollection IdentityServices (this IServiceCollection services , IConfiguration configuration)
        {

            services.AddIdentity<AppUser, IdentityRole>()
                    .AddEntityFrameworkStores<Context>()
                    .AddDefaultTokenProviders();

            services.AddScoped<ITokenServices, TokenServices>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(optons =>
            {
                optons.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = configuration["JWT:ValidIssuer"],
                    ValidateAudience = true,
                    ValidAudience = configuration["JWT:ValidAudience"],
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]))
                };
            });

            return services;
        }
    }
}
