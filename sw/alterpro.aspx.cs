using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class sw_alterpro : System.Web.UI.Page
{
    DBAccess1 DBA = new DBAccess1();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dl();
            gw();
        }
    }
    private void gw()
    {
        string vid = Request["vid"].ToString();
        string str = "select * from 产品 where 流水号=" + vid;
        OleDbDataReader dr = DBA.GetDataReader(str);
        if (dr.Read())
        {

            TextBox1.Text = dr["产品名称"].ToString();
            TextBox2.Text = dr["产品价格"].ToString();
            Image1.ImageUrl = dr["产品图片"].ToString();
            Session["filename"] = dr["产品图片"].ToString();
            content1.Value = dr["产品介绍"].ToString();
            string x = dr["产品类别"].ToString();
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
        string strsql = "Update 产品 set 产品名称='" + 产品名称 + "',产品类别='" + 产品类别 + "',产品价格='" + 产品价格 + "',产品图片='" + picture + "', 产品介绍='" + 产品介绍 + "' where  流水号='" + Request["vid"].ToString() + "'";
        DBA.ExeSql(strsql);
        ClientScript.RegisterStartupScript(ClientScript.GetType(), "alert", "<script>alert('修改信息成功!');</script>");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile == true)
        {
            string filename = FileUpload1.FileName;
            Session["filename"] = "~/sw/images/cp\\" + filename;
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