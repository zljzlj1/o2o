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

       /* if (TextBox1.Text == "" || TextBox0.Text == "")//判断用户名或者密码是否为空
        {
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "alert", " <script> alert('没有输入！');</script> ");
        }
        string usercode = txtcode.Text.Trim();
        if (usercode != Session["iCode"].ToString())
        {
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "alert", " <script> alert('验证码错误！');</script> ");
            TextBox0.Text = "";
        }
        else
        {
            string strUid = TextBox1.Text.Trim();//把用户输入的用户名赋值给strUser
            string strPwd = TextBox0.Text.Trim();//把用户输入的密码赋值给strPwd
            string SQLStr = " select * from Users where UserName='" + strUid + "' and Password='" + strPwd + "' and RoleID!='1'";
            OleDbDataReader dr = DBA.GetDataReader(SQLStr);
            if (dr.Read())
            {
                Session["UserName"] = strUid;
                Session["UserID"] = dr["UserID"].ToString();
                Session["IsSysRole"] = dr["IsSysRole"].ToString();
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "alert", " <script> alert('登录成功！');location.href= 'admin/houtai.aspx'; </script> ");
            }
            else
            {
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "alert", " <script> alert('登录失败，用户不可登录或者输入错误！'); </script> ");
            }
        }
        
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
        }*/

    }
}