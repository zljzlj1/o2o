using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class sw_newsadd : System.Web.UI.Page
{
    DBAccess1 DBA = new DBAccess1();
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Text = System.DateTime.Now.ToString();
        if (!IsPostBack)
        {
            dw1();
        }
    }
    private void dw1()
    {
        string SQL = "select * from 新闻类别";//查询语句
        DataSet ds = DBA.GetDataSet(SQL);
        DropDownList1.DataSource = ds.Tables["datatable"].DefaultView;
        DropDownList1.DataTextField = "新闻类别";
        DropDownList1.DataValueField = "流水号";
        DropDownList1.DataBind();

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string bt = TextBox1.Text;
        string yd = TextBox2.Text;
        string nr = content1.Value;
        if (TextBox1.Text != "" && content1.Value != "")
        {
            string SQLStr = "insert into 新闻信息(新闻标题,新闻内容,新闻类别,添加时间,阅读次数)values('" + bt + "','" + nr + "','" + DropDownList1.SelectedItem.Text + "','" + Label1.Text + "','" + yd + "')";
            OleDbDataReader dr = DBA.GetDataReader(SQLStr);
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "alert", " <script> alert('新闻添加成功！');</script> ");
            TextBox1.Text = "";
            TextBox2.Text = "";

            content1.Value = "";
        }
        else
        {
            
            if (TextBox1.Text == "")
            {
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "alert", " <script> alert('请添加新闻标题！');</script> ");
            }
            if (content1.Value == "")
            {
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "alert", " <script> alert('请添加新闻内容！');</script> ");
            }
        
        }

    }
}