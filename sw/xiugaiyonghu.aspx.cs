using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class sw_xiugaiyonghu : System.Web.UI.Page
{
    DBAccess1 DBA = new DBAccess1();
    protected void Page_Load(object sender, EventArgs e)
    {
        
         string vid = Session["name"].ToString();
            string SQLStr = "select * from 用户 where 用户名='" + vid + "'";
            OleDbDataReader dr = DBA.GetDataReader(SQLStr);
            if (dr.Read())
            {
                TextBox1.Text = dr["用户名"].ToString();
                TextBox2.Text = dr["密码"].ToString();
                TextBox3.Text = dr["密码"].ToString();
                TextBox4.Text = dr["真实姓名"].ToString();
                TextBox5.Text = dr["电话"].ToString();
                TextBox6.Text = dr["地址"].ToString();
                TextBox7.Text = dr["邮编"].ToString();
            }
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string yh = Session["name"].ToString();
        string name = TextBox1.Text.Trim();
        string mima = TextBox2.Text.Trim();
        string real = TextBox3.Text.Trim();
        string phone = TextBox4.Text.Trim();
        string address = TextBox5.Text.Trim();
        string bianma = TextBox6.Text.Trim();
        string strSQL = "Update 用户 set 用户名='" + name + "',密码='" + mima + "',真实姓名='" + real + "',电话='" + phone + "',地址='" + address + "',邮编='" + bianma + "'where 用户名='" + yh + "'";
        DBA.ExeSql(strSQL);
        ClientScript.RegisterStartupScript(ClientScript.GetType(), "alert", "<script>alert('修改成功!');location.href= 'index.aspx ' ; </script>");

    }
}