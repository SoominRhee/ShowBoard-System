using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppServerConnection.Models
{
	public class EntraIDGroup
	{
		public string displayName { get; set; }
		public string description { get; set; }
		public string[] groupTypes { get; set; }
        public string id { get; set; }
    }

	public class EntraIDGroupList
	{
		public List<EntraIDGroup> value { get; set; }
	}
}