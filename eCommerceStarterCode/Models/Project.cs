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
        public int ProjectId { get; set; }
        public string NameOfProject { get; set; }
        public string DetailsOfProject { get; set; }
        public string LocationOfProject { get; set; } // Will attempt to parse to set Project: Latitude and Longitude
        public double Latitude { get; set; } // Will attempt to parse Latitude of Project site
        public double Longitude { get; set; } // Will attempt to parse Longitude of Project site
        public double DurationOfProject { get; set; }

        [ForeignKey("Owner")]
        public string OwnerId { get; set; }
        public Owner Owner { get; set; }

        [ForeignKey("Customer")]
        public string CustonerId { get; set; }
        public Customer Customer { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
