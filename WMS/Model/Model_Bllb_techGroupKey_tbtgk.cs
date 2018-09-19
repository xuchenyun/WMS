/*************************************************************
* 版权所有 ＠ 薛建武 
* 创建时间：2017/7/14 14:14:41
 *************************************************************/
using System;
namespace Model
{
    /// <summary>
    /// 对象类 T_Bllb_techGroupKey_tbtgk[工艺工序关键件表]
    /// </summary>
    [Serializable]
    public class Model_Bllb_techGroupKey_tbtgk
    {
        private String _TBTGK_ID;
        private String _TBKT_ID;
        private Decimal _ASS_ORDER;
        private Decimal _ASS_NUM;
        private String _ASS_TYPE;
        private string _TBTG_ID;//工艺工序ID
        private string _TBT_ID;//工艺ID
        private string _TM_TYPE;//条码类型
        private string _TBBR_ID;//条码规则ID
        private string _RULE_NAME;//规则名称

        private string _KEY_TYPE;//
        public Model_Bllb_techGroupKey_tbtgk()
        {
            this._TBTGK_ID = "";
            this._TBKT_ID = "";
            this._ASS_ORDER = 0;
            this._ASS_NUM = 0;
            this._ASS_TYPE = "";
            this._TBT_ID = "";
            this._TM_TYPE = string.Empty;
            this._TBBR_ID = string.Empty;
            this._RULE_NAME = string.Empty;
            this._KEY_TYPE = string.Empty;
        }
        /// <summary>
        /// 工艺工序关键件ID（全球唯一码）
        /// </summary>
        public String TBTGK_ID
        {
            set { _TBTGK_ID = value; }
            get { return _TBTGK_ID; }
        }
        /// <summary>
        /// 关键类型ID（T_Bllb_keyType_tbkt）
        /// </summary>
        public String TBKT_ID
        {
            set { _TBKT_ID = value; }
            get { return _TBKT_ID; }
        }
        /// <summary>
        /// 组立顺序
        /// </summary>
        public Decimal ASS_ORDER
        {
            set { _ASS_ORDER = value; }
            get { return _ASS_ORDER; }
        }
        /// <summary>
        /// 组立数量
        /// </summary>
        public Decimal ASS_NUM
        {
            set { _ASS_NUM = value; }
            get { return _ASS_NUM; }
        }
        /// <summary>
        /// 类型：0：采购件，1：自生产
        /// </summary>
        public String ASS_TYPE
        {
            set { _ASS_TYPE = value; }
            get { return _ASS_TYPE; }
        }
        /// <summary>
        /// 工艺工序ID
        /// </summary>
        public string TBTG_ID
        {
            get
            {
                return _TBTG_ID;
            }

            set
            {
                _TBTG_ID = value;
            }
        }
        /// <summary>
        /// 工艺ID
        /// </summary>
        public string TBT_ID
        {
            get
            {
                return _TBT_ID;
            }

            set
            {
                _TBT_ID = value;
            }
        }
        /// <summary>
        /// 条码类型
        /// </summary>
        public string TM_TYPE
        {
            get
            {
                return _TM_TYPE;
            }

            set
            {
                _TM_TYPE = value;
            }
        }
        /// <summary>
        /// 条码规则ID
        /// </summary>
        public string TBBR_ID
        {
            get
            {
                return _TBBR_ID;
            }

            set
            {
                _TBBR_ID = value;
            }
        }
        /// <summary>
        /// 规则名称
        /// </summary>
        public string RULE_NAME
        {
            get
            {
                return _RULE_NAME;
            }

            set
            {
                _RULE_NAME = value;
            }
        }

        public string KEY_TYPE
        {
            get
            {
                return _KEY_TYPE;
            }

            set
            {
                _KEY_TYPE = value;
            }
        }
    }
}