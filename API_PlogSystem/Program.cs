
using API_BlogSystem.Extensions;
using CoreLayer_BlogSystem.Entities.Identity;
using CoreLayer_BlogSystem.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RepositaryLayer_BlogSystem.Data;
using ServiceLayer_BlogSystem;

namespace API_PlogSystem
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<Context> (options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))) ;

            builder.Services.AppApplicationServer();
            builder.Services.IdentityServices(builder.Configuration);

            builder.Services.AddLogging(logging =>
            {
                logging.AddConsole();
                logging.AddDebug();
            });

            var app = builder.Build();

            using  var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var Loggerfactory = services.GetRequiredService<ILoggerFactory>();

            try
            {
                var Dbcontext = services.GetRequiredService<Context>();
                await Dbcontext.Database.MigrateAsync();

            }
            catch(Exception ex)
            {
                var Logger = Loggerfactory.CreateLogger<Program>();
                Logger.LogError(ex, "error on update datebase");
            }
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
