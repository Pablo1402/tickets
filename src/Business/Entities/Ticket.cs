namespace Business.Entities
{
    public class Ticket : EntityBase
    {
        public Ticket(Guid ClientCampainId
            , int sequence
            , string note
            , Guid userId)
        {
            ClientCampainId = ClientCampainId;
            Sequence = sequence;
            CreateDate = DateTime.Now;
            Note = note;
            UserId = userId;
        }

        public Guid ClientCampainId { get; private set; }
        public ClientCampain ClientCampain { get; private set; }
        public int Sequence { get; private set; }

        public DateTime CreateDate { get; private set; }
        public string Note { get; private set; }

        public Guid UserId { get; private set; }
        public User User { get; private set; }
    }


}
