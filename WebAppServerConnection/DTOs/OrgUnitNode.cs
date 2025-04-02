using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppServerConnection.DTOs
{
    public class OrgUnitNode
    {
        public string Name { get; set; }
        public List<OrgUnitNode> Children { get; set; }
    }
}