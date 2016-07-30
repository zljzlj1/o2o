using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class sw_tianjiaguanliyuan : System.Web.UI.Page
{
    DBAccess1 DBA = new DBAccess1();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int str1;
        string strSQL = "SELECT * FROM 用户  Where 用户名='" + TextBox1.Text.ToString() + "'";
        DataSet ds = DBA.GetDataSet(strSQL);
        if (ds.Tables[0].Rows.Count > 0)
        {
            str1 = 1;
        }
        else
        {
            str1 = 2;
        }


        if (str1 == 2)
        {
            if (TextBox1.Text == "")
            {
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "alert", "<script>alert('用户名不能为空!'); </script>");
            }
            if (TextBox2.Text == "")
            {
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "alert", "<script>alert('没有输入密码!');</script>");
            }
            if (TextBox3.Text == "")
            {
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "alert", "<script>alert('没有进行确认密码!');</script>");
            }
            else
            {
                string strsql = "insert into 用户 (用户名,密码,真实姓名,电话,地址,邮编,管理员标志) values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox4.Text + "','" +
               TextBox5.Text + "','" + TextBox6.Text + "','" + TextBox7.Text + "','" + true + "')";
                DBA.ExeSql(strsql);
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "alert", "<script>alert('添加成功!'); </script>");
            }
        }
        else
        {
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "alert", "<script>alert('管理员已存在，注册失败!');</script>");
        }
    }
}