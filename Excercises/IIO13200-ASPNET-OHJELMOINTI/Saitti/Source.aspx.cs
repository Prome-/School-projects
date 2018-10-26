using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Source : System.Web.UI.Page
{
    public string Messu
    {
        get { return txtMessage.Text; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        // täällä tehdään yleensä kaikki sivun alustukseen liittyvät asiat
        // HUOM HALUTTAVAA VAIN YHDEN KERRAN! postbackilla tämä tapahtuu uudestaan koska sivu renderöidään uudelleen.
        // laitettava postback tarkistus
        if(!IsPostBack)
        {
            ddlMessages.Items.Add("Ping!");
            ddlMessages.Items.Add("Hello, handshake?");
            ddlMessages.Items.Add("Goodbye.");
        }        
    }

    protected void btnQueryString_Click(object sender, EventArgs e)
    {
        // ohjataan pyyntö uudelle sivulle ja välitetään teksti kutsun mukana. Http get
        Response.Redirect("Tapa1.aspx?Data=" + txtMessage.Text);
    }


    protected void btnHttpPost_Click(object sender, EventArgs e)
    {
        //http post metodilla sivu hakee IDn perusteella itse datan
    }

    protected void btnSession_Click(object sender, EventArgs e)
    {
        // kirjoitetaan Sessioniin
        Session["viesti"] = txtMessage.Text;
        Response.Redirect("Tapa3.aspx");
    }

    protected void btnCookie_Click(object sender, EventArgs e)
    {
        HttpCookie cookie = new HttpCookie("viesti", txtMessage.Text);
        Response.Cookies.Add(cookie);
        Response.Redirect("Tapa4.aspx");
    }

    protected void btnProperty_Click(object sender, EventArgs e)
    {
        // ei kelpaa tässä tapauksessa, koska PreviousPage ei synny
        //Response.Redirect("Tapa5.aspx");

        Server.Transfer("Tapa5.aspx");
    }

    protected void ddlMessages_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtMessage.Text = ddlMessages.SelectedItem.Text;
    }
}