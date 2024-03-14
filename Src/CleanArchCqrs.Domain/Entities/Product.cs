using CleanArchCqrs.Domain.Exceptions;

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
            Name = name;
            Description = description;
            Image = image;
            Price = price;
            Stock = stock;
            CategoryId = categoryId;
        }

        public Product(int id, string name, string description, string image, decimal price, int stock, int categoryId)
        {
            Id = id;
            Name = name;
            Description = description;
            Image = image;
            Price = price;
            Stock = stock;
            CategoryId = categoryId;
        }
    }
}
