using Charity_Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Charity.Controllers
{
    public class PageController : Controller
    {
        // GET: Page
        public ActionResult GetPage(string pageName)
        {
            using (var _Entity = new CharityEntities())
            {
                var lst = _Entity.Pages.Where(x => x.Page1 == pageName).FirstOrDefault();
                return PartialView("LoadPage", lst);
            }
        }
    }
}