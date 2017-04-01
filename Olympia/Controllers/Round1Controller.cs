using Olympia.Models;
using Olympia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Olympia.Controllers
{
    public class Round1Controller : Controller
    {
        private OlympiaEntities db = new OlympiaEntities();
        
        public ActionResult AdminR1()
        {
            string[] player = this.Request.QueryString["joined"].ToString().Split(':');
            int num = int.Parse(player[0]);
            Session["NumberPlayer"] = num;
            ViewBag.num = num;
            if (num >= 1)
            {
                Session["P1ID"] = player[1];
                Session["P1Name"] = db.HocSinh.Find(player[1]).Ten;
            }
            if (num >= 2)
            {
                Session["P2ID"] = player[2];
                Session["P2Name"] = db.HocSinh.Find(player[2]).Ten;
            }
            if (num >= 3)
            {
                Session["P3ID"] = player[4];
                Session["P3Name"] = db.HocSinh.Find(player[3]).Ten;
            }
            if (num >= 4)
            {
                Session["P4ID"] = player[4];
                Session["P4Name"] = db.HocSinh.Find(player[4]).Ten;
            }

            ViewData["listQues"] = getQuesRound1(num);

            return View();
        }

        public ActionResult PlayerR1()
        {
            string[] mess = this.Request.QueryString["id"].Split(':');

            ViewBag.PlayerID = mess[1];
            ViewBag.PlayerName = db.HocSinh.Find(mess[1]).Ten;

            List<Vong1> list = new List<Vong1>();
            for (int i = 2; i < 5; i++)
            {
                list.Add(db.Vong1.Find(int.Parse(mess[i])));
            }
            ViewData["listQues"] = list;

            return View();
        }

        public List<Vong1> getQuesRound1(int num)
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