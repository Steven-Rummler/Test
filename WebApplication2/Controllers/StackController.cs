using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Data_Structure_HW.Controllers
{
    public class StackController : Controller
    {
        static Stack<string> myStack = new Stack<string>();

        // GET: Stack
        public ActionResult Index()
        {
            ViewBag.MyStack = myStack;

            return View();
        }

        // Method for the Add One button
        public ActionResult Add()
        {
            myStack.Push("New Entry " + (myStack.Count + 1));
            ViewBag.MyStack = myStack;
            return View("Index");
        }
        public ActionResult HugeList()
        {
            myStack.Clear();
            do
            {
                myStack.Push("New Entry " + (myStack.Count + 1));
            }
            while (myStack.Count < 2000);
            ViewBag.MyStack = myStack;
            return View("Index");

        }
        public ActionResult Display()
        {
            ViewBag.MyStack = myStack;
            return View("Index");

        }
        public ActionResult Delete()
        {
            if (myStack.Count > 0)
            {
                myStack.Pop();
            }
            else
            {
                ViewBag.Message = "There are no elements to delete";
            }

            ViewBag.MyStack = myStack;
            return View("Index");

        }
        public ActionResult Clear()
        {
            myStack.Clear();
            ViewBag.MyStack = myStack;
            return View("Index");
        }
        public ActionResult Search()
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            sw.Start();

            //loop to do all the work
            if (myStack.Contains("New Entry 7"))
            {
                ViewBag.Message = "New Entry 7 was found";
            }
            else
            {
                ViewBag.Message = "New Entry 7 was not found";
            }

            sw.Stop();

            TimeSpan ts = sw.Elapsed;
            ViewBag.Message += "<br> The time it took is: " + ts;
            //ViewBag.StopWatch = ts;
            ViewBag.MyStack = myStack;
            return View("Index");

        }
        public ActionResult GoHome()
        {

            return RedirectToAction("Index", "Home");

        }
    }
}