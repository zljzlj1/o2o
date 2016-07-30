using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class sw_newsshow1 : System.Web.UI.Page
{
    DBAccess1 DBA = new DBAccess1();
    protected void Page_Load(object sender, EventArgs e)
    {
        string vxh = Request.QueryString["id"].ToString();
        string str = "select * from 新闻信息 where 流水号=" + vxh;

        OleDbDataReader dr = DBA.GetDataReader(str);
        if (dr.Read())
        {
            Label1.Text = dr["新闻内容"].ToString();
            Label2.Text = dr["新闻标题"].ToString();
            Label3.Text = dr["阅读次数"].ToString();
            Label4.Text = dr["添加时间"].ToString();
        }

    }
}