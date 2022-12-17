using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BookStoreAPI.Entities;
using BookStoreAPI.Models;


namespace BookStoreAPI.Controllers
{
    public class BookStoresController : ApiController
    {
        private ZlobinovAPIEntities db = new ZlobinovAPIEntities();

        // GET: api/BookStores
        [ResponseType(typeof(List<BookStoreModel>))]
        public IHttpActionResult GetBookStore()
        {
            return Ok(db.BookStore.ToList().ConvertAll(x=> new BookStoreModel(x)));
        }

        // GET: api/BookStores/5
        [ResponseType(typeof(BookStore))]
        public IHttpActionResult GetBookStore(int id)
        {
            BookStore bookStore = db.BookStore.Find(id);
            if (bookStore == null)
            {
                return NotFound();
            }

            return Ok(bookStore);
        }

        // PUT: api/BookStores/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBookStore(int id, BookStore bookStore)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bookStore.id)
            {
                return BadRequest();
            }

            db.Entry(bookStore).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookStoreExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/BookStores
        [ResponseType(typeof(BookStore))]
        public IHttpActionResult PostBookStore(BookStore bookStore)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BookStore.Add(bookStore);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = bookStore.id }, bookStore);
        }

        // DELETE: api/BookStores/5
        [ResponseType(typeof(BookStore))]
        public IHttpActionResult DeleteBookStore(int id)
        {
            BookStore bookStore = db.BookStore.Find(id);
            if (bookStore == null)
            {
                return NotFound();
            }

            db.BookStore.Remove(bookStore);
            db.SaveChanges();

            return Ok(bookStore);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BookStoreExists(int id)
        {
            return db.BookStore.Count(e => e.id == id) > 0;
        }
    }
}