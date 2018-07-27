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
    public class MonthlySubscriberController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: MonthlySubscribers
        public ActionResult Index()
        {
            return View(db.MonthlySubscribers.ToList());
        }

        // GET:MonthlySubscribers/Details/5
        public ActionResult Details(int? id)
        {
            var currentUserId = User.Identity.GetUserId();
            if (currentUserId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonthlySubscriber subscriber = db.MonthlySubscribers.Where(r => r.ApplicationUserID == currentUserId).FirstOrDefault();
            if (subscriber == null)
            {
                return HttpNotFound();
            }
            return View(subscriber);
        }

        // GET: MonthlySubscribers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MonthlySubscribers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Email,ApplicationUserId")] MonthlySubscriber subscriber)
        {
            var currentUserId = User.Identity.GetUserId();
            subscriber.ApplicationUserID = currentUserId;
            if (ModelState.IsValid)
            {
                subscriber.SubscriptionActive = true;
                subscriber.SubscriptionStartDate = DateTime.Now;
                subscriber.SubscriptionEndDate = subscriber.SubscriptionStartDate.AddDays(30);
                db.MonthlySubscribers.Add(subscriber);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View(subscriber);
        }

        // GET: MonthlySubscribers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonthlySubscriber subscriber = db.MonthlySubscribers.Find(id);
            if (subscriber == null)
            {
                return HttpNotFound();
            }
            return View(subscriber);
        }

        // POST: MonthlySubscribers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Email,ApplicationUserID")] MonthlySubscriber subscriber)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subscriber).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details");
            }
            return View(subscriber);
        }

        // GET: MonthlySubscribers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonthlySubscriber subscriber = db.MonthlySubscribers.Find(id);
            if (subscriber == null)
            {
                return HttpNotFound();
            }
            return View(subscriber);
        }

        // POST: MonthlySubscribers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MonthlySubscriber subscriber = db.MonthlySubscribers.Find(id);
            db.MonthlySubscribers.Remove(subscriber);
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