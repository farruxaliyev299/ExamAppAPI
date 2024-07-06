using ExamApp.DAL;
using ExamApp.Extensions;
using Microsoft.EntityFrameworkCore;

namespace ExamApp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen();

        builder.Services.AddCors(o =>
        {
            o.AddDefaultPolicy(policy =>
            {
                policy
                    .WithOrigins("http://localhost:4200", "https://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });

        builder.Services.AddDbContext<ExamAppDbContext>(o =>
        {
            o.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
        });

        builder.Services.AddServiceManagementExtension();

        var app = builder.Build();

        // Configure the HTTP request pipeline.

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        
        app.UseCors();

        //app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
