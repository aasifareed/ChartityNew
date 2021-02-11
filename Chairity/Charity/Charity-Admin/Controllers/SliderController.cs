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
    public class SliderController : Controller
    {
        CharityEntities _Entity = new CharityEntities();
        // GET: Slider
        public ActionResult Index()
        {
            return View();
        }

        public virtual JsonResult GetSliderImages()
        {

            var lst = _Entity.Sliders.ToList();
            GridDataSource gobj = new GridDataSource
            {
                data = lst.OrderByDescending(x => x.Id).ToList(),
                length = lst.Count
            };
            return Json(gobj, JsonRequestBehavior.AllowGet);
            
        }
        [HttpPost]
        public ActionResult AddUpdateSlider(Slider model, HttpPostedFileBase file)
        {

            ModelState.Clear();
            model.Isactive = true;
            model.ImagePath = SaveFile(file, "Images/Sliders", "Slider_" + Guid.NewGuid().ToString());
            _Entity.Entry(model).State = (model.Id == 0 ? EntityState.Added : EntityState.Modified);
            _Entity.SaveChanges();
            return View("Index");
        }
        [HttpPost]
        public JsonResult SliderDelete(int Id)
        {
            try
            {
                using (var _Entity = new CharityEntities())
                {
                    var _User = _Entity.Sliders.Where(x => x.Id == Id).FirstOrDefault();

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