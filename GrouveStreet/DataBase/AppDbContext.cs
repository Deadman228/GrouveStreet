using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GrouveStreet.DataBase
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

/*        public DbSet<Users> users { get; set; }
        public DbSet<Categoryparts> categoryparts { get; set; }
        public DbSet<Employer> employers { get; set; }
        public DbSet<Orderr> orderrs { get; set; }*/
        public DbSet<Role> role { get; set; }
        public DbSet<Services> services { get; set; }
        public DbSet<Orderr> orderr { get; set; }
        /*        public DbSet<Services> services { get; set; }
               public DbSet<Status> statuses { get; set; } */
    }
}
