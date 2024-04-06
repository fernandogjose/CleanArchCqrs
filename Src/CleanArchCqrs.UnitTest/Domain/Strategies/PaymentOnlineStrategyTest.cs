using CleanArchCqrs.Domain.Enums;
using CleanArchCqrs.Domain.Interfaces.DomainStrategies;
using CleanArchCqrs.Domain.Strategies;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchCqrs.UnitTest.Domain.Strategies
{
    public class PaymentOnlineStrategyTest
    {
        private readonly IPaymentBusinessRuleStrategy _paymentOnlineStrategy;

        public PaymentOnlineStrategyTest()
        {
            // configuration
            var serviceCollection = new ServiceCollection();

            // domain strategy
            serviceCollection.AddScoped<IPaymentBusinessRuleStrategy, PaymentOnlineStrategy>();

            // build
            var services = serviceCollection.BuildServiceProvider();
            _paymentOnlineStrategy = services.GetService<IPaymentBusinessRuleStrategy>() ?? throw new ArgumentException(nameof(IPaymentBusinessRuleStrategy));
        }

        [Fact]
        public void GetBusinessRule_ShouldReturnOnlineRule_WhenProductTypeIsOnline()
        {
            var businessRuleOnline = _paymentOnlineStrategy.GetBusinessRule();

            Assert.NotNull(businessRuleOnline);
            Assert.Equal(ProductTypeEnum.OnLine, businessRuleOnline.ProductType);
            Assert.Equal(ProductTypeEnum.OnLine, _paymentOnlineStrategy.SatisfiedBy);
        }

        //TODO:: Criar as outras regras de negócio para deixa o código com pelo menos 80% de cobertura de testes
        //TODO:: Criar os testes para os outros objetos do sistema, aqui foi só um exemplo de como fazer
    }
}
