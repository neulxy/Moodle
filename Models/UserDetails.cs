﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusinessEntities
{
    public class UserDetails
    {
        [StringLength(7, MinimumLength = 2, ErrorMessage = "UserName length should be between 2 and 7")]
        [Display(Name="User Name"),Required]
        public string UserName { get; set; }

        [Display(Name = "Password"),Required]
        public string Password { get; set; }
    }

}