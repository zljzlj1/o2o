using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class sw_addpro : System.Web.UI.Page
{

    DBAccess1 DBA = new DBAccess1();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dl();
        }
    }
    private void dl()
    {

        string SQL = "select * from 产品类别";//查询语句
        DataSet ds = DBA.GetDataSet(SQL);

        DropDownList1.DataSource = ds.Tables["datatable"].DefaultView;
        DropDownList1.DataTextField = "产品类别";
        DropDownList1.DataValueField = "流水号";
        DropDownList1.DataBind();

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        string 产品类别 = DropDownList1.SelectedItem.Text;
        string 产品名称 = TextBox1.Text;
        string 产品价格 = TextBox2.Text;
        string picture = Session["filename"].ToString();
        string 产品介绍 = content1.Value;
        if (TextBox1.Text != "" && TextBox2.Text != "")
        {
            string SQLStr = "insert into 产品(产品名称,产品价格,产品图片,产品类别,产品介绍)values('" + 产品名称 + "','" + 产品价格 + "','" + picture + "','" + 产品类别 + "','" + 产品介绍 + "')";
            OleDbDataReader dr = DBA.GetDataReader(SQLStr);
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "alert", " <script> alert('产品添加成功！');</script> ");
            TextBox1.Text = "";
            TextBox2.Text = "";
            content1.Value = "";
            DropDownList1.SelectedIndex = 0;
        }
        else
        {
            if (TextBox1.Text == "")
            {
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "alert", " <script> alert('产品名称不能为空！');</script> ");
            }
            if (TextBox2.Text == "")
            {
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "alert", " <script> alert('产品价格不能为空！');</script> ");
            }
        }
     
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile == true)
        {
            string filename = FileUpload1.FileName;
            Session["filename"] = "~/sw/images/cp" + filename;
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/sw/images/cp\\" + filename));
            Image1.ImageUrl = Session["filename"].ToString();
            int filesize = FileUpload1.PostedFile.ContentLength;
            
            if (filesize > 1024 * 1024)
            {
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "alert", " <script> alert('文件大小不能超过1M!');</script>");
                return;
            }
            string fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
            //允许许文件的扩展名保存到数组
            string[] allowExtension = { ".jpg", ".gif", ".txt", ".xls", ".png" };
            //在数组中查找是否存在fileExtension
            if (!allowExtension.Contains(fileExtension))
            {
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "alert", " <script> alert('不允许上传该文件!');</script>");
                return;
            }

        }
        else
        {
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "alert", " <script> alert('没有上传的图片！');</script> ");
        }
    }
}