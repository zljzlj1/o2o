using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class sw_order : System.Web.UI.Page
{
   DBAccess1 DBA = new DBAccess1();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["name"] ==null)
        {
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "alert", "<script>alert('请登录!');location.href= 'index.aspx ' ; </script>");
        }
        if (!IsPostBack)
        {
            string vd = Session["vid"].ToString();
            string strsql = "select * from 产品 where 流水号="+ vd;
            OleDbDataReader dr = DBA.GetDataReader(strsql);
            if (dr.Read())
            {
                Label1.Text = dr["产品名称"].ToString();
                Label2.Text = dr["产品价格"].ToString();
                TextBox1.Text = "1";
            }
           
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
          string strsql1 = "insert into 订单 (产品流水号,订购数量,用户名,订购日期) values('" + Session["vid"].ToString() + "','" + TextBox1.Text + "','" + Session["name"].ToString() + "',Convert(DateTime,'" + DateTime.Today.ToShortDateString() + "',120))";
        DBA.ExeSql(strsql1);
        ClientScript.RegisterStartupScript(ClientScript.GetType(), "alert", "<script>alert('提交成功!'); </script>");
    }
}