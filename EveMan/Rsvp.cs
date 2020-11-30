using System;
using System.Collections.Generic;
using System.Text;

namespace EveMan
{
    class Rsvp
    {
        private int rsvpId;
        private int eventId;
        private int customerId;
        private string rsvpDate;
        public Rsvp(int rId, int eId, int cId, string date)
        {
            this.rsvpId = rId;
            this.eventId = eId;
            this.customerId = cId;
            this.rsvpDate = date;
        }
        public int getId() { return rsvpId; }
        public int getEventId() { return eventId; }
        public int getCustomerId() { return customerId; }
    }
}
