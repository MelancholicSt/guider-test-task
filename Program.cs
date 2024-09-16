using GuiderTestTask.Data.Context;
using GuiderTestTask.Data.Entities;
using GuiderTestTask.Data.Repositories;
using GuiderTestTask.Services;

namespace GuiderTestTask;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
       
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<GuiderDbContext>();
        
        InjectRepositories(builder.Services);
        InjectBusinessLogic(builder.Services);
        
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

    private static void InjectBusinessLogic(IServiceCollection services)
    {
        services.AddScoped<ITagService, TagService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IEstablishmentService, EstablishmentService>();
    }

    private static void InjectRepositories(IServiceCollection services)
    {
        services.AddTransient<ICategoryRepository, CategoryRepository>();
        services.AddTransient<IEstablishmentRepository, EstablishmentRepository>();
        services.AddTransient<ITagRepository, TagRepository>();
    }
}