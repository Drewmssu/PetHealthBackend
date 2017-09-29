using PetHealthAPI.JsonObjects;
using PetHealthAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetHealthAPI.Controllers
{
    public class VetController : BaseController
    {
        public JsonResult Vets(Int32? vetId)
        {
            return Json(vetId.HasValue ? RegisterVetJsonObject.@from(context.Vet.Where(x => x.VetId == vetId).ToList()) : RegisterVetJsonObject.@from(context.Vet.ToList()), JsonRequestBehavior.AllowGet);
        }
    }
}