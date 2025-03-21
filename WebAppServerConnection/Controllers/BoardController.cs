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

        // GET: Performance
        //public ActionResult GetBoardList()
        //{
        //    List<BoardPost> posts = boardRepository.GetBoardList();
        //    return Json(posts, JsonRequestBehavior.AllowGet);
        //}

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

            //var post = posts.FirstOrDefault(p => p.ID == id);
            //if (post != null)
            //{
            //    posts.Remove(post);
            //    return Json(new { success = true });
            //}

            //return Json(new { success = false });
        }

        [HttpPost]
        public ActionResult CreateBoardPost(String summary, String details, String date)
        {
            string organizer = Session["Username"]?.ToString() ?? "익명";
            bool success = boardRepository.CreateBoardPost(summary, details, date, organizer);
            return Json(new { success });

            //BoardPost post = new BoardPost(posts.Count() + 1, DateTime.Now.ToString("yyyy년 MM월 dd일"), Session["Username"].ToString(), summary, details, date);
            //Debug.WriteLine("새로운 게시물 아이디" + post.ID);
            //if(post != null)
            //{
            //    posts.Add(post);
            //    return Json(new { success = true });
            //}

            //return Json(new { success = false });
        }
    }
}