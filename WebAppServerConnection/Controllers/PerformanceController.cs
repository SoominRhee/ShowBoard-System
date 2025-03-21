using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using WebAppServerConnection.Models;
using WebAppServerConnection.Repositories;

namespace WebAppServerConnection.Controllers
{
    public class PerformanceController : Controller
    {

        private PerformanceRepository performanceRepository = new PerformanceRepository();

        // GET: Performance
        public ActionResult GetPerformanceList(string keyword = "")
        {
            List<Performance> performances = performanceRepository.GetPerformanceList(keyword);
            return Json(performances, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SavePerformanceId(int id)
        {
            var isValid = performanceRepository.isPerformanceValid(id);

            if (isValid)
            {
                //Debug.WriteLine($"Session 업데이트 요청: PerformanceId = {id}");
                Session["PerformanceId"] = id;
                //Debug.WriteLine($"Session 업데이트 완료: PerformanceId = {Session["PerformanceId"]}");
                
                return Json(new { success = true });
                
            }
            
            return Json(new { success = false });

        }



        public ActionResult GetPerformanceData()
        {   
            int id = Convert.ToInt32(Session["PerformanceId"]);
            Performance performance = performanceRepository.GetPerformance(id);
            return Json(performance, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetPerformanceDetail(int id)
        {
            Performance performance = performanceRepository.GetPerformance(id);
            return Json(performance, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CreatePerformance(String date, String artist, String location, String details, String link, int availableNum)
        {
            bool isSuccess = performanceRepository.CreatePerformance(date, artist, location, details, link, availableNum);

            if (isSuccess)
            {
                return Json(new { success = true });
            }

            return Json(new { success = false });
        }

    }
}