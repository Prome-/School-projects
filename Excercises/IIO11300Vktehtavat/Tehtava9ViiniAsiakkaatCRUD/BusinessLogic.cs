using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JAMK.IT.IIO11300
{
    static class BusinessLogic
    {
        public static void DeleteCustomer(string ID, string Fname, string Lname, string Addr, string ZIP, string City)
        {
            try
            {
                if (MessageBox.Show("Haluatko varmasti poistaa käyttäjän tiedot?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    JAMK.IT.IIO11300.DBCustomer.RemoveCustomer(ID, Fname, Lname, Addr, ZIP, City);
                    MessageBox.Show("Tiedot poistettu onnistuneesti!");
                }
            }
            catch (Exception ex)
            { 
                throw ex;
            }
        }
    }
}
