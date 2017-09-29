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
        public JsonResult Appointments(Int32? appointmentId)
        {
            return Json(appointmentId.HasValue ? AppointmentJsonObject.@from(context.Appointment.Where(x => x.AppointmentId == appointmentId).ToList()) : AppointmentJsonObject.@from(context.Appointment.ToList()), JsonRequestBehavior.AllowGet);
        }
    }
}