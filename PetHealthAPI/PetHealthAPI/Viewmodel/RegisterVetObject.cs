using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetHealthAPI.ViewModel
{
    public class RegisterVetObject : RegisterPersonObject
    {
        [Url,Required]
        public String LinkedinLink { get; set; }
        [Required]
        public String Degree { get; set; }
    }
}