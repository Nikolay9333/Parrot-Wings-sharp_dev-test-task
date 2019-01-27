using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using ParrotWings.Entities;
using ParrotWings.Interfaces;

namespace Parrot_Wings.Controllers
{
    public class UsersController : ApiController
    {
        #region Fields

        private readonly IDbRepository _dbRepository;

        public UsersController(IDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        #endregion

        // GET: api/Users
        [ResponseType(typeof(IEnumerable<User>))]
        public IHttpActionResult Get()
        {
            User user = new User()
            {
                //Name = "Niko",
                //SurName = "Belik",
                Balance = 500,
               // Password = "1234",
                Email = "zadorozhnyyn@list.ru",
            };

           // _dbRepository.Attach(user);
            _dbRepository.Add(user);
            _dbRepository.Commit();

            var users = _dbRepository.GetAll<User>();

            //TODO возмжоно не зайдет 
            return users?.Count() > 0
                ? (IHttpActionResult) Ok(users)
                : NotFound();
        }

        // GET: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult Get(int id)
        {
            var user = _dbRepository.Get<User>(id);

            return Ok(user);
            //return user == null
            //    ? (IHttpActionResult) Ok(user)
            //    : NotFound();
        }

        // POST: api/Users
        public IHttpActionResult Post(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _dbRepository.Add(user);
            _dbRepository.Commit();

            return Ok();
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

            return Ok(user);
            //TODO fix
            //if (user == null)
            //{
            //    return NotFound();
            //}

            _dbRepository.Delete(user);
            _dbRepository.Commit();

            return Ok(user);
        }
    }
}