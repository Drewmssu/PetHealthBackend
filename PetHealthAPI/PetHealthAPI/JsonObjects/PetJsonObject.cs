using PetHealthAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetHealthAPI.ViewModel
{
    public class PetJsonObject
    {
        public Int32? petId { get; set; }
        [Required]
        public String name { get; set; }
        [Required]
        public String description { get; set; }
        public String ownerName { get; set; }
        public String birthDate { get; set; }
        public String race { get; set; }
        [Required]
        public Int32 ownerId { get; set; }
        [Required]
        public String key { get; set; }
        [Required]
        public String status { get; set; }
        public static PetJsonObject from(Pet pet)
        {
            PetJsonObject plo = new PetJsonObject();
            plo.petId = pet.PetId;
            plo.name = pet.Name;
            plo.description = pet.Description;
            plo.ownerName = pet.Customer.Person.Name;
            plo.ownerId = pet.OwnerId;
            plo.key = pet.Key;
            plo.birthDate = Convert.ToString(pet.BirthDate);
            plo.race = pet.race;
            plo.status = pet.Status;
            return plo;
        }

        public static List<PetJsonObject>from(List<Pet> pets)
        {
            List<PetJsonObject> plos = new List<PetJsonObject>();
            foreach(var p in pets)
            {
                plos.Add(PetJsonObject.from(p));
            }
            return plos;
        }
    }
}