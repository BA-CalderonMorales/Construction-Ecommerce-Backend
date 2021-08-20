using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceStarterCode.Models
{
    public class Project
    {
        [Key]
        public int? ProjectId { get; set; }
        public string NameOfProject { get; set; }
        public string DetailsOfProject { get; set; }
        public string ImageOfProject { get; set; }
        public string LocationOfProject { get; set; } // Parse to get latitude and longitude in frontend.
        public string DurationOfProject { get; set; }

        [ForeignKey("Review")]
        public int? ReviewId { get; set; }
        public Review Reviews { get; set; }

        [ForeignKey("Category")]
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
