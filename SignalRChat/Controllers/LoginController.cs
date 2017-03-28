using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using OlympiaApp.Models;

namespace OlympiaApp.Controllers
{
    public class LoginController : Controller
    {
        private OlympiaEntities db = new OlympiaEntities();
        
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginUser logUser)
        {
            List<HocSinh> list = db.HocSinh.ToList();
            if (logUser.UserName.Equals("admin"))
            {
                if (logUser.Password.Equals(db.HocSinh.Find("admin").MatKhau))
                {
                    Session["logUserID"] = "admin";
                    Session["logUserName"] = "admin";
                    return RedirectToAction("Admin", "Home");
                }
                else
                {
                    ViewBag.LoginFail = "Sai mật khẩu!";
                    return View(logUser);
                }
            }
            else
            {
                foreach (var item in list)
                {
                    if (item.ID.Equals(logUser.UserName))
                    {
                        Session["logUserID"] = item.ID;
                        Session["logUserName"] = item.Ten;
                        return RedirectToAction("Player", "Home");
                    }
                }
                ViewBag.LoginFail = "Sai tên đăng nhập!";
                return View(logUser);
            }
        }
    }
}