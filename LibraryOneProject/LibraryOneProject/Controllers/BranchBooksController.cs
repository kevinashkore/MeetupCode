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
    public class BranchBooksController : ApiController
    {
        private LibraryContext db = new LibraryContext();

        // GET: api/BranchBooks
        public IQueryable<BranchBook> GetBranchBooks()
        {
            return db.BranchBooks;
        }

        // GET: api/BranchBooks/5
        [ResponseType(typeof(BranchBook))]
        public IHttpActionResult GetBranchBook(int id)
        {
            BranchBook branchBook = db.BranchBooks.Find(id);
            if (branchBook == null)
            {
                return NotFound();
            }

            return Ok(branchBook);
        }

        // PUT: api/BranchBooks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBranchBook(int id, BranchBook branchBook)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != branchBook.ID)
            {
                return BadRequest();
            }

            db.Entry(branchBook).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BranchBookExists(id))
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

        // POST: api/BranchBooks
        [ResponseType(typeof(BranchBook))]
        public IHttpActionResult PostBranchBook(BranchBook branchBook)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BranchBooks.Add(branchBook);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = branchBook.ID }, branchBook);
        }

        // DELETE: api/BranchBooks/5
        [ResponseType(typeof(BranchBook))]
        public IHttpActionResult DeleteBranchBook(int id)
        {
            BranchBook branchBook = db.BranchBooks.Find(id);
            if (branchBook == null)
            {
                return NotFound();
            }

            db.BranchBooks.Remove(branchBook);
            db.SaveChanges();

            return Ok(branchBook);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BranchBookExists(int id)
        {
            return db.BranchBooks.Count(e => e.ID == id) > 0;
        }
    }
}