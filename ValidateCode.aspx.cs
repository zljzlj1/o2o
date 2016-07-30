using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//该源码下载自【编程联盟】ASp.Net下载中心 http://aspx.bcbbs.net
public partial class Code : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        DrawCode();
    }
    public void DrawCode()
    {
        int width = 60;
        int height = 20;
        //创建图象
        Bitmap img = new Bitmap(width, height);
        //从图象上获取一个绘画图
        Graphics g = Graphics.FromImage(img);
        try
        {
            //定义字体
            Font font = new Font("Comic sans ms", 12, FontStyle.Bold);
            //定义黑色画笔
            SolidBrush brush = new SolidBrush(Color.Black);
            //定义钢笔,绘制干扰线
            Pen pen1 = new Pen(Color.Gray);
            Pen pen2 = new Pen(Color.Gray);

            //清除整个绘画图面并以指定颜色填充
            g.Clear(ColorTranslator.FromHtml("#F0F0F0"));
            //定义文字的绘制矩形区域
            Rectangle rect = new Rectangle(2, 2, width, height);
            //定义一个随机数用于绘制干扰线
            Random rand = new Random();
            //生成两条横向干扰线
            for (int i = 0; i < 2; i++)
            {
                //Define Point1
                Point p1 = new Point(0, rand.Next(height));
                //Define Point2
                Point p2 = new Point(width, rand.Next(height));
                g.DrawLine(pen1, p1, p2);
            }
            //生成四条纵向干扰线
            for (int i = 0; i < 4; i++)
            {
                //Define Point1
                Point p1 = new Point(rand.Next(width), 0);
                //Define Point2
                Point p2 = new Point(rand.Next(width), height);
                //DrawLine
                g.DrawLine(pen2, p1, p2);
            }
            string strsj = strRand();
            g.DrawString(strsj, font, brush, rect);
            //输出图象            
            img.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            Session["iCode"] = strsj.ToLower();
            //return strRand().ToLower();
        }
        catch (Exception error)
        {
            throw new Exception(error.Message);
        }
        finally
        {
            g.Dispose();
            img.Dispose();
        }
    }
    //产生随机数
    public string strRand()
    {
        char[] strCode = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        string strRandomCode = "";
        Random random = new Random();
        for (int i = 0; i < 4; i++)
        {
            strRandomCode += strCode[random.Next(strCode.Length)];
        }
        return strRandomCode;
    }
}
