using System;
using System.Collections.Generic;

#nullable disable

namespace GrouveStreet.Database.ContextDb
{
    public partial class Status
    {
        public Status()
        {
            Orderrs = new HashSet<Orderr>();
        }

        public short Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Orderr> Orderrs { get; set; }
    }
}
