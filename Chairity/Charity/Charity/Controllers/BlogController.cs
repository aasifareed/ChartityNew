using Charity_Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Charity.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult Index()
        {
            using (var _Entity = new CharityEntities())
            {
                var lst = _Entity.Blogs.ToList();
                return View(lst);
            }
            
        }

        public ActionResult More(int Id)
        {
            using (var _Entity = new CharityEntities())
            {
                var blog = _Entity.Blogs.Where(x => x.Id == Id).FirstOrDefault();
                return View(blog);
            }
        }
    }
}