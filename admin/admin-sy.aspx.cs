using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_admin_sy : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        username.Text = Session["adminname"].ToString();
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        //Session["UID"] = null;
        //Session["Username"] = null;
        Session.Abandon();
        Session.Clear();
        Session.RemoveAll();
        Response.Write("<script>alert('退出成功！');location='../index.aspx';</script>");
    }
}