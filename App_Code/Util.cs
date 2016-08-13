using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections;
using System.Collections.Generic;
/// <summary>
///Database 的摘要说明
/// </summary
public class Util
{

    public Util()
    {

    }

    #region 公用方法

    /// <summary>
    /// sql进行模糊查询和精确查询语句的变换
    /// </summary>
    /// <param name="strSql"></param>
    /// <param name="fieldname"></param>
    /// <param name="fieldvalue"></param>
    /// <param name="option"></param>
    /// <returns></returns>
    public StringBuilder optiontosql(StringBuilder strSql, string fieldname, string fieldvalue, string option)
    {

        if (option == "=")
        {
            strSql.Append(fieldname + "='" + fieldvalue + "' and ");
        }
        else if (option == "like")
        {
            strSql.Append(fieldname + " like '%" + fieldvalue + "%' and ");
        }
        return strSql;
    }
    #endregion
}
