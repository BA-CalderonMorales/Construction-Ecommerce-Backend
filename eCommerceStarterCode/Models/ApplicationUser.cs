using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerceStarterCode.Models
{
    public class ApplicationUser : IdentityUser
    { 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Owner> Owners { get; set; }
        public ICollection<Customer> Customers { get; set; }
    }
}
