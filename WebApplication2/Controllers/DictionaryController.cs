using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Data_Structure_HW.Controllers
{
    public class DictionaryController : Controller
    {

        static Dictionary<int, string> myDictionary = new Dictionary<int, string>();
        // GET: Dictionary
        public ActionResult Index()
        {
            ViewBag.MyDictionary = myDictionary.Values;
            return View();
        }
        // Method for the Add One button
        public ActionResult Add()
        {
            myDictionary.Add((myDictionary.Count + 1), ("New Entry " + (myDictionary.Count + 1)));
            ViewBag.MyDictionary = myDictionary.Values;
            return View("Index");
        }
        public ActionResult HugeList()
        {
            myDictionary.Clear();
            do
            {
                myDictionary.Add((myDictionary.Count + 1), ("New Entry " + (myDictionary.Count + 1)));
            }
            while (myDictionary.Count < 2000);
            ViewBag.MyDictionary = myDictionary.Values;
            return View("Index");

        }
        public ActionResult Display()
        {
            ViewBag.MyDictionary = myDictionary.Values;
            return View("Index");

        }
        public ActionResult Delete()
        {

            if (myDictionary.Count > 0)
            {
                myDictionary.Remove(myDictionary.Count);
            }
            else
            {
                ViewBag.Message = "There are no elements to delete";
            }

            ViewBag.myDictionary = myDictionary.Values;
            return View("Index");

        }
        public ActionResult Clear()
        {
            myDictionary.Clear();
            ViewBag.MyDictionary = myDictionary.Values;
            return View("Index");
        }
        public ActionResult Search()
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            sw.Start();

            //loop to do all the work
            if (myDictionary.ContainsKey(2))
            {
                ViewBag.Message = "New Entry 2 was found";
            }
            else
            {
                ViewBag.Message = "New Entry 2 was not found";
            }

            sw.Stop();

            TimeSpan ts = sw.Elapsed;
            ViewBag.Message += "<br> The time it took is: " + ts;
            //ViewBag.StopWatch = ts;
            ViewBag.myDictionary = myDictionary.Values;
            return View("Index");

        }
        public ActionResult GoHome()
        {

            return RedirectToAction("Index", "Home");

        }
    }
}