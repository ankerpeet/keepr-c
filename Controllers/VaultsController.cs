using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using keepr.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
    [Route("api/[controller]")]
    public class VaultsController : Controller
    {
        public KeeprContext _db { get; private set; }

        public VaultsController(KeeprContext db)
        {
            _db = db;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<Vault> Get()
        {
            return _db.Vaults;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Vault Get(int id)
        {
            return _db.Vaults.Find(id);
        }

        // POST api/values
        [Authorize]
        [HttpPost]
        public string Post([FromBody]Vault vault)
        {
            _db.Vaults.Add(vault);
            _db.SaveChanges();
            return "Vault successfully created.";
        }

        [Authorize]
        [HttpPut("{id}")]
        public string Put(int id, [FromBody]Vault vault)
        {
            var oldVault = _db.Vaults.Find(id);
            oldVault = vault;
            _db.SaveChanges();
            return "Successfully updated";

        }

        // DELETE api/values/5
        [Authorize]
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            _db.Remove(_db.Vaults.Find(id));
            _db.SaveChanges();
            return "Vault successfully removed";
        }
    }
}
