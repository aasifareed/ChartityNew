using Charity_Admin.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Charity_Admin.Controllers
{
    public class MembersController : Controller
    {
        CharityEntities _Entity = new CharityEntities();
        // GET: Members
        public ActionResult Index()
        {
            return View();
        }
        public virtual JsonResult GetMemebers()
        {

            var lst = _Entity.Members.ToList();
            GridDataSource gobj = new GridDataSource
            {
                data = lst.ToList(),
                length = lst.Count
            };
            return Json(gobj, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult MemberDelete(int Id)
        {
            try
            {
                using (var _Entity = new CharityEntities())
                {
                    var _User = _Entity.Members.Where(x => x.MemeberId == Id).FirstOrDefault();

                    _Entity.Entry(_User).State = EntityState.Deleted;
                    _Entity.SaveChanges();
                    return Json("true", JsonRequestBehavior.AllowGet);
                }

            }
            catch
            {
                return Json("false", JsonRequestBehavior.AllowGet);
            }
        }
    }
}