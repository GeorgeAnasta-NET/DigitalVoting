using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalVoting.Models
{
    public class Ballot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public BallotType Type { get; set; }
        public DateTime DateCreated
        {
            get
            {
                return this.dateCreated.HasValue
                   ? this.dateCreated.Value
                   : DateTime.Now;
            }

            set { this.dateCreated = value; }
        }

        private DateTime? dateCreated = null;
    }
}
