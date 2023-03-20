namespace Business.Entities
{
    public class StorePlan: EntityBase
    {
        public string Name { get; private set; }
        public bool Active { get; private set; }
        

        public ICollection<Store> Stores { get; set; }

        public StorePlan(string name, bool active)
        {
            Name = name;
            Active = active;
        }

        public void SetStatus(bool status )
        {
            Active = status;
        }

    }

}
