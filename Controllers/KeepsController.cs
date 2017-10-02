using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using keepr.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace keepr.Controllers
{
    [Route("api/[controller]")]
    public class KeepsController : Controller
    {
        public KeeprContext _db { get; private set; }

        public KeepsController(KeeprContext db)
        {
            _db = db;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<Keep> Get()
        {
            return _db.Keeps;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Keep Get(int id)
        {
            return _db.Keeps.Find(id);
        }

        // POST api/values
        [Authorize]
        [HttpPost]
        public string Post([FromBody]Keep keep)
        {
            _db.Keeps.Add(keep);
            _db.SaveChanges();
            return "Keep successfully created.";
        }

        [Authorize]
        [HttpPut("{id}")]
        public string Put(int id, [FromBody]Keep keep)
        {
            var oldKeep = _db.Keeps.Find(id);
            oldKeep = keep;
            _db.SaveChanges();
            return "Successfully updated";

        }

        // DELETE api/values/5
        [Authorize]
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            _db.Remove(_db.Keeps.Find(id));
            _db.SaveChanges();
            return "Keep successfully removed";
        }
    }
}
