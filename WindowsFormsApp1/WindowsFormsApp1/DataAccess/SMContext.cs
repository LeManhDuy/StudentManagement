using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1.DataAccess
{
    public class SMContext : DbContext
    {
        public SMContext(): base("name=SVCodeFirst")
        {
            Database.SetInitializer<SMContext>(new CreateDB());
        }
        public virtual DbSet<SV> SVs { get; set; }
        public virtual DbSet<LSH> LSHs { get; set; }
    }
}
