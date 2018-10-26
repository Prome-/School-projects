using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Localization : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void buttonA_Click(object sender, EventArgs e)
    {
        //haetaan resursseista kulttuurin mukainen tervehdys        
        lblMessage.Text = GetLocalResourceObject("Tervehdys").ToString();
    }
}