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
using MyCircles.BLL.DTO;

namespace MyCircles.Controller
{
    public class FollowsController : ApiController
    {
        private MyCirclesEntityModel db = new MyCirclesEntityModel();

        // GET: api/Follows
        [HttpGet]
        [Route("api/Follows")]
        public IQueryable<Follow> GetFollows()
        {
            return db.Follows;
        }

        [ResponseType(typeof(Follow))]
        public async Task<IHttpActionResult> GetFollow(int id)
        {
            Follow follow = await db.Follows.FindAsync(id);

            if (follow == null)
            {
                return NotFound();
            }

            return Ok(follow);
        }

        [HttpGet]
        [Route("api/Follows/GetFollowByUsers/{followerId:int}/{followingId:int}")]
        [ResponseType(typeof(bool))]
        public async Task<IHttpActionResult> GetFollowByUsers(int followerId, int followingId)
        {
            bool followExists = (await db.Follows.Where(f => f.FollowerId == followerId && f.FollowingId == followingId).FirstOrDefaultAsync() != null) ? true : false;

            return Ok(followExists);
        }

        // PUT: api/Follows/5
        [HttpPut]
        [Route("api/Follows")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutFollow(int id, Follow follow)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != follow.Id)
            {
                return BadRequest();
            }

            db.Entry(follow).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FollowExists(id))
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

        // POST: api/Follows
        [HttpPost]
        [Route("api/Follows")]
        [ResponseType(typeof(Follow))]
        public async Task<IHttpActionResult> PostFollow(Follow follow)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingFollow = await db.Follows.Where(f => f.FollowerId == follow.FollowerId && f.FollowingId == follow.FollowingId).FirstOrDefaultAsync();
            var followingUser = await db.Users.Where(u => u.Id == follow.FollowingId).FirstOrDefaultAsync();
            var followerUser = await db.Users.Where(u => u.Id == follow.FollowerId).FirstOrDefaultAsync();
            var followDto = new FollowDTO();

            if (existingFollow == null)
            {
                follow.CreatedAt = DateTime.Now;
                follow.IsDeleted = false;
                db.Follows.Add(follow);

                followDto.FollowerId = follow.FollowerId;
                followDto.FollowingId = follow.FollowingId;

                Notification followingNotification = new Notification();
                followingNotification.Type = "positive";
                followingNotification.Action = "Gained a follower";
                followingNotification.Source = $"a user named {followerUser.Name} following you";
                followingNotification.UserId = followingUser.Id;
                followingNotification.CreatedAt = DateTime.Now;
                db.Notifications.Add(followingNotification);

                Notification followerNotification = new Notification();
                followerNotification.Type = "positive";
                followerNotification.Action = $"Followed {followingUser.Name}";
                followerNotification.Source = "following them";
                followerNotification.UserId = followerUser.Id;
                followerNotification.CreatedAt = DateTime.Now;
                db.Notifications.Add(followerNotification);
            }
            else
            {
                db.Follows.Remove(existingFollow);

                Notification followingNotification = new Notification();
                followingNotification.Type = "negative";
                followingNotification.Action = "Lost a follower";
                followingNotification.Source = $"a user named {followerUser.Name} unfollowing you";
                followingNotification.UserId = followingUser.Id;
                followingNotification.CreatedAt = DateTime.Now;
                db.Notifications.Add(followingNotification);

                Notification followerNotification = new Notification();
                followerNotification.Type = "negative";
                followerNotification.Action = $"Unfollowed {followingUser.Name}";
                followerNotification.Source = "unfollowing them";
                followerNotification.UserId = followerUser.Id;
                followerNotification.CreatedAt = DateTime.Now;
                db.Notifications.Add(followerNotification);
            }

            await db.SaveChangesAsync();

            return Ok(followDto);
        }

        // DELETE: api/Follows/5
        [HttpDelete]
        [Route("api/Follows/{id:int}")]
        [ResponseType(typeof(Follow))]
        public async Task<IHttpActionResult> DeleteFollow(int id)
        {
            Follow follow = await db.Follows.FindAsync(id);
            if (follow == null)
            {
                return NotFound();
            }

            db.Follows.Remove(follow);
            await db.SaveChangesAsync();

            return Ok(follow);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FollowExists(int id)
        {
            return db.Follows.Count(e => e.Id == id) > 0;
        }
    }
}