using PetHealthAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetHealthAPI.ViewModel
{
    public class RegisterUserJsonObject
    {
        public String username { get; set; }
        public String password { get; set; }
        [EmailAddress]
        public String mail { get; set; }
        public Person person { get; set; }
    }
}