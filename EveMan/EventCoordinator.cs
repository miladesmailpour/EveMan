using System;
using System.Collections.Generic;
using System.Text;

namespace EveMan
{
    class EventCoordinator
    {
        CustomerManager custMan;
        EventManager eventMan;
        RsvpManager rsvpMan;

        public EventCoordinator(int custIdSeed, int maxCust, int eventIdSeed, int maxEvents, int rsvpIdSeed, int maxRsvp)
        {
            custMan = new CustomerManager(custIdSeed, maxCust);
            eventMan = new EventManager(eventIdSeed, maxEvents);
            rsvpMan = new RsvpManager(rsvpIdSeed, maxRsvp);
        }

        //customer related methods
        public bool addCustomer(string fname, string lname, string phone)
        {
            return custMan.addCustomer(fname, lname, phone);
        }

        public string customerList()
        {
            return custMan.getList();
        }

        public string getCustomerInfoById(int id)
        {
            return custMan.getInfo(id);
        }
        public bool deleteCustomer(int id)
        {
            return custMan.delete(id);
        }

        // Event related methods
        public bool addEvent(string name, string venue, Date eventDate, int maxAttendee)
        {
            return eventMan.addEvent(name, venue, eventDate, maxAttendee);
        }

        public string eventList()
        {
            return eventMan.getList();
        }

        public string getEventInfoById(int id)
        {
            return eventMan.getInfo(id);
        }

        // RSVP related methods
        public bool existCustomer(int id)
        {
            return custMan.exist(id);
        }
        public bool existEvent(int id)
        {
            return eventMan.exist(id);
        }

        public bool makeRsvp(int eventId, int customerId)
        {
            return rsvpMan.addRsvp(eventId, customerId);
        }

        public string rsvpList()
        {
            return rsvpMan.getList(custMan);
        }

    }

}
