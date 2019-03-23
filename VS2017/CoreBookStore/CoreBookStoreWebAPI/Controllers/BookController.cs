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
    public class BookController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get()
        {
            BookStoreDataContext db = new BookStoreDataContext();
            var items = db.Books.ToList();

            return items;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Book> Get(int id)
        {
            BookStoreDataContext db = new BookStoreDataContext();
            var item = db.Books.SingleOrDefault(p => p.ISBN.Equals(id));

            return item;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Book item)
        {
            BookStoreDataContext db = new BookStoreDataContext();
            db.Add(item);
            db.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Book itemNew)
        {
            BookStoreDataContext db = new BookStoreDataContext();
            var item = db.Books.SingleOrDefault(p => p.ISBN.Equals(id));

            item.CategoryID = itemNew.CategoryID;
            item.Title = itemNew.Title;
            item.Photo = itemNew.Photo;
            item.PublishDate = itemNew.PublishDate;
            item.Price = itemNew.Price;
            item.Quantity = itemNew.Quantity;

            db.Update(item);
            db.SaveChangesAsync();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            BookStoreDataContext db = new BookStoreDataContext();
            var item = db.Books.Find(id);
            db.Books.Remove(item);
            db.SaveChanges();
        }
    }
}
