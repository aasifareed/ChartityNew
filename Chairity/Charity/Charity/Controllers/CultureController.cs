using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Charity.Controllers
{
    public class CultureController : Controller
    {
        public ActionResult ChangeCulture(string lng)
        {
            SessionManager.IsArabic = false;
            SessionManager.IsTurkish = false;

            if (lng == "Ar")
                SessionManager.IsArabic = true;

            if (lng == "Tr")
                SessionManager.IsTurkish = true;

            return Redirect(ControllerContext.HttpContext.Request.UrlReferrer.ToString());
        }
    }
}