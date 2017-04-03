using Olympia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Olympia.Controllers
{
    public class Round1Controller : Controller
    {
        private OlympiaEntities db = new OlympiaEntities();
        private Round1Model model = new Round1Model();

        public ActionResult AdminR1()
        {
            string[] player = this.Request.QueryString["joined"].ToString().Split(':');
            int num = int.Parse(player[0]);
            model.players.num = num;

            if (num >= 1)
            {
                model.players.Player1.STT = 1;
                model.players.Player1.id = player[1];
                model.players.Player1.name = db.HocSinh.Find(player[1]).Ten;
            }
            if (num >= 2)
            {
                model.players.Player2.STT = 2;
                model.players.Player2.id = player[2];
                model.players.Player2.name = db.HocSinh.Find(player[2]).Ten;
            }
            if (num >= 3)
            {
                model.players.Player3.STT = 3;
                model.players.Player3.id = player[3];
                model.players.Player3.name = db.HocSinh.Find(player[3]).Ten;
            }
            if (num >= 4)
            {
                model.players.Player4.STT = 4;
                model.players.Player4.id = player[4];
                model.players.Player4.name = db.HocSinh.Find(player[4]).Ten;
            }
            model.listQues = getQuesRound1(num);

            Session["players"] = model.players;

            return View(model);
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

            return View(model);
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