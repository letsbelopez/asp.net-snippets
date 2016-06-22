using Sabio.Web.Models;
using Sabio.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sabio.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    [RoutePrefix("languages")]
    public class LanguagesController : BaseController
    {
        // GET: Languages
        public ActionResult Index()
        {
            return View();
        }

        [Route("create")] [Route("{id:int}/edit")] [HttpGet]
        public ActionResult Create(int id = 0)
        {
            ItemViewModel<int> model = new ItemViewModel<int>();
            model.Item = id;
            return View(model);
        }

        [Route("manage")]
        public ActionResult Manage()
        {
            return View();
        }

        // GET: Angular Languages
        public ActionResult Angular()
        {
            return View();
        }

    }
}
