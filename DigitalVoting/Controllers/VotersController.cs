using DigitalVoting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DigitalVoting.Controllers
{
    public class VotersController : Controller
    {
        private ApplicationDbContext context;

        public VotersController()
        {
            context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }
        // GET: Voter
        public ActionResult Index()
        {
            //var viewers = context.Viewers; //GetViewers();//papers
            var voters = context.Candidates
                .ToList();

            //var viewers = new List<Viewer>
            //{
            //    new Viewer{ id = 1, Name = "Peri Aidino"},
            //    new Viewer{ id = 2, Name = "mike drak"},
            //    new Viewer{ id = 3, Name = "Stergios Dimas"}
            //};
            return View(voters);
        }
    }
}