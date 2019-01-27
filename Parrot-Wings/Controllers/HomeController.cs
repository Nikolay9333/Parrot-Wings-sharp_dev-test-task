using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Ninject;
using ParrotWings.Contexts;

namespace Parrot_Wings.Controllers
{
    public class HomeController : ApiController
    {
        DbContext repo;

        public HomeController(DbContext repo)
        {
            this.repo = repo;
        }

        public ActionResult Get()
        {
            var d = 1;

            return  new EmptyResult();
            //  return View(repo);
        }
    }
}