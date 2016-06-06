using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmployeeManager.Data;
using EmployeeManager.Domain;

namespace EmployeeManager.DBSetup
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new Context())
            {
                db.Employees.Add(new Employee 
                { CompanyId = 1, EmployeeNo = 1, FirstName = "Dwight", LastName = "White", Title = "Sales Person", Salary = 1200});
                db.Employees.Add(new Employee
                { CompanyId = 1, EmployeeNo = 2, FirstName = "Orlando", LastName = "Nunez", Title = "Accountant", Salary = 1400 });
                db.Employees.Add(new Employee
                { CompanyId = 1, EmployeeNo = 3, FirstName = "Dolores", LastName = "Hayes", Title = "Cookie Monitor", Salary = 1300 });
                db.Employees.Add(new Employee
                { CompanyId = 2, EmployeeNo = 4, FirstName = "Joann", LastName = "West", Title = "Engineer", Salary = 1500 });
                db.Employees.Add(new Employee
                { CompanyId = 2, EmployeeNo = 5, FirstName = "Laverne", LastName = "Cruz", Title = "Researcher", Salary = 1400 });
                db.Employees.Add(new Employee
                { CompanyId = 2, EmployeeNo = 6, FirstName = "Iris", LastName = "Elliott", Title = "Lab Technician", Salary = 1000 });
                db.Employees.Add(new Employee
                { CompanyId = 3, EmployeeNo = 7, FirstName = "Margaret", LastName = "Castro", Title = "Photographer", Salary = 1000 });
                db.Employees.Add(new Employee
                { CompanyId = 3, EmployeeNo = 8, FirstName = "Betty", LastName = "Hodges", Title = "Columnist", Salary = 800 });
                db.Employees.Add(new Employee 
                { CompanyId = 3, EmployeeNo = 9, FirstName = "Lucia", LastName = "Knight", Title = "Reporter", Salary = 1100 });
                db.Employees.Add(new Employee 
                { CompanyId = 3, EmployeeNo = 10, FirstName = "Courtney", LastName = "Green", Title = "Editor-in-Chief", Salary = 3600 });

    
                db.SaveChanges();

                var query = from b in db.Employees
                            orderby b.FirstName
                            select b;

                foreach (var item in query)
                {
                    Console.WriteLine("Added " + item.FirstName);
                }
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
