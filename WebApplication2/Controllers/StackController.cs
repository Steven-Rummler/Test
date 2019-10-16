using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructuresAssignment.Controllers
{
    public class StackController : Controller
    {
        static Stack<string> myStack = new Stack<string>();
        // GET: Stack
        public ActionResult Index()
        {
            ViewBag.DisplayMyStack = "<br>";
            ViewBag.DisplayResult = "<br>";
            return View();
        }
       
        public ActionResult AddOne()
        {//adds one value to stack
            myStack.Push("New Entry " + (myStack.Count + 1));
            ViewBag.DisplayResult = "<p>Item added to Stack</p>";
            return View("Index");
        }
        public ActionResult AddList()
        {
            //clears Stack
            myStack.Clear();
            //adds 2000 items "New Entry #"
            for (int iCount = 0; iCount < 2000; iCount++)
            {
                myStack.Push("New Entry " + (iCount + 1));
            }
            ViewBag.DisplayResult = "<p>2,000 items added to Stack</p>";
            return View("Index");
        }
        public ActionResult DisplayStack()
        {//displays whole stack below menu
            foreach (var item in myStack)
            {
                ViewBag.DisplayMyStack += "<p>" + item + "</p><br>";
            }
            return View("Index");
        }
        public ActionResult DeleteFrom()
        {//removes top item in stack
            myStack.Pop();
            ViewBag.DisplayResult = "<p>Top item removed from Stack</p>";
            return View("Index");
        }
        public ActionResult ClearStack()
        {//clears stack
            myStack.Clear();
            ViewBag.DisplayResult = "<p>Stack cleared</p>";
            return View("Index");
        }
        public ActionResult SearchView()
        {
            return View("SearchView");
        }
        [HttpPost]
        public ActionResult SearchStack(string searchValue)
        {//searches for item 100 
            string input = searchValue;
            bool contains = false;
            //begin timer
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            //perform search
            if (myStack.Contains(input)){contains = true;}
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            //return whether it was found and how long it took
            if (contains == true)
            {//return found and time
                ViewBag.DisplayResult = "<p>" + input + " was found in Stack</p><p>Time elapsed: " + ts + "</p>";
            }
            else
            {//return not found and time
                ViewBag.DisplayResult = "<p>" + input + " was not found in Stack because it does not exist</p><p>Time elapsed: " + ts + "</p>";
            }
            return View("Index");
        }
    }
}