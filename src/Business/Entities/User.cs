using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class User : EntityBase
    {
        public User(Guid userTypeId
            ,string name
            , string login
            , string email
            , string password
            , Guid storeId)
        {
            UserTypeId = userTypeId;
            Name = name;
            Login = login;
            Email = email;
            Password = password;
            CreateDate = DateTime.Now;
            StoreId = storeId;
        }

        public Guid UserTypeId { get; private set; }
        public UserType UserType { get; set; }

        public string Name { get; private set; }
        public string Login { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public DateTime CreateDate { get; private set; }

        public Guid StoreId { get; private set; }
        public Store Store { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }

}
