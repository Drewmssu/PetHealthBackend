using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetHealthAPI.JsonObjects
{
    public class RegisterVeterinaryJsonObject
    {
        public Int32 VeterinaryId { get; set; }
        public String Name { get; set; }
        public String DescripVid { get; set; }
        public String PhoneNumber { get; set; }
        public String Location { get; set; }
        public String OpeningHours { get; set; }
    }
}