using System;
using System.Collections.Generic;

#nullable disable

namespace GrouveStreet.Database.ContextDb
{
    public partial class Autopart
    {
        public long Idpart { get; set; }
        public string Name { get; set; }
        public long? Count { get; set; }
        public short? Category { get; set; }
        public string Description { get; set; }
        public long? Cost { get; set; }

        public virtual Categorypart CategoryNavigation { get; set; }
    }
}
