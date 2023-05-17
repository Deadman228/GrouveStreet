using System;
using System.Collections.Generic;

#nullable disable

namespace GrouveStreet.Database.ContextDb
{
    public partial class Service
    {
        public Service()
        {
            Orderservices = new HashSet<Orderservice>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long? Cost { get; set; }

        public virtual ICollection<Orderservice> Orderservices { get; set; }
    }
}
