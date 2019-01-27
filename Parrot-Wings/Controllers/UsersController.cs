using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Ninject;
using ParrotWings.Entities;
using ParrotWings.Interfaces;
using ParrotWings.Repositories;

namespace Parrot_Wings.Controllers
{
    public class UsersController : ApiController
    {
        #region Fields

        private readonly IDbRepository _dbRepository;
        private IEnumerable<int> a;

        public UsersController(IEnumerable<int> a/*IDbRepository dbRepository*/)
        {
            //IKernel ninjectKernel = new StandardKernel();
            //ninjectKernel.Bind<IDbRepository>().To<MsSqlRepository>();
            //this._dbRepository = ninjectKernel.Get<IDbRepository>();

            this.a = a;
        //    this._dbRepository = dbRepository;
        }

        //public UsersController()
        //{

        //}

        #endregion

        // GET: api/Users
        [ResponseType(typeof(IEnumerable<User>))]
        public IHttpActionResult Get()
        {
            User user = new User()
            {
                Name = "Niko",
                SurName = "Belik",
                Balance = 500,
                Password = "1234"
            };

            _dbRepository.Attach(user);
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

            return user == null
                ? (IHttpActionResult) Ok(user)
                : NotFound();
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

            return Json(new {id = user.Id});
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