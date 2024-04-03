using Bookstore.Data;
using BookStore.Api.Extension;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
           // var connectionString = $"Server =DECAGON;Database=BookStore;Integrated Security=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets=true";
            builder.Services.AddDbContext<BookstoreDbContext>(opt =>
           opt.UseSqlServer((builder.Configuration.GetConnectionString("ConnStr"))));

            // Add services to the container.
            builder.Services.AddHttpClient();

            // Configure AutoMapper
            builder.Services.ConfigureAutoMappers();

            // Register Dependency Injection Service Extension
            builder.Services.AddDependencyInjection();

            //configure swagger
            builder.Services.AddSwagger(); 

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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
