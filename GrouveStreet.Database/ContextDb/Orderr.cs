using System;
using System.Collections.Generic;

#nullable disable

namespace GrouveStreet.Database.ContextDb
{
    public partial class Orderr
    {
        public Orderr()
        {
            Orderservices = new HashSet<Orderservice>();
        }

        public long Orderid { get; set; }
        public short? Status { get; set; }
        public long? Emploer { get; set; }
        public string Mark { get; set; }
        public string Number { get; set; }
        public DateTime? Date { get; set; }

        public virtual User EmploerNavigation { get; set; }
        public virtual Status StatusNavigation { get; set; }
        public virtual ICollection<Orderservice> Orderservices { get; set; }
    }
}
