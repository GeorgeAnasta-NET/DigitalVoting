using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DigitalVoting.Controllers
{
    public class VotersController : Controller
    {
        // GET: Voter
        public ActionResult Index()
        {
            return View();
        }
    }
}