using PetHealthAPI.Models;
using PetHealthAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;

namespace PetHealthAPI.Controllers
{
    [RoutePrefix("pet")]
    public class PetController : BaseController
    {
        public JsonResult Pets(Int32? ownerId)
        {
            return ownerId.HasValue
                ? Json(data: new
                    {
                        status = "ok",
                        content = PetJsonObject.@from(context.Pet.Where(x => x.OwnerId == ownerId).ToList())
                    },
                    behavior: JsonRequestBehavior.AllowGet)
                : Json(new
                    {
                        status = "ok",
                        content = PetJsonObject.@from(context.Pet.ToList())
                    },
                    JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult AddPet(PetJsonObject petJsonObject)
        {
            var newPet = new Pet();
            var msg = "error";
            try
            {
                using (var trans = new TransactionScope())
                {
                    if (petJsonObject.petId == null)
                    {
                        context.Pet.Add(newPet);
                    }
                    else
                    {
                        newPet = context.Pet.Find(petJsonObject.petId);
                    }
<<<<<<< HEAD
                    newPet.BirthDate = Convert.ToDateTime(petJsonObject.birthDate);
                    newPet.Description = petJsonObject.description;
                    newPet.Key = petJsonObject.key;
                    newPet.Name = petJsonObject.name;
                    newPet.OwnerId = petJsonObject.ownerId;
                    newPet.race = petJsonObject.race;
                    newPet.Status = petJsonObject.status;
=======
                    if (newPet != null)
                    {
                        newPet.BirthDate = Convert.ToDateTime(petJsonObject.birthDate);
                        newPet.Description = petJsonObject.description;
                        newPet.Key = petJsonObject.key;
                        newPet.Name = petJsonObject.name;
                        newPet.OwnerId = petJsonObject.ownerId;
                        newPet.Race = petJsonObject.race;
                        newPet.Status = petJsonObject.status;
                    }
>>>>>>> cba8dde225e1cb14e11ef3c6179e1ffff77e0d7f
                    context.SaveChanges();
                    trans.Complete();
                    msg = "success";
                }

            }
            catch (Exception e)
            {
                // ignored
            }
            return Json(new { message=msg }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Delete(Int32 petId)
        {
            var msg = "error";
            var pet = context.Pet.Find(petId);
            if (pet == null) return Json(new {message = msg}, JsonRequestBehavior.AllowGet);
            using (var trans = new TransactionScope())
            {
                context.Pet.Find(petId).Status = "INA";
                msg = "success";
            }
            return Json(new { message = msg }, JsonRequestBehavior.AllowGet);
        }
    }
}