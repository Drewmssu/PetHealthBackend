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
using PetHealthAPI.JsonObjects;

namespace PetHealthAPI.Controllers
{
    [RoutePrefix("user")]
    public class UserController : BaseController
    {
        //admin1 1234
        [HttpPost]
        public JsonResult LogIn(String username, String password)
        {
            var st = "password or username error";
            var userLog = new Object();
            var lstUser = context.User.Select(c => new {
                userId = c.UserId,
                username = c.Username,
                mail = c.Mail,
                photo = c.Photo,
                bio = c.Bio,
                salt = c.Salt,
                password = c.Password
                }).ToList();
            var userAttempt = lstUser.FirstOrDefault(x => x.username == username);
            if (userAttempt != null)
            {
                var pss = Hmac.ComputeHMAC_SHA256_Password(password, userAttempt.salt);
                if (userAttempt.password == pss)
                {
                    st = "Success";
                    userLog = userAttempt;
                }
            }
            return Json(new { status = st, userLog = userLog}, JsonRequestBehavior.AllowGet);
            
        }
        [HttpPost]
        public JsonResult Register(RegisterUserJsonObject json)
        {
            var newUser = new User();
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
            return Json(new { status = msg, user = newUser}, JsonRequestBehavior.AllowGet);            
        }
        //TODO: Verify if is a user, vet or veterinary who is registering
        private static void InitPerson(RegisterPersonJsonObject json, Person newPerson)
        {
            newPerson.PersonId = json.userId;
            newPerson.Name = json.name;
            newPerson.LastName = json.lastName;
            newPerson.TipoDocumentoId = json.tipodocumento;
            newPerson.NroDocumento = json.nrodocumento;
            newPerson.Adress = json.adress;
            newPerson.Phone = json.phone;
            newPerson.Birthdate = json.birthdate;
        }


        [HttpPost]
        public JsonResult RegisterCustomer(RegisterCustomerJsonObject json)
        {
            var newPerson = new Person();
            var newCustomer = new Customer();
            var msg = "error";
            if (context.User.Find(json.userId) != null) 
            {
                using(var trans = new TransactionScope())
                {
                    InitPerson(json, newPerson);
                    context.Person.Add(newPerson);
                    context.SaveChanges();
                    newCustomer.CustomerId = json.userId;
                    newCustomer.LastDateLogOn = DateTime.Now;
                    newCustomer.Rating = 0;
                    context.Customer.Add(newCustomer);
                    context.SaveChanges();
                    trans.Complete();
                }
                msg = "done";
            }
            return Json(new { status = msg, customer = json }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult RegisterVet(RegisterVetJsonObject json)
        {
            var newPerson = new Person();
            var newVet = new Vet();
            var msg = "error";
            if (context.User.Find(json.userId) != null)
            {   
                using (var trans = new TransactionScope()) 
                {
                    InitPerson(json, newPerson);
                    context.Person.Add(newPerson);
                    context.SaveChanges();
                    newVet.VetId = json.userId;
                    newVet.Linkedinlink = json.linkedinLink;
                    newVet.Degree = json.degree;
                    context.Vet.Add(newVet);
                    context.SaveChanges();
                    trans.Complete();
                }
                msg = "done";
            }
            return Json(new { status = msg, vet = json }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult RegisterVeterinary(RegisterVeterinaryJsonObject json)
        {
            var newVeterinary = new Veterinary();
            var msg = "error";
            if (context.User.Find(json.VeterinaryId) != null)
            {
                using(var trans=new TransactionScope())
                {
                    newVeterinary.VeterinaryId = json.VeterinaryId;
                    newVeterinary.Name = json.Name;
                    newVeterinary.PresentationVid = json.DescripVid;
                    newVeterinary.PhoneNumber = json.PhoneNumber;
                    newVeterinary.Latitude = json.Latitude;
                    newVeterinary.Longitude = json.Longitude;
                    newVeterinary.OpeningHours = json.OpeningHours;
                    newVeterinary.Rate = json.Rating;
                    context.Veterinary.Add(newVeterinary);
                    context.SaveChanges();
                    trans.Complete();
                }
                msg = "done";
            }
            return Json(new { status = msg, veterinary = json }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Pets(Int32? ownerId)
        {
            if (ownerId.HasValue)
            {
                return Json(new
                {
                    status = "ok",
                    content = PetJsonObject.from(context.Pet.Where(x => x.OwnerId == ownerId).ToList())
                },
                JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new
                {
                    status = "ok",
                    content = PetJsonObject.from(context.Pet.ToList())
                },
            JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult getUser()
        {
            var res = context.User.Select(x => new
            {
                id = x.UserId,
                username = x.Username
            });
            return Json(new { res=res }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getCustomers(Int32? customerId)
        {
            var res = context.Customer.Select(x => new
            {
                id = x.CustomerId,
                username = x.Person.User.Username,
                name = x.Person.Name,
                lastname = x.Person.LastName,
                phone = x.Person.Phone,
                address= x.Person.Adress,
                nrodocumento=x.Person.NroDocumento,
                TipoDocumento=x.Person.DocumentType.Name,
            });
            if (customerId.HasValue)
                res = res.Where(x => x.id == customerId);
            var resp = res.ToList();
            return Json(new { res=resp},JsonRequestBehavior.AllowGet);
        }
    }
}