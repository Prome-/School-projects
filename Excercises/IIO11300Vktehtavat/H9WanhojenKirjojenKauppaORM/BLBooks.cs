using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H9WanhojenKirjojenKauppaORM
{
    [Serializable]
    public class Book
    {
        
        #region PROPERTIES
        private string author;

        public string Author
        {
            get { return author; }
            set { author = value; }
        }

        private int id;

        public int ID
        {
            get { return id; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string country;

        public string Country
        {
            get { return country; }
            set { country = value; }
        }
        private int year;

        public int Year
        {
            get { return year; }
            set { year = value; }
        }


        #endregion
        #region CONSTRUCTORS
        public Book(int id) { this.id = id; }
        public Book(int id, string name, string author, string country, int year)
        {
            this.id = id;
            this.name = name;
            this.author = author;
            this.country = country;
            this.year = year;
        }
        #endregion
        #region METHODS
        public override string ToString()
        {
            return name + ", written by " + author;
        }
        #endregion

    }
    public static class BookShop
    {
        private static string cs = H9WanhojenKirjojenKauppaORM.Properties.Settings.Default.Tietokanta;

        #region METHODS
        public static List<Book> GetTestBooks()
        {
            List<Book> temp = new List<Book>();
            temp.Add(new Book(1, "Sota ja rauha", "Leo Tolstoi", "Venäjä", 1867));
            temp.Add(new Book(1, "Sota ja nuha", "Marja Heikkilä", "Suomi", 1868));
            return temp;
        }

        public static List<Book> GetBooks(Boolean useDB)
        {
            try
            {
                List<Book> books = new List<Book>();
                DataTable dt;
                if (useDB)
                {
                    dt = DBBooks.GetBooks(cs);
                }
                else
                {
                    dt = DBBooks.GetTestData();
                }
                Book book;
                foreach (DataRow dr in dt.Rows)
                {
                    book = new Book((int)dr["id"]);
                    book.Name = dr["name"].ToString();
                    book.Author = dr["author"].ToString();
                    book.Country = dr["country"].ToString();
                    book.Year = (int)dr["year"];
                    books.Add(book);
                }
                return books;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            

        }

        public static int UpdateBook(Book book)
        {
            try
            {
                int rows = DBBooks.UpdateBook(cs, book.ID, book.Name, book.Author, book.Country, book.Year);
                return rows;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
