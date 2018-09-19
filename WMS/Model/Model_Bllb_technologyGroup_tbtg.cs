/*************************************************************
* 版权所有 ＠ 薛建武 
* 创建时间：2017/7/14 14:14:36
 *************************************************************/
using System;
namespace Model
{
    /// <summary>
    /// 对象类 T_Bllb_technologyGroup_tbtg[工艺工序表]
    /// </summary>
    [Serializable]
    public class Model_Bllb_technologyGroup_tbtg
    {
        private String _TBTG_ID;
        private String _TBT_ID;
        private String _TBG_ID;
        private String _INOUT_TYPE;
        private string _ISMUSTPASS;//是否必过
        private string _GROUP_TYPE;//工序类型【0：正常工序；1：维修工序】
        private string _QA_FLAG;//抽检生成
        public Model_Bllb_technologyGroup_tbtg()
        {
            this._TBTG_ID = "";
            this._TBT_ID = "";
            this._TBG_ID = "";
            this._INOUT_TYPE = "";
            this._ISMUSTPASS = "";
            this._GROUP_TYPE = "0";
            this._QA_FLAG = "";
        }
        /// <summary>
        /// 工艺的工序ID（全球唯一码）
        /// </summary>
        public String TBTG_ID
        {
            set { _TBTG_ID = value; }
            get { return _TBTG_ID; }
        }
        /// <summary>
        /// 工艺ID（T_Bllb_technology_tbt）
        /// </summary>
        public String TBT_ID
        {
            set { _TBT_ID = value; }
            get { return _TBT_ID; }
        }
        /// <summary>
        /// 工序ID（T_Bllb_group_tbg）
        /// </summary>
        public String TBG_ID
        {
            set { _TBG_ID = value; }
            get { return _TBG_ID; }
        }
        /// <summary>
        /// 类型：0：投入工序；1：产出工序；2：辅助投入（不纳入投入数）
        /// </summary>
        public String INOUT_TYPE
        {
            set { _INOUT_TYPE = value; }
            get { return _INOUT_TYPE; }
        }
        /// <summary>
        /// 是否必过
        /// </summary>
        public string ISMUSTPASS
        {
            get
            {
                return _ISMUSTPASS;
            }

            set
            {
                _ISMUSTPASS = value;
            }
        }
        /// <summary>
        /// 工序类型【0：正常工序；1：维修工序】
        /// </summary>
        public string GROUP_TYPE
        {
            get
            {
                return _GROUP_TYPE;
            }

            set
            {
                _GROUP_TYPE = value;
            }
        }
        /// <summary>
        /// 抽检生成
        /// </summary>
        public string QA_FLAG
        {
            get
            {
                return _QA_FLAG;
            }

            set
            {
                _QA_FLAG = value;
            }
        }
    }
}