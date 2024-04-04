namespace CleanArchCqrs.Domain.Entities
{
    public abstract class Base
    {
        public int Id { get; protected set; }

        public DateTime CreatedAt { get; protected set; } = DateTime.Now;
    }
}
