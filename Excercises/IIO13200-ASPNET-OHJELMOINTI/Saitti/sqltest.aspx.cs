using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class sqltest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

            MySql.Data.MySqlClient.MySqlConnection mySqlConnection = new MySql.Data.MySqlClient.MySqlConnection();
            mySqlConnection.ConnectionString = "Server=promehub.com:3306;Initial Catalog=atlas;User ID=IIO14S1;Password=vitosenprojekti";
            mySqlConnection.Open();
            switch (mySqlConnection.State)

            {
                case System.Data.ConnectionState.Open:

                    lblMessage.Text = "Onnistu";

                    break;

                case System.Data.ConnectionState.Closed:

                    // Connection could not be made, throw an error

                    throw new Exception("The database connection state is Closed");

                    break;

                default:

                    // Connection is actively doing something else
                    lblMessage.Text = "Jotain outoa";

                    break;

            }

    }
}