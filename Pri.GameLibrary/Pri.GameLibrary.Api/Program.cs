using Microsoft.EntityFrameworkCore;
using Pri.GameLibrary.Core.Interfaces.Repositories;
using Pri.GameLibrary.Core.Interfaces.Services;
using Pri.GameLibrary.Core.Services;
using Pri.GameLibrary.Infrastructure.Data;
using Pri.GameLibrary.Infrastructure.Repositories;

namespace Pri.GameLibrary.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<ApplicationDbContext>(
               options => options
               .UseSqlServer(builder.Configuration
               .GetConnectionString("ApplicationDb")));

            builder.Services.AddTransient<IGameRepository, GameRepository>();
            builder.Services.AddTransient<IReviewRepository, ReviewRepository>();
            builder.Services.AddTransient<IDeveloperRepository, DeveloperRepository>();
            builder.Services.AddTransient<IPlatformRepository, PlatformRepository>();
            builder.Services.AddTransient<IDeveloperService, DeveloperService>();
            builder.Services.AddTransient<IReviewService, ReviewService>();
            builder.Services.AddTransient<IGameService, GameService>();
            builder.Services.AddTransient<IPlatformService, PlatformService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

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