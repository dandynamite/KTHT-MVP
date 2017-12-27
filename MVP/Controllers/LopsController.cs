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
using MVP.Models;

namespace MVP.Controllers
{
    public class LopsController : ApiController
    {
        private StudentContext db = new StudentContext();

        // GET: api/Lops
        public IQueryable<Lop> GetLops()
        {
            return db.Lops;
        }

        // GET: api/Lops/5
        [ResponseType(typeof(Lop))]
        public IHttpActionResult GetLop(int id)
        {
            Lop lop = db.Lops.Find(id);
            if (lop == null)
            {
                return NotFound();
            }

            return Ok(lop);
        }

        // PUT: api/Lops/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLop(int id, Lop lop)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lop.Id)
            {
                return BadRequest();
            }

            db.Entry(lop).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LopExists(id))
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

        // POST: api/Lops
        [ResponseType(typeof(Lop))]
        public IHttpActionResult PostLop(Lop lop)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Lops.Add(lop);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = lop.Id }, lop);
        }

        // DELETE: api/Lops/5
        [ResponseType(typeof(Lop))]
        public IHttpActionResult DeleteLop(int id)
        {
            Lop lop = db.Lops.Find(id);
            if (lop == null)
            {
                return NotFound();
            }

            db.Lops.Remove(lop);
            db.SaveChanges();

            return Ok(lop);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LopExists(int id)
        {
            return db.Lops.Count(e => e.Id == id) > 0;
        }
    }
}