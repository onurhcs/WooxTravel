using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project2WooxTravel.Context;
using Project2WooxTravel.Entities;

namespace Project2WooxTravel.Controllers
{
    public class DefaultController : Controller
    {
        TravelContext context = new TravelContext();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialHead()
        {
            return PartialView();
        }
        public PartialViewResult PartialScript()
        {
            return PartialView();
        }
        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }
        public PartialViewResult PartialBanner()
        {
            var values = context.Destinations.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialAbout()
        {
            var values = context.Destinations.ToList();
            return PartialView(values);
        }

        public PartialViewResult DestiDetail(int id)
        {
            var destination = context.Destinations.Find(id);
            return PartialView(destination);
        }
        public PartialViewResult PartialCountry()
        {
            var values = context.Destinations.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialReservation()
        {
            return PartialView();
        }
        public PartialViewResult PartialDeals()
        {
            var values = context.Destinations.ToList();
            return PartialView(values);
        }
        public PartialViewResult SearchForm()
        {
            // Şehir isimlerini veritabanından al ve tekrarlardan kaçın
            var destinations = context.Destinations
                                       .Select(d => d.City)
                                       .Distinct()
                                       .ToList();

            ViewBag.Destinations = destinations; // Veriyi ViewBag ile View'a gönder

            return PartialView();
        }
        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult CreateReservation(Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                context.Reservations.Add(reservation);
                context.SaveChanges();
                return RedirectToAction("ReservationList", "Reservation", "Admin");
            }
            return View(reservation);
        }

    }
}