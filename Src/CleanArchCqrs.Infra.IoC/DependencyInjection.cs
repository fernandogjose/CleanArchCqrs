using CleanArchCqrs.Application.Mappings;
using CleanArchCqrs.Domain.Interfaces.DataRepositories;
using CleanArchCqrs.Domain.Interfaces.DomainValidations;
using CleanArchCqrs.Domain.Validations;
using CleanArchCqrs.Infra.Data.Context;
using CleanArchCqrs.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchCqrs.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
                )
            );

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DtoToCommandMappingProfile));
            services.AddAutoMapper(typeof(EntityToDtoMappingProfile));

            var handlers = AppDomain.CurrentDomain.Load("CleanArchCqrs.Application");
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(handlers));

            return services;
        }

        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.AddScoped<IProductValidation, ProductValidation>();

            return services;
        }
    }
}
