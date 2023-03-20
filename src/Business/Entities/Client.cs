namespace Business.Entities
{
    public class Client : EntityBase
    {
        public Client(
             string whatsapp
            , DateTime? birthDate
            , Guid storeId)
        {
            Whatsapp = whatsapp;
            BirthDate = birthDate;
            StoreId = storeId;
        }

        public Guid StoreId { get; private set; }
        public Store Store { get; set; }

        public string Whatsapp { get; private set; }
        public DateTime? BirthDate { get; private set; }


        public ICollection<ClientCampain> ClientCampains { get; set; }

    }


}
