using System;
using System.Collections.Generic;
using System.Text;

namespace EveMan
{
    class EventManager : IManager<Event>
    {
        private static int currentEventId;
        private int maxEvents;
        private int numEvents;
        private Event[] eventList;

        public EventManager(int idSeed, int max)
        {
            currentEventId = idSeed;
            maxEvents = max;
            numEvents = 0;
            eventList = new Event[maxEvents];
        }

        public bool addEvent(string name, string venue, Date eventDate, int maxAttendees)
        {
            if (numEvents >= maxEvents) { return false; }
            if (existVenueDate(venue, eventDate)) { return false; }
            Event e = new Event(currentEventId, name, venue, eventDate, maxAttendees);
            eventList[numEvents] = e;
            numEvents++;
            currentEventId++;
            return true;
        }

        public int find(int eid)
        {
            for (int x = 0; x < numEvents; x++)
            {
                if (eventList[x].getId() == eid)
                    return x;
            }
            return -1;
        }

        private bool existVenueDate(string venue, Date eventDate)
        {
            for (int x = 0; x < numEvents; x++)
            {
                if (eventList[x].getVenue().Equals(venue) && eventList[x].getEventDate().dateToString().Equals(eventDate.dateToString()))
                {
                    return true;
                }
            }
            return false;
        }

        public bool exist(int eid)
        {
            int loc = find(eid);
            if (loc == -1) { return false; }
            return true;
        }

        public bool hasRoom(int eid)
        {
            int loc = find(eid);
            if (eventList[loc].getNumAttendees() < eventList[loc].getMaxAttendees())
            {
                return true;
            }
            return false;
        }

        public Event get(int eid)
        {
            int loc = find(eid);
            if (loc == -1) { return null; }
            return eventList[loc];
        }

        public bool delete(int eid)
        {
            int loc = find(eid);
            if (loc == -1) { return false; }
            eventList[loc] = eventList[numEvents - 1];
            numEvents--;
            return true;
        }
        public string getInfo(int eid)
        {
            int loc = find(eid);
            if (loc == -1) { return "There is no event with id " + eid + "."; }
            return eventList[loc].ToString();
        }
        public string getList()
        {
            string s = "Event List:";
            for (int x = 0; x < numEvents; x++)
            {
                s = s + "\n" + eventList[x].getId() + " \t " + eventList[x].getEventName() + " \t " + eventList[x].getVenue();
            }
            return s;
        }

    }

}
