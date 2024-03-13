namespace CleanArchCqrs.Application.Cqrs.Product.Commands
{
    public class ProductUpdateCommand : ProductCommand
    {
        public int Id { get; set; }
    }
}
