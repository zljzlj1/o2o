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
    public partial class Txtplb
    {
        
        public Txtplb()
        { }
        #region  Method

        public string GetTablename()
        {
            string className = this.GetType().FullName;
            className = className.Substring(className.LastIndexOf(".") + 1);
            return className;
        }
        DBAccess1 DBA = new DBAccess1();

        public DataSet searchbymodel(Maticsoft.Model.Txtplb model, string orderby, string option)
        {
            StringBuilder strSql = new StringBuilder();
            Util dbc = new Util();
            strSql.Append("select * from " + GetTablename() + " where 1=1 ");
            string s = "";
            if (model != null)
            {
                if (model.wzplid > 0)
                {
                    strSql = dbc.optiontosql(strSql, "wzplid", model.wzplid.ToString(), option);
                }
                if (model.yhpl != null && model.yhpl.ToString() != "")
                {
                    strSql = dbc.optiontosql(strSql, "yhpl", model.yhpl.ToString(), option);
                }
                if (model.plsj != null && model.plsj.ToString() != "")
                {
                    strSql = dbc.optiontosql(strSql, "plsj", model.plsj.ToString(), option);
                }
                if (model.plyhid > 0)
                {
                    strSql = dbc.optiontosql(strSql, "plyhid", model.plyhid.ToString(), option);
                }
                if (model.toplyhid > 0)
                {
                    strSql = dbc.optiontosql(strSql, "toplyhid", model.toplyhid.ToString(), option);
                }
                if (model.txtid > 0)
                {
                    strSql = dbc.optiontosql(strSql, "txtid", model.txtid.ToString(), option);
                }
                if (model.sortid > 0)
                {
                    strSql = dbc.optiontosql(strSql, "sortid", model.sortid.ToString(), option);
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
        public int insertmodel(Maticsoft.Model.Txtplb model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.wzplid != null && model.wzplid.ToString() != "" && model.wzplid != 0)
            {
                strSql1.Append("wzplid,");
                strSql2.Append("'" + model.wzplid + "',");
            }
            if (model.yhpl != null && model.yhpl.ToString() != "")
            {
                strSql1.Append("yhpl,");
                strSql2.Append("'" + model.yhpl + "',");
            }
            if (model.plsj != null && model.plsj.ToString() != "")
            {
                strSql1.Append("plsj,");
                strSql2.Append("'" + model.plsj + "',");
            }
            if (model.plyhid != null && model.plyhid.ToString() != "" && model.plyhid != 0)
            {
                strSql1.Append("plyhid,");
                strSql2.Append("'" + model.plyhid + "',");
            }
            if (model.toplyhid != null && model.toplyhid.ToString() != "" && model.toplyhid != 0)
            {
                strSql1.Append("toplyhid,");
                strSql2.Append("'" + model.toplyhid + "',");
            }
            if (model.txtid != null && model.txtid.ToString() != "" && model.txtid != 0)
            {
                strSql1.Append("txtid,");
                strSql2.Append("'" + model.txtid + "',");
            }
            if (model.sortid != null && model.sortid.ToString() != "" && model.sortid != 0)
            {
                strSql1.Append("sortid,");
                strSql2.Append("'" + model.sortid + "',");
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
        public Maticsoft.Model.Txtplb DataRowToModel(DataRow row)
        {
            Maticsoft.Model.Txtplb model = new Maticsoft.Model.Txtplb();
            if (row != null)
            {
                if (row["wzplid"] != null && row["wzplid"].ToString() != "")
                {
                    model.wzplid = int.Parse(row["wzplid"].ToString());
                }
                if (row["yhpl"] != null)
                {
                    model.yhpl = row["yhpl"].ToString();
                }
                if (row["plsj"] != null)
                {
                    model.plsj = row["plsj"].ToString();
                }
                if (row["plyhid"] != null && row["plyhid"].ToString() != "")
                {
                    model.plyhid = int.Parse(row["plyhid"].ToString());
                }
                if (row["toplyhid"] != null && row["toplyhid"].ToString() != "")
                {
                    model.toplyhid = int.Parse(row["toplyhid"].ToString());
                }
                if (row["txtid"] != null && row["txtid"].ToString() != "")
                {
                    model.txtid = int.Parse(row["txtid"].ToString());
                }
                if (row["sortid"] != null && row["sortid"].ToString() != "")
                {
                    model.sortid = int.Parse(row["sortid"].ToString());
                }
                
            }
            return model;
        }
        #endregion  Method

    }
}