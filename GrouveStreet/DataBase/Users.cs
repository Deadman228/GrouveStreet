using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrouveStreet.DataBase
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Familia { get; set; }
        public string Patronomyc { get; set; }
        public int RoleID { get; set; }
        public int Phone { get; set; }
    }
}
