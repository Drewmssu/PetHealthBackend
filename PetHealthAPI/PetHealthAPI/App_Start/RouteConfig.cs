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

            routes.MapRoute(
                name: "Customers2",
                url: "customers",
                defaults: new { controller = "User", action = "getCustomers" }
            );

            routes.MapRoute(
                name: "Customers",
                url: "customers/{customerId}",
                defaults: new { controller = "User", action = "getCustomers" }
            );

            //returns pets
            routes.MapRoute(
                name: "UserPets",
                url: "user/pets/{ownerId}",
                defaults: new { controller = "User", action = "Pets" }
            );

            //returns user
            routes.MapRoute(
                name: "Users",
                url: "users",
                defaults: new { controller = "User", action = "getUser" }
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

            routes.MapRoute(
                name: "TipsAdd",
                url: "tips/add",
                defaults: new { controller = "Tip", action = "AddTips" }
            );


            routes.MapRoute(
                name: "TipsDelete",
                url: "tips/delete",
                defaults: new { controller = "Tip", action = "DeleteTip" }
            ); 

            //---------------------- VET CONTROLLER ------------------------//

            //veterinaries

            routes.MapRoute(
                name: "Veterinaries",
                url: "vets",
                defaults: new {controller = "Vet", action = "Veterinaries"}
            );

            //vets 

            routes.MapRoute(
                name: "Vets",
                url: "vet/{vetId}",
                defaults: new {controller = "Vet", action = "Vets"}
            );

            //------------------ APPOINTMENT CONTROLLER ------------------//

            //appointments (petsid if needed)
            routes.MapRoute(
                name: "PetsAppointment",
                url: "pets/appointments/{petId}",
                defaults: new { controller = "Appointment", action = "Appointments" }
            );

            routes.MapRoute(
                name: "AppointmentAdd",
                url: "appointments/add",
                defaults: new { controller = "Appointment", action = "AddAppointments" }
            );
            //------------------ VETERINARIES CONTROLLER -----------------------//
            routes.MapRoute(
                name: "VeterinariesGet",
                url: "veterinaries",
                defaults: new { controller = "Veterinary", action = "veterinaries" }
            );

            //------------------------ DOCUMENTTYPE CONTROLLER -------------------------//
            routes.MapRoute(
                name: "DocumentTypeGet",
                url: "documenttype",
                defaults: new { controller = "DocumentType", action = "DocumentType" }
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
