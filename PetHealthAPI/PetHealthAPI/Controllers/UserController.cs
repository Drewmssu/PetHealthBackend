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
            var msg = "Username Already taken";
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
                msg = "Done!";
                //TODO: Verify if is a user, vet or veterinary who is registering
            }
            return Json(new { message = msg, user = newUser}, JsonRequestBehavior.AllowGet);            
        }
    }
}