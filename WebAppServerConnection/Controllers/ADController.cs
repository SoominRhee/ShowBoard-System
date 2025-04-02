using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppServerConnection.Utils;

namespace WebAppServerConnection.Controllers
{
    public class ADController : Controller
    {
        [HttpGet]
        public ActionResult GetOrgTree()
        {

            Debug.WriteLine("ADController.cs 진입");
            var result = ActiveDirectoryHelper.GetOrgUnits();
            Debug.WriteLine("result form ADController.cs: " + result);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        //public ActionResult GetUsersByOU( string ouName)
        //{
        //    var result = ActiveDirectoryHelper.GetUsersByOU(ouName);
        //    return Json(result);
        //}
    }
    

}