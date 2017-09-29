using PetHealthAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetHealthAPI.JsonObjects
{
    public class AppointmentJsonObject
    {
        public Int32? appointmentId { get; set; }
        public Int32 vetId { get; set; }
        public Int32 veterinaryId { get; set; }
        public Int32 clinicalHistoryId { get; set; }
        public DateTime date { get; set; }
        public String description { get; set; }
        public String prescription { get; set; }

        public static AppointmentJsonObject from(Appointment appointment)
        {
            AppointmentJsonObject apj = new AppointmentJsonObject();
            apj.appointmentId = appointment.AppointmentId;
            apj.vetId = appointment.VetId;
            apj.veterinaryId = appointment.VeterinaryId;
            apj.clinicalHistoryId = appointment.ClinicalHistoryId;
            apj.date = appointment.AppointmentDate;
            apj.description = appointment.Description;
            apj.prescription = appointment.Prescription;
            return apj;
        }

        public static List<AppointmentJsonObject> from(List<Appointment> appointments)
        {
            List<AppointmentJsonObject> apjs = new List<AppointmentJsonObject>();
            foreach(var a in appointments)
            {
                apjs.Add(AppointmentJsonObject.from(a));
            }
            return apjs;
        }
    }
}