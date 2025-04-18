using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppServerConnection.DTOs
{
    public class UserCreateModel
    {
        public string ParentDn { get; set; }
        public string FirstName { get; set; }
        public string Initials { get; set; }
        public string LastName { get; set; }
        public string LogonName { get; set; }
        public string Password { get; set; }
    }

}