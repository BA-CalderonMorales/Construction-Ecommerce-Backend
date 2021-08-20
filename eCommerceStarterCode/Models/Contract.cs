using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceStarterCode.Models
{
    public class Contract
    {
        [Key]
        public int? ContractId { get; set; }
        public DateTime? Date { get; set; } // Date Contract was Submitted to Database.
        public string TypeOfWork { get; set; }
        public string DescriptionOfProject { get; set; }
        public double? CustomerPriceProposal { get; set; }
        public double? Location { get; set; } // Parse to retreive the geolocation (latitude and longitude) in frontend.
        public string Image { get; set; } // An image to store for how the project site looks.
    }
}
