using PetHealthAPI.Controllers;
using PetHealthAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
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
        [HttpPost]
        public JsonResult AddAppointments(AppointmentJsonObject json)
        {
            var status = "ok";
            var actualdate = json.date.Replace(@"\", string.Empty);
            Appointment newAppointment = new Appointment();
            if (json.appointmentId.HasValue)
            {
                newAppointment = context.Appointment.Find(json.appointmentId);
            }else
            {
                context.Appointment.Add(newAppointment);
            }
            using(var trans=new TransactionScope())
            {
                newAppointment.AppointmentDate = Convert.ToDateTime(actualdate);
                newAppointment.Description = json.description;
                newAppointment.PetId = Convert.ToInt32(json.petId);
                newAppointment.VeterinaryId = json.veterinaryId;
                newAppointment.VetId = json.vetId;
                newAppointment.Prescription = json.prescription;
                newAppointment.Status = json.status ;
                context.SaveChanges();
                trans.Complete();
            }
            return Json(new { status = status, appointement = newAppointment }, JsonRequestBehavior.AllowGet);
        }
    }
}