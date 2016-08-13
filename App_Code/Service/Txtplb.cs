using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Model;
using System.Web.Script.Serialization;
namespace Maticsoft.Service
{
    /// <summary>
    /// Adnmin
    /// </summary>
    public partial class Txtplb
    {
        Maticsoft.Dao.Txtplb txtplbDao = new Maticsoft.Dao.Txtplb();
        public Txtplb()
        { }
        #region  Method
        /// <summary>
        /// 全部信息查询，如select * from 表名 ordey by id desc
        /// </summary>
        public object searchbymodeloderbyid(Maticsoft.Model.Txtplb model)
        {
            //return ListToJson(commentDao.searchbymodel(model, "id.desc", null));
            return txtplbDao.searchbymodel(model, "id.desc", null);
        }
        public static string ListToJson(List<Maticsoft.Model.Txtplb> list)
        {
            return (new JavaScriptSerializer().Serialize(list)).ToString();
        }
        #endregion  Method

    }
}