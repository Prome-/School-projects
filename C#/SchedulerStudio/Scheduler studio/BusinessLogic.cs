﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Text.RegularExpressions;


namespace Scheduler_studio
{    
    //Janne
    public class Worker
    {
        #region PROPERTIES

        public string FullName
        {
            get { return firstname + " " + lastname; }
        }

        private long pkey;

        public long PKey
        {
            get { return pkey; }
        }
        
        private string firstname;

        public string Firstname
        {
            get { return firstname;  }
            set { firstname = value; }
            
        }

        private string lastname;

        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }

        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        private string phone;

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        private DateTime regdate;

        public DateTime RegDate
        {
            get { return regdate; }
            set { regdate = value; }
        }

        private string otherInfo;

        public string OtherInfo
        {
            get { return otherInfo; }
            set { otherInfo = value; }
        }
        
        #endregion
        #region CONSTRUCTORS
        public Worker() { }
        public Worker(long id, string fname, string lname, string addr, string phone, DateTime rdate, string other)
        {
            pkey = id;
            firstname = fname;
            lastname = lname;
            address = addr;
            regdate = rdate;
            otherInfo = other;
        }
        #endregion
    }
    //Janne
    public class Note
    {
        #region PROPERTIES
        private string noteauthor;

        public string NoteAuthor
        {
            get { return noteauthor; }
            set { noteauthor = value; }
        }

        private int fkey;

        public int FKey
        {
            get { return fkey; }
            set { fkey = value; }
        }


        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        #endregion
        #region CONSTRUCTORS

        public Note(string msg, string user, int primarykey)
        {
            this.fkey = primarykey;
            this.message = msg;
            this.noteauthor = user;
        }

        public Note(string msg, string user)
        {
            this.message = msg;
            this.noteauthor = user;
        }
        #endregion
    }
    //Janne
    public class Reservation
    {
        #region PROPERTIES
        private int employee;

        public int Employee
        {               
            get { return employee; }
            set { employee = value; }
        }

        private Nullable<int> regcustomer;

        public Nullable<int> RegCustomer
        {
            get { return regcustomer; }
            set { regcustomer = value; }
        }

        private int pkey;

        public int PKey
        {
            get { return pkey; }
            set { pkey = value; }
        }

        private string unregcustomer;

        public string UnregCustomer
        {
            get { return unregcustomer; }
            set { unregcustomer = value; }
        }

        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }


        private string time;

        public string Time
        {
            get { return time; }
            set { time = value; }
        }

        private string service;

        public string Service
        {
            get { return service; }
            set { service = value; }
        }


        #endregion
        #region CONSTRUCTORS
        public Reservation(int id, int worker, Nullable<int> rcustomer, string operation, string customer, DateTime date, string time)
        {
            this.pkey = id;
            this.employee = worker;
            this.regcustomer = rcustomer;
            this.service = operation;
            this.unregcustomer = customer;
            this.date = date;
            this.time = time;
            
        }

        public Reservation(int worker, Nullable<int> rcustomer, string operation, string customer, DateTime date, string time)
        {
            this.employee = worker;
            this.regcustomer = rcustomer;
            this.service = operation;
            this.unregcustomer = customer;
            this.date = date;
            this.time = time;
        }

        #endregion
    }
    //Janne
    public class Customer
    {
        #region PROPERTIES
        private long pkey;

        public long PKey
        {
            get { return pkey; }
        }

        public string FullName
        {
            get { return fname + " " + lname; }
        }

        public string Identifier
        {
            get { return fname + " " + lname + " " + phone; }
        }

        private string fname;

        public string Fname
        {
            get { return fname; }
            set { fname = value; }
        }

        private string lname;

        public string Lname
        {
            get { return lname; }
            set { lname = value; }
        }

        private DateTime regdate;

        public DateTime RegDate
        {
            get { return regdate; }
        }

        private string phone;

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        private string privilege;

        public string Privilege
        {
            get { return privilege; }
            set { privilege = value; }
        }

        private DateTime birthdate;

        public DateTime Birthdate
        {
            get { return birthdate; }
            set { birthdate = value; }
        }


        #endregion
        #region CONSTRUCTORS
        public Customer()
        {
                  
        }
        public Customer(long id, string firstname, string lastname, string phn, string priv, DateTime bdate, DateTime rdate)
        {
            this.pkey = id;
            this.fname = firstname;
            this.lname = lastname;
            this.phone = phn;
            this.privilege = priv;
            this.birthdate = bdate;
            this.regdate = rdate;
        }
        public Customer(string firstname, string lastname, string phn, string priv, DateTime bdate, DateTime rdate)
        {
            this.fname = firstname;
            this.lname = lastname;
            this.phone = phn;
            this.privilege = priv;
            this.birthdate = bdate;
            this.regdate = rdate;
        }

        #endregion
    }

    static class Studio
    {
        #region RESERVATION
        //Janne
        // Hakee reservationista kaiken tiedon
        public static DataTable GetReservations()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = DBStudio.GetReservations();

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Janne
        // Tallentaa varauksen
        public static int SaveReservation(Reservation reservation)
        {
            int rowcount;
            rowcount = DBStudio.InsertReservation(reservation.Service, reservation.Time.ToString(), reservation.Date.Day + "." + reservation.Date.Month + "." + reservation.Date.Year, reservation.UnregCustomer, reservation.RegCustomer, reservation.Employee);

            return rowcount;
        }
        //Janne
        //Tutkii onko syöte kunnossa ja päivittää varaukset jos on
        public static int UpdateReservations(DataTable dtReservations)
        {
            try
            {
                foreach (DataRow row in dtReservations.Rows)
                {
                    if (row.RowState == DataRowState.Modified)
                    {
                        if(String.IsNullOrEmpty(row["RegCustomer"].ToString()) && row["UnregCustomer"].ToString() == "")
                        {
                            // ei kummassakaan asiakaskentässä dataa
                            return -100;
                        }
                        if(!String.IsNullOrEmpty(row["RegCustomer"].ToString()) && row["UnregCustomer"].ToString() != "")
                        {
                            // molemmissa asiakaskentissä dataa
                            return -101;
                        }
                        if (!String.IsNullOrEmpty(row["RegCustomer"].ToString()) && row["UnregCustomer"].ToString() == "")
                        {
                            // varmistetaan ettei check-constraint kosahda kannassa
                            row["UnregCustomer"] = null;
                        }
                        if (row["Service"].ToString().Length > 100)
                        {
                            // liikaa merkkejä palvelussa
                            return -200;
                        }
                        if (!IsValidTime(row["ReservationTime"].ToString()))
                        {
                            //väärä aikaformaatti
                            return -300;
                        }
                        if(!IsValidDate(row["ReservationDate"].ToString()))
                        {
                            // väärä päiväformaatti
                            return -301;
                        }

                    }
                }

                int count;
                // jos mikään if ei lauennut, tehdään tallennus
                count = DBStudio.UpdateReservations(dtReservations);
                return count;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //Janne
        // poistaa varauksen ja palauttaa poistettujen rivien määrän
        public static int RemoveReservation(int pkey)
        {
            try
            {
                int effectedRows = DBStudio.DeleteReservation(pkey);
                return effectedRows;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
        #region WORKER
        //Janne
        //Hakee työntekijät datatablena
        public static DataTable GetWorkersTable()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = DBStudio.GetAllWorkersData();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Janne
        //Hakee työntekijät listana combobokseja varten
        public static List<Worker> GetWorkersList(DataTable dt)
        {
            try
            {
                List<Worker> workers = new List<Worker>();

                // iteroidaan työntekijät listaan
                foreach (DataRow row in dt.Rows)
                {
                    workers.Add(new Worker(Convert.ToInt64(row["PKey"].ToString()), row["Fname"].ToString(), row["Lname"].ToString(), row["Addr"].ToString(), row["Phone"].ToString(), Convert.ToDateTime(row["RegDate"].ToString()), row["Other"].ToString()));
                }

                return workers;
            }
            catch (Exception ex)
            {


                throw ex;
            }
        }
        //Janne
        // Tutkii syötteet ja tallentaa muutokset jos syötteet kunnossa
        public static int UpdateWorkers(DataTable dtWorkers)
        {
            try
            {
                foreach (DataRow row in dtWorkers.Rows)
                {
                    if (row.RowState == DataRowState.Modified)
                    {

                        if (!IsValidPhone(row["Phone"].ToString()))
                        {
                            // väärä puhelinformaatti
                            return -101;
                        }
                        if (row["Fname"].ToString().Length == 0 || row["Fname"].ToString().Length > 20)
                        {
                            // Liikaa tai liian vähän merkkejä etunimessä
                            return -200;
                        }
                        if (row["Lname"].ToString().Length == 0 || row["Lname"].ToString().Length > 30)
                        {
                            // Liikaa tai liian vähän merkkejä sukunimessä
                            return -201;
                        }
                        if (row["Addr"].ToString().Length == 0 || row["Addr"].ToString().Length > 50)
                        {
                            // Liikaa tai liian vähän merkkejä Osoitteessa
                            return -300;
                        }
                        if (row["Other"].ToString().Length > 100)
                        {
                            // liikaa merkkejä otherissa
                            return -400;
                        }
                    }
                }

                // tekee tallennukset ja palauttaa muutettujen rivien määrän
                return DBStudio.UpdateWorker(dtWorkers);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
        #region NOTE
        //Janne
        // Antaa muistion tiedot eteenpäin tallennettavaksi databasekerrokselle
        public static void SaveNote(Note note)
        {
            try
            {
                DBStudio.SaveNote(note.Message, note.FKey);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Janne
        //Antaa poistettavan muistion tiedot eteenpäin databasekerrokselle
        public static void DeleteNote(Note note)
        {
            try
            {
                DBStudio.DeleteNote(note.Message, note.FKey);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Janne
        //Hakee datatablen muistiorivejä, muuttaa sen listaksi ja palauttaa sen
        public static List<Note> GetNotesList()
        {
            try
            {
                DataTable dt;
                dt = DBStudio.GetNotes();

                List<Note> notes = new List<Note>();

                foreach(DataRow row in dt.Rows)
                {
                    notes.Add(new Note(row["Note"].ToString(), row["Fname"].ToString() + " " + row["Lname"].ToString(), Convert.ToInt32(row["Employee"].ToString())));
                }
                return notes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
        #region CUSTOMER
        //Aleksi
        //Alustaa uuden listan, kutsuu tietokantakerroksesta asiakkaiden hakua. Täyttää listan asiakkaiden tiedoilla datatablesta.
        //Palauttaa täytetyn listan kutsujalle.
        public static List<Customer> GetCustomersList()
        {
            try
            {
                List<Customer> customers = new List<Customer>();
                DataTable dt = DBStudio.GetCustomers();

                long pkey;
                DateTime bdate;
                DateTime rdate;

                foreach(DataRow row in dt.Rows)
                {
                    pkey = Convert.ToInt64(row["PKey"].ToString());
                    bdate = Convert.ToDateTime(row["Birthdate"].ToString());
                    rdate = Convert.ToDateTime(row["RegDate"].ToString());
                    


                    customers.Add(new Customer(pkey, row["Fname"].ToString(), row["Lname"].ToString(), row["Phone"].ToString(), row["Privilege"].ToString(), bdate, rdate));
                }

                return customers;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Aleksi
        //Linkkifunktio käyttöliittymäkerroksen ja tietokantakerroksen välillä
        //ainoa toiminto välittää SQL kutsu Business-logiikan läpi
        public static DataTable GetCustomersTable()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = DBStudio.GetCustomers();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion
        //Janne
        //Tutkii regular expressionilla vastaako merkkijono vaatimuksia
        public static bool IsValidTime(string time)
        {
            Regex check = new Regex(@"^(?:0?[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$");

            return check.IsMatch(time);
        }
        //Janne
        //Tutkii regular expressionilla vastaako merkkijono vaatimuksia
        public static bool IsValidPhone(string phone)
        {
            Regex check = new Regex(@"^(\+([0-9]{3})?|^[0-9])([0-9]{2})(\\s)?(([0-9]{3})(\\s)?){2}([0-9])$");

            return check.IsMatch(phone);
        }
        //Janne
        //Tutkii regular expressionilla vastaako merkkijono vaatimuksia
        public static bool IsValidDate(string date)
        {
            Regex check = new Regex(@"^([0-3]?[0-9].[0-3]?[0-9].[0-9]{4})$");

            return check.IsMatch(date);
        }
        
    }
}
