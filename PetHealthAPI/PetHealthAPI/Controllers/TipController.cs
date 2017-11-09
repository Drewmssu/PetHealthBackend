using PetHealthAPI.JsonObjects;
using PetHealthAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;

namespace PetHealthAPI.Controllers
{
    public class TipController : BaseController
    {
        public JsonResult Tips()
        {
            var sts = "ok";
            var lstTips = context.Tip.Where(c=>c.Status=="ACT").Select(c => new {
                TipId = c.TipId,
                OwnerUsername = c.User.Username,
                Content = c.Content,
                Image = c.Image 
                }).ToList();
            if (lstTips.Count == 0) sts = "error";
            return Json(new { status=sts, content=lstTips}, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult AddTips(TipJsonObject json)
        {
            var sts = "ok";

            var tip = new Tip();
            if (json.TipId.HasValue)
            {
                tip = context.Tip.Find(json.TipId);
            }else
            {
                context.Tip.Add(tip);
            }
            using (var trans = new TransactionScope())
            {
                tip.Content = json.Content;
                tip.OwnerId = json.OwnerId;
                tip.Image = json.Image;
                tip.Status = "ACT";
                context.SaveChanges();
                trans.Complete();
            }
            return Json(new { status = sts, tip = json }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteTip(Int32 tipId)
        {
            var status = "ok";
            var tipmod = context.Tip.Find(tipId);
            if (tipmod != null)
            {
                using(var trans =new TransactionScope())
                {
                    tipmod.Status = "INA";
                    context.SaveChanges();
                    trans.Complete();
                }
            }
            return Json(new { status = status, tip = tipmod }, JsonRequestBehavior.AllowGet);
        }
        
    }
}