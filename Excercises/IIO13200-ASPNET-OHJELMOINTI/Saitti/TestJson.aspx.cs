using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JAMK.IT;
using Newtonsoft.Json;

public partial class TestJson : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnGet_Click(object sender, EventArgs e)
    {
        // Haetaan json ja näytetään se sellaisenaan
        string dataa = GetJsonFromWeb("JsonTestP");
        ltResult.Text = dataa;
    }

    protected string GetJsonFromWeb(string filename)
    {
        string url = "http://student.labranet.jamk.fi/~salesa/mat/" + filename;
        using (WebClient wc = new WebClient())
        {
            string json = wc.DownloadString(url);
            return json;
        }
    }

    protected Person ConvertJsonToPerson(string jsonData)
    {
        try
        {
            return JsonConvert.DeserializeObject<Person>(jsonData);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnGetPerson_Click(object sender, EventArgs e)
    {
        string data = GetJsonFromWeb("JsonTestP");
        Person p = ConvertJsonToPerson(data);
        ltResult.Text = string.Format("Löytyi persoona {0}, synt.aika {1}, sukupuoli {2}", p.Name, p.Birthday, p.Gender);        
    }

    protected void btnGetPolitician_Click(object sender, EventArgs e)
    {
        // Haetaan JSON-teksti ja muutetaan se kokoelmaksi Politician-olioita
        string jsonData = GetJsonFromWeb("JsonTest");
        List<Politician> politicians = ConvertJsonToPoliticians(jsonData);
        string msg = "<h2>Suomen hallitus vankka 2016</h2><ul>";
        foreach (Politician politician in politicians)
        {
            msg += "<li>" + politician.Name + ", " + politician.Party + "</li>";
        }
        msg += "</ul>";
        ltResult.Text = msg;

    }

    protected List<Politician> ConvertJsonToPoliticians(string jsonData)
    {
        List<Politician> politicians = JsonConvert.DeserializeObject<List<Politician>>(jsonData);
        return politicians;
    }
}