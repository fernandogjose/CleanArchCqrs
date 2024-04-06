using Amazon.Lambda.Core;
using Amazon.Lambda.SQSEvents;
using CleanArchCqrs.Application.ComandsHandlers.Payment.Commands;
using CleanArchCqrs.Application.Mappings;
using CleanArchCqrs.Domain.Helpers;
using CleanArchCqrs.Domain.Interfaces.DataRepositories;
using CleanArchCqrs.Domain.Interfaces.DomainHelpers;
using CleanArchCqrs.Domain.Interfaces.DomainStrategies;
using CleanArchCqrs.Infra.Data.Context;
using CleanArchCqrs.Infra.Data.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;


// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace CleanArchCqrs.LambdaFunction;

public class Function
{
    private readonly IMediator _mediator;

    /// <summary>
    /// Default constructor. This constructor is used by Lambda to construct the instance. When invoked in a Lambda environment
    /// the AWS credentials will come from the IAM role associated with the function and the AWS region will be set to the
    /// region the Lambda function is executed in.
    /// </summary>
    public Function()
    {
        var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

        // configuration
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddSingleton(configuration);

        // infrastructure
        serviceCollection.AddDbContext<ApplicationDbContext>(
            options => options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
            )
        );

        serviceCollection.AddScoped<IPaymentRepository, PaymentRepository>();
        serviceCollection.AddScoped<IPaymentProcessedRepository, PaymentProcessedRepository>();

        // domain
        typeof(IPaymentBusinessRuleStrategy).Assembly.GetTypes()
            .Where(a => a.Name.EndsWith("Strategy") && !a.IsAbstract && !a.IsInterface)
            .Select(a => new { assignedType = a, serviceTypes = a.GetInterfaces().First() })
            .ToList()
            .ForEach(t => serviceCollection.AddScoped(t.serviceTypes, t.assignedType));

        // helpers
        serviceCollection.AddScoped<IAgentCommissionHelper, AgentCommissionHelper>();
        serviceCollection.AddScoped<IPaymentGoalHelper, PaymentGoalHelper>();
        serviceCollection.AddScoped<IResourcesToAddHelper, ResourcesToAddHelper>();
        serviceCollection.AddScoped<IShipmentToCreateHelper, ShipmentToCreateHelper>();

        // application
        var handlers = AppDomain.CurrentDomain.Load("CleanArchCqrs.Application");
        serviceCollection.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(handlers));

        serviceCollection.AddAutoMapper(typeof(CommandToEntityMappingProfile));
        serviceCollection.AddAutoMapper(typeof(DtoToCommandMappingProfile));
        serviceCollection.AddAutoMapper(typeof(EntityToDtoMappingProfile));

        // build
        var services = serviceCollection.BuildServiceProvider();
        _mediator = services.GetService<IMediator>() ?? throw new ArgumentException(nameof(IMediator));
    }


    /// <summary>
    /// This method is called for every Lambda invocation. This method takes in an SQS event object and can be used 
    /// to respond to SQS messages.
    /// </summary>
    /// <param name="evnt">The event for the Lambda function handler to process.</param>
    /// <param name="context">The ILambdaContext that provides methods for logging and describing the Lambda environment.</param>
    /// <returns></returns>
    public async Task FunctionHandler(SQSEvent evnt, ILambdaContext context)
    {
        foreach (var message in evnt.Records)
        {
            await ProcessMessageAsync(message, context);
        }
    }

    private async Task ProcessMessageAsync(SQSEvent.SQSMessage message, ILambdaContext context)
    {
        try
        {
            context.Logger.LogInformation($"Processed message {message.Body}");
            var paymentProcessCommand = JsonConvert.DeserializeObject<PaymentProcessCommand>(message.Body);
            var paymentProcessResponse = await _mediator.Send(paymentProcessCommand);

            if (paymentProcessResponse) context.Logger.LogInformation($"Payment processed with success: {message.Body}");
            else context.Logger.LogInformation($"Payment processed with failed: {message.Body}");
        }
        catch (Exception ex)
        {
            context.Logger.LogError($"Processed message with error {ex}");
        }
        finally
        {
            await Task.CompletedTask;
        }
    }
}