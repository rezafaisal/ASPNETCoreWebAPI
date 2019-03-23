using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using CoreBookStoreWebAPI.Models;

namespace CoreBookStoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Author>> Get()
        {
            BookStoreDataContext db = new BookStoreDataContext();
            var items = db.Authors.ToList();

            return items;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Author> Get(int id)
        {
            BookStoreDataContext db = new BookStoreDataContext();
            var item = db.Authors.SingleOrDefault(p=>p.AuthorID.Equals(id));

            return item;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Author item)
        {
            BookStoreDataContext db = new BookStoreDataContext();
            db.Add(item);
            db.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Author itemNew)
        {
            BookStoreDataContext db = new BookStoreDataContext();
            var item = db.Authors.SingleOrDefault(p=>p.AuthorID.Equals(id));

            item.Name = itemNew.Name;

            db.Update(item);
            db.SaveChangesAsync();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            BookStoreDataContext db = new BookStoreDataContext();
            var item = db.Authors.Find(id);
            db.Authors.Remove(item);
            db.SaveChanges();

        }
    }
}
