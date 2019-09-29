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
using Seminarska.Models;

namespace Seminarska.Controllers
{
    public class ZivaliIzpisController : ApiController
    {
        private zivaliContext db = new zivaliContext();

        // GET: api/ZivaliIzpis
        public IQueryable<zivali> Getzivalis()
        {
            return db.zivalis;
        }

        // GET: api/ZivaliIzpis/5
        [ResponseType(typeof(zivali))]
        public IHttpActionResult Getzivali(int id)
        {
            zivali zivali = db.zivalis.Find(id);
            if (zivali == null)
            {
                return NotFound();
            }

            return Ok(zivali);
        }

        // PUT: api/ZivaliIzpis/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putzivali(int id, zivali zivali)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != zivali.id)
            {
                return BadRequest();
            }

            db.Entry(zivali).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!zivaliExists(id))
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

        // POST: api/ZivaliIzpis
        [ResponseType(typeof(zivali))]
        public IHttpActionResult Postzivali(zivali zivali)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.zivalis.Add(zivali);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = zivali.id }, zivali);
        }

        // DELETE: api/ZivaliIzpis/5
        [ResponseType(typeof(zivali))]
        public IHttpActionResult Deletezivali(int id)
        {
            zivali zivali = db.zivalis.Find(id);
            if (zivali == null)
            {
                return NotFound();
            }

            db.zivalis.Remove(zivali);
            db.SaveChanges();

            return Ok(zivali);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool zivaliExists(int id)
        {
            return db.zivalis.Count(e => e.id == id) > 0;
        }
    }
}