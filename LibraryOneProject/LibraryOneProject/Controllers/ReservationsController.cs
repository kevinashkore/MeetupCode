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
    public class ReservationsController : ApiController
    {
        private LibraryContext db = new LibraryContext();

        // GET: api/Reservations
        public IQueryable<Reservation> GetReservations()
        {
            return db.Reservations;
            //return db.BranchBooks.Select(x => x.Reservation);
        }

        [Route("api/GetReservationsForCurrentUser/{patronId}")]
        // GET: api/GetReservationsForCurrentUser/1
        public IQueryable<Reservation> GetReservationsForCurrentUser(int patronId)
        {
            return db.Reservations.Where(x=>x.PatronID == patronId);
        }

        // GET: api/Reservations/5
        [ResponseType(typeof(Reservation))]
        public IHttpActionResult GetReservation(int id)
        {
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return NotFound();
            }

            return Ok(reservation);
        }

        // PUT: api/Reservations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutReservation(int id, Reservation reservation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reservation.BranchBookID)
            {
                return BadRequest();
            }

            db.Entry(reservation).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservationExists(id))
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

        // POST: api/Reservations
        [ResponseType(typeof(Reservation))]
        public IHttpActionResult PostReservation(Reservation reservation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Reservations.Add(reservation);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ReservationExists(reservation.BranchBookID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = reservation.BranchBookID }, reservation);
        }

        // DELETE: api/Reservations/5
        [ResponseType(typeof(Reservation))]
        public IHttpActionResult DeleteReservation(int id)
        {
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return NotFound();
            }

            db.Reservations.Remove(reservation);
            db.SaveChanges();

            return Ok(reservation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReservationExists(int id)
        {
            return db.Reservations.Count(e => e.BranchBookID == id) > 0;
        }
    }
}