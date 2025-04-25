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
using System.Diagnostics;



namespace WebAppServerConnection.Controllers
{
    public class EntraIDController : Controller
    {
        [HttpGet]
        public async Task<ActionResult> GetUserList()
        {
            Debug.WriteLine("EntraIDController: GetUserList 진입");

            var repo = new EntraIDRepository();
            var users = await repo.GetUserList();

            return Json(users, JsonRequestBehavior.AllowGet);
        }
    }
}