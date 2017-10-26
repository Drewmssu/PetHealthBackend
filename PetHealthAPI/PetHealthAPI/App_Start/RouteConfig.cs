using System.Web.Mvc;
using System.Web.Routing;

namespace PetHealthAPI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //--------------------- USER CONTROLLER -----------------------//

            //login
            routes.MapRoute(
                name: "LogIn",
                url: "user/login",
                defaults: new { controller = "User", action = "LogIn" }
            );

            //register user

            routes.MapRoute(
                name: "UserRegister",
                url: "user/register",
                defaults: new {controller = "User", action = "Register"}
            );

            //register customer

            routes.MapRoute(
                name: "UserRegisterCustomer",
                url: "user/registerCustomer",
                defaults: new {controller = "User", action = "RegisterCustomer"}
            );

            //register vet

            routes.MapRoute(
                name: "UserRegisterVet",
                url: "user/registerVet",
                defaults: new {controller = "User", action = "RegisterVet"}
            );

            //register veterinary

            routes.MapRoute(
                name: "UserRegisterVeterinary",
                url: "user/registerVeterinary",
                defaults: new { controller = "User", action = "RegisterVeterinary" }
            );

            //returns pets
            routes.MapRoute(
                name: "UserPets",
                url: "user/pets/{ownerId}",
                defaults: new { controller = "User", action = "Pets" }
            );

            //-------------------- PET CONTROLLER --------------------------//

            //return pets

            routes.MapRoute(
                name: "PetPets",
                url: "pet/pets/{ownerId}",
                defaults: new { controller = "Pet", action = "Pets" }
            );

            //add pets
            routes.MapRoute(
                name: "PetAdd",
                url: "pet/add",
                defaults: new {controller = "Pet", action = "AddPet"}
            );

            //delete pet

            routes.MapRoute(
                name: "PetDelete",
                url: "pet/delete/{petId}",
                defaults: new {controller = "Pet", action = "Delete"}
            );

            //-------------------- TIP CONTROLLER --------------------------//

            //tips
            routes.MapRoute(
                name: "Tips",
                url: "tips/",
                defaults: new { controller = "Tip", action = "tips" }
            );

            //---------------------- VET CONTROLLER ------------------------//

            //veterinaries

            routes.MapRoute(
                name: "Veterinaries",
                url: "vet/veterinaries/{veterinaryId}",
                defaults: new {controller = "Vet", action = "Veterinaries"}
            );

            //vets 

            routes.MapRoute(
                name: "Vets",
                url: "vets/{vetId}",
                defaults: new {controller = "Vet", action = "Vets"}
            );

            //------------------ APPOINTMENT CONTROLLER ------------------//

            //appointments (petsid if needed)
            routes.MapRoute(
                name: "PetsAppointment",
                url: "pets/appointments",
                defaults: new { controller = "Appointment", action = "Appointments" }
            );
            //----

            //default
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
