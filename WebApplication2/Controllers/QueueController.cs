using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Data_Structure_HW.Controllers
{
    public class QueueController : Controller
    {
        static Queue<string> myQueue = new Queue<string>();
        // GET: Queue
        public ActionResult Index()
        {
            ViewBag.MyQueue = myQueue;
            return View();
        }
        public ActionResult Add()
        {
            myQueue.Enqueue("New Entry " + (myQueue.Count + 1));
            ViewBag.MyQueue = myQueue;
            return View("Index");
        }
        public ActionResult HugeList()
        {
            myQueue.Clear();

            do
            {
                myQueue.Enqueue("New Entry " + (myQueue.Count + 1));
            }
            while (myQueue.Count < 2000);
            ViewBag.MyQueue = myQueue;

            return View("Index");

        }
        public ActionResult Display()
        {
            ViewBag.MyQueue = myQueue;
            return View("Index");

        }
        public ActionResult Delete()
        {
            if (myQueue.Count > 0)
            {
                myQueue.Dequeue();
            }
            else
            {
                ViewBag.Message = "There are no elements to delete";
            }

            ViewBag.myQueue = myQueue;
            return View("Index");

        }
        public ActionResult Clear()
        {
            myQueue.Clear();
            ViewBag.MyQueue = myQueue;
            return View("Index");
        }
        public ActionResult Search()
        {

            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            sw.Start();

            //loop to do all the work
            if (myQueue.Contains("New Entry 4"))
            {
                ViewBag.Message = "New Entry 4 was found";
            }
            else
            {
                ViewBag.Message = "New Entry 4 was not found";
            }

            sw.Stop();

            TimeSpan ts = sw.Elapsed;

            ViewBag.Message += "<br> The time it took is: " + ts;
            //ViewBag.StopWatch = ts;
            ViewBag.myQueue = myQueue;
            return View("Index");

        }
        public ActionResult GoHome()
        {

            return RedirectToAction("Index", "Home");

        }
    }
}