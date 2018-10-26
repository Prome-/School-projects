using System;
using System.Collections.Generic;
using System.Configuration; // web.configin lukemista varten
using System.Data; // dataa ja yleisiä ADO.NETIN luokkia varten
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Työntekijät : System.Web.UI.Page
{
    string xmlfilu;
    protected void Page_Load(object sender, EventArgs e)
    {
        // haetaan webconfigista xml-tiedoston nimi
        xmlfilu = ConfigurationManager.AppSettings["xmlfilu"];
        lblMessages.Text = xmlfilu;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();        
        ds.ReadXml(Server.MapPath(xmlfilu)); // mappath muuttaa osoitteen dynaamiseksi absoluuttisesta
        gvData.DataSource = ds;
        gvData.DataBind();
    }
}