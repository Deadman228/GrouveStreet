using System;
using System.Collections.Generic;

#nullable disable

namespace GrouveStreet.Database.ContextDb
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public long Id { get; set; }
        public string Namerole { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
