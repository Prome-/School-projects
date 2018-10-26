using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.IIO11300
{
    class Customer
    {
        #region PROPERTIES
        private string fname;
        private string lname;
        private string address;
        private string city;

        public string FName
        {
            get { return fname; }
            set { fname = value; }
        }
        public string LName
        {
            get { return lname; }
            set { lname = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        #endregion
        #region CONSTRUCTORS
        public Customer() { }
        public Customer(string enimi, string snimi, string osoite, string kaupunki)
        {
            fname = enimi;
            lname = snimi;
            address = osoite;
            city = kaupunki;
        }
        #endregion
    }
}
