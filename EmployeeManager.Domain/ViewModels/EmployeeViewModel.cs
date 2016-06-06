using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeManager.Domain.ViewModels
{
    public class EmployeeViewModel
    {
        public string CompanyName { get; set; }
        public int EmployeeNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public Decimal Salary { get; set; }

        //public EmployeeViewModel(Employee employee, string companyName)
        //{
        //    if (employee == null)
        //    {
        //        FirstName = "none";
        //        LastName = "none";
        //        CompanyName = "none";
        //        Title = "none";
        //    }
        //    else
        //    {
        //        CompanyName = companyName;
        //        EmployeeNo = employee.EmployeeNo;
        //        FirstName = employee.FirstName;
        //        LastName = employee.LastName;
        //        Title = employee.Title;
        //        Salary = employee.Salary;
        //    }
        //}
    }
}
