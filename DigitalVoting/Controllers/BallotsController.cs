using DigitalVoting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DigitalVoting.Controllers
{
    public class BallotsController : Controller
    {
        private ApplicationDbContext context;

        public BallotsController()
        {
            context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var model = context.InMemoryBallotData();
            return View(model);
        }

    }
}