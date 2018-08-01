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
    [Authorize(Roles = "Admin,RegisteredUser,Subscriber")]
    public class ProjectController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Project
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.TitleSortParm = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewBag.DesignerSortParm = sortOrder == "Designer" ? "designer_desc" : "Designer";
            ViewBag.TechniqueSortParm = sortOrder == "Supplies" ? "supplies_desc" : "Supplies";
            ViewBag.TechniqueSortParm = sortOrder == "Technique" ? "technique_desc" : "Technique";

            var projects = from p in db.Projects select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                projects = projects.Where(p => p.ProjectTitle.Contains(searchString) || p.ProjectDesigner.Contains(searchString) || p.Supplies.Contains(searchString) || p.Technique.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "title_desc":
                    projects = projects.OrderByDescending(p => p.ProjectTitle);
                    break;
                case "Designer":
                    projects = projects.OrderBy(p => p.ProjectDesigner);
                    break;
                case "designer_desc":
                    projects = projects.OrderByDescending(p => p.ProjectDesigner);
                    break;
                case "Supplies":
                    projects = projects.OrderBy(p => p.Supplies);
                    break;
                case "supplies_desc":
                    projects = projects.OrderByDescending(p => p.Supplies);
                    break;
                case "Technique":
                    projects = projects.OrderBy(p => p.Technique);
                    break;
                case "technique_desc":
                    projects = projects.OrderByDescending(p => p.Technique);
                    break;
                default:
                    projects = projects.OrderBy(p => p.ProjectTitle);
                    break;

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
