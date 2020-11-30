using System;
using System.Collections.Generic;
using System.Text;

namespace EveMan
{
    class RsvpManager
    {
        private static int currentRsvpId;
        private int maxRsvps;
        private int numRsvps;
        private Rsvp[] rsvpList;

        public RsvpManager(int idSeed, int max)
        {
            currentRsvpId = idSeed;
            maxRsvps = max;
            numRsvps = 0;
            rsvpList = new Rsvp[maxRsvps];
        }

        public bool addRsvp(int eventId, int customerId)
        {
            if (numRsvps >= maxRsvps) { return false; }
            Rsvp r = new Rsvp(currentRsvpId, eventId, customerId, DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt"));
            rsvpList[numRsvps] = r;
            numRsvps++;
            currentRsvpId++;
            return true;
        }
        public string getList(CustomerManager cm)
        {
            string s = "RSVP List:";
            for (int x = 0; x < numRsvps; x++)
            {
                s = s + "\n" + rsvpList[x].getId() + " \t " + rsvpList[x].getEventId() + " \t " + cm.getFullName(rsvpList[x].getCustomerId());
            }
            return s;
        }
    }
}
