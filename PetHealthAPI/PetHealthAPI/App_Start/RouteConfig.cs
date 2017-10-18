using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PetHealthAPI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //--USER CONTROLLER--

            //login
            routes.MapRoute(
                "LogIn",
                "user/login",
                new { controller = "User", action = "LogIn" }
            );

            //register user

            routes.MapRoute(
                "UserRegister",
                "user/register",
                new {controller = "User", action = "Register"}
            );

            //register customer

            routes.MapRoute(
                "UserRegisterCustomer",
                "user/registerCustomer",
                new {controller = "User", action = "RegisterCustomer"}
            );

            //register vet

            routes.MapRoute(
                "UserRegisterVet",
                "user/registerVet",
                new {controller = "User", action = "RegisterVet"}
            );

            //returns pets
            routes.MapRoute(
                "UserPets",
                "user/pets/{ownerId}",
                new { controller = "User", action = "Pets" }
            );
            
            //--PET CONTROLLER--

            //return pets

            

            //add pets
            routes.MapRoute(
                "PetsAdd",
                "pets/add",
                new {controller = "Pet", action = "AddPet"}
            );
           
            //appointments (petsid if needed)
            routes.MapRoute(
                "PetsAppointment",
                "pets/appointments",
                new { controller = "Appointment", action = "Appointments" }
            );
            //vets 
            routes.MapRoute(
                "Vets",
                "vets/",
                new { controller = "Vet", action = "vets" }
            );
            //tips
            routes.MapRoute(
                "Tips",
                "tips/",
                new { controller = "Tip", action = "tips" }
            );
            //default
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
