using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ShowCustomers : System.Web.UI.Page
{
    string connStr;
    protected void Page_Load(object sender, EventArgs e)
    {
      connStr = "Data Source=eight.labranet.jamk.fi;Initial Catalog=Viini;Persist Security Info=True;User ID=koodari;Password=koodari13";
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
      int lkm = 0;
      //get data from SQL Server and write it to HTML
      tulokset.InnerHtml = "<h1>Salaiset loppahuuli-asiakkaat </h1>";

    //looppi jossa InnerHtmlää kasvatetaan
    tulokset.InnerHtml += "<div>";
    DataTable dt = new DataTable("asiakkaat");
      SqlDataAdapter da = new SqlDataAdapter("SELECT Firstname, Lastname, City FROM customer", connStr);
      da.Fill(dt);
      foreach (DataRow rivi in dt.Rows)
      {
        tulokset.InnerHtml += string.Format("{0} {1} {2} </br>", rivi[0], rivi[1], rivi[2]);
        lkm++;
      }
    tulokset.InnerHtml += "</div>";
    //lopputekstit
    tulokset.InnerHtml += string.Format("<h2> {0} customers listed from database </h2>", lkm);

    }
}