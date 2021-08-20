using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceStarterCode.Models
{
    public class Review
    {
        [Key]
        public int? ReviewId { get; set; }
        public string ReviewContent { get; set; } // Written by the Customer that had work done for them.
    }
}
