using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Olympia.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Chat()
        {
            return View();
        }

        // GET: Home
        public ActionResult Admin()
        {
            ViewBag.NumPlayer = 0;
            ViewBag.UserID = Session["logUserID"];
            ViewBag.UserName = Session["logUserName"];
            return View();
        }

        public ActionResult Player()
        {
            ViewBag.UserID = Session["logUserID"];
            ViewBag.UserName = Session["logUserName"];
            return View();
        }
    }
}