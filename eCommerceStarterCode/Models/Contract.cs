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
        public int ContractId { get; set; }
        public DateTime Date { get; set; }
        public string TypeOfWork { get; set; }
        public string DescriptionOfProject { get; set; }
        public double CustomerPriceProposal { get; set; }
        public double Location { get; set; }

        [ForeignKey("Customer")]
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
