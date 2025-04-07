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
        

        public static List<ADTreeNode> GetRootNodes(string username, string password)
        {
            List<ADTreeNode> result = new List<ADTreeNode>();

            try
            {
                //DirectoryEntry root = new DirectoryEntry("LDAP://192.168.4.120/DC=test.DC=iqpad,DC=local", username, password); // 나중에는 실제 로그인 값으로 동작
                DirectoryEntry root = new DirectoryEntry("LDAP://192.168.4.120/DC=test,DC=iqpad,DC=local", "TEST\\administrator", "smstar1221!");

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
                string path = $"LDAP://192.168.4.120/{dn}";
                DirectoryEntry entry = new DirectoryEntry(path, "TEST\\administrator", "smstar1221!");

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


    }
}
