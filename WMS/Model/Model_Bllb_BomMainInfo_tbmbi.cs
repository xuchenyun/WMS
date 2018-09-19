/*************************************************************
* 版权所有 ＠ 薛建武 
* 创建时间：2017/10/27 17:28:27
 *************************************************************/
using System;
namespace Model
{
   /// <summary>
   /// 对象类 T_Bllb_BomMainInfo_tbmbi[产品BOM信息主表]
   /// </summary>
   [Serializable]
   public class Model_Bllb_BomMainInfo_tbmbi
   {
        private String _TBMBI_ID;// ID
        private String _PRODUCTCODE;// 产品代码
        private String _IS_ENABLE;// 是否启用
        private String _IS_DEFAULT;// 是否默认
        private String _VER;// 产品代码版本
        private String _CREATOR;// 创建人员工号
        private DateTime _CREATE_TIME;// 创建时间
        private String _UPDATOR;// 更新人员工号
        private DateTime _UPDATE_TIME;// 更新时间

       public Model_Bllb_BomMainInfo_tbmbi()
       {
            this._TBMBI_ID="";
            this._PRODUCTCODE="";
            this._IS_ENABLE="";
            this._IS_DEFAULT="";
            this._VER="";
            this._CREATOR="";
            this._CREATE_TIME=DateTime.Parse("1900-01-01");
            this._UPDATOR="";
            this._UPDATE_TIME=DateTime.Parse("1900-01-01");

       }
        /// <summary>
        /// ID
        /// </summary>
        public String TBMBI_ID
        {
            set { _TBMBI_ID = value; }
            get { return _TBMBI_ID; }
        }
        /// <summary>
        /// 产品代码
        /// </summary>
        public String PRODUCTCODE
        {
            set { _PRODUCTCODE = value; }
            get { return _PRODUCTCODE; }
        }
        /// <summary>
        /// 是否启用
        /// </summary>
        public String IS_ENABLE
        {
            set { _IS_ENABLE = value; }
            get { return _IS_ENABLE; }
        }
        /// <summary>
        /// 是否默认
        /// </summary>
        public String IS_DEFAULT
        {
            set { _IS_DEFAULT = value; }
            get { return _IS_DEFAULT; }
        }
        /// <summary>
        /// 产品代码版本
        /// </summary>
        public String VER
        {
            set { _VER = value; }
            get { return _VER; }
        }
        /// <summary>
        /// 创建人员工号
        /// </summary>
        public String CREATOR
        {
            set { _CREATOR = value; }
            get { return _CREATOR; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CREATE_TIME
        {
            set { _CREATE_TIME = value; }
            get { return _CREATE_TIME; }
        }
        /// <summary>
        /// 更新人员工号
        /// </summary>
        public String UPDATOR
        {
            set { _UPDATOR = value; }
            get { return _UPDATOR; }
        }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UPDATE_TIME
        {
            set { _UPDATE_TIME = value; }
            get { return _UPDATE_TIME; }
        }
   }
}