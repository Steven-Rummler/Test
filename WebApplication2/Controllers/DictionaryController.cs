using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructuresAssignment.Controllers
{
    public class DictionaryController : Controller
    {
        static Dictionary<string,int> myDictionary = new Dictionary<string,int>();
        // GET: Dictionary
        public ActionResult Index()
        {
            ViewBag.DisplayMyDictionary = "<br>";
            ViewBag.DisplayResult = "<br>";
            return View();
        }
        public ActionResult AddOne()
        {//adds one value to dictionary
            myDictionary["New Entry " + (myDictionary.Count + 1)] = myDictionary.Count +1;
            ViewBag.DisplayResult = "<p>Item added to dictionary</p>";
            return View("Index");
        }
        public ActionResult AddList()
        {
            //clears dictionary
            myDictionary.Clear();
            //adds 2000 items "New Entry # : #"
            for (int iCount = 0; iCount < 2000; iCount++)
            {
                myDictionary["New Entry " + (myDictionary.Count + 1)] = myDictionary.Count + 1;
            }
            ViewBag.DisplayResult = "<p>2,000 items added to Dictionary</p>";
            return View("Index");
        }
        public ActionResult DisplayDictionary()
        {//displays whole dictionary below menu
            foreach (KeyValuePair<string,int> pair in myDictionary)
            {
                ViewBag.DisplayMyDictionary += "<p>" + pair.Key + ": " + pair.Value + "</p>";
            }
            return View("Index");
        }
        public ActionResult DeleteFrom()
        {//removes item 100 from dictionary
            if (myDictionary.ContainsValue(100))
            {
                myDictionary.Remove("New Entry 100"); //take one out of the dictionary
                ViewBag.DisplayResult = "<p>New Entry 100 removed from Dictionary</p>";
            }
            else { ViewBag.DisplayResult = "<p>New Entry 100 could not be removed from Dictionary because it does not exist</p>"; }
            return View("Index");
        }
        public ActionResult ClearDictionary()
        {//clears dictionary
            myDictionary.Clear();
            ViewBag.DisplayResult = "<p>Dictionary cleared</p>";
            return View("Index");
        }
        public ActionResult SearchView()
        {
            return View("SearchView");
        }
        [HttpPost]
        public ActionResult SearchDictionary(string searchValue)
        {//hardcoded search 100 
            string input = searchValue;
            bool contains = false;
            //begin timer
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            //perform search
            if (myDictionary.Count > 0)
            {
                if (myDictionary.ContainsKey(input)) { contains = true; }
            }
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            //return whether it was found and how long it took
            if (contains == true)
            {//return found and time
                ViewBag.DisplayResult = "<p>Found " + input + " and it returned the value " + myDictionary[input] + "</p><p>Time to complete search: " + ts + "<p/>";
            }
            else
            {//return not found and time
                ViewBag.DisplayResult = "<p>Did not find " + input + " in dictionary</p><p>Time to complete search: " + ts + "<p/>";
            }
            return View("Index");
        }
    }
}