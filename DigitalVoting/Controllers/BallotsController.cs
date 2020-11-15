using DigitalVoting.Models;
using DigitalVoting.ViewModels;
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

        public ActionResult Create()
        {
            var viewModel = new BallotFormViewModel()
            {
                BallotTypes = context.BallotTypes.ToList()
            };

            return View(viewModel);
        }

        //public  ActionResult Save(BallotFormViewModel ballotModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        var balModel = new BallotFormViewModel()
        //        {
        //            BallotTypes = context.BallotTypes.ToList()
        //        };
        //        return View("Index", balModel);
        //        //return View("BallotForm", balModel);
        //    }

        //    if (ballotModel.Id == 0)  // Create
        //    {
        //        var ballot = new Ballot()
        //        {
        //            Id = ballotModel.Id,
        //            Name = ballotModel.Name,
        //            TypeId = (int)ballotModel.BallotType
        //        };
        //        context.Ballots.Add(ballot);
        //    }
        //    //else  //Edit
        //    //{
        //    //    var vinylDb = context.Vinyls.SingleOrDefault(v => v.Id == vinylModel.Id);
        //    //    // autes oi tesseris grammes mporeis na peis oti einai i whiteList
        //    //    vinylDb.Title = vinylModel.Title;
        //    //    vinylDb.Artist = vinylModel.Artist;
        //    //    vinylDb.ReleaseYear = vinylModel.ReleaseYear;
        //    //    vinylDb.GenreId = vinylModel.Genre;
        //    //    vinylDb.LabelId = vinylModel.Label;
        //    //    vinylDb.Price = vinylModel.Price;
        //    //}
        //    context.SaveChanges();

        //    return RedirectToAction("Index", "Ballots");
        //}
    }
}