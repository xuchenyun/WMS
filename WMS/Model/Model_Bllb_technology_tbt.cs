/*************************************************************
* 版权所有 ＠ 薛建武 
* 创建时间：2017/7/14 14:11:53
 *************************************************************/
using System;
namespace Model
{
    /// <summary>
    /// 对象类 T_Bllb_technology_tbt[工艺名称主表]
    /// </summary>
    [Serializable]
    public class Model_Bllb_technology_tbt
    {
        private String _TBT_ID;
        private String _TECH_NAME;
        private String _TECH_DESC;
        private String _CREATOR;
        private DateTime _CREATE_TIME;
        private String _MODIFIER;
        private DateTime _MODIFY_TIME;
        private String _FLOWXMLFILE;  
        private string _IS_DISABLE;//是否禁用
        public Model_Bllb_technology_tbt()
        {
            this._TBT_ID = "";
            this._TECH_NAME = "";
            this._TECH_DESC = "";
            this._CREATOR = "";
            this._CREATE_TIME = DateTime.Parse("1900-01-01");
            this._MODIFIER = "";
            this._MODIFY_TIME = DateTime.Parse("1900-01-01");
            this._FLOWXMLFILE = string.Empty;  
            this._IS_DISABLE = "";

        }
        /// <summary>
        /// 工艺ID(全球唯一码)
        /// </summary>
        public String TBT_ID
        {
            set { _TBT_ID = value; }
            get { return _TBT_ID; }
        }
        /// <summary>
        /// 工艺名称
        /// </summary>
        public String TECH_NAME
        {
            set { _TECH_NAME = value; }
            get { return _TECH_NAME; }
        }
        /// <summary>
        /// 工艺描述
        /// </summary>
        public String TECH_DESC
        {
            set { _TECH_DESC = value; }
            get { return _TECH_DESC; }
        }
        /// <summary>
        /// 创建人
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
        /// 修改人
        /// </summary>
        public String MODIFIER
        {
            set { _MODIFIER = value; }
            get { return _MODIFIER; }
        }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime MODIFY_TIME
        {
            set { _MODIFY_TIME = value; }
            get { return _MODIFY_TIME; }
        }
        /// <summary>
        /// 流程图XML文件
        /// </summary>
        public string FLOWXMLFILE
        {
            get
            {
                return _FLOWXMLFILE;
            }

            set
            {
                _FLOWXMLFILE = value;
            }
        }
        /// <summary>
        /// 是否禁用
        /// </summary>
        public string IS_DISABLE
        {
            get
            {
                return _IS_DISABLE;
            }

            set
            {
                _IS_DISABLE = value;
            }
        }
     
    }
}