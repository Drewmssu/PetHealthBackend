using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetHealthAPI.ViewModel
{
    public class RegisterPersonObject
    {
        [Required]
        public int UserId { get; set; }
        [MaxLength(100), MinLength(2)]
        public String Name { get; set; }
        [MaxLength(100)]
        public String LastName { get; set; }
        [MaxLength(10)]
        public String DNI { get; set; }
        [MaxLength(200)]
        public String Adress { get; set; }
        [Phone]
        public String Phone { get; set; }
    }
}