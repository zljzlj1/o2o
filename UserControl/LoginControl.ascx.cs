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

public partial class UserControl_LoginControl : System.Web.UI.UserControl
{
   /*
   DBClass dbObj = new DBClass();
    UserInfoClass uiObj = new UserInfoClass();
*/
    protected void Page_Load(object sender, EventArgs e)
    {
        TxtUserCode.BackColor = System.Drawing.Color.Transparent;
        TxtUserPwd.BackColor = System.Drawing.Color.Transparent;
        TxtUserName.BackColor = System.Drawing.Color.Transparent;
       /* if (!IsPostBack)
        {
            //lbCode.Text = new randomCode().RandomNum(4);//产生验证码
            if (Session["UID"] != null)
            {
                table2.Visible = true;
                table1.Visible = false;
                this.lbUserName.Text = Session["Username"].ToString();
            }
        }*/
    }
    protected void btLogin_Click(object sender, ImageClickEventArgs e)
    {
        /*
        Session["UID"] = null;
        Session["Username"] = null;
        if (TxtUserName.Text.Trim() == "" || TxtUserPwd.Text.Trim() == "")
        {
            Response.Write("<script>alert('登录名和密码不能为空！');location='javascript:history.go(-1)';</script>");
        }
        else
        {
            if (TxtUserCode.Text.Trim().CompareTo(lbValid.ImageUrl.ToString()) == 1)
            {
                int p_Int_IsExists = uiObj.UserExists(TxtUserName.Text.Trim(), TxtUserPwd.Text.Trim());
                if (p_Int_IsExists == 100)
                {
                    DataSet ds = uiObj.ReturnUIDs(TxtUserName.Text.Trim(), TxtUserPwd.Text.Trim(), "UserInfo");
                    Session["UID"] = Convert.ToInt32(ds.Tables["UserInfo"].Rows[0][0].ToString());
                    Session["Username"] = ds.Tables["UserInfo"].Rows[0][1].ToString();
                    Response.Redirect("index.aspx");
                }
                else
                {
                    Response.Write("<script>alert('您的登录有误，请核对后再重新登录!');location='javascript:history.go(-1)';</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('请正确输入验证码！');location='javascript:history.go(-1)';</script>");
            }
        }*/
    }
    protected void btRegister_Click(object sender, ImageClickEventArgs e)
    {
       // Response.Redirect("Register.aspx");
    }
    
}