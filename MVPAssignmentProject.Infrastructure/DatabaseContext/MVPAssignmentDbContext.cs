using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

using MVPAssignmentProject.Domain.Model;

namespace MVPAssignmentProject.Infrastructure.DatabaseContext
{
    public class MVPAssignmentDbContext:DbContext
    {

        public DbSet<PropertyTypes> PropertyTypes { get; set; }
        public DbSet<BrokerDetails> BrokerDetails { get; set; }
        public DbSet<PropertyDetails> PropertyDetails { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }

    

   
}
