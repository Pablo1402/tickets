namespace Business.Entities
{
    public class Store : EntityBase
    {

        public string Name { get;  set; }
        public string Email { get;  set; }
        public DateTime CreateDate { get;  set; }
        public bool Active { get;  set; }
        public string? Image { get;  set; }

        public Guid StorePlanId { get;  set; }
        public StorePlan StorePlan { get; set; }


        public IEnumerable<User> Users { get; set; }
        public ICollection<Campain> Campains { get; set; }

        public ICollection<Client> Clients { get; set; }

    }

}
