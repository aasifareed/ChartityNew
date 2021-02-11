using Charity_Admin.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Charity_Admin.Controllers
{
    public class PagesController : Controller
    {
        // GET: Pages
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetPagesList()
        {
            using (var _Entity = new CharityEntities())
            {
                var lst = _Entity.Pages.ToList();
                GridDataSource gobj = new GridDataSource
                {
                    data = lst.ToList(),
                    length = lst.Count
                };
                return Json(gobj, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetPage(int PageId)
        {
            using (var _Entity = new CharityEntities())
            {
                var page = _Entity.Pages.Where(p => p.PageId == PageId).FirstOrDefault();
                PageModel obj = new PageModel();
                obj.PageId = page.PageId;
                obj.Content_Eng = page.Content_Eng;
                obj.Content_Tr = page.Content_Tr;
                obj.Content_Ar = page.Content_Ar;
                obj.PageName = page.Page1;
                return View(obj);
            }
        }
        [HttpPost]
        public JsonResult SaveChanges(PageModel model)
        {
            try
            {

                Page page = new Page();
                page.PageId = model.PageId;
                page.Page1 = model.PageName;
                page.Content_Eng = Server.HtmlDecode(model.Content_Eng);
                page.Content_Tr = Server.HtmlDecode(model.Content_Tr);
                page.Content_Ar = Server.HtmlDecode(model.Content_Ar);
                using (var _Entity = new CharityEntities())
                {
                    _Entity.Entry(page).State = EntityState.Modified;
                    _Entity.SaveChanges();
                    return Json("true", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("false", JsonRequestBehavior.AllowGet);
            }
        }
    }
}