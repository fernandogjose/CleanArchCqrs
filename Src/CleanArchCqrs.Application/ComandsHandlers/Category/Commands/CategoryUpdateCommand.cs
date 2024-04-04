using CleanArchCqrs.Application.ComandsHandlers.Category.Commands;

namespace CleanArchCqrs.Application.ComandsHandlers.Category.Commands
{
    public class CategoryUpdateCommand : CategoryCommand
    {
        public int Id { get; set; }
    }
}
