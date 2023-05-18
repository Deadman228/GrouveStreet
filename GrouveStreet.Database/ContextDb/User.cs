using System;
using System.Collections.Generic;

#nullable disable

namespace GrouveStreet.Database.ContextDb
{
    public partial class User
    {
        public User()
        {
            Orderrs = new HashSet<Orderr>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Familia { get; set; }
        public string Patronomyc { get; set; }
        public long? RoleId { get; set; }
        public short? Phone { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Orderr> Orderrs { get; set; }
    }
}
