using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetHealthAPI.Controllers
{
    public class VeterinaryController : Controller
    {
        // GET: Veterinary
        public ActionResult Index()
        {
            return View();
        }
    }
}