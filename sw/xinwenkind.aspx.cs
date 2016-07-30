using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class sw_xinwenkind : System.Web.UI.Page
{
    DBAccess1 DBA = new DBAccess1();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gw();
        }
    }
    private void gw()//数据库加载
    {
        string strsql = "select * from 新闻类别";
        DataSet ds = DBA.GetDataSet(strsql);
        GridView1.DataSource = ds.Tables["datatable"].DefaultView;
        GridView1.DataBind();
        Show();
    }
    private void Show()
    {//显示当前页数和总页数

        Label1.Text = "第 " + (GridView1.PageIndex + 1).ToString() + " 页";
        Label2.Text = "总共 " + GridView1.PageCount.ToString() + " 页";
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        gw();
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        gw();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string 流水号 = GridView1.DataKeys[e.RowIndex].Value.ToString();
        string strSQL = "delete from 新闻类别 where 流水号='" + 流水号 + "'";

        if ((GridView1.Rows.Count) % (GridView1.PageSize) == 1)//判断最后一页是否只有一条记录
        {
            GridView1.PageIndex = GridView1.PageIndex - 1;

            gw();
        }

        DataSet ds = DBA.GetDataSet(strSQL);
        gw();

    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = (int)e.NewEditIndex;
        gw();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {


        string 流水号 = GridView1.DataKeys[e.RowIndex].Value.ToString();
        string 新闻类别 = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[1].Controls[0])).Text.Trim();
        string strSQL = "Update 新闻类别 set 新闻类别='" + 新闻类别 + "' where 流水号='" + 流水号 + "'";
        OleDbDataReader dr = DBA.GetDataReader(strSQL);
        GridView1.EditIndex = -1;
        gw();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string mc = TextBox1.Text;
        if (mc != "")
        {
            string strSQL = "insert into 新闻类别(新闻类别) values('" + mc + "')";
            OleDbDataReader dr = DBA.GetDataReader(strSQL);
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "alert", " <script> alert('添加成功！');</script> ");
            gw();
            TextBox1.Text = "";
        }
        else
        {
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "alert", " <script> alert('请输入新闻类别！');</script> ");
        }
       
    }
    protected void lik(object sender, EventArgs e)
    {
        string arg = ((LinkButton)sender).CommandArgument.ToString();
        switch (arg)
        {//根据不同的arguement值,进行相应的操作：
            case "n":
                if (GridView1.PageIndex < GridView1.PageCount - 1)//判断是否为最后一条记录
                {
                    GridView1.PageIndex = GridView1.PageIndex + 1;//读取到下一页
                }
                break;//返回
            case "p":
                if (GridView1.PageIndex > 0)//判断是否为第一页
                {
                    GridView1.PageIndex = GridView1.PageIndex - 1;//读取到前一页的内容
                }
                break;
            case "l":
                GridView1.PageIndex = (GridView1.PageCount - 1);//读取最后一页
                break;
            default://不满足上述情况，则读取首页的内容
                GridView1.PageIndex = 0;
                break;
        }
        gw();
    }
}