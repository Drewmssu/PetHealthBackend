using PetHealthAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetHealthAPI.JsonObjects
{
    public class AppointmentController : BaseController
    {
        public JsonResult Appointments(Int32? veterinaryId)
        {
            if (veterinaryId.HasValue)
            {
                return Json(AppointmentJsonObject.from(context.Appointment.Where(x => x.VeterinaryId == veterinaryId).ToList()), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(AppointmentJsonObject.from(context.Appointment.ToList()), JsonRequestBehavior.AllowGet);
            }
        }
    }
}