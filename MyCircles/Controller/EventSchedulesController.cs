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
    public class EventSchedulesController : ApiController
    {
        private MyCirclesEntityModel db = new MyCirclesEntityModel();

        // GET: api/EventSchedules
        public IQueryable<EventSchedule> GetEventSchedules()
        {
            return db.EventSchedules;
        }

        // GET: api/EventSchedules/5
        [ResponseType(typeof(EventSchedule))]
        public async Task<IHttpActionResult> GetEventSchedule(int id)
        {
            EventSchedule eventSchedule = await db.EventSchedules.FindAsync(id);
            if (eventSchedule == null)
            {
                return NotFound();
            }

            return Ok(eventSchedule);
        }

        // PUT: api/EventSchedules/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEventSchedule(int id, EventSchedule eventSchedule)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eventSchedule.eventScheduleID)
            {
                return BadRequest();
            }

            db.Entry(eventSchedule).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventScheduleExists(id))
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

        // POST: api/EventSchedules
        [ResponseType(typeof(EventSchedule))]
        public async Task<IHttpActionResult> PostEventSchedule(EventSchedule eventSchedule)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EventSchedules.Add(eventSchedule);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = eventSchedule.eventScheduleID }, eventSchedule);
        }

        // DELETE: api/EventSchedules/5
        [ResponseType(typeof(EventSchedule))]
        public async Task<IHttpActionResult> DeleteEventSchedule(int id)
        {
            EventSchedule eventSchedule = await db.EventSchedules.FindAsync(id);
            if (eventSchedule == null)
            {
                return NotFound();
            }

            db.EventSchedules.Remove(eventSchedule);
            await db.SaveChangesAsync();

            return Ok(eventSchedule);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EventScheduleExists(int id)
        {
            return db.EventSchedules.Count(e => e.eventScheduleID == id) > 0;
        }
    }
}