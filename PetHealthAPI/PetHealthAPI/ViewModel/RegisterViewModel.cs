using PetHealthAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetHealthAPI.ViewModel
{
    public class RegisterViewModel
    {
        public String username { get; set; }
        public String password { get; set; }
        public String mail { get; set; }

        public Person person { get; set; }
    }
}