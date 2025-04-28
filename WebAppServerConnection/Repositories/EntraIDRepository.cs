using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Identity.Client;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using WebAppServerConnection.Models;
using System.Diagnostics;

namespace WebAppServerConnection.Repositories
{
    public class EntraIDRepository
    {
        private readonly string tenantId = "86405abf-69f9-4524-b4b7-c1682a278764";
        private readonly string clientId = "34ec262b-2de8-4559-9824-a4e88982fc65";
        private readonly string clientSecret = "";

        public async Task<List<EntraIDUser>> GetUserList()
        {
            Debug.WriteLine("Repository: GetUsersList 진입");

            var scopes = new[] { "https://graph.microsoft.com/.default" };

            var app = ConfidentialClientApplicationBuilder
                .Create(clientId)
                .WithClientSecret(clientSecret)
                .WithAuthority($"https://login.microsoftonline.com/{tenantId}")
                .Build();

            var result = await app.AcquireTokenForClient(scopes).ExecuteAsync();
            var token = result.AccessToken;

            using (var http = new HttpClient())
            {
                http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var response = await http.GetStringAsync("https://graph.microsoft.com/v1.0/users");
                var userList = JsonConvert.DeserializeObject<EntraIDUserList>(response);

                return userList?.value ?? new List<EntraIDUser>();
            }
        }
    }
}