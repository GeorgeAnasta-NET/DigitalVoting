using DigitalVoting.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DigitalVoting.ViewModels;
using Microsoft.AspNet.Identity;

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

        public ActionResult Details(int Id)
        {
            var ballot = _context.Ballots.SingleOrDefault(b => b.Id == Id);
            if (ballot == null)
                return HttpNotFound();
            if (ballot.CandidateId == null)
                return HttpNotFound();
            if (ballot.Combinations == null)
                return HttpNotFound();
            //var viewModel = new BallotDetailsViewModel { Ballot = ballot };

            //if (User.Identity.IsAuthenticated)
            //{
            //    var userId = User.Identity.GetUserId();

            //    viewModel.IsCombinations = _context.Combinations
            //        .Any(c => c.BallotId == ballot.Id && c.CandidateId == userId);
            //}

            return View(ballot);
        }
    }
}