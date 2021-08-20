﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceStarterCode.Models
{
    public class Category
    {
        [Key]
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; } // Plumbing, Tile, Framing, Concrete...etc.
    }
}
