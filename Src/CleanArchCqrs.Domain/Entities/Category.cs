using CleanArchCqrs.Domain.Validations;

namespace CleanArchCqrs.Domain.Entities
{
    public sealed class Category : Base
    {
        public string Name { get; private set; }

        public ICollection<Product> Products { get; set; }

        public Category(string name)
        {
            ValidateName(name);

            Name = name;
        }

        public Category(int id, string name)
        {
            ValidateId(id);
            ValidateName(name);

            Id = id;
            Name = name;
        }

        private void ValidateId(int id)
        {
            DomainExceptionValidation.When(id < 0, "Id is invalid");
        }

        private void ValidateName(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Name is required");
            DomainExceptionValidation.When(name.Length < 3, "Name is too short. Minimum 3 characters");
        }
    }
}
