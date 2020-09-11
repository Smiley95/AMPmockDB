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
    public class PortfoliosController : ApiController
    {
        private IGenericRepository<Portfolio> repository = null;


        public PortfoliosController()
        {
            repository = new GenericRepository<Portfolio>();
        }
        // GET: api/Portfolios

        public IEnumerable<Portfolio> GetPortfolios()
        {
            return repository.GetAll();
        }

        // GET: api/Portfolios/5
        [ResponseType(typeof(Portfolio))]
        public IHttpActionResult GetPortfolio( Guid id)
        {
            Portfolio portfolio = repository.GetById(id);
            if (portfolio == null)
            {
                return NotFound();
            }

            return Ok(portfolio);
        }

        // PUT: api/Portfolios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPortfolio(Guid id, Portfolio portfolio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != portfolio.Portfolio_ID)
            {
                return BadRequest();
            }

            repository.Update(portfolio);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Portfolios
        [ResponseType(typeof(Portfolio))]
        public IHttpActionResult PostPortfolio(Portfolio portfolio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repository.Insert(portfolio);

            return CreatedAtRoute("DefaultApi", new { id = portfolio.Portfolio_ID }, portfolio);
        }

        // DELETE: api/Portfolios/5
        [ResponseType(typeof(Portfolio))]
        public IHttpActionResult DeletePortfolio(Guid id)
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