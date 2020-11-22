using DigitalVoting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalVoting.ViewModels
{
    public class BallotFormViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public byte BallotType { get; set; }

        public IEnumerable<BallotType> BallotTypes { get; set; }

        public BallotFormViewModel()
        {
            Id = 0;
        }

        public int CandidateId { get; set; }

        public IEnumerable<Candidate> Candidates { get; set; }
    }
}