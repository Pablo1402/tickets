namespace Business.Entities
{
    public class UserType: EntityBase
    {
        public string Name { get; private set; }

        public ICollection<User> Users { get; set; }

        public UserType(string name)
        {
            Name = name;
        }
    }

}
