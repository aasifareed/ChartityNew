using Charity_Admin.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Charity.Controllers
{
    public class SignUpController : Controller
    {
        // GET: SignUp
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult SignUpNow(Member model)
        {
            using (var _Entity = new CharityEntities())
            {
                var obj = _Entity.Members.Where(x => x.Email == model.Email).FirstOrDefault();
                if (obj == null)
                {
                    model.CreatedOn = DateTime.Now;
                    _Entity.Entry(model).State = EntityState.Added;
                    _Entity.SaveChanges();
                    return Json("true", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("false", JsonRequestBehavior.AllowGet);
                }
            }
        }
    }
}