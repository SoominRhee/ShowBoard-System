using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppServerConnection.DTOs
{
    public class ADTreeNode
    {
        public string Name { get; set; }
        public string DistinguishedName { get; set; }
        public string SchemaClassName { get; set; }
    }
}