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
        public List<Maticsoft.Model.Txtplb> searchbymodel(Maticsoft.Model.Txtplb model, string orderby, string option)
        {
            StringBuilder strSql = new StringBuilder();
            Util dbc = new Util();
            strSql.Append("select * from " + GetTablename() + " where ");
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
                s = strSql.ToString().Remove(strSql.Length - 5);
            }
            else
            {
                s = strSql.ToString().Remove(strSql.Length - 7);
            }
            //if (orderby != null && orderby != "")
            //{
            //    string[] a = orderby.Split('.');
            //    s = s + " order by " + a[0].ToString() + " " + a[1].ToString();
            //}
            DataSet ds = DBA.GetDataSet(s.ToString());
            int count = ds.Tables[0].Rows.Count;
            if (count > 0)
            {
                List<Maticsoft.Model.Txtplb> list = new List<Model.Txtplb>();
                for (int i = 0; i < count; i++)
                {
                    list.Add(DataRowToModel(ds.Tables[0].Rows[i]));
                }
                return list;
            }
            return null;
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