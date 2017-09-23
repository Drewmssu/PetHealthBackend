using PetHealthAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Text;
using PetHealthAPI.Helpers;
using PetHealthAPI.Models;
using System.Web.Helpers;

namespace PetHealthAPI.Controllers
{
    public class UserController : BaseController
    {
        //admin1 1234
        [HttpPost]
        public JsonResult LogIn(String username, String password)
        {
            var st = "password or username error";
            var UserLog = new Object();
            var lstUser = context.User.Select(c => new {
                userId = c.UserId,
                username = c.Username,
                mail = c.Mail,
                photo = c.Photo,
                bio = c.Bio,
                salt = c.Salt,
                password = c.Password
                }).ToList();
            var UserAttempt = lstUser.FirstOrDefault(x => x.username == username);
            if (UserAttempt != null)
            {
                var pss = Hmac.ComputeHMAC_SHA256_Password(password, UserAttempt.salt);
                if (UserAttempt.password == pss)
                {
                    st = "Success";
                    UserLog = UserAttempt;
                }
            }
            return Json(new { message = st, userLog = UserLog}, JsonRequestBehavior.AllowGet);
            
        }
        [HttpPost]
        public JsonResult Register(RegisterViewModel json)
        {
            User newUser = new User();
            var msg = "error";
            if (context.User.FirstOrDefault(x => x.Username == json.username) == null)
            {
                using (var trans = new TransactionScope())
                {
                    var newSalt= Hmac.GenerateSalt();
                    newUser.Username = json.username;
                    newUser.Mail = json.mail;
                    newUser.Salt = newSalt;
                    newUser.Password = Hmac.ComputeHMAC_SHA256_Password(json.password, newSalt);
                    newUser.Status = "ACT";
                    newUser.Creation = DateTime.Now;
                    context.User.Add(newUser);
                    context.SaveChanges();
                    trans.Complete();
                }
                msg = "done";
            }
            return Json(new { message = msg, user = newUser}, JsonRequestBehavior.AllowGet);            
        }
        //TODO: Verify if is a user, vet or veterinary who is registering
        private static void InitPerson(RegisterPersonObject json, Person newPerson)
        {
            newPerson.PersonId = json.UserId;
            newPerson.Name = json.Name;
            newPerson.LastName = json.LastName;
            newPerson.DNI = json.DNI;
            newPerson.Adress = json.Adress;
            newPerson.Phone = json.Phone;
        }

        [HttpPost]
        public JsonResult RegisterCustomer(RegisterCustomerObject json)
        {
            Person newPerson = new Person();
            Customer newCustomer = new Customer();
            var msg = "error";
            if (context.User.Find(json.UserId) != null) 
            {
                using(var trans = new TransactionScope())
                {
                    InitPerson(json, newPerson);
                    context.Person.Add(newPerson);
                    context.SaveChanges();
                    newCustomer.CustomerId = json.UserId;
                    newCustomer.LastDateLogOn = DateTime.Now;
                    newCustomer.Rating = 0;
                    context.Customer.Add(newCustomer);
                    context.SaveChanges();
                    trans.Complete();
                }
                msg = "done";
            }
            return Json(new { message = msg, customer = newPerson }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult RegisterVet(RegisterVetObject json)
        {
            Person newPerson = new Person();
            Vet newVet = new Vet();
            var msg = "error";
            if (context.User.Find(json.UserId) != null)
            {
                using (var trans = new TransactionScope()) 
                {
                    InitPerson(json, newPerson);
                    context.Person.Add(newPerson);
                    context.SaveChanges();
                    newVet.VetId = json.UserId;
                    newVet.Linkedinlink = json.LinkedinLink;
                    newVet.Degree = json.Degree;
                    context.Vet.Add(newVet);
                    context.SaveChanges();
                    trans.Complete();
                }
                msg = "done";
            }
            return Json(new { message = msg, vet = newVet }, JsonRequestBehavior.AllowGet);
        }
    }
}