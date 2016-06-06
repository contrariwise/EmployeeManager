using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeManager.Domain
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public int CompanyId { get; set; }
        public int EmployeeNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public Decimal Salary { get; set; }
    }
}
