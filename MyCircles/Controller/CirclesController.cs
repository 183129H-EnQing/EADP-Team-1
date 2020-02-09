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
using MyCircles.BLL;

namespace MyCircles.Controller
{
    public class CirclesController : ApiController
    {
        private MyCirclesEntityModel db = new MyCirclesEntityModel();

        // GET: api/Circles
        public IQueryable<Circle> GetCircles()
        {
            return db.Circles;
        }

        // GET: api/Circles/5
        [ResponseType(typeof(Circle))]
        public async Task<IHttpActionResult> GetCircle(string id)
        {
            Circle circle = await db.Circles.FindAsync(id);
            if (circle == null)
            {
                return NotFound();
            }

            return Ok(circle);
        }

        // PUT: api/Circles/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCircle(string id, Circle circle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != circle.Id)
            {
                return BadRequest();
            }

            db.Entry(circle).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CircleExists(id))
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

        // POST: api/Circles
        [ResponseType(typeof(Circle))]
        public async Task<IHttpActionResult> PostCircle(Circle circle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Circles.Add(circle);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CircleExists(circle.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = circle.Id }, circle);
        }

        // DELETE: api/Circles/5
        [ResponseType(typeof(Circle))]
        public async Task<IHttpActionResult> DeleteCircle(string id)
        {
            Circle circle = await db.Circles.FindAsync(id);
            if (circle == null)
            {
                return NotFound();
            }

            db.Circles.Remove(circle);
            await db.SaveChangesAsync();

            return Ok(circle);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CircleExists(string id)
        {
            return db.Circles.Count(e => e.Id == id) > 0;
        }
    }
}