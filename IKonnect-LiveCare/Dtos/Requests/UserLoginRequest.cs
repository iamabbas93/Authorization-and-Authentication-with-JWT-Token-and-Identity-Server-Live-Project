﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IKonnect_LiveCare.Dtos.Requests
{
    public class UserLoginRequest
    {
        [Required]
        
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
