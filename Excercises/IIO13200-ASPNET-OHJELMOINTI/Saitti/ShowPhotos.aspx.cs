using System;
using System.Collections.Generic;
using System.IO;//for Directory
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ShowPhotos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      try
      {
        //Bind photos to Repeater
        Repeater1.DataSource = GetPhotos();
        Repeater1.DataBind();
      }
      catch (Exception ex)
      {
        myLabel.Text = ex.Message;
      }
    }
    protected List<String> GetPhotos()
    {
      try
      {
        List<String> photos = new List<string>();
        string photosPath = MapPath("~/Images");
        string[] files = Directory.GetFiles(photosPath);
        foreach (var filename in files)
        {
          photos.Add("~/Images/" + Path.GetFileName(filename));
        }
        return photos;
      }
      catch (Exception ex)
      {
        throw;
      }
    }
}