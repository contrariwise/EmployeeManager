﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeManager.Domain;
using EmployeeManager.Data;

namespace EmployeeManager.Web.Controllers
{
    public class EmployeesController : ApiController
    {
        private readonly IEmployeeRepository repository = null;

        public EmployeesController(IEmployeeRepository repository)
        {
            this.repository = repository;
        }

        public EmployeesController()
        {
            this.repository = new EmployeeRepository();
        }

        public HttpResponseMessage Get(int id)
        {
            var employee = repository.Get(id);
            if (employee == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee not found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, employee);
        }

        public HttpResponseMessage Get()
        {
            var employees = repository.GetAllEmployees();

            if (employees != null && employees.Any())
            {
                return Request.CreateResponse(HttpStatusCode.OK, employees);
            }

            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee not found");
        }

        protected override void Dispose(bool disposing)
        {
           if (repository != null) 
               repository.Dispose();

            base.Dispose(disposing);
        }
    }
}
