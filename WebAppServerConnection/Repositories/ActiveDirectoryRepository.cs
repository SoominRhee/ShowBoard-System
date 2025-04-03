using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.DirectoryServices;
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
                Debug.WriteLine("❌ AD에서 그룹 조회 중 오류: " + ex.Message);
            }

            return false;
        }

        public static List<OrgUnitNode> GetOrgUnits()
        {
            try
            {
                List<OrgUnitNode> result = new List<OrgUnitNode>();
                DirectoryEntry root = new DirectoryEntry("LDAP://192.168.4.120/DC=test,DC=iqpad,DC=local", "TEST\\administrator", "smstar1221!");

                foreach (DirectoryEntry ou in root.Children)
                {
                    if (ou.SchemaClassName == "organizationalUnit" && ou.Properties["name"].Value.ToString() == "iqpad")
                    {
                        result.Add(BuildOrgUnitTree(ou));
                    }
                }
                Debug.WriteLine("result form ADHelper.cs: " + result);


                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("GetOrgUnits AD 연결 실패: " + ex.Message);
                return new List<OrgUnitNode>();
            }
        }

        private static OrgUnitNode BuildOrgUnitTree(DirectoryEntry entry)
        {
            OrgUnitNode node = new OrgUnitNode
            {
                Name = entry.Properties["name"].Value.ToString(),
                DistinguishedName = entry.Properties["distinguishedName"].Value.ToString(),
                Children = new List<OrgUnitNode>()
            };

            foreach (DirectoryEntry child in entry.Children)
            {
                if (child.SchemaClassName == "organizationalUnit")
                {
                    node.Children.Add(BuildOrgUnitTree(child)); // 재귀 호출
                }
            }

            return node;
        }



        public static List<ADUser> GetUsersByOU(string dn)
        {
            Debug.WriteLine("ADHelper로 들어온 dn: " + dn);
            List<ADUser> users = new List<ADUser>();

            string path = $"LDAP://192.168.4.120/" + dn;
            DirectoryEntry entry = new DirectoryEntry(path,"TEST\\administrator", "smstar1221!");

            DirectorySearcher searcher = new DirectorySearcher(entry)
            {
                Filter = "(objectClass=user)"
            };

            try
            {
                foreach (SearchResult result in searcher.FindAll())
                {
                    DirectoryEntry user = result.GetDirectoryEntry();

                    users.Add(new ADUser
                    {
                        Name = user.Properties["cn"].Value?.ToString(),
                        Type = "User",
                        Description = user.Properties["description"].Value?.ToString() ?? ""
                    });
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine("GetUsersByOu AD 연결 실패: " + ex.Message);
            }

            Debug.WriteLine("GetusersByOU 리턴값: " + users);
            return users;
        }
    }
}
