using Charity_Admin.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Charity.Controllers
{
    public class ContactController : Controller
    {
        CharityEntities _Entity = new CharityEntities();
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Res()
        {
            return View();
        }
        public ActionResult SaveContactUs(ContactU model)
        {
            try
            {

                ModelState.Clear();
                model.CreatedOn = DateTime.Now;
                _Entity.Entry(model).State = EntityState.Added;
                _Entity.SaveChanges();
                Session["_c"] =  "true";
                return View("Res");
            }
            catch (Exception ex)
            {
                Session["_c"] = "false";
                return View("Res");
            }
        }
    }
}