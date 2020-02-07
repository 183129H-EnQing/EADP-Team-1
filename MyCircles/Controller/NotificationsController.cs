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
    public class NotificationsController : ApiController
    {
        private MyCirclesEntityModel db = new MyCirclesEntityModel();

        // GET: api/Notifications
        [HttpGet]
        [Route("api/notifications")]
        public IQueryable<Notification> GetNotifications()
        {
            return db.Notifications;
        }

        // GET: api/Notifications/5
        [HttpGet]
        [Route("api/notifications/{userId:int}")]
        public async Task<IHttpActionResult> GetUserNotifications(int userId)
        {
            var notifications = await 
                db.Notifications
                    .Where(n => n.UserId == userId && n.IsRead == false)
                    .Select(n => new NotificationDTO()
                    {
                        Id = n.Id,
                        Action = n.Action,
                        Source = n.Source,
                        UserId = n.UserId,
                        Type = n.Type,
                        CallToAction = n.CallToAction,
                        CallToActionLink = n.CallToActionLink,
                        IsRead = n.IsRead,
                        AdditionalMessage = n.AdditionalMessage,
                        CreatedAt = n.CreatedAt
                    })
                    .OrderBy(n => n.CreatedAt)
                    .ToListAsync();

            foreach (var notification in await db.Notifications.Where(n => n.UserId == userId && n.IsRead == false).ToListAsync())
            {
                notification.IsRead = true;
                await db.SaveChangesAsync();
            }

            if (notifications == null)
            {
                return NotFound();
            }

            return Ok(notifications);
        }

        // PUT: api/Notifications/5
        [HttpPut]
        [Route("api/notifications")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutNotification(int id, Notification notification)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != notification.Id)
            {
                return BadRequest();
            }

            db.Entry(notification).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotificationExists(id))
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

        // POST: api/Notifications
        [HttpPost]
        [Route("api/notifications")]
        [ResponseType(typeof(Notification))]
        public async Task<IHttpActionResult> PostNotification(Notification notification)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            notification.CreatedAt = DateTime.Now;
            db.Notifications.Add(notification);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = notification.Id }, notification);
        }

        // DELETE: api/Notifications/5
        [HttpDelete]
        [Route("api/notifications/{id:int}")]
        [ResponseType(typeof(Notification))]
        public async Task<IHttpActionResult> DeleteNotification(int id)
        {
            Notification notification = await db.Notifications.FindAsync(id);
            if (notification == null)
            {
                return NotFound();
            }

            db.Notifications.Remove(notification);
            await db.SaveChangesAsync();

            return Ok(notification);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }

            base.Dispose(disposing);
        }

        private bool NotificationExists(int id)
        {
            return db.Notifications.Count(e => e.Id == id) > 0;
        }
    }
}