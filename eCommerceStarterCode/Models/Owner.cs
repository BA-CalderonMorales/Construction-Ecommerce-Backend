using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceStarterCode.Models
{
    public class Owner
    {
        [Key]
        public int? OwnerId { get; set; }
        public ICollection<Contract> Contracts { get; set; }
        public ICollection<Project> Projects { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
    }
}
