using PetHealthAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetHealthAPI.JsonObjects
{
    public class CustomerJson
    {
        public int id { get; set; }
        public String username { get; set; }
        public String name { get; set; }
        public String lastname { get; set; }
        public String phone { get; set; }
        public String address { get; set; }
        public String nrodocumento { get; set; }
        public String tipodocumento { get; set; }
        public Int32? tipodocumentoId { get; set; }
        public String birthdate { get; set; }
        public static CustomerJson from(Customer x)
        {
            CustomerJson cjson = new CustomerJson();
            cjson.id = x.CustomerId;
            cjson.username = x.Person.User.Username;
            cjson.name = x.Person.Name;
            cjson.lastname = x.Person.LastName;
                cjson.phone = x.Person.Phone;
                cjson.address = x.Person.Adress;
                cjson.nrodocumento = x.Person.NroDocumento;
                cjson.tipodocumento = x.Person.DocumentType.Name;
                cjson.tipodocumentoId = x.Person.TipoDocumentoId;
                cjson.birthdate = Convert.ToString(x.Person.Birthdate);
            return cjson;
        }
        public static List<CustomerJson> from(List<Customer> pets)
        {
            List<CustomerJson> plos = new List<CustomerJson>();
            foreach (var p in pets)
            {
                plos.Add(CustomerJson.from(p));
            }
            return plos;
        }
    }
}