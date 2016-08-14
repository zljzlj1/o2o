using System;
using System.Collections.Generic;
using System.Web.Services; //引入命名空间


public partial class Comment : System.Web.UI.Page
{
    public static string UserID = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] != null)
        {
            UserID = Session["UserID"].ToString();
        }
    }
    [WebMethod]
    public static Object getCommentList(String txtid)
    {
        Maticsoft.Service.Txtplb txtplbService = new Maticsoft.Service.Txtplb();
        Maticsoft.Model.Txtplb model=new Maticsoft.Model.Txtplb();
        //文章ID
        model.txtid =   int.Parse(txtid);
        List<Maticsoft.Model.Txtplb> list = txtplbService.searchListByModel(model);
        List<Maticsoft.ToModel.Txtplb> tolist = new List<Maticsoft.ToModel.Txtplb>();
        for(int i=0;i<list.Count;i++)
        {
            Maticsoft.Model.Txtplb txtplb = list[i];
            Maticsoft.Service.User userService = new Maticsoft.Service.User();
            //查找评论人
            Maticsoft.Model.User plUsermodel = new Maticsoft.Model.User();
            plUsermodel.UserID = txtplb.plyhid;
            Maticsoft.Model.User plUser = userService.searchUserbymodel(plUsermodel);

            //查找受评论人
            Maticsoft.Model.User toPlUsermodel = new Maticsoft.Model.User();
            toPlUsermodel.UserID = txtplb.toplyhid;
            Maticsoft.Model.User toPlUser = userService.searchUserbymodel(toPlUsermodel);


            //封装返回html的数据
            Maticsoft.ToModel.Txtplb totxtplb = txtplb.ModelToModel(txtplb);
            totxtplb.plyhidstr = plUser.Username;
            totxtplb.toplyhidstr = toPlUser.Username;
            if (UserID != null) { 
                int usetid=int.Parse(UserID);
                //封装评论人
                if (txtplb.plyhid == usetid)
                {
                    totxtplb.plyhidstr= "我";
                }
                //封装受评论人
                if (txtplb.toplyhid == usetid)
                {
                    totxtplb.toplyhidstr = "我";
                }
            }
            tolist.Add(totxtplb);
        }
        return tolist;
    }

    [WebMethod]
    public static Object setComment(String sortid, String yhpl)
    {
        Dictionary<string, Object> data = new Dictionary<string, Object>();
        Maticsoft.ToModel.Txtplb toTxtplb = new Maticsoft.ToModel.Txtplb();
        Maticsoft.Service.Txtplb txtplbService = new Maticsoft.Service.Txtplb();
        if (UserID != null)
        {
            
            if (sortid != null)
            {
                int sortId = int.Parse(sortid);
                Maticsoft.Model.Txtplb model = new Maticsoft.Model.Txtplb();
                if (sortId == 0)
                {
                    //添加根评论内容
                    model.plyhid = int.Parse(UserID);
                    model.toplyhid = int.Parse(UserID);
                    model.plsj = DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss");
                    model.yhpl = yhpl;
                    model.sortid = sortId;
                    //文章ID
                    model.txtid = 2;
                    txtplbService.insertmodel(model);
                }
                else
                {
                    //添加根文件下的内容
                    Maticsoft.Model.Txtplb txtplbmodel = new Maticsoft.Model.Txtplb();
                    txtplbmodel.wzplid = int.Parse(sortid);
                    Maticsoft.Model.Txtplb txtplb = txtplbService.searchTxtplbbymodel(txtplbmodel);
                    if (int.Parse(UserID) == txtplb.plyhid) {
                        data.Add("result", false);
                        data.Add("msg", "不能评论自己的内容");
                        return data;
                    }

                    model.plyhid = int.Parse(UserID);
                    model.toplyhid = txtplb.plyhid;
                    model.plsj = DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss");
                    model.yhpl = yhpl;
                    model.sortid = sortId;
                    //文章ID
                    model.txtid = 2;
                    txtplbService.insertmodel(model);
                }
                data.Add("result", true);
                data.Add("msg", "评论成功");
            }
            
        }
        else
        {
            data.Add("result", false);
            data.Add("msg", "用户还没有登录，登录后才能评论");
        }
        return data;
    }

}