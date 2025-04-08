using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppServerConnection.DTOs
{
    public class ADDetail
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string DisplayName { get; set; }
        public string DistinguishedName { get; set; }
        public string Guid { get; set; }
        public string SamAccountName { get; set; }
        public string Mail { get; set; }
        public string Created { get; set; }
    }
}