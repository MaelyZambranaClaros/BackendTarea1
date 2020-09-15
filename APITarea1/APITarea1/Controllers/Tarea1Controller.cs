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
using APITarea1.Models;

namespace APITarea1.Controllers
{
    public class Tarea1Controller : ApiController
    {
        private DataContext db = new DataContext();

        public object GetPrueba()
        {
            throw new NotImplementedException();
        }

        // GET: api/Tarea1
        [Authorize]
        public IQueryable<Tarea1> GetTarea1()
        {
            return db.Tarea1;
        }

        // GET: api/Tarea1/5
        [Authorize]
        [ResponseType(typeof(Tarea1))]
        public IHttpActionResult GetTarea1(int id)
        {
            Tarea1 tarea1 = db.Tarea1.Find(id);
            if (tarea1 == null)
            {
                return NotFound();
            }

            return Ok(tarea1);
        }

        // PUT: api/Tarea1/5
        [Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTarea1(int id, Tarea1 tarea1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tarea1.ZambranaID)
            {
                return BadRequest();
            }

            db.Entry(tarea1).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tarea1Exists(id))
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

        // POST: api/Tarea1
        [Authorize]
        [ResponseType(typeof(Tarea1))]
        public IHttpActionResult PostTarea1(Tarea1 tarea1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tarea1.Add(tarea1);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tarea1.ZambranaID }, tarea1);
        }

        // DELETE: api/Tarea1/5
        [Authorize]
        [ResponseType(typeof(Tarea1))]
        public IHttpActionResult DeleteTarea1(int id)
        {
            Tarea1 tarea1 = db.Tarea1.Find(id);
            if (tarea1 == null)
            {
                return NotFound();
            }

            db.Tarea1.Remove(tarea1);
            db.SaveChanges();

            return Ok(tarea1);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Tarea1Exists(int id)
        {
            return db.Tarea1.Count(e => e.ZambranaID == id) > 0;
        }
    }
}