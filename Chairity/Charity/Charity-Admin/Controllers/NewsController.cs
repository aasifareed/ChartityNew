using Charity_Admin.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Charity_Admin.Controllers
{
    public class NewsController : Controller
    {
        CharityEntities _Entity = new CharityEntities();
        // GET: News
        public ActionResult Index()
        {
            return View();
        }

        public virtual JsonResult GetNewsList()
        {

            var lst = _Entity.News.ToList();
            GridDataSource gobj = new GridDataSource
            {
                data = lst.OrderByDescending(x => x.Id).ToList(),
                length = lst.Count
            };
            return Json(gobj, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public ActionResult AddUpdate(News model, HttpPostedFileBase file)
        {

            ModelState.Clear();
            if (model.Id == 0)
                model.CreatedOn = DateTime.Now;
            if (file != null)
                model.ImagePath = SaveFile(file, "Images/News", "News_" + Guid.NewGuid().ToString());

            _Entity.Entry(model).State = (model.Id == 0 ? EntityState.Added : EntityState.Modified);
            _Entity.SaveChanges();
            return View("Index");
        }
        [HttpGet]
        public ActionResult AddNewsEdit(int Id)
        {
            try
            {
                News model = new News();
                model = _Entity.News.Where(x => x.Id == Id).SingleOrDefault();
                if (model == null)
                {
                    model = new News();
                    model.IsDeleted = false;
                    model.CreatedOn = DateTime.Now;
                }

                return PartialView("AddNewsEdit", model);
            }
            catch (Exception e)
            {
                return Json(e.Message.ToString(), JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult NewsDelete(int Id)
        {
            try
            {
                using (var _Entity = new CharityEntities())
                {
                    var _User = _Entity.News.Where(x => x.Id == Id).FirstOrDefault();

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
        [HttpPost]
        public string SaveFile(HttpPostedFileBase file, string folderName, string FileName)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    var guid = Guid.NewGuid().ToString();
                    var extn = Path.GetExtension(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/" + folderName), FileName + "" + extn);
                    bool folderExists = Directory.Exists(Server.MapPath("~/" + folderName));
                    if (!folderExists)
                        Directory.CreateDirectory(Server.MapPath("~/" + folderName));
                    file.SaveAs(_path);
                    return "/" + folderName + "/" + FileName + "" + extn;
                }
            }
            catch (Exception e)
            {
                return null;
            }
            return null;
        }
    }

}