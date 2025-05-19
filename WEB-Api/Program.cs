
using CRUD.DBConnect;
using CRUD.Repository.Implementation;
using CRUD.Repository.Interfaces;
using CRUD.Services.Implementations;
using CRUD.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CRUD
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

            // Register services

            builder.Services.AddScoped<IEmployeeServices, EmployeeServices>();
            builder.Services.AddScoped<IDepartmentServices, DepartmentServices>();

            // Register repository interfaces
            builder.Services.AddScoped<ICompany>();
            builder.Services.AddScoped<IEmployee>();
            builder.Services.AddScoped<IDepartment>();

            builder.Services.AddScoped<ICompany>();
            builder.Services.AddScoped<ICompanyServices, ComapnyServices>();


            builder.Services.AddDbContext<ApplicationDbContect>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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
