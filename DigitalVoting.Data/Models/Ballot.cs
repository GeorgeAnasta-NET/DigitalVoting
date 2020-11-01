using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalVoting.Data.Models
{
    public class Ballot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public BallotType Type { get; set; }
    }
}
