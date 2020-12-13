using DigitalVoting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalVoting.ViewModels
{
    public class BallotDetailsViewModel
    {
        public Ballot Ballot { get; set; }

        public bool IsCombinations { get; set; }
    }
}