using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmployeeManager.Domain;

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

        public IEnumerable<Employee> GetAllEmployees()
        {
            return context.Employees;
        }

        public Employee Get(int id)
        {
            return context.Employees.FirstOrDefault(e => e.EmployeeId == id);
        }
    }
}
