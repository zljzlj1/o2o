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
      
       
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Session["adminname"] = null;
        Session["time"] = null;
         string usercode = TextBox3.Text.Trim();
         if (TextBox1.Text == "" || TextBox2.Text == "")//判断用户名或者密码是否为空
         {
             ClientScript.RegisterStartupScript(ClientScript.GetType(), "alert", " <script> alert('登录名和密码不能为空！');</script> ");
         }
      
        else if (usercode != Session["iCode"].ToString())
         {
             ClientScript.RegisterStartupScript(ClientScript.GetType(), "alert", " <script> alert('请输入正确的验证码！！');</script> ");
           
         }
         else
         {
             string strUid = TextBox1.Text.Trim();
             string strPwd = TextBox2.Text.Trim();
             string SQLStr = " select * from Admin where adminname='" + strUid + "' and admm='" + strPwd + "'";
             OleDbDataReader dr = DBA.GetDataReader(SQLStr);
             if (dr.Read())
             {
                 Session["adminid"] = dr["adminid"].ToString();
                 Session["adminname"] = strUid;
                 Session["bz"] = dr["bz"].ToString();
                 string vadminid = dr["adminid"].ToString();
                 string vlogintime = dr["logintime"].ToString(); 
                
                 if (vlogintime == null || vlogintime == "")
                 {
                     Session["time"] = DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss");
                     string sql = "update Admin set logintime='" + Session["time"] + "'where adminid= '" + vadminid + "'";
                     DBA.ExeSql(sql);
                 }
                 else
                 {
                     string sql = "update Admin set sctime='" + vlogintime + "'where adminid= '" + vadminid + "'";
                     DBA.ExeSql(sql);

                     Session["time"] = DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss");
                     string sqll = "update Admin set logintime='" + Session["time"] + "'where adminid= '" + vadminid + "'";
                     DBA.ExeSql(sqll);
                 }


                 TextBox1.Text = "";
                 TextBox2.Text = "";
                 TextBox3.Text = "";
                 ClientScript.RegisterStartupScript(ClientScript.GetType(), "alert", " <script> alert('登录成功！');location.href= 'admin/admin-sy.aspx'; </script> ");
               }
             else
             {
                 ClientScript.RegisterStartupScript(ClientScript.GetType(), "alert", " <script> alert('登录失败，用户不可登录或者输入错误！'); </script> ");
             }
         }
        
        
         }

    
}