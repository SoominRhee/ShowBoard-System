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
            string username = Session["Username"].ToString();
            string password = Session["Password"].ToString();

            //string username = "test"; // 수정 필요
            //string password = "test"; // 수정 필요

            var result = ActiveDirectoryRepository.GetRootNodes(username, password);
            return Json(result, JsonRequestBehavior.AllowGet);
        }



        [HttpGet]
        public ActionResult GetChildNodes(string dn)
        {
            string username = Session["Username"].ToString();
            string password = Session["Password"].ToString();

            //string username = "test"; // 수정 필요
            //string password = "test"; // 수정 필요

            Debug.WriteLine("GetChildNodes 요청 Dn: " + dn);

            var result = ActiveDirectoryRepository.GetChildNodes(dn, username, password);
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult GetChildrenFlat(string dn)
        {
            string username = Session["Username"].ToString();
            string password = Session["Password"].ToString();

            //string username = "test"; // 수정 필요
            //string password = "test"; // 수정 필요

            Debug.WriteLine("GetChildFlat 요청 Dn: " + dn);

            var result = ActiveDirectoryRepository.GetChildrenFlat(dn, username, password);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetDetails(string dn)
        {
            string username = Session["Username"].ToString();
            string password = Session["Password"].ToString();

            //string username = "test"; // 수정 필요
            //string password = "test"; // 수정 필요

            var result = ActiveDirectoryRepository.GetDetails(dn, username, password);
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult GetAllowedChildClasses(string dn)
        {
            Debug.WriteLine("Controller: GetAllowedChildClasses 진입");

            string username = Session["Username"].ToString();
            string password = Session["Password"].ToString();

            var result = ActiveDirectoryRepository.GetAllowedChildClasses(dn, username, password);
            Debug.WriteLine("Controller - 허용 클래스 개수: " + result.Count);
            return Json(result, JsonRequestBehavior.AllowGet);
            
        }
    }
}