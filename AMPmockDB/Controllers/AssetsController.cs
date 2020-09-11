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
    public class AssetsController : ApiController
    {
        private IGenericRepository<Asset> repository = null;


        public AssetsController()
        {
            repository = new GenericRepository<Asset>();
        }
        // GET: api/Assets

        public IEnumerable<Asset> GetAssets()
        {
            return repository.GetAll();
        }

        // GET: api/Assets/5
        [ResponseType(typeof(Asset))]
        public IHttpActionResult GetAsset([FromBody] Guid id)
        {
            Asset asset = repository.GetById(id);
            if (asset == null)
            {
                return NotFound();
            }

            return Ok(asset);
        }

        // PUT: api/Assets/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAsset(Guid id, Asset asset)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != asset.Asset_ID)
            {
                return BadRequest();
            }

            repository.Update(asset);

            return StatusCode(HttpStatusCode.OK);
        }

        // POST: api/Assets
        [ResponseType(typeof(Asset))]
        public IHttpActionResult PostAsset(Asset asset)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repository.Insert(asset);

            return CreatedAtRoute("DefaultApi", new { id = asset.Asset_ID }, asset);
        }

        // DELETE: api/Assets/5
        [ResponseType(typeof(Asset))]
        public IHttpActionResult DeleteAsset(Guid id)
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