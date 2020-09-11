using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AMPmockDB.DBContext;
using AMPmockDB.Repositories;

namespace AMPmockDB.Controllers
{
    [Authorize(Roles = "expert")]
    public class UsersController : ApiController
    {
        private IGenericRepository<User> repository = null;


        public UsersController()
        {
            repository = new GenericRepository<User>();
        }
        // GET: api/Users

        public IEnumerable<User> GetUsers()
        {
            return repository.GetAll();
        }

        // GET: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser([FromBody] Guid id)
        {
            User user = repository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser(string id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.user_email)
            {
                return BadRequest();
            }

            repository.Update(user);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Users
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repository.Insert(user);

            return CreatedAtRoute("DefaultApi", new { id = user.user_email }, user);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(string id)
        {
            repository.Delete(id);

            return Ok(id);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}