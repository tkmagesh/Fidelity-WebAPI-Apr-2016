using _02_BugApiServer.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace _02_BugApiServer.Controllers
{
    public class BugsController : ApiController
    {
        private static IList<Bug> _bugsList = new List<Bug> {
            new Bug { Id = 1, Name = "Bug - 1", IsClosed = false, createdAt = new DateTime(2015, 3, 13) },
            new Bug { Id = 2, Name = "Bug - 2", IsClosed = false, createdAt = new DateTime(2015, 3, 15) },
            new Bug { Id = 3, Name = "Bug - 3", IsClosed = false, createdAt = new DateTime(2016, 4, 11) },
            new Bug { Id = 4, Name = "Bug - 4", IsClosed = false, createdAt = new DateTime(2016, 4, 12) },
            new Bug { Id = 5, Name = "Bug - 5", IsClosed = false, createdAt = new DateTime(2016, 4, 13) },
            new Bug { Id = 6, Name = "Bug - 6", IsClosed = false, createdAt = new DateTime(2016, 4, 16) }
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
        
        public  IHttpActionResult Get(int year, int month = 0, int day = 0)
        {
            var bugs = _bugsList.Where(b => b.createdAt.Year == year);
            if (month > 0)
                bugs = bugs.Where(b => b.createdAt.Month == month);
            if (day > 0)
                bugs = bugs.Where(b => b.createdAt.Day == day);
            if (bugs.Any())
                return Ok(bugs);
            return NotFound();
        }

        // POST: api/Bugs
        public IHttpActionResult Post(Bug bug)
        {
            if (ModelState.IsValid)
            {
                bug.Id = _bugsList.Max(b => b.Id) + 1;
                _bugsList.Add(bug);
                return Created<Bug>(Url.Link("DefaultApi", new { id = bug.Id }), bug);
            }
            
            var error = ModelState["bug"].Errors.Aggregate(string.Empty, (result , modelError) 
                => result += modelError.Exception.Message);

            return BadRequest(error);
            
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
