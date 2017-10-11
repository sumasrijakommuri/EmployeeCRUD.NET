using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeeWebApp.Models;

namespace EmployeeWebApp.ViewModels
{
    public class EmployeeListViewModel
    {
        public List<Employee> Employees { get; set; }
        public List<Address> Addresses { get; set; }
    }
}