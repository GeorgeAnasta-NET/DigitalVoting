using DigitalVoting.Models;
using DigitalVoting.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

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
            var model = context.Ballots
                .Include(t => t.Type)
                .Include(t => t.Candidate)
                .ToList();

            return View(model);
        }

        public ActionResult Create()
        {
            var viewModel = new BallotFormViewModel()
            {
                BallotTypes = context.BallotTypes.ToList(),
                Candidates = context.Candidates.ToList()
            };

            return View(viewModel);
        }

        public ActionResult Edit(int Id)
        {
            var ballot = context.Ballots.SingleOrDefault(b => b.Id == Id);
            var ballotType = context.BallotTypes.ToList();
            var candidate = context.Candidates.ToList();

            if (ballot == null)
            {
                return HttpNotFound();
            }

            var ballotModel = new BallotFormViewModel()
            {
                Id = ballot.Id,
                Name = ballot.Name,
                BallotType = (byte)ballot.TypeId,
                BallotTypes = ballotType,
                CandidateId = ballot.CandidateId,
                Candidates = candidate
            };

            return View("BallotForm", ballotModel);
        }

        public ActionResult Save(BallotFormViewModel ballotModel)
        {
            if (!ModelState.IsValid)
            {
                var balModel = new BallotFormViewModel()
                {
                    BallotTypes = context.BallotTypes.ToList(),
                    Candidates = context.Candidates.ToList()
                };
                return View("Index", balModel);
                //return View("BallotForm", balModel);
            }

            if (ballotModel.Id == 0)  // Create
            {
                var ballot = new Ballot()
                {
                    Id = ballotModel.Id,
                    Name = ballotModel.Name,
                    TypeId = (int)ballotModel.BallotType,
                    CandidateId = ballotModel.CandidateId
                };
                context.Ballots.Add(ballot);
            }
            else  //Edit
            {
                var ballotDb = context.Ballots.SingleOrDefault(b => b.Id == ballotModel.Id);
                ballotDb.Name = ballotModel.Name;
                ballotDb.TypeId = ballotModel.BallotType;
                ballotDb.CandidateId = ballotModel.CandidateId;
            }
            context.SaveChanges();

            return RedirectToAction("Index", "Ballots");
        }

        public ActionResult Delete(int Id)
        {
            var ballot = context.Ballots
                .Where(b => b.Id == Id)
                .Include(t => t.Type)
                .SingleOrDefault();

            //Soft Delete
            ballot.IsDeleted = true;
            //Hard delete
            //context.Ballots.Remove(ballot);
            context.SaveChanges();

            return RedirectToAction("Index", "Ballots");
        }
    }
}