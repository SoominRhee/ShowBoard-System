using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppServerConnection.DTOs;
using WebAppServerConnection.Models;
using WebAppServerConnection.Repositories;

namespace WebAppServerConnection.Controllers
{
    public class AccountController : Controller
    {
        private UserRepository userRepository = new UserRepository();


        public ActionResult Login()
        {
            return View();
        }


        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }


        [HttpPost]
        public ActionResult Login(string Username, string Password)
        {
            UserLoginResult result = userRepository.GetUserLoginInfo(Username, Password);
            if (result != null)
            {
                Session["UserID"] = result.ID;
                Session["Username"] = Username;
                Session["IsAdmin"] = result.IsAdmin;
                return Json(new { success = true, message = "로그인 성공" });
            }

            return Json(new { success = false, message = "아이디 또는 비밀번호가 잘못되었습니다." });
        }

        [HttpGet]
        public ActionResult CheckAdmin()
        {
            bool isAdmin = Session["IsAdmin"] != null && (bool)Session["IsAdmin"];
            return Json(new { isAdmin = isAdmin }, JsonRequestBehavior.AllowGet);
        }
    }
}