﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RegisterOfFixAssets.Models
{
    public class ValidationTest
    {
        [Required]
        public string name { get; set; }

        [Required]
        public int marks { get; set; }
    }
}