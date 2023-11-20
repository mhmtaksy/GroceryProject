using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using apimvcproje.Models;

namespace apimvcproje.Controllers
{
    public class SebzelersController : ApiController
    {
        private ManavEntities db = new ManavEntities();

        // GET: api/Sebzelers
        public IQueryable<Sebzeler> GetSebzelers()
        {
            return db.Sebzelers;
        }

        // GET: api/Sebzelers/5
        [ResponseType(typeof(Sebzeler))]
        public async Task<IHttpActionResult> GetSebzeler(int id)
        {
            Sebzeler sebzeler = await db.Sebzelers.FindAsync(id);
            if (sebzeler == null)
            {
                return NotFound();
            }

            return Ok(sebzeler);
        }

        // PUT: api/Sebzelers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSebzeler(int id, Sebzeler sebzeler)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sebzeler.sebzeID)
            {
                return BadRequest();
            }

            db.Entry(sebzeler).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SebzelerExists(id))
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

        // POST: api/Sebzelers
        [ResponseType(typeof(Sebzeler))]
        public async Task<IHttpActionResult> PostSebzeler(Sebzeler sebzeler)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sebzelers.Add(sebzeler);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = sebzeler.sebzeID }, sebzeler);
        }

        // DELETE: api/Sebzelers/5
        [ResponseType(typeof(Sebzeler))]
        public async Task<IHttpActionResult> DeleteSebzeler(int id)
        {
            Sebzeler sebzeler = await db.Sebzelers.FindAsync(id);
            if (sebzeler == null)
            {
                return NotFound();
            }

            db.Sebzelers.Remove(sebzeler);
            await db.SaveChangesAsync();

            return Ok(sebzeler);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SebzelerExists(int id)
        {
            return db.Sebzelers.Count(e => e.sebzeID == id) > 0;
        }
    }
}