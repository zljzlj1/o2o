using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Maticsoft.Model
{

    [Serializable]
    public partial class User
    {
        public User()
        { }
        #region Model

        /// <summary>
        /// 用户id
        /// </summary>
        private int _UserID;
        /// <summary>
        /// 用户id
        /// </summary>
        public int UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }

        /// <summary>
        /// 用户名
        /// </summary>
        private string _Username;
        /// <summary>
        /// 用户名
        /// </summary>
        public string Username
        {
            get { return _Username; }
            set { _Username = value; }
        }

        /// <summary>
        /// 联系电话
        /// </summary>
        private string _lxdh;
        /// <summary>
        /// 联系电话
        /// </summary>
        public string lxdh
        {
            get { return _lxdh; }
            set { _lxdh = value; }
        }

        /// <summary>
        /// 邮编
        /// </summary>
        private string _yb;
        /// <summary>
        /// 邮编
        /// </summary>
        public string yb
        {
            get { return _yb; }
            set { _yb = value; }
        }

        /// <summary>
        /// 省份id
        /// </summary>
        private int _sfid;
        /// <summary>
        /// 省份id
        /// </summary>
        public int sfid
        {
            get { return _sfid; }
            set { _sfid = value; }
        }

        /// <summary>
        /// 市id
        /// </summary>
        private int _sid;
        /// <summary>
        /// 市id
        /// </summary>
        public int sid
        {
            get { return _sid; }
            set { _sid = value; }
        }

        /// <summary>
        /// 县id
        /// </summary>
        private int _xid;
        /// <summary>
        /// 县id
        /// </summary>
        public int xid
        {
            get { return _xid; }
            set { _xid = value; }
        }

        /// <summary>
        /// 镇id
        /// </summary>
        private int _zid;
        /// <summary>
        /// 镇id
        /// </summary>
        public int zid
        {
            get { return _zid; }
            set { _zid = value; }
        }
        /// <summary>
        /// 村id
        /// </summary>
        private int _cid;
        /// <summary>
        /// 村id
        /// </summary>
        public int cid
        {
            get { return _cid; }
            set { _cid = value; }
        }
        /// <summary>
        /// 密码
        /// </summary>
        private string _mm;
        /// <summary>
        /// 密码
        /// </summary>
        public string mm
        {
            get { return _mm; }
            set { _mm = value; }
        }
        /// <summary>
        /// 具体地址
        /// </summary>
        private string _Jtdz;
        /// <summary>
        /// 具体地址
        /// </summary>
        public string Jtdz
        {
            get { return _Jtdz; }
            set { _Jtdz = value; }
        }
        /// <summary>
        /// 真实姓名
        /// </summary>
        private string _truename;
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string truename
        {
            get { return _truename; }
            set { _truename = value; }
        }
        
        #endregion Model

    }
}

