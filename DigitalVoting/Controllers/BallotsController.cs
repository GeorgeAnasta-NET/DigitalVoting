using DigitalVoting.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DigitalVoting.Controllers
{
    public class BallotsController : Controller
    {
        IBallotData db;

        public BallotsController()
        {
            db = new InMemoryBallotData();
        }

        public ActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
        }

    }
}