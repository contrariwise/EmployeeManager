using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using EmployeeManager.Domain;

namespace EmployeeManager.Data
{
    public class EmployeeConfiguration : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {
            HasKey(k => k.EmployeeId);

            Property(p => p.EmployeeId)
                .HasColumnName("EmployeeId")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.CompanyId)
                .HasColumnName("CompanyId")
                .IsRequired();

            Property(p => p.EmployeeNo)
                .HasColumnName("EmployeeNo")
                .IsRequired();

            Property(p => p.FirstName)
                .HasColumnName("FirstName")
                .IsRequired();

            Property(p => p.LastName)
                .HasColumnName("LastName")
                .IsRequired();

            Property(p => p.Title)
                .HasColumnName("Title")
                .IsRequired();

            Property(p => p.Salary)
                .HasColumnName("Salary")
                .IsRequired();
        }
    }
}
