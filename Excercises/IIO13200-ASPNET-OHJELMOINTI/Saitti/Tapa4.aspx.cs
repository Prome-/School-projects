using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Tapa4 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // tarkistetaan löytyykö cookieta. jos löytyy niin kirjoitetaan sen arvo
        foreach (string item in Request.Cookies)
        {
            if(item == "viesti")
            {
                cookieTargetDiv.InnerHtml = Request.Cookies["viesti"].Value;
            }
        }
    }
}