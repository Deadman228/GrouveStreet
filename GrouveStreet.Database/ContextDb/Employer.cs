using System;
using System.Collections.Generic;

#nullable disable

namespace GrouveStreet.Database.ContextDb
{
    public partial class Employer
    {
        public long Idemployer { get; set; }
        public string Name { get; set; }
        public string Familia { get; set; }
        public string Patronomyc { get; set; }
        public short? Login { get; set; }

        public virtual User IdemployerNavigation { get; set; }
    }
}
