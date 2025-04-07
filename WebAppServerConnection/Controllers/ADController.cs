using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppServerConnection.Repositories;

namespace WebAppServerConnection.Controllers
{
    public class ADController : Controller
    {
        [HttpGet]
        public ActionResult GetRootNodes()
        {
            //string username = Session["Username"].ToString();
            //string password = Session["Password"].ToString();
            string username = "test"; // 수정 필요
            string password = "test"; // 수정 필요

            var result = ActiveDirectoryRepository.GetRootNodes(username, password);
            return Json(result, JsonRequestBehavior.AllowGet);
        }



        [HttpGet]
        public ActionResult GetChildNodes(string dn)
        {
            //string username = Session["Username"].ToString();
            //string password = Session["Password"].ToString();
            string username = "test"; // 수정 필요
            string password = "test"; // 수정 필요

            Debug.WriteLine("GetChildNodes 요청 Dn: " + dn);

            var result = ActiveDirectoryRepository.GetChildNodes(dn, username, password);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}