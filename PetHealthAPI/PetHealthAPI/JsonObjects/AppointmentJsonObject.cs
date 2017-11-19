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
        public Int32? petId { get; set; }
        public String date { get; set; }
        public String description { get; set; }
        public String prescription { get; set; }
        public String status { get; set; }

        /**NOT FOR INPUT**/

        public String vet { get; set; }
        public String pet { get; set; }
        public String veterinary { get; set; }
        public static AppointmentJsonObject from(Appointment appointment)
        {
            AppointmentJsonObject apj = new AppointmentJsonObject();
            apj.appointmentId = appointment.AppointmentId;
            apj.vetId = appointment.VetId;
            apj.veterinaryId = appointment.VeterinaryId;
            apj.petId = appointment.PetId;
            apj.date = appointment.AppointmentDate.ToString();
            apj.description = appointment.Description;
            apj.prescription = appointment.Prescription;
            apj.vet = appointment.Vet.Person.Name + " " + appointment.Vet.Person.LastName;
            apj.veterinary = appointment.Veterinary.Name;
            apj.pet = appointment.Pet.Name; 
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