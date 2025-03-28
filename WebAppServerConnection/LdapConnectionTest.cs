using System;
using System.DirectoryServices;

namespace ADTest
{
    class LdapConnectionTest
    {
        static void Main(string[] args)
        {
            string ldapPath = "LDAP://192.168.4.120/DC=test,DC=iqpad,DC=local";
            string username = "TEST\\normaluser1";   // AD 사용자 계정
            string password = "smstar1221!"; // AD 사용자 비밀번호

            try
            {
                DirectoryEntry entry = new DirectoryEntry(ldapPath, username, password);
                object native = entry.NativeObject; // 실제 연결 시도

                Console.WriteLine("✅ AD 서버 연결 및 인증 성공!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ 연결 실패: " + ex.Message);
            }

            Console.WriteLine("엔터 키를 누르면 종료됩니다.");
            Console.ReadLine();
        }
    }
}
