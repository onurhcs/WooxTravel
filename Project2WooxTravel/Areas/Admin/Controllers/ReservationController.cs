using Project2WooxTravel.Context;
using Project2WooxTravel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project2WooxTravel.Areas.Admin.Controllers
{
    public class ReservationController : Controller
    {
        TravelContext context = new TravelContext();

        // GET: Admin/Reservation
        public ActionResult ReservationList()
        {
            var values = context.Reservations.ToList();
            return View(values);
        }
        public ActionResult CreateReservation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateReservation(Reservation reservation)
        {
            context.Reservations.Add(reservation); 
            context.SaveChanges();
            return RedirectToAction("ReservationList", "Reservation", "Admin");
        }
        public ActionResult DeleteReservation(int id)
        {
            var value = context.Reservations.Find(id);
            context.Reservations.Remove(value);
            context.SaveChanges();
            return RedirectToAction("ReservationList", "Reservation", "Admin");
        }
        [HttpGet]
        public ActionResult UpdateReservation(int id)
        {
            var value = context.Reservations.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateReservation(Reservation reservation)
        {
            var value = context.Reservations.Find(reservation.ReservationId);
            value.Description=reservation.Description;
            value.Name = reservation.Name;
            value.Phone = reservation.Phone;
            value.PersonCount = reservation.PersonCount;
            context.SaveChanges();
            return RedirectToAction("ReservationList", "Reservation", "Admin");
        }
    }
}