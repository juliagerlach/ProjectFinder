﻿using Microsoft.AspNet.Identity;
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
    public class RegisteredUserController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: RegisteredUsers
        public ActionResult Index()
        {
            return View(db.RegisteredUsers.ToList());
        }

        // GET: RegisteredUsers/Details/5
        public ActionResult Details(int? id)
        {
            var currentUserId = User.Identity.GetUserId();
            if (currentUserId == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            RegisteredUser registeredUser = db.RegisteredUsers.Where(r => r.ApplicationUserID == currentUserId).FirstOrDefault();
            if (registeredUser == null)
                {
                    return HttpNotFound();
                }
            else if (registeredUser != null)
                {
                    DateTime accessEnd = registeredUser.AccessEndDate;
                    var accessDays = accessEnd - DateTime.Now;

                    if (accessDays.Days < 3)
                        {
                            return RedirectToAction("LapseNotification");
                                //ViewBag.Message = "Your 30-day trial ends soon. Subscribe now for continued access to The Bead Project Finder.";
                        }
                }

            return View(registeredUser);
        }

        // GET: RegisteredUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegisteredUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Email,ApplicationUserId")] RegisteredUser registeredUser)
        {
            var currentUserId = User.Identity.GetUserId();
            registeredUser.ApplicationUserID = currentUserId;
            
            if (ModelState.IsValid)
            {
                registeredUser.AccessType = "registered user";
                registeredUser.AccessActive = true;
                registeredUser.AccessStartDate = DateTime.Now;
                registeredUser.AccessEndDate = registeredUser.AccessStartDate.AddDays(30);
                db.RegisteredUsers.Add(registeredUser);
                db.SaveChanges();
                return RedirectToAction("Details");
            }

            return View();
        }

        // GET: RegisteredUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisteredUser registeredUser = db.RegisteredUsers.Find(id);
            if (registeredUser == null)
            {
                return HttpNotFound();
            }
            return View(registeredUser);
        }

        // POST: RegisteredUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Email,ApplicationUserID")] RegisteredUser registeredUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registeredUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details");
            }
            return View(registeredUser);
        }

        // GET: RegisteredUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisteredUser registeredUser = db.RegisteredUsers.Find(id);
            if (registeredUser == null)
            {
                return HttpNotFound();
            }
            return View(registeredUser);
        }

        // POST: RegisteredUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RegisteredUser registeredUser = db.RegisteredUsers.Find(id);
            db.RegisteredUsers.Remove(registeredUser);
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

        public ActionResult LapseNotification()
        { 
             //if (User.IsInRole("Registered User"))
             //   {
             //       var currentUserId = User.Identity.GetUserId();
             //       var registeredUser = db.RegisteredUsers.Where(r => r.ApplicationUserID == currentUserId).FirstOrDefault();

             //       if (registeredUser != null)
             //       {
             //           DateTime accessEnd = registeredUser.AccessEndDate;
             //           var accessDays = accessEnd - DateTime.Now;

             //           if (accessDays.Days< 3)
             //           {
             //               ViewBag.Message = "Your 30-day trial ends soon. Subscribe now for continued access to The Bead Project Finder.";
             //           }
             //       }
             //   }
                return View();
            }

        // GET: RegisteredUsers/UpgradeSub
        //public ActionResult UpgradeSub()
        //{
        //    return View();
        //}

        //// POST: RegisteredUsers/UpgradeSub
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult UpgradeSub([Bind(Include = "ID,Name,StreetAddress,City,State,PostalCode,Email,ApplicationUserId,SubscriptionType")] RegisteredUser registeredUser)
        //{
        //    var currentUserId = User.Identity.GetUserId();
        //    registeredUser.ApplicationUserID = currentUserId;
        //    if (ModelState.IsValid)
        //    {

        //        if (registeredUser.AccessType == "monthly")
        //        {
        //            registeredUser.SubscriptionActive = true;
        //            registeredUser.SubscriptionStartDate = DateTime.Now;
        //            registeredUser.SubscriptionEndDate = subscriber.SubscriptionStartDate.AddDays(30);
        //            registeredUser.Payment = 2;
        //            db.Subscribers.Add(subscriber);
        //            db.SaveChanges();

        //            return RedirectToAction("Index1", "Subscriber");
        //        }

        //        else if (subscriber.SubscriptionType == "yearly")
        //        {
        //            subscriber.SubscriptionActive = true;
        //            subscriber.SubscriptionStartDate = DateTime.Now;
        //            subscriber.SubscriptionEndDate = subscriber.SubscriptionStartDate.AddDays(365);
        //            subscriber.Payment = 10;
        //            db.Subscribers.Add(subscriber);
        //            db.SaveChanges();
        //            return RedirectToAction("Index", "Subscriber");
        //        }

        //    }

        //    return View();
        //}
    }
}