using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using Project_ASP.NET.Repository;

namespace Project_ASP.NET
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ProjectPRN231_HuyDQContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("MyStoreDB")));
            builder.Services.AddScoped<ProjectPRN231_HuyDQContext>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
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