using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmployeeManager.Data;
using EmployeeManager.Domain;
using EmployeeManager.Domain.ViewModels;

namespace EmployeeManager.Web.Tests
{
    public class FakeEmployeeRepository : IEmployeeRepository
    {
        public List<Employee> Employees { get; set; }

        public FakeEmployeeRepository()
        {
            Employees = new List<Employee>();
            Employees.Add(new Employee { CompanyId = 1, EmployeeNo = 1, FirstName = "Dwight", LastName = "White", Title = "Sales Person", Salary = 1200 });
            Employees.Add(new Employee { CompanyId = 1, EmployeeNo = 2, FirstName = "Orlando", LastName = "Nunez", Title = "Accountant", Salary = 1400 });
        }

        public void Dispose()
        { }

        public EmployeeViewModel Get(int id)
        {
            Employee employee = Employees.FirstOrDefault(e => e.EmployeeNo == id);
            EmployeeViewModel viewModel = null;

            if (employee != null)
            {
                viewModel = new EmployeeViewModel()
                {
                    EmployeeNo = employee.EmployeeNo,
                    CompanyName = "Acme",
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Title = employee.Title,
                    Salary = employee.Salary
                };
            }
            return viewModel;
        }

        public IEnumerable<EmployeeNameViewModel> GetAllEmployees()
        {
            throw new NotImplementedException();
        }
    }
}
