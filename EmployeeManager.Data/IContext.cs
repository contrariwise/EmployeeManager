using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using EmployeeManager.Domain;

namespace EmployeeManager.Data
{
    public interface IContext
    {
        IDbSet<Employee> Employees { get; set; }
    }
}
