using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using EmployeeManager.Domain;
using EmployeeManager.Domain.ViewModels;
using Newtonsoft.Json;

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

        //Jag tror inte att koden för att anropa tjänsten ska vara här, men jag är osäker på var den ska vara
        //Här skulle jag be om hjälp från en senior
        public EmployeeViewModel Get(int id)
        {
            EmployeeViewModel viewModel = null;
            Employee employee = context.Employees.FirstOrDefault(e => e.EmployeeId == id);
            String endpoint = "http://novacompanysvc.azurewebsites.net/api/companies/" + id;
            var client = new WebClient();

            Company company = new Company();
            try
            {
                company = JsonConvert.DeserializeObject<Company>(client.DownloadString(endpoint));
            }
            catch
            {
                company.Name = "Unkown";
            }

            if (employee != null)
            {
                viewModel = new EmployeeViewModel()
                            {
                                CompanyName = company.Name,
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

    public class Company
    {
        public int CompanyId { get; set; }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
