﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Bikes_MS_.Models;

namespace Bikes_MS_.Controllers
{
    public class HomeController : Controller
    {
        Bike_context db = new Bike_context();


        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Shop()
        {
            IEnumerable<Bike> bikes = db.Bikes;
            ViewBag.Bikes = bikes;
            return View();
        }

        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.Id = id;
            return View();
        }
        [HttpPost]
        public JavaScriptResult Buy(Purchase purchase)
        {
            var mess = $@"alert('Пане(і) " + purchase.Person + ", дякуємо за покупку!');";
            purchase.data = DateTime.Now;

            db.Purchases.Add(purchase);

            db.SaveChanges();
            return JavaScript(mess);
            //return "Пане(і) " + purchase.Person + ", дякуємо за покупку!";
        }


    }
}