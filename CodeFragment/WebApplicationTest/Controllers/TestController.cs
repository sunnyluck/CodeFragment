using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationTest.Models;
using WebApplicationTest.ViewModels;

namespace WebApplicationTest.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult GetView()
        {
            Employee emp = new Employee();
            emp.FirstName = "Sukesh";
            emp.LastName = "Marla";
            emp.Salary = 20000;

            EmployeeViewModel vmEmp = new EmployeeViewModel();
            vmEmp.EmployeeName = emp.FirstName + " " + emp.LastName;
            vmEmp.Salary = emp.Salary.ToString("C");
            if (emp.Salary > 15000)
            {
                vmEmp.SalaryColor = "yellow";
            }
            else
            {
                vmEmp.SalaryColor = "green";
            }

            vmEmp.UserName = "Admin";


            return View("MyView", vmEmp);
            //var emp = new Employee();
            //emp.FirstName = "Sukesh";
            //emp.LastName = "Marla";
            //emp.Salary = 20000;
            //ViewData["Employee"] = emp;
            //return View("MyView",emp);
        }

        public ActionResult GetGridView()
        {
            var employeeListViewModel = new EmployeeListViewModel();

            var empBal = new EmployeeBusinessLayer();
            List<Employee> employees = empBal.GetEmployees();

            var empViewModels = new List<EmployeeViewModel>();

            foreach (Employee emp in employees)
            {
                var empViewModel = new EmployeeViewModel();
                empViewModel.EmployeeName = emp.FirstName + " " + emp.LastName;
                empViewModel.Salary = emp.Salary.ToString("C");
                if (emp.Salary > 15000)
                {
                    empViewModel.SalaryColor = "yellow";
                }
                else
                {
                    empViewModel.SalaryColor = "green";
                }
                empViewModels.Add(empViewModel);
            }
            employeeListViewModel.Employees = empViewModels;
            employeeListViewModel.UserName = "Admin";
            return View("MyGridView", employeeListViewModel);
        }

        public string GetString()
        {
            return "Hello World is old now. It’s time for wassup bro ;)";
        }

        public ActionResult ReturnView()
        {
            return View();
        }
    }
}