using CleanArchCqrs.Domain.Exceptions;

namespace CleanArchCqrs.Domain.Entities
{
    public sealed class Category : Base
    {
        public string Name { get; private set; }

        public ICollection<Product> Products { get; set; }

        public Category(string name)
        {
            Name = name;
        }

        public Category(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
