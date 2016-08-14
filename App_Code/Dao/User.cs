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
namespace Maticsoft.Dao
{

    /// <summary>
    /// Method
    /// </summary>
    /// 
    public partial class User
    {

        public User()
        { }
        #region  Method

        public string GetTablename()
        {
            string className = this.GetType().FullName;
            className = className.Substring(className.LastIndexOf(".") + 1);
            return className;
        }
        DBAccess1 DBA = new DBAccess1();

        public DataSet searchbymodel(Maticsoft.Model.User model, string orderby, string option)
        {
            StringBuilder strSql = new StringBuilder();
            Util dbc = new Util();
            strSql.Append("select * from [" + GetTablename() + "] where 1=1 ");
            string s = "";
            if (model != null)
            {
                if (model.UserID > 0)
                {
                    strSql = dbc.optiontosql(strSql, "UserID", model.UserID.ToString(), option);
                }
                if (model.Username != null && model.Username.ToString() != "")
                {
                    strSql = dbc.optiontosql(strSql, "Username", model.Username.ToString(), option);
                }
                if (model.lxdh != null && model.lxdh.ToString() != "")
                {
                    strSql = dbc.optiontosql(strSql, "lxdh", model.lxdh.ToString(), option);
                }
                if (model.yb != null && model.yb.ToString() != "")
                {
                    strSql = dbc.optiontosql(strSql, "yb", model.yb.ToString(), option);
                }
                if (model.sfid > 0)
                {
                    strSql = dbc.optiontosql(strSql, "sfid", model.sfid.ToString(), option);
                }
                if (model.sid > 0)
                {
                    strSql = dbc.optiontosql(strSql, "sid", model.sid.ToString(), option);
                }
                if (model.xid > 0)
                {
                    strSql = dbc.optiontosql(strSql, "xid", model.xid.ToString(), option);
                }
                if (model.zid > 0)
                {
                    strSql = dbc.optiontosql(strSql, "zid", model.zid.ToString(), option);
                }
                if (model.cid > 0)
                {
                    strSql = dbc.optiontosql(strSql, "cid", model.cid.ToString(), option);
                }
                if (model.mm != null && model.mm.ToString() != "")
                {
                    strSql = dbc.optiontosql(strSql, "mm", model.mm.ToString(), option);
                }
                if (model.Jtdz != null && model.Jtdz.ToString() != "")
                {
                    strSql = dbc.optiontosql(strSql, "Jtdz", model.Jtdz.ToString(), option);
                }
                if (model.truename != null && model.truename.ToString() != "")
                {
                    strSql = dbc.optiontosql(strSql, "truename", model.truename.ToString(), option);
                }
                
            }
            s = strSql.ToString();
            if (orderby != null && orderby != "")
            {
                string[] a = orderby.Split('.');
                s = s + " order by " + a[0].ToString() + " " + a[1].ToString();
            }
            return DBA.GetDataSet(s.ToString());
        }
        public int insertmodel(Maticsoft.Model.User model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.UserID > 0)
            {
                strSql1.Append("UserID,");
                strSql2.Append("'" + model.UserID + "',");
            }
            if (model.Username != null && model.Username.ToString() != "")
            {
                strSql1.Append("Username,");
                strSql2.Append("'" + model.Username + "',");
            }
            if (model.lxdh != null && model.lxdh.ToString() != "")
            {
                strSql1.Append("lxdh,");
                strSql2.Append("'" + model.lxdh + "',");
            }
            if (model.yb != null && model.yb.ToString() != "")
            {
                strSql1.Append("yb,");
                strSql2.Append("'" + model.yb + "',");
            }
            if (model.sfid > 0)
            {
                strSql1.Append("sfid,");
                strSql2.Append("'" + model.sfid + "',");
            }
            if (model.sid > 0)
            {
                strSql1.Append("sid,");
                strSql2.Append("'" + model.sid + "',");
            }
            if (model.xid > 0)
            {
                strSql1.Append("xid,");
                strSql2.Append("'" + model.xid + "',");
            }
            if (model.zid > 0)
            {
                strSql1.Append("zid,");
                strSql2.Append("'" + model.zid + "',");
            }
            if (model.cid > 0)
            {
                strSql1.Append("cid,");
                strSql2.Append("'" + model.cid + "',");
            }
            if (model.mm != null && model.mm.ToString() != "")
            {
                strSql1.Append("mm,");
                strSql2.Append("'" + model.mm + "',");
            }
            if (model.Jtdz != null && model.Jtdz.ToString() != "")
            {
                strSql1.Append("Jtdz,");
                strSql2.Append("'" + model.Jtdz + "',");
            }
            if (model.truename != null && model.truename.ToString() != "")
            {
                strSql1.Append("truename,");
                strSql2.Append("'" + model.truename + "',");
            }
            strSql.Append("insert into " + GetTablename() + "(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            return DBA.ExeSqlRows(strSql.ToString());
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.User DataRowToModel(DataRow row)
        {
            Maticsoft.Model.User model = new Maticsoft.Model.User();
            if (row != null)
            {
                if (row["UserID"] != null && row["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(row["UserID"].ToString());
                }
                if (row["Username"] != null)
                {
                    model.Username = row["Username"].ToString();
                }
                if (row["lxdh"] != null)
                {
                    model.lxdh = row["lxdh"].ToString();
                }
                if (row["yb"] != null)
                {
                    model.lxdh = row["yb"].ToString();
                }
                if (row["sfid"] != null && row["sfid"].ToString() != "")
                {
                    model.sfid = int.Parse(row["sfid"].ToString());
                }
                if (row["sid"] != null && row["sid"].ToString() != "")
                {
                    model.sid = int.Parse(row["sid"].ToString());
                }
                if (row["xid"] != null && row["xid"].ToString() != "")
                {
                    model.xid = int.Parse(row["xid"].ToString());
                }
                if (row["zid"] != null && row["zid"].ToString() != "")
                {
                    model.zid = int.Parse(row["zid"].ToString());
                }
                if (row["cid"] != null && row["cid"].ToString() != "")
                {
                    model.cid = int.Parse(row["cid"].ToString());
                }
                if (row["mm"] != null)
                {
                    model.mm = row["mm"].ToString();
                }
                if (row["Jtdz"] != null)
                {
                    model.Jtdz = row["Jtdz"].ToString();
                }
                if (row["truename"] != null)
                {
                    model.truename = row["truename"].ToString();
                }
            }
            return model;
        }
        #endregion  Method

    }
}