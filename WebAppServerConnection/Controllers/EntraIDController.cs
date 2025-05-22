using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.Identity.Client;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using WebAppServerConnection.Models;
using WebAppServerConnection.Repositories;
using WebAppServerConnection.DTOs;
using System.Diagnostics;



namespace WebAppServerConnection.Controllers
{
    public class EntraIDController : Controller
    {
        private EntraIDRepository repo = new EntraIDRepository();

        [HttpGet]
        public async Task<ActionResult> GetUserList()
        {
            Debug.WriteLine("EntraIDController: GetUserList 진입");

            var users = await repo.GetUserList();

            return Json(users, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<ActionResult> GetGroupList()
        {
            Debug.WriteLine("EntraIDController: GetGroupList 진입");

            var groups = await repo.GetGroupList();

            return Json(groups, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<ActionResult> GetApplicationList()
        {
            Debug.WriteLine("EntraIDController: GetApplicationList 진입");

            var groups = await repo.GetApplicationList();

            return Json(groups, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<ActionResult> GetGroupMembers(string groupId)
        {
            var members = await repo.GetGroupMembers(groupId);
            return Json(members, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser(EntraIDCreateUser request)
        {
            var success = await repo.CreateUserAsync(request);
            return Json(new { success });
        }

        [HttpPost]
        public async Task<ActionResult> CreateGroup(EntraIDCreateGroup request)
        {
            var success = await repo.CreateGroupAsync(request);
            return Json(new { success });
        }

        [HttpPost]
        public async Task<ActionResult> AddGroupMembers(GroupMembersRequest req)
        {
            var result = await repo.AddGroupMembersAsync(req.GroupId, req.UserIds);
            return Json(new { success = result });
        }

        [HttpPost]
        public async Task<ActionResult> RemoveGroupMembers(GroupMembersRequest req)
        {
            var result = await repo.RemoveGroupMembersAsync(req.GroupId, req.UserIds);
            return Json(new { success = result });
        }


    }
}