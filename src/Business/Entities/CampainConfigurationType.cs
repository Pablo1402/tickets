namespace Business.Entities
{
    public class CampainConfigurationType : EntityBase
    {
        public string Name { get; private set; }

        public ICollection<Campain> Campains { get; set; }

        public CampainConfigurationType(string name)
        {
            Name = name;
        }
    }


}
