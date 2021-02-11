using Charity_Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Charity.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult Index()
        {
            using (var _Entity = new CharityEntities())
            {
                var lst = _Entity.News.ToList();
                return View(lst);
            }
        }
        public ActionResult More(int Id)
        {
            using (var _Entity = new CharityEntities())
            {
                var news = _Entity.News.Where(x => x.Id == Id).FirstOrDefault();
                return View(news);
            }
        }
    }
}