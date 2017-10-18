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
                "LogIn",
                "user/login",
                defaults: new { controller = "User", action = "LogIn" }
            );

            //register user

            routes.MapRoute(
                "UserRegister",
                "user/register",
                defaults: new {controller = "User", action = "Register"}
            );

            //register customer

            routes.MapRoute(
                "UserRegisterCustomer",
                "user/registerCustomer",
                defaults: new {controller = "User", action = "RegisterCustomer"}
            );

            //register vet

            routes.MapRoute(
                "UserRegisterVet",
                "user/registerVet",
                defaults: new {controller = "User", action = "RegisterVet"}
            );

            //returns pets
            routes.MapRoute(
                "UserPets",
                "user/pets/{ownerId}",
                defaults: new { controller = "User", action = "Pets" }
            );

            //-------------------- PET CONTROLLER --------------------------//

            //return pets

            routes.MapRoute(
                "PetPets",
                "pet/pets/{ownerId}",
                defaults: new { controller = "Pet", action = "Pets" }
            );

            //add pets
            routes.MapRoute(
                "PetAdd",
                "pet/add",
                new {controller = "Pet", action = "AddPet"}
            );

            //delete pet

            routes.MapRoute(
                "PetDelete",
                "pet/delete/{petId}",
                new {controller = "Pet", action = "Delete"}
            );

            //-------------------- TIP CONTROLLER --------------------------//

            //tips
            routes.MapRoute(
                "Tips",
                "tips/",
                new { controller = "Tip", action = "tips" }
            );

            //---------------------- VET CONTROLLER ------------------------//

            //veterinaries

            routes.MapRoute(
                "Veterinaries",
                "vet/veterinaries/{veterinaryId}",
                new {controller = "Vet", action = "Veterinaries"}
            );

            //vets 

            routes.MapRoute(
                "Vets",
                "vet/vets/{vetId}",
                new {controller = "Vet", action = "Vets"}
            );

            //------------------ APPOINTMENT CONTROLLER ------------------//

            //appointments (petsid if needed)
            routes.MapRoute(
                "PetsAppointment",
                "pets/appointments",
                new { controller = "Appointment", action = "Appointments" }
            );
            //----
            ////vets 
            //routes.MapRoute(
            //    "Vets",
            //    "vets/",
            //    new { controller = "Vet", action = "vets" }
            //);

            //default
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
