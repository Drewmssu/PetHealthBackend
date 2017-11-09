using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetHealthAPI.JsonObjects;

namespace PetHealthAPI.Controllers
{
    public class VeterinaryController : BaseController
    {
        // GET: Veterinary
        public JsonResult veterinaries()


        {
            var sux = RegisterVeterinaryJsonObject.from(context.Veterinary.ToList());
            return Json(new { status = "ok", veterinaries = sux },JsonRequestBehavior.AllowGet);
        }
    }
}