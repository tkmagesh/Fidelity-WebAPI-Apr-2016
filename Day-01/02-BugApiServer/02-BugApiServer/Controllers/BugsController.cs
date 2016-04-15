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
        public IHttpActionResult Get(int id)
        {
            var b = _bugsList.FirstOrDefault(bug => bug.Id == id);
            if (b == null)
            {
                return NotFound();
            } else
            {
                return Ok<Bug>(b);
            }
        }

        // POST: api/Bugs
        public IHttpActionResult Post(Bug bug)
        {
            bug.Id = _bugsList.Max(b => b.Id) + 1;
            _bugsList.Add(bug);
            return Created<Bug>("/api/bugs/" + bug.Id, bug);
        }

        // PUT: api/Bugs/5
        public IHttpActionResult Put(int id,Bug bug)
        {
            var b = _bugsList.FirstOrDefault(bg => bg.Id == id);
            if (b == null)
            {
                return NotFound();
            }
            b.Name = bug.Name;
            b.IsClosed = bug.IsClosed;
            b.createdAt = bug.createdAt;
            return Ok(b);
        }

        // DELETE: api/Bugs/5
        public void Delete(int id)
        {
        }
    }
}
