using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Campain : EntityBase
    {

        public Campain(string name
            , Guid storeId
            , bool active
            , Guid campainConfigurationTypeId
            , int? quantityTickets)
        {
            Name = name;
            CreateDate = DateTime.Now;
            StoreId = storeId;
            Active = active;
            CampainConfigurationTypeId = campainConfigurationTypeId;
            QuantityTickets = quantityTickets;
        }

        public string Name { get; private set; }
        public DateTime CreateDate { get; private set; }

        public DateTime? EndDate { get; private set; }

        public Guid StoreId { get; private set; }
        public Store Store { get; set; }

        public bool Active { get; private set; }

        public Guid CampainConfigurationTypeId { get; private set; }
        public CampainConfigurationType CampainConfigurationType { get; private set; }

        public int? QuantityTickets { get; private set; }

        public ICollection<ClientCampain> ClientCampains { get; set; }


    }
}
