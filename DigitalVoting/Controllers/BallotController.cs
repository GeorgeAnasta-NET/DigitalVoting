using DigitalVoting.Models;
using System;
using System.Collections.Generic;
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
            return View();
        }
    }
}