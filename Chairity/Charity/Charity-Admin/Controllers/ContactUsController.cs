using Charity_Admin.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Charity_Admin.Controllers
{
    public class ContactUsController : Controller
    {
        CharityEntities _Entity = new CharityEntities();
        // GET: ContactUs
        public ActionResult Index()
        {
            return View();
        }

        public virtual JsonResult GetContactUsList()
        {

            var lst = _Entity.ContactUs.ToList();
            GridDataSource gobj = new GridDataSource
            {
                data = lst.OrderByDescending(x => x.Id).ToList(),
                length = lst.Count
            };
            return Json(gobj, JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        public ActionResult GetContactUs(int Id)
        {
            try
            {
                ContactU model = new ContactU();
                model = _Entity.ContactUs.Where(x => x.Id == Id).SingleOrDefault();
                return PartialView("GetContactUs", model);
            }
            catch (Exception e)
            {
                return Json(e.Message.ToString(), JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult ContactUsDelete(int Id)
        {
            try
            {
                using (var _Entity = new CharityEntities())
                {
                    var _User = _Entity.ContactUs.Where(x => x.Id == Id).FirstOrDefault();

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