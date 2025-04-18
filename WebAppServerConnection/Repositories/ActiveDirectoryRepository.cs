using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.DirectoryServices;
using System.Text.RegularExpressions;
using System.Web.Services;
using WebAppServerConnection.DTOs;

namespace WebAppServerConnection.Repositories
{
    public class ActiveDirectoryRepository
    {
        private const string ldapPath = "LDAP://192.168.4.120/DC=test,DC=iqpad,DC=local";
        public static bool TryLogin(string username, string password)
        {
            try
            {

                string fullUsername = "TEST\\" + username;

                using (DirectoryEntry entry = new DirectoryEntry(ldapPath, fullUsername, password))
                {
                    object native = entry.NativeObject;
                    Debug.WriteLine("AD 서버 연결 성공");
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }


        public static bool IsUserDomainAdmins(string username, string password)
        {
            try
            {
                string fullUsername = "TEST\\" + username;

                using (DirectoryEntry entry = new DirectoryEntry(ldapPath, username, password))
                {
                    using (DirectorySearcher searcher = new DirectorySearcher(entry))
                    {
                        searcher.Filter = $"(sAMAccountName={username})";  // 사용자 계정명으로 필터링
                        searcher.PropertiesToLoad.Add("memberOf");

                        SearchResult result = searcher.FindOne();

                        if (result != null)
                        {
                            var groups = result.Properties["memberOf"];
                            foreach (var group in groups)
                            {
                                if (group.ToString().Contains("CN=Domain Admins"))
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("AD에서 그룹 조회 중 오류: " + ex.Message);
            }

            return false;
        }
        

        public static List<ADTreeNode> GetRootNodes(string username, string password)
        {
            List<ADTreeNode> result = new List<ADTreeNode>();

            try
            {
                string fullUsername = "TEST\\" + username;

                //DirectoryEntry root = new DirectoryEntry("LDAP://192.168.4.120/DC=test,DC=iqpad,DC=local", "TEST\\administrator", "smstar1221!"); // 수정 필요

                DirectoryEntry root = new DirectoryEntry(ldapPath, fullUsername, password);

                string name = root.Properties["name"].Value?.ToString();
                string dn = root.Properties["distinguishedName"].Value?.ToString();

                result.Add(new ADTreeNode
                {
                    Name = name,
                    DistinguishedName = dn,
                    SchemaClassName = root.SchemaClassName
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine("AD 루트 노드 로딩 실패" + ex);
            }

            return result;
        }


        public static List<ADTreeNode> GetChildNodes(string dn, string username, string password)
        {
            List<ADTreeNode> result = new List<ADTreeNode>();
            Debug.WriteLine("GetChildNodes 진입");

            try
            {
                string fullUsername = "TEST\\" + username;

                string path = $"LDAP://192.168.4.120/{dn}";

                //DirectoryEntry entry = new DirectoryEntry(path, "TEST\\administrator", "smstar1221!"); // 수정 필요

                DirectoryEntry entry = new DirectoryEntry(path, fullUsername, password);

                foreach(DirectoryEntry child in entry.Children)
                {
                    if (child.SchemaClassName == "organizationalUnit" ||
                        child.SchemaClassName == "container" ||
                        child.SchemaClassName == "domainDNS")
                    {
                        string name = child.Properties["name"].Value?.ToString();
                        string childDn = child.Properties["distinguishedName"].Value?.ToString();

                        result.Add(new ADTreeNode
                        {
                            Name = name,
                            DistinguishedName = childDn,
                            SchemaClassName = child.SchemaClassName
                        });
                    }
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine("GetChildNodes 실패: " + ex.Message);
            }

            return result;
        }


        public static List<ADEntry> GetChildrenFlat(string dn, string username, string password)
        {
            List<ADEntry> result = new List<ADEntry>();

            try
            {
                string fullUsername = "TEST\\" + username;

                string path = $"LDAP://192.168.4.120/{dn}";
                //DirectoryEntry entry = new DirectoryEntry(path, "TEST\\administrator", "smstar1221!"); // 수정 필요

                DirectoryEntry entry = new DirectoryEntry(path, fullUsername, password);

                foreach (DirectoryEntry child in entry.Children)
                {
                    result.Add(new ADEntry
                    {
                        Name = child.Properties["name"].Value?.ToString(),
                        Type = child.SchemaClassName,
                        Description = child.Properties["description"].Value?.ToString() ?? "",
                        DistinguishedName = child.Properties["distinguishedName"]?.Value?.ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("GetChildrenFlat 오류: " + ex.Message);
            }

            return result;
        }


        public static ADDetail GetDetails(string dn, string username, string password)
        {
            ADDetail detail = new ADDetail();

            try
            {
                string fullUsername = "TEST\\" + username;
                string path = $"LDAP://192.168.4.120/{dn}";

                //DirectoryEntry entry = new DirectoryEntry(path, "TEST\\administrator", "smstar1221!"); // 수정 필요

                DirectoryEntry entry = new DirectoryEntry(path, fullUsername, password);


                detail.Name = entry.Properties["name"].Value?.ToString();
                detail.Type = entry.SchemaClassName;
                detail.Description = entry.Properties["description"].Value?.ToString();
                detail.DisplayName = entry.Properties["displayName"].Value?.ToString();
                detail.DistinguishedName = entry.Properties["distinguishedName"].Value?.ToString();
                detail.Guid = entry.Guid.ToString();
                detail.SamAccountName = entry.Properties["sAMAccountName"].Value?.ToString();
                detail.Mail = entry.Properties["mail"].Value?.ToString();
                detail.Created = entry.Properties["whenCreated"].Value?.ToString();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("GetDetails 오류: " + ex.Message);
            }

            return detail;
        }


        public static List<string> GetAllowedChildClasses(string dn, string username, string password)
        {
            var result = new List<string>();
            Debug.WriteLine("Repository: GetAllowedChildClasses 진입");
            try
            {
                string fullUsername = "TEST\\" + username;
                string path = $"LDAP://192.168.4.120/{dn}";

                using (var entry = new DirectoryEntry(path, fullUsername, password))
                {
                    Debug.WriteLine("DN: " + entry.Properties["distinguishedName"].Value);

                    entry.RefreshCache(new[] { "allowedChildClassesEffective" });

                    var allowed = entry.Properties["allowedChildClassesEffective"];
                    if (allowed != null)
                    {
                        foreach (var cls in allowed)
                        {
                            result.Add(cls.ToString().ToLower());
                        }
                    }
                }
                
            }
            catch(Exception ex)
            {
                Debug.WriteLine("GetAllowdChildClasses 오류" + ex.Message);
            }

            Debug.WriteLine("Repository - 허용 클래스 개수: " + result.Count);
            return result;
        }



        public static void CreateUser(UserCreateModel model, string username, string password)
        {
            string fullUsername = "TEST\\" + username;
            string path = $"LDAP://192.168.4.120/{model.ParentDn}";

            try
            {
                using (var parent = new DirectoryEntry(path, fullUsername, password))
                {
                    Debug.WriteLine("Repository: CreateUser 진입");

                    string fullName = $"{model.FirstName} {model.LastName} {DateTime.Now.Ticks}".Trim();
                    fullName = Regex.Replace(fullName, @"[,+""<>;=\\#]", "");

                    var user = parent.Children.Add("CN=" + fullName, "user");

                    string lastName = string.IsNullOrWhiteSpace(model.LastName) ? "NoLastName" : model.LastName;

                    string baseSam = model.LogonName;
                    string randomSuffix = DateTime.Now.Ticks.ToString().Substring(10);
                    string sam = (baseSam + randomSuffix).Length > 20
                        ? (baseSam + randomSuffix).Substring(0, 20)
                        : baseSam + randomSuffix;

                    string upn = model.LogonName + "@test.iqpad.local";

                    user.Properties["sAMAccountName"].Value = sam;
                    user.Properties["userPrincipalName"].Value = upn;
                    user.Properties["displayName"].Value = fullName;
                    user.Properties["sn"].Value = lastName;
                    user.Properties["givenName"].Value = model.FirstName;
                    user.Properties["name"].Value = fullName;
                    user.Properties["pwdLastSet"].Value = 0;

                    user.CommitChanges();
                    Debug.WriteLine("사용자 초기 등록 완료");

                    user.Invoke("SetPassword", new object[] { model.Password });
                    Debug.WriteLine("비밀번호 설정 완료");

                    user.InvokeSet("AccountDisabled", new object[] { false });
                    user.CommitChanges();
                    Debug.WriteLine("사용자 활성화 완료");

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("예외 발생: " + ex.ToString());
                if (ex.InnerException != null)
                    Debug.WriteLine("내부 예외: " + ex.InnerException.ToString());
                throw;
            }
        }




    }
}
