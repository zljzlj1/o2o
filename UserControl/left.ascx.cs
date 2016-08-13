using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class UserControl_left : System.Web.UI.UserControl
{
    DBAccess1 DBA = new DBAccess1();
  
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DCGIBind();

        }
    }
    public void DCGIBind()
    {

        string strSQL = "select * from Splb";
        DataSet ds = DBA.GetDataSet(strSQL);
        Splb.DataSource = ds.Tables["datatable"].DefaultView;
        Splb.DataBind();
       
       

    }
   
    protected void Splb_EditCommand(object source, DataListCommandEventArgs e)
    {
        Response.Redirect("~/ClassGoods.aspx? splbid=" + Splb.DataKeys[e.Item.ItemIndex].ToString());
    }
}