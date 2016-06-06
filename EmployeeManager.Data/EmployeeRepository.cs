using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmployeeManager.Domain;
using EmployeeManager.Domain.ViewModels;

namespace EmployeeManager.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private Context context = new Context();
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    if (context != null)
                        context.Dispose();
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<EmployeeNameViewModel> GetAllEmployees()
        {
            return context.Employees.Select(e => new EmployeeNameViewModel
            {
                EmployeeId = e.EmployeeId,
                FirstName = e.FirstName,
                LastName = e.LastName
            });
        }

        public EmployeeViewModel Get(int id)
        {
            EmployeeViewModel viewModel = null;
            Employee employee = context.Employees.FirstOrDefault(e => e.EmployeeId == id);

            if (employee != null)
            {
                return new EmployeeViewModel()
                {
                    CompanyName = "Acme",
                    EmployeeNo = employee.EmployeeNo,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Title = employee.Title,
                    Salary = employee.Salary
                };
            }
            return viewModel;
        }
             
    }
}
