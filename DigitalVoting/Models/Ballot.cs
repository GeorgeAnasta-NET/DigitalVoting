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

        public ICollection<ApplicationUser> Candidates { get; set; }

        public ICollection<Combination> Combinations { get; set; }
        
        public Ballot()
        {
            Candidates = new Collection<ApplicationUser>();
            Combinations = new Collection<Combination>();
        }
    }
}