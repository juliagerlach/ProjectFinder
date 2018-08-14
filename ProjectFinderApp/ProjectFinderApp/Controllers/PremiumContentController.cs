using Microsoft.AspNet.Identity;
using ProjectFinderApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Hosting;
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
            return View(db.PremiumContents.ToList());
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

        // POST: PremiumContent/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContentID,ProjectTitle,Technique,Supplies,FilePath1,FilePath2,FileName,ContactInfo,ApplicationUserID")] HttpPostedFileBase file1, HttpPostedFileBase file2, PremiumContent premiumContent, Subscriber subscriber)
        {
            var currentUserId = User.Identity.GetUserId();
            
            string FilePath1 = Path.Combine(Server.MapPath("~/UploadedFiles/"), Path.GetFileName(file1.FileName));
            string FilePath2 = Path.Combine(Server.MapPath("~/UploadedFiles/"), Path.GetFileName(file2.FileName));
            string PDFName = Path.GetFileName(file2.FileName);

            if (ModelState.IsValid)
            {
                
                file1.SaveAs(FilePath1);
                premiumContent.FilePath1 = "/../UploadedFiles/" + file1.FileName;
                
                file2.SaveAs(FilePath2);
                premiumContent.FilePath2 = "/../UploadedFiles/" + file2.FileName;
                ViewBag.Message = "File Uploaded Successfully!";

                premiumContent.FileName = PDFName;
                subscriber.ApplicationUserID = currentUserId;

                db.PremiumContents.Add(premiumContent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "File Upload Failed!";
            }
            return RedirectToAction("Index");
        }
        

        // GET: Comments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PremiumContent premiumContent = db.PremiumContents.Find(id);
            if (premiumContent == null)
            {
                return HttpNotFound();
            }
            return View(premiumContent);
        }
        public ActionResult Download(int id)
        {
            PremiumContent premiumContent = db.PremiumContents.Find(id);
            var dir = new System.IO.DirectoryInfo(Server.MapPath("~/UploadedFiles/"));
            System.IO.FileInfo[] fileNames = dir.GetFiles("*.*");
            List<string> items = new List<string>();
            string file = premiumContent.FileName;

                        
            //var FileVirtualPath = "~/UploadedFiles/" + file;
            ////string file = premiumContent.FilePath2;

            if (!System.IO.File.Exists(file))
            {
                return HttpNotFound();
            }

            var fileBytes = System.IO.File.ReadAllBytes(file);
            var response = new FileContentResult(fileBytes, "application/octet-stream")
            {
                FileDownloadName = premiumContent.FileName
            };
            return response;
        }

        //public ActionResult Downloads()
        //{
        //    var dir = new System.IO.DirectoryInfo(Server.MapPath("~/UploadedFiles/"));
        //    System.IO.FileInfo[] fileNames = dir.GetFiles("*.*"); 
        //    List<string> items = new List<string>();
        //    foreach (var file in fileNames)
        //    {
        //        items.Add(file.Name);
        //    }
        //    return View(items);
        //}
        //public FileResult Download(string FileName)
        //{
        //    var FileVirtualPath = "~/UploadedFiles/" + FileName;
        //    return File(FileVirtualPath, "application/forcedownload", Path.GetFileName(FileVirtualPath));
        //}


    }
}