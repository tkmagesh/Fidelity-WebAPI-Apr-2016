using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _02_BugApiServer.Models
{
    public class Bug
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsClosed { get; set; }
        public DateTime createdAt { get; set; }
    }
}