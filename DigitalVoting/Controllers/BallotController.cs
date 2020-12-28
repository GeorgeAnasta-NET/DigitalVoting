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
        //thelei authenticate
        // πρέπει να δουμε τους υποψηφίους του Ψηφοδελτίου στο VIEW
        //πρέπει να φτιάξουμε και τους συνδιασμους του ψηφοδελτίου, προχωράμε ετσι για αρχή
        public ActionResult Details(int Id)
        {
            var ballot = _context.Ballots.Include(b => b.Candidate).SingleOrDefault(b => b.Id == Id);
            try
            {
                if (ballot == null)
                    throw new Exception("We cann't find Ballot");
                if (ballot.CandidateId == null)
                    throw new Exception("We cann't find Candidate");
                if (ballot.Combinations == null)
                    throw new Exception("We cann't find Combinations");
            }
            catch (Exception ex)
            {
                throw;
            }
            
            //var viewModel = new BallotDetailsViewModel { Ballot = ballot };

            //if (User.Identity.IsAuthenticated)
            //{
            //    var userId = User.Identity.GetUserId();

            //    viewModel.IsCombinations = _context.Combinations
            //        .Any(c => c.BallotId == ballot.Id && c.CandidateId == userId);
            //}

            return View(ballot);
        }

        //Για να γίνει create ενα ψηφοδέλτιο πρέπει να δούμε αν αφορά combinations ή όχι
        //Εν συνεχεία, να γίνει εισαγωγή excel αρχείου με τους υποψηφίους
        //και μετά να γίνει η δημιουργία
        public ActionResult Create()
        {
            return View();
        }
    }
}