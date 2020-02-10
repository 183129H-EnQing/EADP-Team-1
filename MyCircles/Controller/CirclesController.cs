using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Linq.SqlClient;
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
        [HttpGet]
        [Route("api/Circles")]
        public IQueryable<Circle> GetCircles()
        {
            return db.Circles;
        }

        // GET: api/Circles/5
        [HttpGet]
        [Route("api/Circles/{searchQuery}")]
        [ResponseType(typeof(Circle))]
        public async Task<IHttpActionResult> GetCircle(string searchQuery)
        {
            var circles = 
                await
                    (from c in db.Circles
                    where SqlMethods.Like(c.Id, searchQuery)
                    select new { UserCircle = c }
                )
                .ToListAsync();

            if (circles == null)
            {
                return NotFound();
            }

            return Ok(circles);
        }

        // PUT: api/Circles/5
        [HttpPut]
        [Route("api/Circles")]
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
        [HttpPost]
        [Route("api/Circles")]
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
        [HttpDelete]
        [Route("api/Circles/{id}")]
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