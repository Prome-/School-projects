using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BookShop : System.Web.UI.Page
{
    protected static BookShopEntities ctx;
    // ctx tulee sanasta context
    protected void Page_Load(object sender, EventArgs e)
    {
        ctx = new BookShopEntities();
        if (!IsPostBack)
        {            
            FillControls();
        }
    }

    protected void FillControls()
    {
        try
        {
            var result = from c in ctx.Customers orderby c.lastname, c.firstname select new { c.id, c.lastname };
            ddlCustomers.DataSource = result.ToList();
            ddlCustomers.DataValueField = "id";
            ddlCustomers.DataTextField = "lastname";
            ddlCustomers.DataBind();
            tbFirstName.Text = string.Empty;
            tbLastName.Text = string.Empty;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #region METHODS

    protected void GetCustomers()
    {
        try
        {
            gvCustomers.DataSource = ctx.Customers.ToList();
            gvCustomers.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void GetBooks()
    {
        try
        {
            gvBooks.DataSource = ctx.Books.ToList();
            gvBooks.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnGetBooks_Click(object sender, EventArgs e)
    {
        try
        {
            GetBooks();
        }
        catch (Exception ex)
        {
            lblFooter.Text = ex.Message;            
        }
    }

  

    protected void btnGetCustomers_Click(object sender, EventArgs e)
    {
        try
        {
            GetCustomers();
        }
        catch (Exception ex)
        {
            lblFooter.Text = ex.Message;
        }
    }

    protected void ddlCustomers_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if(ddlCustomers.SelectedIndex > 0)
            {
                ddlOrders.Items.Clear();
                int cid = Int32.Parse(ddlCustomers.SelectedValue);
                //lblFooter.Text =
                // haetaan valittu asiakas
                var ret = from c in ctx.Customers
                          where c.id == cid
                          select c;
                Customer asiakas = ret.FirstOrDefault();
                if(asiakas != null)
                {
                    lblFooter.Text = string.Format("Valitsit asiakkaan {0}", asiakas.lastname);
                    tbFirstName.Text = asiakas.firstname;
                    tbLastName.Text = asiakas.lastname;
                    // tutkitaan onko valitulla asiakkalla tilauksia. jos on, näytetään ne.
                    if(asiakas.Orders.Count > 0)
                    {
                        lblFooter.Text += string.Format(", tilauksia {0}", asiakas.Orders.Count);
                        var ordersToDDL = (from o in asiakas.Orders
                                     select new { o.odate, o.oid }).ToList();
                        ddlOrders.DataSource = ordersToDDL;
                        ddlOrders.DataTextField = "odate";
                        ddlOrders.DataValueField = "oid";
                        ddlOrders.DataBind();

                        int orderId = Int32.Parse(ddlOrders.SelectedValue);

                        var orders = (from o in ctx.Orders
                                     where o.oid == orderId
                                     select o).ToList();
                        // haetaan tilausten tilausrivit
                        gvOrders.DataSource = orders;
                        gvOrders.DataBind();
                    }
                    else
                    {
                        lblFooter.Text += "Ei tilauksia.";
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblFooter.Text = ex.Message;
        }
    }

    protected void AddCustomer()
    {
        using (BookShopEntities entities = new BookShopEntities())
        {
            Customer customer = new Customer();
            customer.firstname = tbFirstName.Text;
            customer.lastname = tbLastName.Text;
            entities.Customers.Add(customer);
            entities.SaveChanges();
        }
    }

    protected void SaveModifiedCustomer()
    {
        int customerID = Int32.Parse(ddlCustomers.SelectedValue);

            Customer customer = (from c in ctx.Customers where c.id == customerID select c).FirstOrDefault();
            //Customer customer = entities.Customers.Find(customerID);
            customer.firstname = tbFirstName.Text;
            customer.lastname = tbLastName.Text;
            ctx.SaveChanges();
        
    }

    protected void DeleteCustomer()
    {
        int customerID = Int32.Parse(ddlCustomers.SelectedValue);
        using (BookShopEntities entities = new BookShopEntities())
        {
            Customer customer = (from c in entities.Customers where c.id == customerID select c).FirstOrDefault();
            //Customer customer = entities.Customers.Find(customerID);
            // huom! Onko asiakas järkevä poistaa? Vaihtoehtona laittaa kantaan asiakkaalle flagi jolla voidaan merkata asiakas inaktiiviseksi, niin relaatiot ei räjähdä
            entities.Customers.Remove(customer);
            entities.SaveChanges();
        }
    }

    protected void btnAddCustomer_Click(object sender, EventArgs e)
    {
        AddCustomer();
        FillControls();
    }

    protected void btnSaveModifiedCustomer_Click(object sender, EventArgs e)
    {
        SaveModifiedCustomer();
        FillControls();
    }

    protected void btnDeleteCustomer_Click(object sender, EventArgs e)
    {
        DeleteCustomer();
        FillControls();
    }
    #endregion
}