using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace DigitalVoting.Models
{
    public class Ballot
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string CandidateId { get; set; }
        public ApplicationUser Candidate { get; set; }

        public ICollection<Combination> Combinations { get; set; }
        
        public Ballot()
        {
            Combinations = new Collection<Combination>();
        }
    }
}