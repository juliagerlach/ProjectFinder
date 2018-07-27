using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectFinderApp.Models;

namespace ProjectFinderApp.Controllers
{
    public class ProjectController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Project
        public ActionResult Index(string  searchString)
        {
            var projects = from p in db.Projects select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                projects = projects.Where(p => p.ProjectTitle.Contains(searchString) || p.ProjectDesigner.Contains(searchString) || p.Supplies.Contains(searchString) || p.Technique.Contains(searchString));
            }
            return View(projects.ToList());
        }

        // GET: Project/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // GET: Project/Create
        public ActionResult Create()
        {
            ViewBag.IssueID = new SelectList(db.Issues, "IssueID", "IssueMonth");
            ViewBag.MagazineID = new SelectList(db.Magazines, "MagazineID", "MagazineTitle");
            return View();
        }

        // POST: Project/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProjectID,ProjectTitle,ProjectDesigner,MagazineID,IssueID,PageNumber,Technique,Supplies,PublisherLink,OnlineLink,FilePath")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Projects.Add(project);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IssueID = new SelectList(db.Issues, "IssueID", "IssueMonth", project.IssueID);
            ViewBag.MagazineID = new SelectList(db.Magazines, "MagazineID", "MagazineTitle", project.MagazineID);
            return View(project);
        }

        // GET: Project/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            ViewBag.IssueID = new SelectList(db.Issues, "IssueID", "IssueMonth", project.IssueID);
            ViewBag.MagazineID = new SelectList(db.Magazines, "MagazineID", "MagazineTitle", project.MagazineID);
            return View(project);
        }

        // POST: Project/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProjectID,ProjectTitle,ProjectDesigner,MagazineID,IssueID,PageNumber,Technique,Supplies,PublisherLink,OnlineLink,FilePath")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IssueID = new SelectList(db.Issues, "IssueID", "IssueMonth", project.IssueID);
            ViewBag.MagazineID = new SelectList(db.Magazines, "MagazineID", "MagazineTitle", project.MagazineID);
            return View(project);
        }

        // GET: Project/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Project/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Project project = db.Projects.Find(id);
            db.Projects.Remove(project);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
