using System;
using System.Diagnostics;
using System.DirectoryServices;

namespace WebAppServerConnection.Utils
{
    public class ActiveDirectoryHelper
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
    }
}
