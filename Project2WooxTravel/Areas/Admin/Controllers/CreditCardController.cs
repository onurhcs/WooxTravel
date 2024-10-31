using Project2WooxTravel.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Project2WooxTravel.Areas.Admin.Controllers
{
    public class CreditCardController : Controller
    {
        // GET: Admin/CreditCard
        TravelContext context = new TravelContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddressAndPayment()
        {
            return View();
        }
    }
}