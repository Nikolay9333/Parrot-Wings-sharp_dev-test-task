using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using ParrotWings.Entities;
using ParrotWings.Interfaces;
using Parrot_Wings.Models;
using  PwUser = ParrotWings.Entities.User;
using  MTHistory = ParrotWings.Entities.MoneyTransferHistory;

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
            var enumerable = moneyTransfers.ToList();
            if (enumerable.Count > 0)
            {
                return Ok(enumerable);
            }

            return NotFound();
        }

        // GET: api/MoneyTransfers/5
        [ResponseType(typeof(MoneyTransfer))]
        public IHttpActionResult Get(int id)
        {
            var moneyTransfer = _dbRepository.Get<MoneyTransfer>(id);

            if (moneyTransfer == null)
            {
                return NotFound();
            }

            return Ok(moneyTransfer);
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

            return Ok(new {id = moneyTransfer.Id});
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

        [Authorize]
        [HttpPost]
        [Route("api/ExecuteMoneyTransfer")]
        public IHttpActionResult ExecuteMoneyTransfer([FromBody] MoneyTransferQuery moneyTransferQeury)
        {
            var currentUserEmail = User.Identity.Name;
            var sender = PwUser.GetUserByEmail(_dbRepository, moneyTransferQeury?.SenderEmail);

            if (sender == null || currentUserEmail != sender.Email || sender.Balance < moneyTransferQeury?.Amount)
            {
                return BadRequest();
            }

            var recipient = PwUser.GetUserByEmail(_dbRepository, moneyTransferQeury?.RecipientEmail);
            if (recipient == null)
            {
                return BadRequest();
            }

            _dbRepository.Attach(sender);
            _dbRepository.Attach(recipient);

            using (var transaction = _dbRepository.BeginTransaction())
            {
                try
                {
                    sender.Balance -= moneyTransferQeury.Amount;
                    recipient.Balance += moneyTransferQeury.Amount;

                    var transfer = new MoneyTransfer()
                    {
                        Amount = moneyTransferQeury.Amount,
                        SenderEmail = sender.Email,
                        RecipientEmail = recipient.Email,
                        CommitAt = DateTime.Now
                    };

                    _dbRepository.Add(transfer);
                    _dbRepository.Commit();

                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();

                    return InternalServerError();
                }
            }

            return Ok();
        }

        [Authorize]
        [HttpGet]
        [Route("api/GetMoneyTransferHistory")]
        public IHttpActionResult GetMoneyTransferHistory(string email)
        {
            var history = MTHistory.GetMoneyTransferHistoryByEmail(_dbRepository, email);

            return Ok(history);
        }
    }
}