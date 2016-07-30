using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class sw_newguanli : System.Web.UI.Page
{
    DBAccess1 DBA = new DBAccess1();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gw();
            dw1();
            Session["id"] = null;
        }
    }
    private void Show()
    {//显示当前页数和总页数

        Label1.Text = "第 " + (GridView1.PageIndex + 1).ToString() + " 页";
        Label2.Text = "总共 " + GridView1.PageCount.ToString() + " 页";
    }
    private void gw()//数据库加载
    {
        string strsql = "select * from 新闻信息 where 新闻类别 ='企业新闻'";
        DataSet ds = DBA.GetDataSet(strsql);
        GridView1.DataSource = ds.Tables["datatable"].DefaultView;
        GridView1.DataBind();
        Show();
    }
    private void gw1()//数据库加载
    {

        string vd = Session["id"].ToString();

        string strsql = "select * from 新闻信息 where 新闻类别 like'" + vd + "'";

        DataSet ds = DBA.GetDataSet(strsql);
        GridView1.DataSource = ds.Tables["datatable"].DefaultView;
        GridView1.DataBind();
        Show();

    }
    private void pd()
    {
        if (Session["id"] == null)
        {
            gw();
        }
        else
        {
            gw1();
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
    protected void link(object sender, EventArgs e)
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
        pd();
    }


    protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
    {

        string vid = DropDownList1.SelectedItem.Text;
        Session["id"] = vid;
        gw1();
        Show();
    }
    protected void GridView1_PageIndexChanging1(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        pd();
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        pd();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string 流水号 = GridView1.DataKeys[e.RowIndex].Value.ToString();
        string strSQL = "delete from 新闻信息 where 流水号='" + 流水号 + "'";

        if ((GridView1.Rows.Count) % (GridView1.PageSize) == 1)//判断最后一页是否只有一条记录
        {
            GridView1.PageIndex = GridView1.PageIndex - 1;

            pd();
        }

        DataSet ds = DBA.GetDataSet(strSQL);
        pd();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string 流水号 = GridView1.DataKeys[e.RowIndex].Value.ToString();

        string 新闻标题 = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[1].Controls[0])).Text.Trim();
        string 新闻类别 = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[2].Controls[0])).Text.Trim();
        string 添加时间 = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[3].Controls[0])).Text.Trim();
        string 阅读次数 = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[4].Controls[0])).Text.Trim();
        string strSQL = "Update 新闻信息 set 新闻标题='" + 新闻标题 + "',新闻类别='" + 新闻类别 + "',添加时间='" + 添加时间 + "',阅读次数='" + 阅读次数 + "' where 流水号='" + 流水号 + "'";
        DataSet ds = DBA.GetDataSet(strSQL);


        GridView1.EditIndex = -1;
        pd();
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = (int)e.NewEditIndex;
        pd();
    }
}