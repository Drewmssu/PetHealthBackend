using PetHealthAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetHealthAPI.Controllers
{
    [RoutePrefix("tip")]
    public class TipController : BaseController
    {
        public JsonResult tips()
        {
            var sts = "ok";
            var LstTips = context.Tip.Where(c=>c.Status=="ACT").Select(c=>new {
                TipId=c.TipId,
                OwnerId=c.OwnerId,
                Content=c.Content,
                Image=c.Image 
                }).ToList();
            if (LstTips.Count == 0) sts = "error";
            return Json(new { status=sts, tips=LstTips}, JsonRequestBehavior.AllowGet);
        }
        
    }
}