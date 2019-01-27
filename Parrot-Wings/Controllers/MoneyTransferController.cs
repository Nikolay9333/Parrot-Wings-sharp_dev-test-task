using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ParrotWings.Entities;
using ParrotWings.Interfaces;

namespace Parrot_Wings.Controllers
{
    public class MoneyTransferController : ApiController
    {
        #region Fields

        private readonly IDbRepository _dbRepository;

        public MoneyTransferController(IDbRepository dbRepository)
        {
            this._dbRepository = dbRepository;
        }

        public MoneyTransferController()
        {

        }

        #endregion

        // GET: api/MoneyTransfers
        [ResponseType(typeof(IEnumerable<MoneyTransfer>))]
        public IHttpActionResult Get()
        {
            var MoneyTransfers = _dbRepository.GetAll<MoneyTransfer>();

            //TODO возмжоно не зайдет 
            return MoneyTransfers?.Count() > 0
                ? (IHttpActionResult) Ok(MoneyTransfers)
                : NotFound();
        }

        // GET: api/MoneyTransfers/5
        [ResponseType(typeof(MoneyTransfer))]
        public IHttpActionResult Get(int id)
        {
            var MoneyTransfer = _dbRepository.Get<MoneyTransfer>(id);

            return MoneyTransfer == null
                ? (IHttpActionResult) Ok(MoneyTransfer)
                : NotFound();
        }

        // POST: api/MoneyTransfers
        public IHttpActionResult Post(MoneyTransfer MoneyTransfer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _dbRepository.Add(MoneyTransfer);
            _dbRepository.Commit();

            return Json(new {id = MoneyTransfer.Id});
        }

        // PUT: api/MoneyTransfers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(MoneyTransfer MoneyTransfer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _dbRepository.Attach(MoneyTransfer);
            _dbRepository.Commit();

            return Ok();
        }

        // DELETE: api/MoneyTransfers/5
        [ResponseType(typeof(MoneyTransfer))]
        public IHttpActionResult Delete(int id)
        {
            var MoneyTransfer = _dbRepository.Get<MoneyTransfer>(id);
            if (MoneyTransfer == null)
            {
                return NotFound();
            }

            _dbRepository.Delete(MoneyTransfer);
            _dbRepository.Commit();

            return Ok(MoneyTransfer);
        }
    }
}