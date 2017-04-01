using Olympia.Models;
using System.Web.Mvc;

namespace Olympia.Controllers
{
    public class Round3Controller : Controller
    {
        private OlympiaEntities db = new OlympiaEntities();

        public ActionResult AdminR3()
        {
            return View();
        }

        public ActionResult PlayerR3()
        {
            return View();
        }
    }
}