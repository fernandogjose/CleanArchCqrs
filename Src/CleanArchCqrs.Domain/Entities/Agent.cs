namespace CleanArchCqrs.Domain.Entities
{
    public sealed class Agent : Base
    {
        public string Name { get; private set; }

        public string Email { get; set; }

        public ICollection<Payment> Payments { get; set; }

        public Agent(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public Agent(int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }
    }
}
