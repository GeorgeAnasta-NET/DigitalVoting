using DigitalVoting.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DigitalVoting.Data.Services
{
    public class InMemoryBallotData : IBallotData
    {
        List<Ballot> ballots;

        public InMemoryBallotData()
        {
            ballots = new List<Ballot>()
            {
                new Ballot { Id = 1, Name = "Ψηφοφορία Καθηγητών", Type = BallotType.Teachers},
                new Ballot { Id = 2, Name = "Ψηφοφορία Φοιτητών", Type = BallotType.Students}
            };
        }

        public IEnumerable<Ballot> GetAll()
        {
            return ballots.OrderBy(b => b.Name);
        }
    }
}
