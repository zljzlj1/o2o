using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Web.Services; //引入命名空间

public partial class Comment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    [WebMethod]
    public static Object getCommentList()
    {
        Maticsoft.Service.Txtplb txtplbService = new Maticsoft.Service.Txtplb();
        Object a=txtplbService.searchbymodeloderbyid(null);
        return a;
    }
}