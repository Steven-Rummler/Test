using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructuresAssignment.Controllers
{
    public class QueueController : Controller
    {
        static Queue<string> myQueue = new Queue<string>();
        // GET: Stack
        public ActionResult Index()
        {
            ViewBag.DisplayMyQueue = "<br>";
            ViewBag.DisplayResult = "<br>";
            return View();
        }
        public  ActionResult AddOne()
        {//adds one value to queue
            myQueue.Enqueue("New Entry " + (myQueue.Count + 1));
            ViewBag.DisplayResult = "<p>Item added to Queue</p>";
            return View("Index");
        }
        public ActionResult AddList()
        {
            //clears queue
            myQueue.Clear();
            //adds 2000 items "New Entry #"
            for (int iCount = 0; iCount < 2000; iCount++)
            {
                myQueue.Enqueue("New Entry " + (iCount + 1));
            }
            ViewBag.DisplayResult = "<p>2,000 items added to Queue</p>";
            return View("Index");
        }
        public ActionResult DisplayQueue()
        {//displays whole stack below menu
            foreach (var item in myQueue)
            {
                ViewBag.DisplayMyQueue += "<p>" + item + "</p>";
            }
            return View("Index");
        }
        public ActionResult DeleteFrom()
        {//removes top item in stack
            myQueue.Dequeue();
            ViewBag.DisplayResult = "<p>First item removed from Queue</p>";
            return View("Index");
        }
        public ActionResult ClearQueue()
        {//clears stack
            myQueue.Clear();
            ViewBag.DisplayResult = "<p>Queue cleared</p>";
            return View("Index");
        }
        public ActionResult SearchQueue()
        {//get input for what to search 
            string input = "New Entry 100";
            bool contains = false;
            //begin timer
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            //perform search
            if (myQueue.Contains(input)) { contains = true; }
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            //return whether it was found and how long it took
            if (contains == true)
            {//return found and time
                ViewBag.DisplayResult = "<p>New Entry 100 found in Queue</p><p>Time elapsed: " + ts + "</p>";
            }
            else
            {//return not found and time
                ViewBag.DisplayResult = "<p>New Entry 100 was not found in Queue because it does not exist</p><p>Time elapsed: " + ts + "</p>";
            }
            return View("Index");
        }
        public ActionResult SearchView()
        {
            return View("SearchView");
        }
        [HttpPost]
        public ActionResult SearchQueue(string searchValue)
        {//searches for input item
            string input = searchValue;
            bool contains = false;
            //begin timer
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            //perform search
            if (myQueue.Contains(input)) { contains = true; }
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            //return whether it was found and how long it took
            if (contains == true)
            {//return found and time
                ViewBag.DisplayResult = "<p>" + input + " was found in the queue</p><p>Time elapsed: " + ts + "</p>";
            }
            else
            {//return not found and time
                ViewBag.DisplayResult = "<p>" + input + " was not found in the queue because it does not exist</p><p>Time elapsed: " + ts + "</p>";
            }
            return View("Index");
        }
    }
}