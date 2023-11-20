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
    public class GörevliController : ApiController
    {
        private ManavEntities db = new ManavEntities();

        // GET: api/Görevli
        public IQueryable<Görevli> GetGörevli()
        {
            return db.Görevli;
        }

        // GET: api/Görevli/5
        [ResponseType(typeof(Görevli))]
        public async Task<IHttpActionResult> GetGörevli(int id)
        {
            Görevli görevli = await db.Görevli.FindAsync(id);
            if (görevli == null)
            {
                return NotFound();
            }

            return Ok(görevli);
        }

        // PUT: api/Görevli/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGörevli(int id, Görevli görevli)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != görevli.görevliID)
            {
                return BadRequest();
            }

            db.Entry(görevli).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GörevliExists(id))
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

        // POST: api/Görevli
        [ResponseType(typeof(Görevli))]
        public async Task<IHttpActionResult> PostGörevli(Görevli görevli)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Görevli.Add(görevli);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = görevli.görevliID }, görevli);
        }

        // DELETE: api/Görevli/5
        [ResponseType(typeof(Görevli))]
        public async Task<IHttpActionResult> DeleteGörevli(int id)
        {
            Görevli görevli = await db.Görevli.FindAsync(id);
            if (görevli == null)
            {
                return NotFound();
            }

            db.Görevli.Remove(görevli);
            await db.SaveChangesAsync();

            return Ok(görevli);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GörevliExists(int id)
        {
            return db.Görevli.Count(e => e.görevliID == id) > 0;
        }
    }
}