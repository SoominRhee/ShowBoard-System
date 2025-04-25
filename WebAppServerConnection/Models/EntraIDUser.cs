using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppServerConnection.Models
{
    public class EntraIDUser
    {
        public string displayName { get; set; }
        public string mail { get; set; }
        public string userPrincipalName { get; set; }
        public string id { get; set; }
    }

    public class EntraIDUserList
    {
        public List<EntraIDUser> value { get; set; }
    }
}