using PetHealthAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetHealthAPI.Controllers
{
    public class BaseController : Controller
    {
        public PetHealthEntities context;
        // GET: Base
        public BaseController()
        {
            context = new PetHealthEntities();
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}