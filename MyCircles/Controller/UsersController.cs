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
    public class UsersController : ApiController
    {
        private MyCirclesEntityModel db = new MyCirclesEntityModel();

        // GET: api/Users
        [HttpGet]
        [Route("api/users")]
        public IQueryable<User> GetUsers()
        {
            return db.Users;
        }

        // GET: api/Users/bob
        [HttpGet]
        [Route("api/users/{searchQuery}")]
        [ResponseType(typeof(List<UserDTO>))]
        public async Task<IHttpActionResult> GetUserBySearchQuery(string searchQuery)
        {
            var users = await 
                db.Users
                    .Where(u => u.Username.Contains(searchQuery) || u.Name.Contains(searchQuery))
                    .Select(p => new UserDTO()
                    {
                        Id = p.Id,
                        Username = p.Username,
                        EmailAddress = p.EmailAddress,
                        Name = p.Name,
                        Bio = p.Bio,
                        Longitude = p.Longitude,
                        City = p.City,
                        ProfileImage = p.ProfileImage,
                        IsLoggedIn = p.IsLoggedIn
                    })
                    .ToListAsync();

            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        //[HttpGet]
        //[Route("api/users/GetFollowingUsers/{userId:int}")]
        //[ResponseType(typeof(bool))]
        //public async Task<IHttpActionResult> GetFollowingUsers(int userId)
        //{
        //    bool followingUsers = (await db.Follows.Where(f => f.FollowerId == followerId && f.FollowingId == followingId).FirstOrDefaultAsync() != null) ? true : false;

        //    return Ok(followExists);
        //}

        // PUT: api/Users/5
        [HttpPut]
        [Route("api/users")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUser(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.Id)
            {
                return BadRequest();
            }

            db.Entry(user).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        [HttpPost]
        [Route("api/users")]
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(user);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete]
        [Route("api/Users/{id:int}")]
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> DeleteUser(int id)
        {
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            db.Users.Remove(user);
            await db.SaveChangesAsync();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.Id == id) > 0;
        }
    }
}