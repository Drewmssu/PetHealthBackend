using PetHealthAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetHealthAPI.ViewModel
{
    public class RegisterVetJsonObject : RegisterPersonJsonObject
    {
        [Url, Required]
        public String linkedinLink { get; set; }
        [Required]
        public String degree { get; set; }

        public static RegisterVetJsonObject from(Vet vet)
        {
            RegisterVetJsonObject vjo = new RegisterVetJsonObject();
            vjo.userId = vet.Person.User.UserId;
            vjo.name = vet.Person.Name;
            vjo.lastName = vet.Person.LastName;
            vjo.dni = vet.Person.DNI;
            vjo.adress = vet.Person.Adress;
            vjo.phone = vet.Person.Phone;
            vjo.linkedinLink = vet.Linkedinlink;
            vjo.degree = vet.Degree;
            return vjo;

        }

        public static List<RegisterVetJsonObject> from(List<Vet> vets)
        {
            List<RegisterVetJsonObject> vjos = new List<RegisterVetJsonObject>();
            foreach(var v in vets)
            {
                vjos.Add(RegisterVetJsonObject.from(v));
            }
            return vjos;
        }
    }
}