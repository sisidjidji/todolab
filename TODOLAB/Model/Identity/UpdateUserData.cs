﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace TODOLAB.Model.Identity
{
    public class UpdateUserData
    {
        [Required]

        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

       
    }
}
