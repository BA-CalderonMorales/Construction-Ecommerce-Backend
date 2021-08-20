using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceStarterCode.Models
{
    public class Customer
    {
        [Key]
        public int? CustomerId { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
    }
}
