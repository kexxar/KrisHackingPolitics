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
using KMMOpenNewsBackend.Models;

namespace KMMOpenNewsBackend.Controllers
{
    public class NewsPostsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/NewsPosts
        public IQueryable<NewsPost> GetNewsPosts()
        {
            return db.NewsPosts;
        }

        // GET: api/NewsPosts/5
        [ResponseType(typeof(NewsPost))]
        public async Task<IHttpActionResult> GetNewsPost(int id)
        {
            NewsPost newsPost = await db.NewsPosts.FindAsync(id);
            if (newsPost == null)
            {
                return NotFound();
            }

            return Ok(newsPost);
        }

        // PUT: api/NewsPosts/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutNewsPost(int id, NewsPost newsPost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != newsPost.Id)
            {
                return BadRequest();
            }

            db.Entry(newsPost).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewsPostExists(id))
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

        // POST: api/NewsPosts
        [ResponseType(typeof(NewsPost))]
        public async Task<IHttpActionResult> PostNewsPost(NewsPost newsPost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NewsPosts.Add(newsPost);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = newsPost.Id }, newsPost);
        }

        // DELETE: api/NewsPosts/5
        [ResponseType(typeof(NewsPost))]
        public async Task<IHttpActionResult> DeleteNewsPost(int id)
        {
            NewsPost newsPost = await db.NewsPosts.FindAsync(id);
            if (newsPost == null)
            {
                return NotFound();
            }

            db.NewsPosts.Remove(newsPost);
            await db.SaveChangesAsync();

            return Ok(newsPost);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NewsPostExists(int id)
        {
            return db.NewsPosts.Count(e => e.Id == id) > 0;
        }
    }
}