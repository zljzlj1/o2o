using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Maticsoft.Model
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
        /// 评论内容
        /// </summary>
        private string _yhpl;

        /// <summary>
        /// 评论回复级别
        /// </summary>
        private int _sortid;

        /// <summary>
        /// 评论人
        /// </summary>
        private int _plyhid;

        /// <summary>
        /// 文章id
        /// </summary>
        private int _txtid;

        /// <summary>
        /// 评论时间
        /// </summary>
        private string _plsj;

        /// <summary>
        /// 受评论人
        /// </summary>
        private int _toplyhid;

        public string yhpl
        {
            get { return _yhpl; }
            set { _yhpl = value; }
        }
        public int plyhid
        {
            get { return _plyhid; }
            set { _plyhid = value; }
        }
        public int txtid
        {
            get { return _txtid; }
            set { _txtid = value; }
        }
        public string plsj
        {
            get { return _plsj; }
            set { _plsj = value; }
        }
        public int toplyhid
        {
            get { return _toplyhid; }
            set { _toplyhid = value; }
        }
        public int sortid
        {
            get { return _sortid; }
            set { _sortid = value; }
        }
        public int wzplid
        {
            get { return _wzplid; }
            set { _wzplid = value; }
        }
        public Maticsoft.ToModel.Txtplb ModelToModel(Maticsoft.Model.Txtplb txtplb)
        {
            Maticsoft.ToModel.Txtplb totxtplb = new Maticsoft.ToModel.Txtplb();
            totxtplb.plyhid = txtplb.plyhid;
            totxtplb.toplyhid = txtplb.toplyhid;
            totxtplb.txtid = txtplb.txtid;
            totxtplb.sortid = txtplb.sortid;
            totxtplb.plsj = txtplb.plsj;
            totxtplb.wzplid = txtplb.wzplid;
            totxtplb.yhpl = txtplb.yhpl;
            return totxtplb;
        }
        #endregion Model

    }
}

