using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppServerConnection.Models
{
	public class EntraIDApplication
	{
		public string displayName { get; set; }
		public string appID { get; set; }
		public string publisherDomain { get; set; }
		public string signInAudience { get; set; }
	}

	public class EntraIDApplicationList
	{
		public List<EntraIDApplication> value { get; set; }
	}
}