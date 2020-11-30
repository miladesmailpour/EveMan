using System;
using System.Collections.Generic;
using System.Text;

namespace EveMan
{
    class CustomerManager : IManager<Customer>
    {
        private static int currentCustNumber;
        private int maxNumCustomers;
        private int numCustomers;
        private Customer[] customerList;

        public CustomerManager(int ccn, int max)
        {
            currentCustNumber = ccn;
            maxNumCustomers = max;
            numCustomers = 0;
            customerList = new Customer[maxNumCustomers];
        }

        public bool addCustomer(string fn, string ln, string ph)
        {
            if (numCustomers >= maxNumCustomers) { return false; }
            Customer c = new Customer(currentCustNumber, fn, ln, ph);
            currentCustNumber++;
            customerList[numCustomers] = c;
            numCustomers++;
            return true;
        }

        public int find(int cid)
        {
            for (int x = 0; x < numCustomers; x++)
            {
                if (customerList[x].getId() == cid)
                    return x;
            }
            return -1;
        }

        public bool exist(int cid)
        {
            int loc = find(cid);
            if (loc == -1) { return false; }
            return true;
        }

        public Customer get(int cid)
        {
            int loc = find(cid);
            if (loc == -1) { return null; }
            return customerList[loc];
        }

        public string getInfo(int cid)
        {
            int loc = find(cid);
            if (loc == -1) { return "There is no customer with id " + cid + "."; }
            return customerList[loc].ToString();
        }

        public bool delete(int cid)
        {
            int loc = find(cid);
            if (loc == -1) { return false; }
            customerList[loc] = customerList[numCustomers - 1];
            numCustomers--;
            return true;
        }
        public string getFullName(int cId)
        {
            int loc = find(cId);
            return customerList[loc].getFirstName() + " " + customerList[loc].getLastName();
        }

        public string getList()
        {
            string s = "Customer List:";
            s = s + "\nNumber \t Name \t  \t Phone";
            for (int x = 0; x < numCustomers; x++)
            {
                s = s + "\n" + customerList[x].getId() + "\t" + customerList[x].getFirstName() + "\t" + customerList[x].getLastName() + "\t" + customerList[x].getPhone();
            }
            return s;
        }


    }

}
