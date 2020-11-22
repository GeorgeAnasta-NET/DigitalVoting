using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DigitalVoting.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser> 
    {
        public DbSet<Ballot> Ballots { get; set; }
        public DbSet<BallotType> BallotTypes { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        
        public ApplicationDbContext()
            : base("DigitalVotingDb", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        List<Ballot> ballots;

        public IEnumerable<Ballot> InMemoryBallotData()
        {
            ballots = new List<Ballot>()
            {
                new Ballot { Id = 1, Name = "Ψηφοφορία Καθηγητών", Type = new BallotType{ Id = 1, Name = "Teachers" } },
                new Ballot { Id = 2, Name = "Ψηφοφορία Φοιτητών", Type = new BallotType{ Id = 2, Name = "Students"} }
            };
            return ballots;
        }

    }
}