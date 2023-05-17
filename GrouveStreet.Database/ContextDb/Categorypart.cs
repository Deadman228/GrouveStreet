using System;
using System.Collections.Generic;

#nullable disable

namespace GrouveStreet.Database.ContextDb
{
    public partial class Categorypart
    {
        public Categorypart()
        {
            Autoparts = new HashSet<Autopart>();
        }

        public short Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Autopart> Autoparts { get; set; }
    }
}
