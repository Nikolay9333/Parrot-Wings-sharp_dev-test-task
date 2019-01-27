using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using ParrotWings.Entities;
using ParrotWings.Interfaces;
using  PwUser = ParrotWings.Entities.User;

namespace Parrot_Wings.Controllers
{
    [System.Web.Http.Authorize]
    public class UsersController : ApiController
    {
        #region Fields

        private readonly IDbRepository _dbRepository;

        #endregion

        #region Controllers

        public UsersController(IDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        #endregion

        // GET: api/Users
        [ResponseType(typeof(IEnumerable<User>))]
        public IHttpActionResult Get()
        {
            var q = User;
            var users = _dbRepository.GetAll<User>().Select(u => new {u.UserName, u.Email, u.Balance}).ToList();

            return users?.Count > 0
                ? (IHttpActionResult) Ok(users)
                : NotFound();
        }

        // GET: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult Get(long id)
        {
            var email = User.Identity.Name;
            PwUser.GetUserByEmail(_dbRepository, email);

            var user = _dbRepository.Get<User>(id);

            return Ok(user);
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _dbRepository.Attach(user);
            _dbRepository.Commit();

            return Ok();
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult Delete(int id)
        {
            var user = _dbRepository.Get<User>(id);

            if (user == null)
            {
                return NotFound();
            }

            _dbRepository.Delete(user);
            _dbRepository.Commit();

            return Ok(user);
        }
    }
}