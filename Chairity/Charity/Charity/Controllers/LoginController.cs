using Charity_Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Charity.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DoLogin(Member model)
        {
            using (var _Entity = new CharityEntities())
            {
                var obj = _Entity.Members.Where(x => x.Email == model.Email && 
                                                x.Password == model.Password).FirstOrDefault();
                if (obj == null)
                {
                    return Json("false", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    Session["_MemeberId"] = obj.MemeberId;
                    Session["_FullName"] = obj.Name;
                    return Json("true", JsonRequestBehavior.AllowGet);
                }
            }
        }

        [HttpPost]
        public JsonResult LogOut()
        {
            Session["_MemeberId"] = null;
            Session["_FullName"] = null;

            return Json("true", JsonRequestBehavior.AllowGet);
        }
    }
}