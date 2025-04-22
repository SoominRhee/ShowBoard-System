using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppServerConnection.Models;
using WebAppServerConnection.Repositories;

namespace WebAppServerConnection.Controllers
{
    public class BoardController : Controller
    {
        private BoardRepository boardRepository = new BoardRepository();

        public ActionResult GetBoardList(string keyword = "")
        {
            List<BoardPost> boardPosts = boardRepository.GetBoardList(keyword);
            return Json(boardPosts, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult DeleteBoardPost(int id)
        {
            bool success = boardRepository.DeleteBoardPost(id);
            return Json(new { success });
        }

        [HttpPost]
        public ActionResult CreateBoardPost(String summary, String details, String date)
        {
            string organizer = Session["Username"]?.ToString() ?? "익명";
            bool success = boardRepository.CreateBoardPost(summary, details, date, organizer);
            return Json(new { success });
        }
    }
}