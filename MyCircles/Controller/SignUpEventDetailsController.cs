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
    public class SignUpEventDetailsController : ApiController
    {
        private MyCirclesEntityModel db = new MyCirclesEntityModel();

        // GET: api/SignUpEventDetails
        [HttpGet]
        [Route("api/signupeventdetails")]
        public IQueryable<SignUpEventDetail> GetSignUpEventDetails()
        {
            return db.SignUpEventDetails;
        }

        // GET: api/SignUpEventDetails/5
        [HttpGet]
        [Route("api/signupeventdetails/{eventId:int}")]
        [ResponseType(typeof(EventSignUpDetailsDTO))]
        public async Task<IHttpActionResult> GetSignUpEventDetail(int eventId)
        {

            var signUpEventDetailsList = await db.SignUpEventDetails.Where(event1 => event1.eventId == eventId)
                .Select(s => new EventSignUpDetailsDTO()
                {
                    userId = s.userId
                })
                .ToListAsync();

            if (signUpEventDetailsList == null)
            {
                return NotFound();
            }

            return Ok(signUpEventDetailsList);
        }

        // PUT: api/SignUpEventDetails/5
        [HttpPut]
        [Route("api/signupeventdetails")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSignUpEventDetail(int id, SignUpEventDetail signUpEventDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != signUpEventDetail.Id)
            {
                return BadRequest();
            }

            db.Entry(signUpEventDetail).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SignUpEventDetailExists(id))
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

        // POST: api/SignUpEventDetails
        [HttpPost]
        [Route("api/signupeventdetails")]
        [ResponseType(typeof(SignUpEventDetail))]
        public async Task<IHttpActionResult> PostSignUpEventDetail(SignUpEventDetail signUpEventDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SignUpEventDetails.Add(signUpEventDetail);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = signUpEventDetail.Id }, signUpEventDetail);
        }

        // DELETE: api/SignUpEventDetails/5
        [HttpDelete]
        [Route("api/signupeventdetails")]
        [ResponseType(typeof(SignUpEventDetail))]
        public async Task<IHttpActionResult> DeleteSignUpEventDetail(int id)
        {
            SignUpEventDetail signUpEventDetail = await db.SignUpEventDetails.FindAsync(id);
            if (signUpEventDetail == null)
            {
                return NotFound();
            }

            db.SignUpEventDetails.Remove(signUpEventDetail);
            await db.SaveChangesAsync();

            return Ok(signUpEventDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SignUpEventDetailExists(int id)
        {
            return db.SignUpEventDetails.Count(e => e.Id == id) > 0;
        }
    }
}