using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APIRecipeProject.Models
{
    public class Registration
    {
        [Required]
        [DisplayName("Enter Name")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Enter User Name")]
        public string UserName { get; set; }
        [Required]
        [DisplayName("Enter password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DisplayName("Enter email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}