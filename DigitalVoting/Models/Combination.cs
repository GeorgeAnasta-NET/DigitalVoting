using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalVoting.Models
{
    public class Combination
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string CandidateId { get; set; }
        public ApplicationUser Candidate { get; set; }

        public int BallotId { get; set; }
        public Ballot Ballot { get; set; }
    }
}