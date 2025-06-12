using Application.Supporting.Auth.Interfaces;
using Application.Supporting.Auth.Services;
using Infrastrucutre;
using Infrastrucutre.Repositories.Supporting.Interfaces;
using Infrastrucutre.Repositories.Supporting.Services;
using Microsoft.EntityFrameworkCore;

namespace Horeca;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

        builder.Services.AddScoped<IAuthRepository, AuthRepository>();
        builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
        builder.Services.AddScoped<IAuthService, AuthService>();
        
        builder.Services.AddControllers();
        
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        
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