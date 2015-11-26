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
    public class PatronsController : ApiController
    {
        private LibraryContext db = new LibraryContext();

        // GET: api/Patrons
        public IQueryable<Patron> GetPatrons()
        {
            return db.Patrons;
        }

        // GET: api/Patrons/5
        [ResponseType(typeof(Patron))]
        public IHttpActionResult GetPatron(int id)
        {
            Patron patron = db.Patrons.Find(id);
            if (patron == null)
            {
                return NotFound();
            }

            return Ok(patron);
        }

        // PUT: api/Patrons/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPatron(int id, Patron patron)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != patron.ID)
            {
                return BadRequest();
            }

            db.Entry(patron).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatronExists(id))
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

        // POST: api/Patrons
        [ResponseType(typeof(Patron))]
        public IHttpActionResult PostPatron(Patron patron)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Patrons.Add(patron);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = patron.ID }, patron);
        }

        // DELETE: api/Patrons/5
        [ResponseType(typeof(Patron))]
        public IHttpActionResult DeletePatron(int id)
        {
            Patron patron = db.Patrons.Find(id);
            if (patron == null)
            {
                return NotFound();
            }

            db.Patrons.Remove(patron);
            db.SaveChanges();

            return Ok(patron);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PatronExists(int id)
        {
            return db.Patrons.Count(e => e.ID == id) > 0;
        }
    }
}