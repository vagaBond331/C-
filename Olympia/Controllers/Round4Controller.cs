using Olympia.Models;
using Olympia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Olympia.Controllers
{
    public class Round4Controller : Controller
    {
        private OlympiaEntities db = new OlympiaEntities();

        public ActionResult AdminR4()
        {
            return View();
        }

        public ActionResult PlayerR4()
        {
            return View();
        }
    }
}