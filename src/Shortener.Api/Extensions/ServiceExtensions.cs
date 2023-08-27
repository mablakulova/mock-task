using DAL.Entities;
using DAL.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Shortener.Api.Services;

namespace DAL.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureRepositories(this IServiceCollection services) =>
            services.AddScoped<IRepository<LinkEntity>, Repository<LinkEntity>>();

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<ShortLinkContext>(opts =>
                opts.UseSqlServer(configuration.GetConnectionString("SqlConnection")));

        public static void ConfigureServices(this IServiceCollection services) =>
            services.AddScoped<IShorteningService, ShorteningService>();

        public static void ConfigureSwagger(this IServiceCollection services) =>
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "ShortLink", Version = "v1" });
            });
    }
}
