﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APIRecipeProject.Models
{
    public class LoginModel
    {
        [Required]
        [StringLength(20)]
        public string Password { get; set; }
        [Required]
        [StringLength(35)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}