using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace RSGymPT_DAL.Model
{
    public class RSGymPTDBContext : DbContext
    {
       
        public RSGymPTDBContext() : base("RSGymPTDB")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<User> User { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<PersonalTrainer> PersonalTrainer { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Request> Request { get; set; }
    }
}

