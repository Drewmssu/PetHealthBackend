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
        public JsonResult Veterinaries(Int32? veterinaryId)
        {
            return Json(data: veterinaryId.HasValue ? 
                        RegisterVetJsonObject.@from(context.Vet.Where(x => x.VetId == veterinaryId).ToList()) : 
                        RegisterVetJsonObject.@from(context.Vet.ToList()), behavior: JsonRequestBehavior.AllowGet);
        }

        public JsonResult Vets(Int32? vetId) => Json(data: vetId.HasValue ? 
                                                    RegisterVetJsonObject.@from(context.Vet.Where(x => x.VetId == vetId).ToList()) : 
                                                    RegisterVetJsonObject.@from(context.Vet.ToList()), behavior: JsonRequestBehavior.AllowGet);
    }

}