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
    public class MeyvelersController : ApiController
    {
        private ManavEntities db = new ManavEntities();

        // GET: api/Meyvelers
        public IQueryable<Meyveler> GetMeyvelers()
        {
            return db.Meyvelers;
        }

        // GET: api/Meyvelers/5
        [ResponseType(typeof(Meyveler))]
        public async Task<IHttpActionResult> GetMeyveler(int id)
        {
            Meyveler meyveler = await db.Meyvelers.FindAsync(id);
            if (meyveler == null)
            {
                return NotFound();
            }

            return Ok(meyveler);
        }

        // PUT: api/Meyvelers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMeyveler(int id, Meyveler meyveler)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != meyveler.meyveID)
            {
                return BadRequest();
            }

            db.Entry(meyveler).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeyvelerExists(id))
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

        // POST: api/Meyvelers
        [ResponseType(typeof(Meyveler))]
        public async Task<IHttpActionResult> PostMeyveler(Meyveler meyveler)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Meyvelers.Add(meyveler);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = meyveler.meyveID }, meyveler);
        }

        // DELETE: api/Meyvelers/5
        [ResponseType(typeof(Meyveler))]
        public async Task<IHttpActionResult> DeleteMeyveler(int id)
        {
            Meyveler meyveler = await db.Meyvelers.FindAsync(id);
            if (meyveler == null)
            {
                return NotFound();
            }

            db.Meyvelers.Remove(meyveler);
            await db.SaveChangesAsync();

            return Ok(meyveler);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MeyvelerExists(int id)
        {
            return db.Meyvelers.Count(e => e.meyveID == id) > 0;
        }
    }
}