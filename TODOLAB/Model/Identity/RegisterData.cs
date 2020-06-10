﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace TODOLAB.Model.Identity
{
    public class RegisterData
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirsttName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime? BirthDate { get; set; }
    }
}