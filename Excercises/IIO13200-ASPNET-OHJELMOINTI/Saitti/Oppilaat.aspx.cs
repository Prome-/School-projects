using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Oppilaat : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnGetStudents_Click(object sender, EventArgs e)
    {
        try
        {
            string connString = ConfigurationManager.ConnectionStrings["Oppilaat"].ConnectionString;
            gvOppilaat.DataSource = JAMK.ICT.Data.DBPlacebo.GetDataFromMysql(connString);
            gvOppilaat.DataBind();
        }
        catch (Exception ex)
        {

            throw;
        }
    }
}