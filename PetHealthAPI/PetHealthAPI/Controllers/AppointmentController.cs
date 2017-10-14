using PetHealthAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetHealthAPI.JsonObjects
{
    [RoutePrefix("appointment")]
    public class AppointmentController : BaseController
    {
        public JsonResult Appointments(Int32? petId)
        {
            if (petId.HasValue)
            {
                return Json(new
                    {
                        status = "ok",
                        content = AppointmentJsonObject.from(context.Appointment.Where(x => x.PetId == petId).ToList())
                    }, JsonRequestBehavior.AllowGet
                );
            }
            else
            {
                return Json(new
                    {
                        status = "ok",
                        content = AppointmentJsonObject.from(context.Appointment.ToList())
                    }, JsonRequestBehavior.AllowGet
                );
            }
            //return Json(appointmentId.HasValue ? AppointmentJsonObject.@from(context.Appointment.Where(x => x.AppointmentId == appointmentId).ToList()) : AppointmentJsonObject.@from(context.Appointment.ToList()), JsonRequestBehavior.AllowGet);
        }
    }
}