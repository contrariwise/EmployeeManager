using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeManager.Data;
using EmployeeManager.Domain;
using EmployeeManager.Domain.ViewModels;
using EmployeeManager.Web.Controllers;


namespace EmployeeManager.Web.Tests
{
    [TestClass]
    public class EmployeesControllerTest
    {
        IEmployeeRepository fakeRepository = new FakeEmployeeRepository();

        Employee employee = new Employee()
        {
            EmployeeNo = 1,
            CompanyId = 1,
            FirstName = "Dwight",
            LastName = "White",
            Title = "Salesperson",
            Salary = 1200
        };
        

        [TestMethod]
        public void Get_ShouldReturnEmployeeWithValidId()
        {

            EmployeesController controller = new EmployeesController(fakeRepository);
            controller.Request = new HttpRequestMessage();
            controller.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());


            HttpResponseMessage response = controller.Get(employee.EmployeeNo);
            EmployeeViewModel viewModel = response.Content.ReadAsAsync<EmployeeViewModel>().Result;


            Assert.IsNotNull(response);
            Assert.IsNotNull(viewModel);
            Assert.IsNotNull(response.Content);
            Assert.IsInstanceOfType(response.Content, typeof(ObjectContent<EmployeeViewModel>));
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(employee.EmployeeNo, viewModel.EmployeeNo);
            Assert.AreEqual(employee.FirstName, viewModel.FirstName);
            Assert.AreEqual(employee.LastName, viewModel.LastName);
        }

        [TestMethod]
        public void Get_ShouldReturn404EmployeeWithInValidId()
        {
            employee.EmployeeNo = 99;
            EmployeesController controller = new EmployeesController(fakeRepository);
            controller.Request = new HttpRequestMessage();
            controller.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());


            HttpResponseMessage response = controller.Get(employee.EmployeeNo);
            EmployeeViewModel viewModel = response.Content.ReadAsAsync<EmployeeViewModel>().Result;


            Assert.IsNotNull(response);
            Assert.IsNotNull(viewModel);
            Assert.IsNotNull(response.Content);
            Assert.IsInstanceOfType(response.Content, typeof(ObjectContent<System.Web.Http.HttpError>));
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
