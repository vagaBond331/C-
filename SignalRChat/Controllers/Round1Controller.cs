using OlympiaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OlympiaApp.Controllers
{
    public class Round1Controller : Controller
    {
        private OlympiaEntities db = new OlympiaEntities();
        private List<Vong1> list = new List<Vong1>();

        // GET: Round1
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Admin()
        {
            string[] player = this.Request.QueryString["joined"].ToString().Split(':');
            int num = int.Parse(player[0]);
            ViewBag.num = num;
            if (num >= 1) ViewBag.Player1 = player[1];
            if (num >= 2) ViewBag.Player2 = player[2];
            if (num >= 3) ViewBag.Player3 = player[3];
            if (num >= 4) ViewBag.Player4 = player[4];
            getQues1(num);
            ViewData["listQues"] = list;

            return View();
        }

        public ActionResult Player()
        {
            string playerID = this.Request.QueryString["id"];
            string playerName = db.HocSinh.Find(playerID).Ten;
            ViewBag.PlayerID = playerID;
            ViewBag.PlayerName = playerName;
            ViewData["listQues"] = list;
            return View();
        }

        public void getQues1(int num)
        {
            Random r = new Random();
            for (int i = 0; i < 3 * num; i++)
            {
                list.Add(db.Vong1.Find(r.Next(1, db.Vong1.ToList().Count())));
            }
        }
    }
}