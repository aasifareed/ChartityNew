using Charity_Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Charity.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Sliders()
        {
            using (var _Entity = new CharityEntities())
            {
                var lst = _Entity.Sliders.ToList();
                return PartialView("Slider", lst);
            }
        }

        public ActionResult Footer()
        {
            using (var _Entity = new CharityEntities())
            {
                var lst = _Entity.Footers.Take(1).FirstOrDefault();
                if (lst != null)
                {
                    Session["_Email"] = lst.Email;
                    Session["_Phone"] = lst.Contact1;
                }
                return PartialView("Footer", lst);
            }
        }
    }
}