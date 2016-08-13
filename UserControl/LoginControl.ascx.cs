using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;





public partial class UserControl_LoginControl : System.Web.UI.UserControl
{
  
    DBAccess1 DBA = new DBAccess1();
    protected void Page_Load(object sender, EventArgs e)
    {
        TxtUserCode.BackColor = System.Drawing.Color.Transparent;
        TxtUserPwd.BackColor = System.Drawing.Color.Transparent;
        TxtUserName.BackColor = System.Drawing.Color.Transparent;
       if (!IsPostBack)
        {

            if (Session["UserID"] != null)
            {
                table2.Visible = true;
                table1.Visible = false;
                this.lbUserName.Text = Session["Username"].ToString();
            }

            if (Session["Username"] != null)
            {
                table2.Visible = true;
                table1.Visible = false;
                this.lbUserName.Text = Session["Username"].ToString();
            }
        }
    }



    protected void btLogin_Click(object sender, ImageClickEventArgs e)
    {

        Session["UserID"] = null;
        Session["Username"] = null;
        string usercode = TxtUserCode.Text.Trim();
    if (TxtUserName.Text.Trim() == "" || TxtUserPwd.Text.Trim() == "")
        {
            Response.Write("<script>alert('登录名和密码不能为空！');location='javascript:history.go(-1)';</script>");
        }

    else if (usercode != Session["iCode"].ToString())
        { Response.Write("<script>alert('请输入正确的验证码！！');location='javascript:history.go(-1)';</script>"); }
        else
        {
           

            string strUid = TxtUserName.Text.Trim();
            string strPwd = TxtUserPwd.Text.Trim();
            string SQLStr = " select Username,UserID from [User] where Username='" + strUid + "' and mm='" + strPwd + "' ";
           
            OleDbDataReader dr = DBA.GetDataReader(SQLStr);
            if (dr.Read())
            {
               
                Session["UserID"] = dr["UserID"].ToString(); 
                Session["Username"] = strUid;
                Response.Write("<script>alert('登录成功！');location='index.aspx';</script>");
             
            }
            else
            {
               
                Response.Write("<script>alert(' 登录失败，用户不存在或者输入错误！');location='javascript:history.go(-1)';</script>");
            }
        
        }
       
       
        
        
   
        }
    
    protected void btRegister_Click(object sender, ImageClickEventArgs e)
    {
         Response.Redirect("zhuce.aspx");
    }
    
}