using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Hello : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // tämä laukeaa aina sivun latauksen yhteydessä
    }

    protected void btnHello_Click(object sender, EventArgs e)
    {
        // luetaan käyttäjän antama syöte
        string input = "Terve: " + txtNimi.Text;
        lblResult.Text = input;

    }
}