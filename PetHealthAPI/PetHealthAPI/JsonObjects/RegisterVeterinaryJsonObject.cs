using PetHealthAPI.Models;
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
        public Decimal Longitude { get; set; }
        public Decimal Latitude { get; set; }
        public String OpeningHours { get; set; }
        public Decimal Rating { get; set; }

        public static RegisterVeterinaryJsonObject from(Veterinary v)
        {
            RegisterVeterinaryJsonObject vjson = new RegisterVeterinaryJsonObject();
            vjson.VeterinaryId = v.VeterinaryId;
            vjson.Name = v.Name;
            vjson.DescripVid = v.PresentationVid;
            vjson.PhoneNumber = v.PhoneNumber;
            vjson.Longitude =Convert.ToDecimal(v.Longitude);
            vjson.Latitude = Convert.ToDecimal(v.Latitude);
            vjson.OpeningHours = v.OpeningHours;
            vjson.Rating = Convert.ToDecimal(v.Rate);
            return vjson;
        }

        public static List<RegisterVeterinaryJsonObject> from (List<Veterinary> lstv)
        {
            List<RegisterVeterinaryJsonObject> lstj = new List<RegisterVeterinaryJsonObject>();
            foreach(var veterinary in lstv)
            {
                lstj.Add(RegisterVeterinaryJsonObject.from(veterinary));
            }
            return lstj;
        }
    }
}