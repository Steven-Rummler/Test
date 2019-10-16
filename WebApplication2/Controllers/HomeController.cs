using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlowOut.Models;
using BlowOut.DAL;
using System.Web.Security;

namespace BlowOut.Controllers
{
    public class HomeController : Controller
    {
        private BlowOutContext db = new BlowOutContext();

        public static bool login = false;

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Rentals()
        {
            return View(db.Instruments.ToList());
        }

        [HttpGet]
        public ActionResult Create(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Client client, int id)
        {
            if (ModelState.IsValid)
            {
                db.Clients.Add(client);
                db.SaveChanges();

                Instrument instrument = db.Instruments.Find(id);
                instrument.ClientID = client.ClientID;
                db.SaveChanges();
                return RedirectToAction("Summary", new { ClientID = client.ClientID, InstrumentID = instrument.InstrumentID });
            }

            return View(client);
        }

        public ActionResult Summary(int ClientID, int InstrumentID)
        {
            Instrument instrument = db.Instruments.Find(InstrumentID);
            Client client = db.Clients.Find(ClientID);
            ViewBag.Instrument = instrument;
            ViewBag.Client = client;
            return View();
        }

        public ActionResult Selection()
        {
            return View();
        }

        public ActionResult Trumpet()
        {
            ViewBag.Image = "/Content/trumpet.jpg";
            ViewBag.usedCost = "$25";
            ViewBag.newCost = "$55";
            ViewBag.Name = "Trumpet";
            return View("Instrument");
        }

        public ActionResult Trombone()
        {
            ViewBag.Image = "/Content/trombone.jpg";
            ViewBag.usedCost = "$25";
            ViewBag.newCost = "$55";
            ViewBag.Name = "Trombone";
            return View("Instrument");
        }

        public ActionResult Tuba()
        {
            ViewBag.Image = "/Content/tuba.jpg";
            ViewBag.usedCost = "$25";
            ViewBag.newCost = "$55";
            ViewBag.Name = "Tuba";
            return View("Instrument");
        }

        public ActionResult Flute()
        {
            ViewBag.Image = "/Content/flute.jpg";
            ViewBag.usedCost = "$25";
            ViewBag.newCost = "$55";
            ViewBag.Name = "Flute";
            return View("Instrument");
        }

        public ActionResult Clarinet()
        {
            ViewBag.Image = "/Content/clarinet.jpg";
            ViewBag.usedCost = "$25";
            ViewBag.newCost = "$55";
            ViewBag.Name = "Clarinet";
            return View("Instrument");
        }

        public ActionResult Saxophone()
        {
            ViewBag.Image = "/Content/saxophone.png";
            ViewBag.usedCost = "$25";
            ViewBag.newCost = "$55";
            ViewBag.Name = "Saxophone";
            return View("Instrument");
        }

        public ActionResult Login()
        {
            if (login) { return RedirectToAction("UpdateData"); }
            ViewBag.Check = "Please enter your username and password.";
            return View();
        }

        [HttpPost]
        public ActionResult Login(string name, string pass)
        {
            if (name == "Missouri" && pass == "ShowMe")
            {
                login = true;
                return RedirectToAction("UpdateData");
            }
            ViewBag.Check = "The username or password was incorrect.";
            return View();
        }

        [HttpPost]
        public ActionResult AuthLogin(FormCollection form, bool rememberMe = false)
        {
            String email = form["Email Address"].ToString();
            String password = form["Password"].ToString();

            if (email == "greg@test.com" && password == "a")
            {
                FormsAuthentication.SetAuthCookie(email, rememberMe);
                return RedirectToAction("Index", "Home");
            }

            return View("Login");
        }

        public ActionResult UpdateData()
        {
            if (!login) { return RedirectToAction("Login"); }
            return View(db.Instruments.ToList());
        }

        public ActionResult Details(int id)
        {
            Instrument instrument = db.Instruments.Find(id);
            return View(instrument);
        }
    }
}