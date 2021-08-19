using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MariosConstruction.Models
{
    public class Owner : IdentityUser
    {
        [Key]
        public int OwnerId { get; set; }
        public string first_name
    }
}