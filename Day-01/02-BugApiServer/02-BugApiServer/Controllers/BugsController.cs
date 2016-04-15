using _02_BugApiServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _02_BugApiServer.Controllers
{
    public class BugsController : ApiController
    {
        private static IList<Bug> _bugsList = new List<Bug> {
            new Bug { Id = 1, Name = "User authentication failure", IsClosed = false, createdAt = new DateTime(2016, 4, 13) },
            new Bug { Id = 2, Name = "Server communication erratic", IsClosed = false, createdAt = new DateTime(2016, 4, 15) }
        };

        // GET: api/Bugs
        public IEnumerable<Bug> Get()
        {
            return _bugsList;
        }

        // GET: api/Bugs/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Bugs
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Bugs/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Bugs/5
        public void Delete(int id)
        {
        }
    }
}
