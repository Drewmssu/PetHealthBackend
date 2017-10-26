using PetHealthAPI.JsonObjects;
using PetHealthAPI.Models;
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
            var sts = "ok";
            List<Vet> vets;
            if (veterinaryId.HasValue)
            {
                vets = context.Contract
                    .Where(x => x.VeterinaryId == Convert.ToInt32(veterinaryId) && DateTime.Now >= x.StartDate && DateTime.Now < x.EndDate)
                    .Select(x => x.Vet)
                    .ToList();
            }else
            {
                vets = context.Vet.ToList();
            }
            return Json(new { status = sts, vets=vets},JsonRequestBehavior.AllowGet);
        }

        public JsonResult Vets(Int32 vetId)
        {
            var sts = "ok";
            var vet = context.Vet.Find(vetId);
            if (vet == null)
            {
                sts = "error: vet not found";
            }
            return Json(new { status = sts, vet = vet });
        }
    }

}