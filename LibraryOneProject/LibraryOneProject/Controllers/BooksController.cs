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
using LibraryOneProject.Models;

namespace LibraryOneProject.Controllers
{
    public class BooksController : ApiController
    {
        private LibraryContext db = new LibraryContext();

        // GET: api/Books
        public IQueryable<Book> GetBooks()
        {
            //var query = db.Books.Select(x => new { Book = x,  Author = x.Author, ID = x.ID, AuthorID= x.AuthorID, Title=x.Title, BranchBooks = x.BranchBooks.Where(bb => bb.PatronID != null).ToList() });
            //var results = query.ToList();
            //var books = results.AsQueryable();
            //var books = results.Select(x => x.Book).AsQueryable();
            //return books;
            var books = db.Books;
            return books;//.Include(x=>x.BranchBooks);
        }

        // GET: api/Books/5
        [ResponseType(typeof(Book))]
        public IHttpActionResult GetBook(int id)
        {
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        // PUT: api/Books/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBook(int id, Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != book.ID)
            {
                return BadRequest();
            }

            db.Entry(book).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
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

        // POST: api/Books
        [ResponseType(typeof(Book))]
        public IHttpActionResult PostBook(Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Books.Add(book);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = book.ID }, book);
        }

        // DELETE: api/Books/5
        [ResponseType(typeof(Book))]
        public IHttpActionResult DeleteBook(int id)
        {
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }

            db.Books.Remove(book);
            db.SaveChanges();

            return Ok(book);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BookExists(int id)
        {
            return db.Books.Count(e => e.ID == id) > 0;
        }
    }
}