using Olympia.Models;
using Olympia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Olympia.Controllers
{
    public class Round2Controller : Controller
    {
        private OlympiaEntities db = new OlympiaEntities();

        public ActionResult AdminR2()
        {
            return View();
        }

        public ActionResult PlayerR2()
        {
            return View();
        }

        public List<Vong1> getQuesRound2(int num)
        {
            List<Vong1> list = new List<Vong1>();
            Random r = new Random();
            for (int i = 0; i < 3 * num; i++)
            {
                int idQues = r.Next(1, db.Vong1.ToList().Count());
                list.Add(db.Vong1.Find(idQues));
                if (num >= 1 && i < 3) ViewBag.Ques1 += idQues + ":";
                else if (num >= 2 && i < 6) ViewBag.Ques2 += idQues + ":";
                else if (num >= 3 && i < 9) ViewBag.Ques3 += idQues + ":";
                else if (num >= 4 && i < 12) ViewBag.Ques4 += idQues + ":";
            }
            return list;
        }
    }
}