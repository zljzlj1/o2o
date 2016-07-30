using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Odbc;

public partial class sw_newsxin : System.Web.UI.Page
{


    DBAccess1 DBA = new DBAccess1();


    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {

            if (Request.QueryString["id"] != null)
            {

                gw();
            }
            else
            {
                Response.Write("<script>alert('ID值为空')</script>");
            }




        }
    }
    private void Show()
    {//显示当前页数和总页数

        Label1.Text = "第 " + (GridView1.PageIndex + 1).ToString() + " 页";
        if (GridView1.PageCount > 1)
        {
            Label2.Text = "总共 " + GridView1.PageCount.ToString() + " 页";
        }
        else
        {
            Label2.Text = "总共 " + 1 + " 页";
        }
    }
    private void gw()//数据库加载
    {
        string strsql = "select * from 新闻信息 where 新闻类别 like'" + Request.QueryString["id"].ToString() + "'";


        DataSet ds = DBA.GetDataSet(strsql);
        GridView1.DataSource = ds.Tables["datatable"].DefaultView;
        GridView1.DataBind();
        Show();

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
                if (GridView1.PageCount > 1)
                {
                    GridView1.PageIndex = (GridView1.PageCount - 1);//读取最后一页
                }
                else
                {
                    GridView1.PageIndex = GridView1.PageCount;
                }

                break;
            default://不满足上述情况，则读取首页的内容
                GridView1.PageIndex = 0;
                break;
        }
        gw();//加载数据库内容
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        gw();
    }
    
    
}