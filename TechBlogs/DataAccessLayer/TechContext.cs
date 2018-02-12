using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlogs.Models;

namespace DataAccessLayer
{
   public partial class TechContext : DbContext
    {
        static TechContext()
        {
            Database.SetInitializer<TechContext>(null);
        }

        public TechContext()
            : base("Name=TechContext")
        {
            this.Configuration.ProxyCreationEnabled = false;
            Configuration.AutoDetectChangesEnabled = false;
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Posts> Posts { get; set; }
        public DbSet<Tags> Tags { get; set; }
        public DbSet<Comments> Comments { get; set; }
    }
}
