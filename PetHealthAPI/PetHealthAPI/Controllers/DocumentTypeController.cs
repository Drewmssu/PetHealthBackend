using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetHealthAPI.Controllers
{
    public class DocumentTypeController : BaseController
    {
        // GET: DocumentType
        public JsonResult DocumentType()
        {
            var lst = context.DocumentType.Where(x=>x.Status=="ACT").Select(x => new
            {
                id = x.DocumentTypeId,
                abreviation = x.Abreviation,
                name = x.Name
            }).ToList();
            return Json(new {status="ok", documents=lst }, JsonRequestBehavior.AllowGet);
        }
    }
}