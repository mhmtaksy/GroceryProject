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
    public class ManavlarsController : ApiController
    {
        private ManavEntities db = new ManavEntities();

        // GET: api/Manavlars
        public IQueryable<Manavlar> GetManavlars()
        {
            return db.Manavlars;
        }

        // GET: api/Manavlars/5
        [ResponseType(typeof(Manavlar))]
        public async Task<IHttpActionResult> GetManavlar(int id)
        {
            Manavlar manavlar = await db.Manavlars.FindAsync(id);
            if (manavlar == null)
            {
                return NotFound();
            }

            return Ok(manavlar);
        }

        // PUT: api/Manavlars/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutManavlar(int id, Manavlar manavlar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != manavlar.manavID)
            {
                return BadRequest();
            }

            db.Entry(manavlar).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManavlarExists(id))
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

        // POST: api/Manavlars
        [ResponseType(typeof(Manavlar))]
        public async Task<IHttpActionResult> PostManavlar(Manavlar manavlar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Manavlars.Add(manavlar);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = manavlar.manavID }, manavlar);
        }

        // DELETE: api/Manavlars/5
        [ResponseType(typeof(Manavlar))]
        public async Task<IHttpActionResult> DeleteManavlar(int id)
        {
            Manavlar manavlar = await db.Manavlars.FindAsync(id);
            if (manavlar == null)
            {
                return NotFound();
            }

            db.Manavlars.Remove(manavlar);
            await db.SaveChangesAsync();

            return Ok(manavlar);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ManavlarExists(int id)
        {
            return db.Manavlars.Count(e => e.manavID == id) > 0;
        }
    }
}