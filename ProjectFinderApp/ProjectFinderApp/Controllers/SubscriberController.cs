using Microsoft.AspNet.Identity;
using ProjectFinderApp.Models;
using Stripe;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ProjectFinderApp.Controllers
{
    public class SubscriberController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public int Amount { get; private set; }

        
        // GET: Subscribers
        public ActionResult List()
        {
            return View(db.Subscribers.ToList());
        }

        // GET:Subscribers/Details/5
        public ActionResult Details(int? id)
        {
            var currentUserId = User.Identity.GetUserId();
            if (currentUserId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscriber subscriber = db.Subscribers.Where(r => r.ApplicationUserID == currentUserId).FirstOrDefault();
            if (subscriber == null)
            {
                return HttpNotFound();
            }
            return View(subscriber);
        }

        // GET: Subscribers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Subscribers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Email,ApplicationUserId")] Subscriber subscriber)
        {
            var currentUserId = User.Identity.GetUserId();
            subscriber.ApplicationUserID = currentUserId;
            if (ModelState.IsValid)
            {

                if (subscriber.SubscriptionType == "monthly")
                {
                    subscriber.SubscriptionActive = true;
                    subscriber.SubscriptionStartDate = DateTime.Now;
                    subscriber.SubscriptionEndDate = subscriber.SubscriptionStartDate.AddDays(30);
                    subscriber.Payment = 2;
                    db.Subscribers.Add(subscriber);
                    db.SaveChanges();

                    return RedirectToAction("Index", "Subscriber");
                }

                else if (subscriber.SubscriptionType == "yearly")
                {
                    subscriber.SubscriptionActive = true;
                    subscriber.SubscriptionStartDate = DateTime.Now;
                    subscriber.SubscriptionEndDate = subscriber.SubscriptionStartDate.AddDays(365);
                    subscriber.Payment = 10;
                    db.Subscribers.Add(subscriber);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Subscriber");
                }

            }

            return View();
        }

        public ActionResult Index()
        {
           

            var stripePublishKey = ConfigurationManager.AppSettings[ClientKeys.StripeApiPublishableKey];
            ViewBag.StripePublishKey = stripePublishKey;

            return View();
        }

        // GET: Subscribers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscriber subscriber = db.Subscribers.Find(id);
            if (subscriber == null)
            {
                return HttpNotFound();
            }
            return View(subscriber);
        }

        // POST: Subscribers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Email,ApplicationUserID")] Subscriber subscriber)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subscriber).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details");
            }
            return View(subscriber);
        }

        // GET: Subscribers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscriber subscriber = db.Subscribers.Find(id);
            if (subscriber == null)
            {
                return HttpNotFound();
            }
            return View(subscriber);
        }

        // POST: Subscribers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Subscriber subscriber = db.Subscribers.Find(id);
            db.Subscribers.Remove(subscriber);
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

        public ActionResult Charge(string stripeEmail, string stripeToken, Subscriber subscriber)
        {
            var customers = new StripeCustomerService();
            var charges = new StripeChargeService();

            var customer = customers.Create(new StripeCustomerCreateOptions
            {
                Email = stripeEmail,
                SourceToken = stripeToken
            });

            var charge = charges.Create(new StripeChargeCreateOptions
            {
                        Amount = subscriber.Payment,
                        Description = "Payment Amount",
                        Currency = "usd",
                        CustomerId = customer.Id
                    
            });

            return View();
        }

       

        public ActionResult Error()
        {
            return View();
        }
    }
}