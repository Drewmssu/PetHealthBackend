using PetHealthAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetHealthAPI.Controllers
{
    public class PetController : BaseController
    {
        // GET: Vet
        public JsonResult Pets()
        {
            return Json(new {
                status ="ok",
                content =PetListObject.from(context.Pet.ToList())
            },
            JsonRequestBehavior.AllowGet);
        }

        public JsonResult Pets(Int32 OwnerId)
        {
            return Json(new {
                status = "ok",
                content = PetListObject.from(context.Pet.Where(x=>x.OwnerId==OwnerId).ToList())
            },
            JsonRequestBehavior.AllowGet);
        }
    }
}