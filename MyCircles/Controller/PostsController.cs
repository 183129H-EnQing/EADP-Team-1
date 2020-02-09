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
using MyCircles.DAL;

namespace MyCircles.Controller
{
    public class PostsController : ApiController
    {
        private MyCirclesEntityModel db = new MyCirclesEntityModel();

        // GET: api/Posts
        [HttpGet]
        [Route("api/posts")]
        public IQueryable<Post> GetPosts()
        {
            return db.Posts;
        }

        // GET: api/Posts/5
        [HttpGet]
        [Route("api/posts/{searchQuery}")]
        [ResponseType(typeof(IEnumerable<Post>))]
        public async Task<IHttpActionResult> GetPostsBySearchQuery(string searchQuery)
        {
            var posts = await
                db.Posts
                    .Where(p => p.Content.Contains(searchQuery))
                    .Select(p => new PostDTO()
                    {
                        Id = p.Id,
                        Content = p.Content,
                        Image = p.Image,
                        UserId = p.UserId,
                        CircleId = p.CircleId,
                        DateTime = p.DateTime,
                        User = 
                            new UserDTO()
                            {
                                Id = p.User.Id,
                                Username = p.User.Username,
                                EmailAddress = p.User.EmailAddress,
                                Name = p.User.Name,
                                Bio = p.User.Bio,
                                Latitude = p.User.Latitude,
                                Longitude = p.User.Longitude,
                                City = p.User.City,
                                ProfileImage = p.User.ProfileImage,
                                IsLoggedIn = p.User.IsLoggedIn
                            }
                    })
                    .OrderBy(p => p.DateTime)
                    .ToListAsync();

            if (posts == null)
            {
                return NotFound();
            }

            return Ok(posts);
        }

        // PUT: api/Posts/5
        [HttpPut]
        [Route("api/Posts")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPost(int id, Post post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != post.Id)
            {
                return BadRequest();
            }

            db.Entry(post).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(id))
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

        // POST: api/Posts
        [HttpPost]
        [Route("api/Posts")]
        [ResponseType(typeof(Post))]
        public async Task<IHttpActionResult> PostPost(Post post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Posts.Add(post);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = post.Id }, post);
        }

        [HttpDelete]
        [Route("api/Posts/{id:int}")]
        // DELETE: api/Posts/5
        [ResponseType(typeof(Post))]
        public async Task<IHttpActionResult> DeletePost(int id)
        {
            Post post = await db.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            db.Posts.Remove(post);
            await db.SaveChangesAsync();

            return Ok(post);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PostExists(int id)
        {
            return db.Posts.Count(e => e.Id == id) > 0;
        }
    }
}