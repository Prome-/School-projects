using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SQLConcurrency : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void gvStuff_SelectedIndexChanged(object sender, EventArgs e)
    {
        int i = gvStuff.SelectedIndex;
        string nimi = gvStuff.Rows[i].Cells[1].Text;
        string kuvaus = gvStuff.Rows[i].Cells[2].Text;
        lblEditable.Text = String.Format("{0}, {1}", nimi, kuvaus);

        dvStuff.PageIndex = i;
    }
}