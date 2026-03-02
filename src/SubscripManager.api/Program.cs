using SubscripManager.application.Interfaces;
using SubscripManager.application.Services;
using SubscripManager.domain.Interfaces;
using SubscripManager.infra.Repositories;

namespace SubscripManager.api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        builder.Services.AddScoped<IUserServices, UserServices>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();

        builder.Services.AddScoped<ISignatureServices, SignatureServices>();
        builder.Services.AddScoped<ISignatureRepository, SignatureRepository>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
