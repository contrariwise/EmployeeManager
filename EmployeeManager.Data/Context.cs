using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using EmployeeManager.Domain;

namespace EmployeeManager.Data
{
    public class Context : DbContext, IContext
    {
        public Context()
        {
        }

        public IDbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions
                .Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations
                .Add(new EmployeeConfiguration());
        }

    }
}
