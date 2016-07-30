using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class sw_xiugainews : System.Web.UI.Page
{
    DBAccess1 DBA = new DBAccess1();
    protected void Page_Load(object sender, EventArgs e)
    {
        //判断是否初次加载
        if (!IsPostBack)
        {
            dw();
            gw();
            Label1.Text = Request["vid"].ToString();
        }
    }
    private void gw()
    {
        string vid = Request["vid"].ToString();
        string str = "select * from 新闻信息 where 流水号=" + vid;
        OleDbDataReader dr = DBA.GetDataReader(str);
        if (dr.Read())
        {

            TextBox1.Text = dr["新闻标题"].ToString();
            TextBox2.Text = dr["阅读次数"].ToString();
            TextBox3.Text = dr["添加时间"].ToString();
            content1.Value = dr["新闻内容"].ToString();
            string x = dr["新闻类别"].ToString();
            int i;
            for (i = 0; i < DropDownList1.Items.Count; i++)
            {
                if (DropDownList1.Items[i].Text == x)
                {
                    DropDownList1.Items[i].Selected = true;
                }
            }
        }

    }

    private void dw()
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
        string 新闻标题 = TextBox1.Text;
        string 阅读次数 = TextBox2.Text;
        string 新闻内容 = content1.Value;
        string 新闻类别 = DropDownList1.SelectedItem.Text;
        string 添加时间 = TextBox3.Text;
        string strsql = "Update 新闻信息 set 新闻标题='" + 新闻标题 + "',阅读次数='" + 阅读次数 + "',新闻内容='" + 新闻内容 + "',新闻类别='" + 新闻类别 + "',添加时间='" + 添加时间 + "' where  流水号='" + Request["vid"].ToString() + "'";
        DBA.ExeSql(strsql);
        ClientScript.RegisterStartupScript(ClientScript.GetType(), "alert", "<script>alert('修改信息成功!');location.href='newguanli.aspx';</script>");
        gw();
        dw();
    }
}