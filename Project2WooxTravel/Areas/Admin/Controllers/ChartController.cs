using Project2WooxTravel.Context;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Project2WooxTravel.Areas.Admin.Controllers
{
    public class ChartController : Controller
    {
        TravelContext context = new TravelContext();

        // GET: Admin/Chart
        public ActionResult Index()
        {
            ViewBag.ReservationsName = context.Reservations.OrderByDescending(x => x.ReservationId).Take(20).Select(x => x.Name).ToList(); //grafik 1
            ViewBag.ReservationPerson = context.Reservations.OrderByDescending(x => x.ReservationId).Take(20).Select(x => x.PersonCount).ToList(); //grafik1
            ViewBag.TurSayısıAdı = context.Destinations.Select(x => x.Title).ToList();//grafik2

            ViewBag.TurKapasitesi = context.Destinations.Select(x => x.Capacity).ToList();//grafik2
            ViewBag.TurFiyatı = context.Destinations.Select(x => x.Price).ToList();//grafik3
            ViewBag.TopResName = context.Reservations.OrderByDescending(x => x.PersonCount).Select(x => x.Name).Take(10).ToList();//grafik3
            ViewBag.TopResPerson = context.Reservations.OrderByDescending(x => x.PersonCount).Select(x => x.PersonCount).Take(10).ToList();//grafik4
            return View();
        }
    }
}