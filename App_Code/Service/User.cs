using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Model;
using System.Collections;
using System.Web.Script.Serialization;
namespace Maticsoft.Service
{
    /// <summary>
    /// Adnmin
    /// </summary>
    public partial class User
    {
        Maticsoft.Dao.User userDao = new Maticsoft.Dao.User();
        public User()
        { }
        #region  Method
        /// <summary>
        /// 获取文章评论列表
        /// 全部信息查询，如select * from 表名
        /// 返回list集合
        /// </summary>
        public List<Maticsoft.Model.User> searchListByModel(Maticsoft.Model.User model)
        {
            DataSet ds = userDao.searchbymodel(model, null, "=");
            int count = ds.Tables[0].Rows.Count;
            if (count > 0)
            {
                List<Maticsoft.Model.User> list = new List<Model.User>();
                for (int i = 0; i < count; i++)
                {
                    list.Add(userDao.DataRowToModel(ds.Tables[0].Rows[i]));
                }
                return list;
            }
            return null;
        }
        /// <summary>
        /// 发表评论
        /// 添加model信息到数据库中,如insert into 表名 （字段名，...）values （‘添加的内容’，....)
        /// </summary>
        public int insertmodel(Maticsoft.Model.User model)
        {
            return userDao.insertmodel(model);
        }
        /// <summary>
        /// 获取User
        /// 根据model查询，如select * from 表名 where 字段= '查询的内容'
        /// </summary>
        public DataSet searchDatasetByModel(Maticsoft.Model.User model)
        {
            return userDao.searchbymodel(model, null, "=");
        }

        /// <summary>
        /// 根据model查询，如select * from 表名 where 字段= '查询的内容'
        /// 然后再将查询的DataSet内容转换成需要查询mode，这个model包括全部信息
        /// </summary>
        public Maticsoft.Model.User searchUserbymodel(Maticsoft.Model.User model)
        {
            DataSet result = this.searchDatasetByModel(model);
            if (result.Tables[0].Rows.Count > 0)
            {
                return userDao.DataRowToModel(result.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        public static string ListToJson(List<Maticsoft.Model.User> list)
        {
            return (new JavaScriptSerializer().Serialize(list)).ToString();
        }
        #endregion  Method

    }
}