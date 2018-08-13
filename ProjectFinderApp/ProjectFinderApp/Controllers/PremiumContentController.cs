using ProjectFinderApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectFinderApp.Controllers
{
    [Authorize(Roles = "Admin,Subscriber")]
    public class PremiumContentController : Controller
        
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: PremiumContent
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult UploadFiles(IEnumerable<HttpPostedFileBase> files)
        //{
        //    foreach (var file in files)
        //    {
        //        string filePath = Guid.NewGuid() + Path.GetExtension(file.FileName);
        //        file.SaveAs(Path.Combine(Server.MapPath("~/UploadedFiles"), filePath));
        //        //write code here to save info to db
        //        //db.PremiumContents.Add(files);
        //        //db.SaveChanges();
        //        //return PartialView("detail");
        //    }
        //    return Json("file uploaded successfully");
        //}

        public ActionResult Create()
        {
            return View();
        }

        // POST: Project/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContentID,ProjectTitle,Technique,Supplies,FilePath1,FilePath2,ContactInfo")] HttpPostedFileBase file1, HttpPostedFileBase file2, PremiumContent premiumContent )
        {
            if (ModelState.IsValid)
            {
                if (file1 != null && file2 != null)
                {
                    string FilePath1 = Path.Combine(Server.MapPath("~/UploadedFiles"), Path.GetFileName(file1.FileName));
                    file1.SaveAs(FilePath1);
                    string FilePath2 = Path.Combine(Server.MapPath("~/UploadedFiles"), Path.GetFileName(file2.FileName));
                    file2.SaveAs(FilePath2);
                    ViewBag.Message = "File Uploaded Successfully!";
                }
                db.PremiumContents.Add(premiumContent);
                db.SaveChanges();
            }
            else
            {
                ViewBag.Message = "File Upload Failed!";
            }
            return View("Index");
        }
        //[HttpPost]
        //public ActionResult Create(PremiumContent Content, HttpPostedFileBase File1, HttpPostedFileBase File2)
        //{
        //    if (File1 != null && File1.ContentLength > 0 && File2 != null)
        //    {
        //        Content.Image = new byte[File1.ContentLength];
        //        File1.InputStream.Read(Content.Image, 0, File1.ContentLength);
        //        string ImageName = System.IO.Path.GetFileName(File2.FileName);
        //        string physicalPath = Server.MapPath("~/img/" + ImageName);

        //        File2.SaveAs(physicalPath);
        //        Content.FilePath = "img/" + ImageName;
        //        db.PremiumContents.Add(Content);
        //        db.SaveChanges();
        //        return PartialView("detail");
        //    }
        //    if (File1 != null && File1.ContentLength > 0 && File2 == null)
        //    {
        //        Content.Image = new byte[File1.ContentLength];
        //        File1.InputStream.Read(Content.Image, 0, File1.ContentLength);
        //        db.PremiumContents.Add(Content);
        //        db.SaveChanges();
        //        return PartialView("detail");
        //    }
        //    if (File1 == null && File2 != null)
        //    {
        //        string ImageName = System.IO.Path.GetFileName(File2.FileName);
        //        string physicalPath = Server.MapPath("~/img/" + ImageName);
        //        File2.SaveAs(physicalPath);
        //        Content.FilePath = "img/" + ImageName;
        //        db.PremiumContents.Add(Content);
        //        db.SaveChanges();
        //        return PartialView("detail");
        //    }
        //    else
        //    {
        //        db.PremiumContents.Add(Content);
        //        db.SaveChanges();
        //        return PartialView("detail");
        //    }
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ProjectTitle,Technique,Supplies,ContactInfo")]string file,HttpPostedFileBase upload)
        //{
        //    if (file != null)
        //    {

        //    }

        //}
        
        public ActionResult UploadFiles(IEnumerable<HttpPostedFileBase> files)
        {
            foreach (var file in files)
            {
                string filePath = Guid.NewGuid() + Path.GetExtension(file.FileName);
                file.SaveAs(Path.Combine(Server.MapPath("~/UploadedFiles"), filePath));
            }
            return Json("file uploaded successfully");
        }
        //[HttpPost]
        //public ActionResult AddImage(PremiumContent premiumContent)
        //{
        //    public string fileName = Path.GetFileNameWithoutExtension(ApplicationDbContext.PremiumContents.ImageFile.FileName);
        //    return View();
        //}
    } 
}