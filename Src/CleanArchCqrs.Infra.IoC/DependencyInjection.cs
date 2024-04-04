using Amazon.Runtime;
using CleanArchCqrs.Application.Mappings;
using CleanArchCqrs.Domain.Interfaces.DataRepositories;
using CleanArchCqrs.Domain.Interfaces.DomainValidations;
using CleanArchCqrs.Domain.Interfaces.Sqs.Factories;
using CleanArchCqrs.Domain.Interfaces.Sqs.Services;
using CleanArchCqrs.Domain.Options;
using CleanArchCqrs.Domain.Validations;
using CleanArchCqrs.Infra.Data.Context;
using CleanArchCqrs.Infra.Data.Repositories;
using CleanArchCqrs.Infra.Sqs.Factories;
using CleanArchCqrs.Infra.Sqs.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;

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

            services.AddScoped<IAgentRepository, AgentRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(CommandToEntityMappingProfile));
            services.AddAutoMapper(typeof(DtoToCommandMappingProfile));
            services.AddAutoMapper(typeof(EntityToDtoMappingProfile));

            var handlers = AppDomain.CurrentDomain.Load("CleanArchCqrs.Application");
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(handlers));

            return services;
        }

        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.AddScoped<IProductValidation, ProductValidation>();
            services.AddScoped<IPaymentValidation, PaymentValidation>();

            return services;
        }

        public static IServiceCollection AddSqs(this IServiceCollection services, IConfiguration configuration)
        {
            SqsOptions.SqsRegion = configuration.GetSection("SqsOptions:SqsRegion").Value;
            SqsOptions.SqsQueueId = configuration.GetSection("SqsOptions:SqsQueueId").Value;
            SqsOptions.SqsQueueName = configuration.GetSection("SqsOptions:SqsQueueName").Value;
            SqsOptions.IamAccessKey = configuration.GetSection("SqsOptions:IamAccessKey").Value;
            SqsOptions.IamSecretKey = configuration.GetSection("SqsOptions:IamSecretKey").Value;

            services.AddSingleton<ISqsClientFactory, SqsClientFactory>();
            services.AddSingleton<ISqsService, SqsService>();

            return services;
        }
    }
}
