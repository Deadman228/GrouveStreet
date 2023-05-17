using System;
using System.Collections.Generic;

#nullable disable

namespace GrouveStreet.Database.ContextDb
{
    public partial class Orderservice
    {
        public int Id { get; set; }
        public long? IdOrder { get; set; }
        public long? IdService { get; set; }

        public virtual Orderr IdOrderNavigation { get; set; }
        public virtual Service IdServiceNavigation { get; set; }
    }
}
