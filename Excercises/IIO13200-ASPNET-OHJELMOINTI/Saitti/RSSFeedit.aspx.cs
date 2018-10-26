using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class RSSFeedit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void getFeeds_Click(object sender, EventArgs e)
    {
        // asetetaan xmldatasource osoittamaan iltasanomien xml-tiedostoon / RSS feediin
        // @ ennen stringiä /-merkkien takia
        xdsFeedit.DataFile = @"http://www.iltasanomat.fi/rss/tuoreimmat.xml";
        xdsFeedit.XPath = @"rss/channel/item";
        GetFeeds();
    }

    protected void GetFeeds()
    {
        try
        {
            // hakee xml:n XmlDocument-olioon
            XmlDocument xmldoc = xdsFeedit.GetXmlDocument();
            //rssfeedin title ja julkaisuaika
            XmlNode node = xmldoc.SelectSingleNode("/rss/channel");
            string title = node["title"].InnerText;
            string releasedate = node["pubDate"].InnerText;
            // loopataan kaikki itemit läpi
            XmlNodeList nodelist = xmldoc.SelectNodes("/rss/channel/item");
            ltMessages.Text = string.Format("<h1>{0} {1}", title, releasedate);
            string rssTitle = "";
            string rssLink = "";
            string rssDescription = "";
            string rssEnclosureUrl = "";
            ltFeed.Text = "";

            foreach (XmlNode listnode in nodelist)
            {
                rssTitle = listnode["title"].InnerText;
                rssLink = listnode["link"].InnerText;
                rssDescription = listnode["description"].InnerText;

                if(listnode["enclosure"] != null)
                {
                    rssEnclosureUrl = listnode["enclosure"].GetAttribute("url");
                }       
                else
                {
                    rssEnclosureUrl = "";
                }         
                
                ltFeed.Text += string.Format("<p><a href='{1}'><img src='{0}'/><br>{2}</a><br>{3}</p>", rssEnclosureUrl, rssLink, rssTitle, rssDescription);
            }
                        
        }
        catch (Exception ex)
        {
            ltMessages.Text = ex.Message;
        }
    }

    protected void getYleFeeds_Click(object sender, EventArgs e)
    {
        xdsFeedit.DataFile = @"http://feeds.yle.fi/uutiset/v1/majorHeadlines/YLE_UUTISET.rss";
        xdsFeedit.XPath = @"channel/item";
        GetFeeds();
    }
}