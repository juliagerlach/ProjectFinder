using ProjectFinderApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectFinderApp.Controllers
{
    public class PremiumContentController : Controller
        
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: PremiumContent
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(PremiumContent Content, HttpPostedFileBase File1, HttpPostedFileBase File2)
        {
            if (File1 != null && File1.ContentLength > 0 && File2 != null)
            {
                Content.Image = new byte[File1.ContentLength];
                File1.InputStream.Read(Content.Image, 0, File1.ContentLength);
                string ImageName = System.IO.Path.GetFileName(File2.FileName);
                string physicalPath = Server.MapPath("~/img/" + ImageName);

                File2.SaveAs(physicalPath);
                Content.FilePath = "img/" + ImageName;
                db.PremiumContents.Add(Content);
                db.SaveChanges();
                return PartialView("detail");
            }
            if (File1 != null && File1.ContentLength > 0 && File2 == null)
            {
                Content.Image = new byte[File1.ContentLength];
                File1.InputStream.Read(Content.Image, 0, File1.ContentLength);
                db.PremiumContents.Add(Content);
                db.SaveChanges();
                return PartialView("detail");
            }
            if (File1 == null && File2 != null)
            {
                string ImageName = System.IO.Path.GetFileName(File2.FileName);
                string physicalPath = Server.MapPath("~/img/" + ImageName);
                File2.SaveAs(physicalPath);
                Content.FilePath = "img/" + ImageName;
                db.PremiumContents.Add(Content);
                db.SaveChanges();
                return PartialView("detail");
            }
            else
            {
                db.PremiumContents.Add(Content);
                db.SaveChanges();
                return PartialView("detail");
            }
        }
    } 
}