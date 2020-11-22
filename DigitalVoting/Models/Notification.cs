using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DigitalVoting.Models
{
    public class Notification
    {
        public int Id { get; private set; }
        public DateTime DateTime { get; private set; }
        public NotificationType Type { get; private set; }
        public DateTime? OriginalDateTime { get; private set; }
        public string OriginalVenue { get; private set; }

        [Required]
        public Ballot Ballot { get; private set; }

        protected Notification()
        { }

        private Notification(NotificationType type, Ballot ballot)
        {
            if (ballot == null)
                throw new ArgumentNullException("gig");

            Type = type;
            Ballot = ballot;
            DateTime = DateTime.Now;
        }

        public static Notification BallotCreated(Ballot ballot)
        {
            return new Notification(NotificationType.BallotCreated, ballot);
        }

        public static Notification BallotUpdated(Ballot newGig, DateTime originalDateTime, string originalVenue)
        {
            var notification = new Notification(NotificationType.BallotUpdated, newGig);
            notification.OriginalDateTime = originalDateTime;
            notification.OriginalVenue = originalVenue;

            return notification;
        }

        public static Notification BallotCanceled(Ballot ballot)
        {
            return new Notification(NotificationType.BallotCanceled, ballot);
        }
    }
}