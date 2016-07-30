using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class sw_chanpingview : System.Web.UI.Page
{
    DBAccess1 DBA = new DBAccess1();
    protected void Page_Load(object sender, EventArgs e)
    {
        string vxh = Request.QueryString["vid"].ToString();
        string st = "select * from 产品 where 流水号=" + vxh;
        OleDbDataReader dr = DBA.GetDataReader(st);
        if (dr.Read())
        {
            Label1.Text = dr["流水号"].ToString();
            Label2.Text = dr["产品名称"].ToString();
            Label3.Text = dr["产品价格"].ToString();
            Label4.Text = dr["产品类别"].ToString();
            Label5.Text = dr["产品介绍"].ToString();
            Image1.ImageUrl = dr["产品图片"].ToString();
        }
        Session["vid"] = Request.QueryString["vid"].ToString();
    }
}