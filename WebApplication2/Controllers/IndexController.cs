using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructuresAssignment.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {//this is the only page without comments so I hope this works
            return View();
        }
        public ActionResult Exit()
        {//redirects to byu.edu
            return Redirect("https://www.byu.edu/");
        }
    }
    
}