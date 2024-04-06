using Bogus;
using CleanArchCqrs.Domain.Entities;

namespace CleanArchCqrs.UnitTest.Application.Factories
{
    public class AgentFactory
    {
        private readonly int _productId;
        private readonly string _name;
        private readonly string _email;

        public AgentFactory()
        {
            var faker = new Faker();
            _productId = faker.Random.Int(1, 100);
            _name = faker.Person.FullName;
            _email = faker.Person.Email;
        }

        public Agent GetAgent(
            int productId = -1,
            string name = "-1",
            string email = "-1")
        {
            return new Agent(
                productId == -1 ? _productId : productId,
                name == "-1" ? _name : name,
                email == "-1" ? _email : email);
        }
    }
}
