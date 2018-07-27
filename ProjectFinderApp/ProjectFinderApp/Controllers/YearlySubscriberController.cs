using Microsoft.AspNet.Identity;
using ProjectFinderApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ProjectFinderApp.Controllers
{
    public class YearlySubscriberController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: YearlySubscribers
        public ActionResult Index()
        {
            return View(db.YearlySubscribers.ToList());
        }

        // GET:YearlySubscribers/Details/5
        public ActionResult Details(int? id)
        {
            var currentUserId = User.Identity.GetUserId();
            if (currentUserId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YearlySubscriber yearlySubscriber = db.YearlySubscribers.Where(r => r.ApplicationUserID == currentUserId).FirstOrDefault();
            if (yearlySubscriber == null)
            {
                return HttpNotFound();
            }
            return View(yearlySubscriber);
        }

        // GET: YearlySubscribers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: YearlySubscribers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Email,ApplicationUserId")] YearlySubscriber yearlySubscriber)
        {
            var currentUserId = User.Identity.GetUserId();
            yearlySubscriber.ApplicationUserID = currentUserId;
            if (ModelState.IsValid)
            {
                yearlySubscriber.SubscriptionActive = true;
                yearlySubscriber.SubscriptionStartDate = DateTime.Now;
                yearlySubscriber.SubscriptionEndDate = yearlySubscriber.SubscriptionStartDate.AddDays(365);
                db.YearlySubscribers.Add(yearlySubscriber);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View(yearlySubscriber);
        }

        // GET: YearlySubscribers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YearlySubscriber yearlySubscriber = db.YearlySubscribers.Find(id);
            if (yearlySubscriber == null)
            {
                return HttpNotFound();
            }
            return View(yearlySubscriber);
        }

        // POST: YearlySubscribers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Email,ApplicationUserID")] YearlySubscriber yearlySubscriber)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yearlySubscriber).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details");
            }
            return View(yearlySubscriber);
        }

        // GET: YearlySubscribers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YearlySubscriber yearlySubscriber = db.YearlySubscribers.Find(id);
            if (yearlySubscriber == null)
            {
                return HttpNotFound();
            }
            return View(yearlySubscriber);
        }

        // POST: YearlySubscribers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            YearlySubscriber yearlySubscriber = db.YearlySubscribers.Find(id);
            db.YearlySubscribers.Remove(yearlySubscriber);
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