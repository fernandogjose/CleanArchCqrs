using CleanArchCqrs.Domain.Validations;

namespace CleanArchCqrs.Domain.Entities
{
    public sealed class Product : Base
    {
        public string Name { get; private set; }

        public string Description { get; private set; }

        public string Image { get; private set; }

        public decimal Price { get; private set; }

        public int Stock { get; private set; }

        public int CategoryId { get; private set; }

        public Category Category { get; set; }

        public Product(string name, string description, string image, decimal price, int stock, int categoryId)
        {
            ValidateName(name);
            ValidateCategoryId(categoryId);

            Name = name;
            Description = description;
            Image = image;
            Price = price;
            Stock = stock;
            CategoryId = categoryId;
        }

        public Product(int id, string name, string description, string image, decimal price, int stock, int categoryId)
        {
            ValidateId(id);
            ValidateName(name);
            ValidateCategoryId(categoryId);

            Id = id;
            Name = name;
            Description = description;
            Image = image;
            Price = price;
            Stock = stock;
            CategoryId = categoryId;
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

        private void ValidateCategoryId(int categoryId)
        {
            DomainExceptionValidation.When(categoryId < 0, "CategoryId is invalid");
        }
    }
}
