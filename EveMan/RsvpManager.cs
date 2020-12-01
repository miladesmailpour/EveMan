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

        public string addRsvp(int eventId, int customerId, CustomerManager cm, EventManager em)
        {
            if (numRsvps >= maxRsvps) { return "out of RSVP request! Please contact to the support system."; }
            int locCustomer = cm.find(customerId);
            int locEvent = em.find(eventId);
            if (locEvent == -1) { return String.Format("Event with id {0} was not found..", eventId); }
            if (locCustomer == -1) { return String.Format("Customer with id {0} was not found..", customerId); }
            if (!em.hasRoom(eventId)) { return String.Format("Event with id {0} has NO more room..", eventId);}
            Event currEvent = em.get(eventId);
            if (currEvent.findAttendee(customerId) != -1) { return String.Format("Customer with id {0} was already added.", customerId); }
            currEvent.addAttendee(cm.get(customerId));
            Rsvp r = new Rsvp(currentRsvpId, eventId, customerId, DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt"));
            rsvpList[numRsvps] = r;
            numRsvps++;
            currentRsvpId++;
            return "";
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
