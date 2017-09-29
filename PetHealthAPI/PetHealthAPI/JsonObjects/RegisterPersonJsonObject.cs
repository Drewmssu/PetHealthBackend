using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetHealthAPI.ViewModel
{
    public class RegisterPersonJsonObject
    {
        [Required]
        public int userId { get; set; }
        [MaxLength(100), MinLength(2)]
        public String name { get; set; }
        [MaxLength(100)]
        public String lastName { get; set; }
        [MaxLength(10)]
        public String dni { get; set; }
        [MaxLength(200)]
        public String adress { get; set; }
        [Phone]
        public String phone { get; set; }
    }
}