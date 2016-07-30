using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class sw_houleft : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Label1.Text = Session["UserName"].ToString(); 
        Label2.Text = DateTime.Now.ToString("F");
    }
    public void Clear()
    {
        
Session["UserName"] = null;
    }
}