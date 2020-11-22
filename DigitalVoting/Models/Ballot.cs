using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public DateTime DateTime { get; set; }
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

        public int CandidateId { get; set; }
        public Candidate Candidate { get; set; }

        public bool IsCanceled { get; private set; }

        public ICollection<Candidate> Ballots { get; set; }

        public bool IsDeleted { get; set; }

        public Ballot()
        {
            Ballots = new Collection<Candidate>();
        }

        public void Cancel()
        {
            IsCanceled = true;

            var notification = Notification.BallotCanceled(this);

            foreach (var candidate in Ballots.Select(c => c.Candidates))
            {
                candidate.Notify(notification);
            }
        }

        public void Modify(DateTime dateTime, int ballotType)
        {
            var notification = Notification.BallotUpdated(this, DateTime);

            //Venue = venue;
            //DateTime = dateTime;
            //GenreId = genre;

            foreach (var attendee in Ballots.Select(c => c.Candidates))
            {
                attendee.Notify(notification);
            }
        }
    }
}
