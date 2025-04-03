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
        public ActionResult GetOrgTree()
        {

            Debug.WriteLine("AD/GetOrgTree 진입");
            var result = ActiveDirectoryRepository.GetOrgUnits();
            Debug.WriteLine("result form AD/GetOrgTree : " + result);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetUsersByOU(string dn)
        {
            Debug.WriteLine("AD/GetUsersByOu 진입");

            var result = ActiveDirectoryRepository.GetUsersByOU(dn);
            Debug.WriteLine("result form AD/GetUsersByOu: " + result);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }


}