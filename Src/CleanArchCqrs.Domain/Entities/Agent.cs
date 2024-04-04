namespace CleanArchCqrs.Domain.Entities
{
    public sealed class Agent : Base
    {
        public string Name { get; private set; }

        public ICollection<Payment> Payments { get; set; }

        public Agent(string name)
        {
            Name = name;
        }

        public Agent(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
