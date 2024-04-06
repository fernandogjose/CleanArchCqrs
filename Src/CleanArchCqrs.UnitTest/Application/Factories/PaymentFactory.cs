using Bogus;
using CleanArchCqrs.Application.ComandsHandlers.Payment.Commands;
using CleanArchCqrs.Domain.Entities;
using CleanArchCqrs.Domain.Enums;

namespace CleanArchCqrs.UnitTest.Application.Factories
{
    public class PaymentFactory
    {
        private readonly int _paymentId;
        private readonly decimal _value;
        private readonly int _productId;
        private readonly int _agentId;

        public PaymentFactory()
        {
            var faker = new Faker();
            _paymentId = faker.Random.Int(1, 100);
            _value = faker.Random.Decimal(1, 100);
            _productId = faker.Random.Int(1, 100);
            _agentId = faker.Random.Int(1, 100);
        }

        public PaymentCreateCommand GetPaymentCreateCommand(
            PaymentGoalEnum paymentGoalEnum = PaymentGoalEnum.Upgrade,
            PaymentTypeEnum paymentTypeEnum = PaymentTypeEnum.Pix,
            decimal value = -1,
            int productId = -1,
            int agentId = -1)
        {
            return new PaymentCreateCommand(
                paymentGoalEnum.ToString(),
                paymentTypeEnum.ToString(),
                value == -1 ? _value : value,
                productId == -1 ? _productId : productId,
                agentId == -1 ? _agentId : agentId);
        }

        public Payment GetPayment(int paymentId = -1)
        {
            return new Payment(paymentId == -1 ? _paymentId : paymentId);
        }
    }
}
