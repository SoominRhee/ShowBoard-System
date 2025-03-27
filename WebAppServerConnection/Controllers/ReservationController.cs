using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using WebAppServerConnection.DTOs;
using WebAppServerConnection.Models;
using WebAppServerConnection.Repositories;

namespace WebAppServerConnection.Controllers
{
    public class ReservationController : Controller
    {
        private UserRepository userRepository = new UserRepository();
        private ReservationRepository reservationRepository = new ReservationRepository();

        [HttpPost]
        public ActionResult CreateReservation()
        {
            int performanceId = Convert.ToInt32(Session["PerformanceId"]);
            int userId = Convert.ToInt32(Session["UserId"]);
            bool success = reservationRepository.CreateReservation(userId, performanceId);
            Debug.WriteLine(performanceId);
            Debug.WriteLine(userId);

            return Json(new { success });
        }

        public ActionResult GetReservationList(string keyword = "")
        {
            //String username = Session["Username"].ToString();
            //var user = AccountController.users.FirstOrDefault(u => u.Username == username);

            //return Json(user.ReservationList, JsonRequestBehavior.AllowGet);
            if (Session["Username"] == null)
            {
                return Json(new { success = false, message = "로그인이 필요합니다." }, JsonRequestBehavior.AllowGet);
            }

            string username = Session["Username"].ToString();
            int? userId = Convert.ToInt32(Session["UserId"]);
            Debug.WriteLine("리스트 가져올 기준 아이디 확인: ", userId);
            //if (userId.HasValue)
            //{
            //    return Json(new { success = false, message = "사용자 정보를 찾을 수 없습니다." }, JsonRequestBehavior.AllowGet);
            //}

            List<Performance> reservations = reservationRepository.GetUserReservations(userId.Value, keyword);
            

            return Json(reservations, JsonRequestBehavior.AllowGet);
        }


        public ActionResult GetUserListByPerformanceId(int id) {
            List<UserReservationInfo> reservationInfo = reservationRepository.GetUserListByPerformanceId(id);
            Debug.WriteLine("Controller return: " + reservationInfo.Count);

            for(int i = 0; i<reservationInfo.Count; i++)
            {
                Debug.WriteLine($"[예약자] ID: {reservationInfo[i].UserID}, 이름: {reservationInfo[i].Username}, 예약일: {reservationInfo[i].ReservationDate}");

            }
            return Json(reservationInfo, JsonRequestBehavior.AllowGet);
        }
    }
}