using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmployeeManager.Domain;

namespace EmployeeManager.Data
{
    public interface IEmployeeRepository : IDisposable
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee Get(int id);
    }
}
