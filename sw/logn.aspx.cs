using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class sw_logn : System.Web.UI.Page
{
    DBAccess1 DBA = new DBAccess1();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] != null||Session["name"]!=null)
        {
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "alert", "<script>alert('用户已登录，请退出后再进行操作!');location.href= 'index.aspx ' ; </script>");
        }
       
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        string strUser = TextBox1.Text;
        string strPwd = TextBox2.Text;

        string SQLStr = "SELECT * FROM 用户 Where 用户名='" + strUser + "' and 密码 = '" + strPwd + "'";
        OleDbDataReader dr = DBA.GetDataReader(SQLStr);

        if (dr.Read())
        {
          string flag = dr["管理员标志"].ToString();
            if (flag == "True")
            {
               
               
                    Session["UserName"] = strUser;
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "alert", " <script> alert('管理员登录成功！');location='houtai.aspx';</script> ");
              
             
                
            }
            else
            {
                
                    Session["UserName"] = strUser;
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "alert", " <script> alert('用户登录成功！');location='index.aspx';</script> ");
               
            }
          

        }
        else
        {
            if (strUser == "" || strPwd == "")
            {
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "alert", "<script>alert('管理员或用户或密码不能为空!');</script>");
            }
            else
            {
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "alert", "<script>alert('管理员或用户不存在或密码错误!');</script>");
            }
        }

    }
}