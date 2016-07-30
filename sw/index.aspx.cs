using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class sw_index : System.Web.UI.Page
{
    DBAccess1 DBA = new DBAccess1();
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        Panel1.Visible = false;
        Panel2.Visible = false;
       
        if (Session["UserName"]!=null)
        {
         Session["name"] = Session["UserName"].ToString();
         
        }
     
        if (Session["name"] != null)
        {
            Label1.Text = Session["name"].ToString();
    
            Panel2.Visible = true;
      
          
        }
        else 
        {
            Panel1.Visible = true;
        }
            
 }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string sqlstr="select * from  用户 Where 管理员标志=0 and 用户名='" + TextBox1.Text+ "' and 密码 = '" + TextBox2.Text + "'";
        DataSet ds = new DataSet();
        ds = DBA.GetDataSet(sqlstr);
        
        if (ds.Tables[0].Rows.Count == 0)
            {
                if (TextBox1.Text == "" || TextBox2.Text == "")
            {
             string scriptStringd = "alert('" + "用户名未写或密码未写，请确认后再登录！" + "');";
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "warning", scriptStringd, true);
            }
            else
            {
                string scriptString = "alert('" + "用户名不存在或密码错误，请确认后再登录！" + "');";
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "warning", scriptString, true);
            }
            }
            else
            {
               
                Session["name"] = TextBox1.Text;
                Label1.Text = "<b>" + Session["name"].ToString() + "</b>";
                Panel1.Visible = false;
                Panel2.Visible = true;

            }
    }

    protected void Button3_Click1(object sender, EventArgs e)
    {
        Session["name"] = null;
        Session["UserName"] = null;
        ClientScript.RegisterStartupScript(ClientScript.GetType(), "alert", "<script>alert('退出成功!');location.href= 'index.aspx ' ; </script>");
    }
   
}