using PetHealthAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetHealthAPI.ViewModel
{
    public class PetListObject
    {
        public Int32 VetId { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String OwnerName { get; set; }
        public Int32 OwnerId { get; set; }
        public String Key { get; set; }
        public static PetListObject from(Pet pet)
        {
            PetListObject plo = new PetListObject();
            plo.VetId = pet.PetId;
            plo.Name = pet.Name;
            plo.Description = pet.Description;
            plo.OwnerName = pet.Name;
            plo.OwnerId = pet.OwnerId;
            plo.Key = pet.Key;
            return plo;
        }

        public static List<PetListObject>from(List<Pet> pets)
        {
            List<PetListObject> plos = new List<PetListObject>();
            foreach(var p in pets)
            {
                plos.Add(PetListObject.from(p));
            }
            return plos;
        }
    }
}