using CleanArchCqrs.Application.Dtos;
using MediatR;

namespace CleanArchCqrs.Application.ComandsHandlers.Product.Commands
{
    public class ProductUpdateCommand : IRequest<ProductUpdateResponse>
    {
        public int Id { get; set; }

        public string Name { get; private set; } = string.Empty;

        public string Description { get; private set; } = string.Empty;

        public string Image { get; private set; } = string.Empty;

        public decimal Price { get; private set; }

        public int Stock { get; private set; }

        public int CategoryId { get; private set; }

        public ProductUpdateCommand(int id, string name, string description, string image, decimal price, int stock, int categoryId)
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
