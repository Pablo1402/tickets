namespace Business.Entities
{
    public class ClientCampain : EntityBase
    {
        public ClientCampain(bool paid
            , Guid clientId
            , Guid campainId)
        {
            CreateDate = DateTime.Now;
            Paid = paid;
            ClientId = clientId;
            CampainId = campainId;
        }

        public DateTime CreateDate { get; private set; }
        public bool Paid { get; private set; }

        public DateTime? PaidDate { get; private set; }

        public Guid ClientId { get; private set; }
        public Client Client { get; private set; }

        public Guid CampainId { get; private set; }
        public Campain Campain { get; private set; }

        public ICollection<Ticket> Tickets { get; set; }
    }


}
