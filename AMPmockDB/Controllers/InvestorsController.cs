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
    public class InvestorsController : ApiController
    {
        private IGenericRepository<Investor> repository = null;

        
        public InvestorsController()
        {
            repository = new GenericRepository<Investor>();
        }
        // GET: api/Investors
        
        public IEnumerable<Investor> GetInvestors()
        {
            return repository.GetAll();
        }

        // GET: api/Investors/5
        [ResponseType(typeof(Investor))]
        public IHttpActionResult GetInvestor([FromBody]Guid id)
        {
            Investor investor = repository.GetById(id);
            if (investor == null)
            {
                return NotFound();
            }

            return Ok(investor);
        }

        // PUT: api/Investors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInvestor(Guid id, Investor investor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != investor.Investor_ID)
            {
                return BadRequest();
            }

            repository.Update(investor);
            
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Investors
        [ResponseType(typeof(Investor))]
        public IHttpActionResult PostInvestor(Investor investor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repository.Insert(investor);

            return CreatedAtRoute("DefaultApi", new { id = investor.Investor_ID }, investor);
        }

        // DELETE: api/Investors/5
        [ResponseType(typeof(Investor))]
        public IHttpActionResult DeleteInvestor(Guid id)
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