using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Tapa5 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // tarkistetaan tunnistaako edellisen sivun oikein
        var joku = PreviousPage;
        string msg = "";
        if(joku != null)
        {
            // tehdään jotain
            msg = joku.Messu;
            targetDiv.InnerHtml = msg;
        }
        else
        {
            targetDiv.InnerHtml = "Ei aiempaa sivua";
        }
    }
}