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
        private Round2Model model = new Round2Model();

        public ActionResult AdminR2()
        {
            string[] point = this.Request.QueryString["point"].ToString().Split(':');

            model.players = Session["players"] as ListPlayer;
            int num = model.players.num;
            if (num >= 1) model.players.Player1.pointR1 = int.Parse(point[0]);
            if (num >= 2) model.players.Player2.pointR1 = int.Parse(point[1]);
            if (num >= 3) model.players.Player3.pointR1 = int.Parse(point[2]);
            if (num >= 4) model.players.Player4.pointR1 = int.Parse(point[3]);

            return View(model);
        }

        [HttpPost]
        public ActionResult AdminR2(Round2Model model)
        {
            model.list = db.Vong2.ToList().Where(o => o.Nhom == model.group).ToList();

            for (int i = 0; i < 4; i++)
            {
                model.list[i].DapAn = addSpace(model.list[i].DapAn, model.list[i].SoHangDoc);
            }

            return View(model);
        }

        public ActionResult PlayerR2()
        {
            return View();
        }

        public string addSpace(string a, int time)
        {
            for (int i = 0; i < 7-time; i++)
            {
                a = " " + a;
            }
            return a;
        }
    }
}