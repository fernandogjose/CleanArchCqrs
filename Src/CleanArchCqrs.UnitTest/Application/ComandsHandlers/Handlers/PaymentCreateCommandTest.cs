using Bogus;
using CleanArchCqrs.Application.Mappings;
using CleanArchCqrs.Domain.Entities;
using CleanArchCqrs.Domain.Exceptions;
using CleanArchCqrs.Domain.Interfaces.DataRepositories;
using CleanArchCqrs.Domain.Interfaces.DomainStrategies;
using CleanArchCqrs.Domain.Interfaces.DomainValidations;
using CleanArchCqrs.Domain.Interfaces.Sqs.Services;
using CleanArchCqrs.Domain.Validations;
using CleanArchCqrs.UnitTest.Application.Factories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace CleanArchCqrs.UnitTest.Application.ComandsHandlers.Handlers
{
    public class PaymentCreateCommandTest
    {
        private readonly IMediator _mediator;
        private readonly Mock<IPaymentRepository> _paymentRepositoryMock;
        private readonly Mock<IAgentRepository> _agentRepositoryMock;
        private readonly Mock<IProductRepository> _productRepositoryMock;
        private readonly Mock<ISqsService> _sqsServiceMock;
        private readonly Faker _faker;

        public PaymentCreateCommandTest()
        {
            // Faker
            _faker = new Faker();

            // configuration
            var serviceCollection = new ServiceCollection();

            // infrastructure
            _paymentRepositoryMock = new Mock<IPaymentRepository>();
            serviceCollection.AddSingleton(_paymentRepositoryMock.Object);

            _agentRepositoryMock = new Mock<IAgentRepository>();
            serviceCollection.AddSingleton(_agentRepositoryMock.Object);

            _productRepositoryMock = new Mock<IProductRepository>();
            serviceCollection.AddSingleton(_productRepositoryMock.Object);

            _sqsServiceMock = new Mock<ISqsService>();
            serviceCollection.AddSingleton(_sqsServiceMock.Object);

            // domain
            typeof(IPaymentBusinessRuleStrategy).Assembly.GetTypes()
                .Where(a => a.Name.EndsWith("Strategy") && !a.IsAbstract && !a.IsInterface)
                .Select(a => new { assignedType = a, serviceTypes = a.GetInterfaces().First() })
                .ToList()
                .ForEach(t => serviceCollection.AddScoped(t.serviceTypes, t.assignedType));

            // helpers
            serviceCollection.AddScoped<IPaymentValidation, PaymentValidation>();

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

        [Fact]
        public async Task PaymentCreateCommandHandler_ShouldReturnIdInPaymentCreateResponse_WhenSuccess_Async()
        {
            // assert
            var paymentFactory = new PaymentFactory();
            var paymentProcessCommand = paymentFactory.GetPaymentCreateCommand();

            var productGetByIdAsyncResponse = new Product(paymentProcessCommand.ProductId);

            var agentFactory = new AgentFactory();
            var agentGetByIdAsyncResponse = agentFactory.GetAgent(productId: paymentProcessCommand.ProductId);

            var paymentCreateAsyncResponse = paymentFactory.GetPayment();

            _productRepositoryMock
                .Setup(s => s.GetByIdAsync(It.Is<int>(v => v == paymentProcessCommand.ProductId)))
                .ReturnsAsync(productGetByIdAsyncResponse);

            _agentRepositoryMock
                .Setup(s => s.GetByIdAsync(It.Is<int>(v => v == paymentProcessCommand.AgentId)))
                .ReturnsAsync(agentGetByIdAsyncResponse);

            _paymentRepositoryMock
                .Setup(s => s.CreateAsync(It.IsAny<Payment>()))
                .ReturnsAsync(paymentCreateAsyncResponse);

            // act
            var paymentProcessResponse = await _mediator.Send(paymentProcessCommand);

            // arrange
            Assert.NotNull(paymentProcessResponse);
            Assert.True(paymentProcessResponse.Id == paymentCreateAsyncResponse.Id);
        }

        [Fact]
        public async Task PaymentCreateCommandHandler_ShouldReturnDomainException_WhenProductNotFound_Async()
        {
            // assert
            var paymentFactory = new PaymentFactory();
            var paymentProcessCommand = paymentFactory.GetPaymentCreateCommand();

            // act
            var paymentProcessResponseWithException = await Assert.ThrowsAsync<DomainException>(async () => await _mediator.Send(paymentProcessCommand));

            // arrange
            Assert.Equal("Product not found", paymentProcessResponseWithException.Message);
        }

        [Fact]
        public async Task PaymentCreateCommandHandler_ShouldReturnDomainException_WhenProductIdIsInvalid_Async()
        {
            // assert
            var paymentFactory = new PaymentFactory();
            var paymentProcessCommand = paymentFactory.GetPaymentCreateCommand(productId: 0);

            // act
            var paymentProcessResponseWithException = await Assert.ThrowsAsync<DomainException>(async () => await _mediator.Send(paymentProcessCommand));

            // arrange
            Assert.Equal("Product is invalid", paymentProcessResponseWithException.Message);
        }

        //TODO:: Criar as outras regras de negócio para deixa o código com pelo menos 80% de cobertura de testes
        //TODO:: Criar os testes para os outros objetos do sistema, aqui foi só um exemplo de como fazer
    }
}
