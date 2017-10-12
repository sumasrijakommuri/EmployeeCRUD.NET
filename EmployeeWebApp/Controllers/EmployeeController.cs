using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeWebApp.Models;
using EmployeeWebApp.ViewModels;

namespace EmployeeWebApp.Controllers
{
    public class EmployeeController : Controller
    {
        public ApplicationDbContext context;

        public EmployeeController()
        {
            context = new ApplicationDbContext();
        }

        // GET: Employee
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(EmployeeFormViewModel viewModel)
        {
            var address = new Address
            {
                Id = Guid.NewGuid().ToString(),
                StreetAddress1 = viewModel.StreetAddress1,
                StreetAddress2 = viewModel.StreetAddress2,
                City = viewModel.City,
                State = viewModel.State,
                Country = viewModel.Country,
                ZipCode = viewModel.ZipCode
            };

            var employee = new Employee
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Email = viewModel.Email,
                Address = address
            };

           
            
            context.Addresses.Add(address);
            context.Employees.Add(employee);
            context.SaveChanges();
            return RedirectToAction("Index","Home");
        }

        [Authorize]
        [HttpGet]
        public ActionResult EmployeeList(EmployeeListViewModel viewModel)
        {
            var employees = context.Employees.ToList();
            var addresses = context.Addresses.ToList();
            viewModel.Employees = employees;
            viewModel.Addresses = addresses;

            return View("EmployeeList", viewModel);
        }


        [Authorize]
        [HttpPost]
        public JsonResult Delete(string Id)
        {
            var existing = context.Employees.Find(Id);
            
            if (existing != null )
            {
               
                context.Employees.Remove(existing);
               
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Failed!");
            }
            return Json("Deletion Successful!");
        }

        [Authorize]
        [HttpPost]
        public ActionResult EditEmployee(string Id)
        {
            var viewModel = new EditFormViewModel();
            var existing = context.Employees.Find(Id);
            if (existing != null)
            {
                var address = context.Addresses.Find(existing.Address);
                if (address != null)
                {
                    viewModel.FirstName = existing.FirstName;
                    viewModel.LastName = existing.LastName;
                    viewModel.Email = existing.Email;
                    viewModel.StreetAddress1 = address.StreetAddress1;
                    viewModel.StreetAddress2 = address.StreetAddress2;
                    viewModel.City = address.City;
                    viewModel.State = address.State;
                    viewModel.Country = address.Country;
                    viewModel.ZipCode = address.ZipCode;
                }
            }
            return View("Edit", viewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(EditFormViewModel viewModel)
        {
           
            return View("EmployeeList");
        }
    }
}