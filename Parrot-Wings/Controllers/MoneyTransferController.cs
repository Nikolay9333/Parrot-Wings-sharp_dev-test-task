using System.Collections.Generic;
using System.Linq;
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
            _dbRepository = dbRepository;
        }

        #endregion

        // GET: api/MoneyTransfers
        [ResponseType(typeof(IEnumerable<MoneyTransfer>))]
        public IHttpActionResult Get()
        {
            var moneyTransfers = _dbRepository.GetAll<MoneyTransfer>();

            //TODO возмжоно не зайдет 
            return moneyTransfers?.Count() > 0
                ? (IHttpActionResult) Ok(moneyTransfers)
                : NotFound();
        }

        // GET: api/MoneyTransfers/5
        [ResponseType(typeof(MoneyTransfer))]
        public IHttpActionResult Get(int id)
        {
            var moneyTransfer = _dbRepository.Get<MoneyTransfer>(id);

            return moneyTransfer == null
                ? (IHttpActionResult) Ok(moneyTransfer)
                : NotFound();
        }

        // POST: api/MoneyTransfers
        public IHttpActionResult Post(MoneyTransfer moneyTransfer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _dbRepository.Add(moneyTransfer);
            _dbRepository.Commit();

            return Json(new {id = moneyTransfer.Id});
        }

        // PUT: api/MoneyTransfers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(MoneyTransfer moneyTransfer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _dbRepository.Attach(moneyTransfer);
            _dbRepository.Commit();

            return Ok();
        }

        // DELETE: api/MoneyTransfers/5
        [ResponseType(typeof(MoneyTransfer))]
        public IHttpActionResult Delete(int id)
        {
            var moneyTransfer = _dbRepository.Get<MoneyTransfer>(id);
            if (moneyTransfer == null)
            {
                return NotFound();
            }

            _dbRepository.Delete(moneyTransfer);
            _dbRepository.Commit();

            return Ok(moneyTransfer);
        }
    }
}