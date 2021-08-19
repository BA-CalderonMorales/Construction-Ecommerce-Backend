using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerceStarterCode.Models
{
    public class Owner : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [ForeignKey("Customer")]
        public string CustomerId { get; set; }
        public ICollection<Customer> Customers { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public ICollection<Category> Categories { get; set; }

        [ForeignKey("Contract")]
        public int ContractId { get; set; }
        public ICollection<Contract> Contracts { get; set; }


    }
}
