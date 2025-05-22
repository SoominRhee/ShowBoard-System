using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppServerConnection.DTOs
{
	public class GroupMembersRequest
	{
        public string GroupId { get; set; }
        public List<string> UserIds { get; set; }
    }
}