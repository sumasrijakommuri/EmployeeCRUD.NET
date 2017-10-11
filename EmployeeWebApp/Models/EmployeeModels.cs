using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EmployeeWebApp.Models
{
	public class Employee
    { 
		[Key]
		public string Id { get; set; }

	    public string FirstName { get; set; }
	    public string LastName { get; set; }

		[Required]
	    public string Email { get; set; }

		[Required]
		public Address Address { get; set; }
	}

    public class Address
    {
		[Key]
        public string Id { get; set; }

        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
		public string Country { get; set; }
        public string ZipCode { get; set; }
    }
}