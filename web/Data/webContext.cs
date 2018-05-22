using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using User = web.Models.User;

namespace web.Data
{
    public class webContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        //public DbSet<Message> Messages { get; set; }
        //public DbSet<Repiy> Repiys { get; set; }
    }
}
