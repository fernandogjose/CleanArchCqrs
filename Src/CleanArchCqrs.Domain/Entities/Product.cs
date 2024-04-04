using CleanArchCqrs.Domain.Enums;

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

        public ProductTypeEnum Type { get; set; }

        public Category Category { get; set; }

        public ICollection<Payment> Payments { get; set; }

        public Product(int id)
        {
            Id = id;
        }

        public Product(string name, string description, string image, decimal price, int stock, int categoryId, ProductTypeEnum type)
        {
            Name = name;
            Description = description;
            Image = image;
            Price = price;
            Stock = stock;
            CategoryId = categoryId;
            Type = type;
        }

        public Product(int id, string name, string description, string image, decimal price, int stock, int categoryId, ProductTypeEnum type)
        {
            Id = id;
            Name = name;
            Description = description;
            Image = image;
            Price = price;
            Stock = stock;
            CategoryId = categoryId;
            Type = type;
        }
    }
}
