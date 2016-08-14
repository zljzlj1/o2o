using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Maticsoft.ToModel
{

    [Serializable]
    public partial class Txtplb
    {
        public Txtplb()
        { }
        #region Model

        /// <summary>
        /// 评论id
        /// </summary>
        private int _wzplid;
        /// <summary>
        /// 评论id
        /// </summary>
        public int wzplid
        {
            get { return _wzplid; }
            set { _wzplid = value; }
        }

        /// <summary>
        /// 评论内容
        /// </summary>
        private string _yhpl;
        /// <summary>
        /// 评论内容
        /// </summary>
        public string yhpl
        {
            get { return _yhpl; }
            set { _yhpl = value; }
        }

        /// <summary>
        /// 评论回复级别
        /// </summary>
        private int _sortid;
        /// <summary>
        /// 评论回复级别
        /// </summary>
        public int sortid
        {
            get { return _sortid; }
            set { _sortid = value; }
        }

        /// <summary>
        /// 评论人
        /// </summary>
        private int _plyhid;
        /// <summary>
        /// 评论人
        /// </summary>
        public int plyhid
        {
            get { return _plyhid; }
            set { _plyhid = value; }
        }

        /// <summary>
        /// 评论人注释，若评论人为当前用户的话显示为我,否则显示为用户姓名
        /// </summary>
        private string _plyhidstr;
        /// <summary>
        /// 评论人注释，若评论人为当前用户的话显示为我,否则显示为用户姓名
        /// </summary>
        public string plyhidstr
        {
            get { return _plyhidstr; }
            set { _plyhidstr = value; }
        }

        /// <summary>
        /// 文章id
        /// </summary>
        private int _txtid;
        /// <summary>
        /// 文章id
        /// </summary>
        public int txtid
        {
            get { return _txtid; }
            set { _txtid = value; }
        }

        /// <summary>
        /// 评论时间
        /// </summary>
        private string _plsj;
        /// <summary>
        /// 评论时间
        /// </summary>
        public string plsj
        {
            get { return _plsj; }
            set { _plsj = value; }
        }

        /// <summary>
        /// 受评论人
        /// </summary>
        private int _toplyhid;
        /// <summary>
        /// 受评论人
        /// </summary>
        public int toplyhid
        {
            get { return _toplyhid; }
            set { _toplyhid = value; }
        }

        /// <summary>
        /// 受评论人注释，若评论人为当前用户的话显示为我,否则显示为用户姓名
        /// </summary>
        private string _toplyhidstr;

        /// <summary>
        /// 受评论人注释，若评论人为当前用户的话显示为我,否则显示为用户姓名
        /// </summary>
        public string toplyhidstr
        {
            get { return _toplyhidstr; }
            set { _toplyhidstr = value; }
        }
        
        #endregion Model

    }
}

