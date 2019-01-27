using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using ParrotWings.Entities;
using ParrotWings.Interfaces;
using Parrot_Wings.Models;
using  PwUser = ParrotWings.Entities.User;

namespace Parrot_Wings.Controllers
{
    [Authorize]
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
            var users = _dbRepository.GetAll<User>().Select(u => new
            {
                u.UserName,
                u.Email,
                u.Balance
            }).ToList();

            if (users.Count > 0)
            {
                return Ok(users);
            }

            return NotFound();
        }

        // GET: api/Users/5
        [ResponseType(typeof(User))]
        [Route("get-user-info")]
        public IHttpActionResult GetUserInfo()
        {
            var email = User.Identity.Name;
            var user = PwUser.GetUserByEmail(_dbRepository, email);
            if (user == null)
            {
                return BadRequest();
            }

            return Ok(user);
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(RegisterModel registerModel)
        {
            var email = User.Identity.Name;
            var user = PwUser.GetUserByEmail(_dbRepository, email);
            if (!ModelState.IsValid || user == null)
            {
                return BadRequest(ModelState);
            }

            _dbRepository.Attach(user);
            _dbRepository.Commit();

            return Ok();
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult Delete()
        {
            var email = User.Identity.Name;
            var user = PwUser.GetUserByEmail(_dbRepository, email);

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