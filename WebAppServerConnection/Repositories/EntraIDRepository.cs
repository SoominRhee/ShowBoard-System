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
using System.Text;

namespace WebAppServerConnection.Repositories
{
    public class EntraIDRepository
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        private readonly string tenantId = "";
        private readonly string clientId = "";
        private readonly string clientSecret = "";

        private async Task<string> GetAccessTokenAsync()
        {
            var scopes = new[] { "https://graph.microsoft.com/.default" };

            var app = ConfidentialClientApplicationBuilder
                .Create(clientId)
                .WithClientSecret(clientSecret)
                .WithAuthority($"https://login.microsoftonline.com/{tenantId}")
                .Build();

            var result = await app.AcquireTokenForClient(scopes).ExecuteAsync();
            return result.AccessToken;
        }


        public async Task<List<EntraIDUser>> GetUserList()
        {
            Debug.WriteLine("Repository: GetUserList 진입");

            try
            {
                var token = await GetAccessTokenAsync();

                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var response = await _httpClient.GetStringAsync("https://graph.microsoft.com/v1.0/users");
                var userList = JsonConvert.DeserializeObject<EntraIDUserList>(response);

                return userList?.value ?? new List<EntraIDUser>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("GetUserList 오류 발생: " + ex.Message);
                return new List<EntraIDUser>();
            }
        }

        public async Task<List<EntraIDGroup>> GetGroupList()
        {
            Debug.WriteLine("Repository: GetGroupList 진입");

            try
            {
                var token = await GetAccessTokenAsync();

                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var response = await _httpClient.GetStringAsync("https://graph.microsoft.com/v1.0/groups");
                var groupList = JsonConvert.DeserializeObject<EntraIDGroupList>(response);

                return groupList?.value ?? new List<EntraIDGroup>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("GetGroupList 오류 발생: " + ex.Message);
                return new List<EntraIDGroup>();
            }
        }

        public async Task<List<EntraIDApplication>> GetApplicationList()
        {
            Debug.WriteLine("Repository: GetApplicationList 진입");

            try
            {
                var token = await GetAccessTokenAsync();

                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var response = await _httpClient.GetStringAsync("https://graph.microsoft.com/v1.0/applications");
                var applicationList = JsonConvert.DeserializeObject<EntraIDApplicationList>(response);

                return applicationList?.value ?? new List<EntraIDApplication>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("GetGroupList 오류 발생: " + ex.Message);
                return new List<EntraIDApplication>();
            }
        }

        public async Task<List<EntraIDUser>> GetGroupMembers(string groupId)
        {
            var token = await GetAccessTokenAsync();

            using (var http = new HttpClient())
            {
                http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var response = await _httpClient.GetStringAsync($"https://graph.microsoft.com/v1.0/groups/{groupId}/members");
                var memberList = JsonConvert.DeserializeObject<EntraIDUserList>(response);

                return memberList?.value ?? new List<EntraIDUser>();
            }
        }

        public async Task<bool> CreateUserAsync(EntraIDCreateUser request)
        {
            var token = await GetAccessTokenAsync();

            string fixedDomain = "@soominrhee01gmail.onmicrosoft.com";

            string upn = request.UserPrincipalName.Contains("@")
                ? request.UserPrincipalName
                : request.UserPrincipalName + fixedDomain;

            string mailNickname = upn.Split('@')[0];

            var userPayload = new
            {
                accountEnabled = true,
                displayName = request.DisplayName,
                mailNickname = mailNickname,
                userPrincipalName = upn,
                passwordProfile = new
                {
                    forceChangePasswordNextSignIn = false,
                    password = request.Password
                }
            };

            var json = JsonConvert.SerializeObject(userPayload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.PostAsync("https://graph.microsoft.com/v1.0/users", content);

            var resultContent = await response.Content.ReadAsStringAsync();

            Debug.WriteLine("Graph API 응답 상태: " + response.StatusCode);
            Debug.WriteLine("응답 내용: " + resultContent);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> CreateGroupAsync(EntraIDCreateGroup request)
        {
            var token = await GetAccessTokenAsync();

            string mailNickname = request.DisplayName.Replace(" ", "").ToLower();

            var groupPayload = new
            {
                displayName = request.DisplayName,
                mailNickname = mailNickname,
                description = request.Description,
                mailEnabled = false,
                securityEnabled = true
            };

            var json = JsonConvert.SerializeObject(groupPayload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.PostAsync("https://graph.microsoft.com/v1.0/groups", content);
            var resultContent = await response.Content.ReadAsStringAsync();

            Debug.WriteLine("Graph API 응답 상태: " + response.StatusCode);
            Debug.WriteLine("응답 내용: " + resultContent);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> AddGroupMembersAsync(string groupId, List<string> userIds)
        {
            var token = await GetAccessTokenAsync();

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            bool allSuccess = true;
            foreach (var userId in userIds)
            {
                var body = new Dictionary<string, object>
                {
                    ["@odata.id"] = $"https://graph.microsoft.com/v1.0/directoryObjects/{userId}"
                };

                var content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync($"https://graph.microsoft.com/v1.0/groups/{groupId}/members/$ref", content);
                if (!response.IsSuccessStatusCode)
                {
                    Debug.WriteLine($"AddMember 실패: {userId} → {response.StatusCode}");
                    allSuccess = false;
                }
            }

            return allSuccess;
        }

        public async Task<bool> RemoveGroupMembersAsync(string groupId, List<string> userIds)
        {
            var token = await GetAccessTokenAsync();

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            bool allSuccess = true;
            foreach (var userId in userIds)
            {
                var response = await _httpClient.DeleteAsync($"https://graph.microsoft.com/v1.0/groups/{groupId}/members/{userId}/$ref");
                if (!response.IsSuccessStatusCode)
                {
                    Debug.WriteLine($"RemoveMember 실패: {userId} → {response.StatusCode}");
                    allSuccess = false;
                }
            }

            return allSuccess;
        }


    }
}