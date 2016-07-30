using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class sw_yonghu : System.Web.UI.Page
{
    DBAccess1 DBA = new DBAccess1();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        if (TextBox1.Text == "" || TextBox1.Text == null)
        {
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "alert", "<script>alert('用户名不能为空!'); </script>");
        }
        if (TextBox2.Text == "" || TextBox2.Text == null)
        {
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "alert", "<script>alert('密码不能为空!'); </script>");
        }
        if (TextBox3.Text == "" || TextBox3.Text == null)
        {
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "alert", "<script>alert('确认密码不能为空!'); </script>");
        }
        else
        {
            string strSQL = "SELECT * FROM 用户  Where 用户名='" + TextBox1.Text.ToString() + "'";
            DataSet ds = DBA.GetDataSet(strSQL);
            if (ds.Tables[0].Rows.Count == 0 || ds.Tables[0].Rows.Count == null)
            {
                string strsql = "insert into 用户 (用户名,密码,真实姓名,电话,地址,邮编) values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox4.Text + "','" +
                  TextBox5.Text + "','" + TextBox6.Text + "','" + TextBox7.Text + "')";
                DBA.ExeSql(strsql);
                Session["UserName"] = TextBox1.Text;
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "alert", "<script>alert('注册成功!');location.href= 'index.aspx ' ; </script>");
            }
            else
            {
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "alert", "<script>alert('用户名已存在，注册失败,请重新注册!');</script>");
            }
        }    
    }
  
}