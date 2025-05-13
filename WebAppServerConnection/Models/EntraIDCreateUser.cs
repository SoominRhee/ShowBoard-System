using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppServerConnection.Models
{
	public class EntraIDCreateUser
	{
        public string DisplayName { get; set; }
        public string UserPrincipalName { get; set; }
        public string Password { get; set; }
    }
}