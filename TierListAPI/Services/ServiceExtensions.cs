using Microsoft.EntityFrameworkCore;
using TierListAPI.Persistence.Context;
using TierListAPI.Persistence.Repositories;
using TierListAPI.Persistence.Repository;

namespace TierListAPI.Services;

public static class ServiceExtensions
{
    public static void ConfigurePersistence(this IServiceCollection services)
    {
        DotEnv.Load();

        var connection = DotEnv.Get("DATABASE_URL");

        services.AddDbContext<TierListDBContext>(opt => opt.UseNpgsql(connection));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IItemRepository, ItemRepository>();
        services.AddScoped<ITagRepository, TagRepository>();
        services.AddScoped<ITierRepository, TierRepository>();
        services.AddScoped<ITierListTemplateRepository, TierListTemplateRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserAnswerRepository, UserAnswerRepository>();
        services.AddScoped<ISubmissionRepository, SubmissionRepository>();
    }

    public static void ConfigureApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(config => {
            config.LicenseKey = DotEnv.Get("LICENSE_KEY");
        }, typeof(Program).Assembly);

        services.AddMediatR(config =>
        {
            config.LicenseKey = DotEnv.Get("LICENSE_KEY");

            config.RegisterServicesFromAssembly(typeof(Program).Assembly);
        });

        services.AddScoped<IAutheticator, JWTHandler>();
    }

    public static void ConfigureCorsPolicy(this IServiceCollection services) 
    {
        services.AddCors(opt =>
            opt.AddDefaultPolicy(builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
            )
        );
    }
}
