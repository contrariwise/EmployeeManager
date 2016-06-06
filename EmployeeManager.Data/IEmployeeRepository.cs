using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmployeeManager.Domain;
using EmployeeManager.Domain.ViewModels;

namespace EmployeeManager.Data
{
    public interface IEmployeeRepository : IDisposable
    {
        IEnumerable<EmployeeNameViewModel> GetAllEmployees();
        EmployeeViewModel Get(int id);
    }
}
