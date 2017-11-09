using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetHealthAPI.ViewModel
{
    public class RegisterPersonJsonObject : RegisterUserJsonObject
    {
        [Required]
        public int userId { get; set; }
        [MaxLength(100), MinLength(2)]
        public String name { get; set; }
        [MaxLength(100)]
        public String lastName { get; set; }
        [MaxLength(15)]
        public String nrodocumento { get; set; }
        public Int32 tipodocumento { get; set; }
        [MaxLength(200)]
        public String adress { get; set; }
        //[Phone]
        public String phone { get; set; }
        public DateTime birthdate { get; set; }
        //-----------------NOT FOR INPUT-----------------------//
        public String documentName { get; set; }
    }
}