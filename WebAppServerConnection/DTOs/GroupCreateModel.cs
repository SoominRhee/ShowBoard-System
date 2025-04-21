using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppServerConnection.DTOs
{
	public class GroupCreateModel
	{
        public string ParentDn { get; set; }
        public string GroupName { get; set; }
	}
}