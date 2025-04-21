using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppServerConnection.Repositories;
using WebAppServerConnection.DTOs;

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


        [HttpPost]
        public ActionResult CreateUser(UserCreateModel model)
        {
            try
            {
                Debug.WriteLine("Controller: CreateUser 진입");

                string username = Session["Username"].ToString();
                string password = Session["Password"].ToString();

                ActiveDirectoryRepository.CreateUser(model, username, password);
                return Json(new { success = true, message = "사용자 생성 완료" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult CreateGroup(GroupCreateModel model)
        {
            try
            {
                Debug.WriteLine("Controller: CreateGroup 진입");

                string username = Session["Username"].ToString();
                string password = Session["Password"].ToString();

                ActiveDirectoryRepository.CreateGroup(model, username, password);
                return Json(new { success = true, message = "그룹 생성 완료" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult CreateOU(OUCreateModel model)
        {
            try
            {
                Debug.WriteLine("Controller: CreateOU 진입");

                string username = Session["Username"].ToString();
                string password = Session["Password"].ToString();

                ActiveDirectoryRepository.CreateOU(model, username, password);
                return Json(new { success = true, message = "OU 생성 완료" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}