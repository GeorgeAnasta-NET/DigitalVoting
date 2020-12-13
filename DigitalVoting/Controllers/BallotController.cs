using DigitalVoting.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DigitalVoting.Controllers
{
    public class BallotController : Controller
    {
        private ApplicationDbContext _context;

        //ctor
        public BallotController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Ballot
        public ActionResult Index()
        {
            var ballots = _context.Ballots.ToList();

            return View(ballots);
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}