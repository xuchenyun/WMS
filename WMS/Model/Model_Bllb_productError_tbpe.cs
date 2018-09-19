/*************************************************************
* 版权所有 ＠ 薛建武 
* 创建时间：2017/8/7 17:18:53
 *************************************************************/
using System;
namespace Model
{
   /// <summary>
   /// 对象类 T_Bllb_productError_tbpe[不良记录表]
   /// </summary>
   [Serializable]
   public class Model_Bllb_productError_tbpe
   {
        private String _TBPE_ID;// 不良记录ID（全球唯一码）
        private String _TBPS_ID;// 产品状态ID（全球唯一码）
        private String _TBEC_ID;// 不良代码ID（T_Bllb_errorCode_tbec）
        private String _ERROR_MAN;// 不良判定人
        private DateTime _ERROR_TIME;// 不良时间
        private String _TBER_ID;// 不良原因ID（T_Bllb_errorReason_tber）
        private String _TBRM_ID;// 维修方法ID（T_Bllb_repairMethod_tbrm）
        private String _NO_ERROR;// 是否误判（Y/N）
        private String _REPAIR_MAN;// 维修人
        private DateTime _REPAIR_TIME;// 维修时间
        private string _TBG_ID;//工序ID
        private string _TBS_ID;//工位ID
       public Model_Bllb_productError_tbpe()
       {
            this._TBPE_ID="ewid(";
            this._TBPS_ID="";
            this._TBEC_ID="";
            this._ERROR_MAN="";
            this._ERROR_TIME=DateTime.Parse("1900-01-01");
            this._TBER_ID="";
            this._TBRM_ID="";
            this._NO_ERROR="";
            this._REPAIR_MAN="";
            this._REPAIR_TIME=DateTime.Parse("1900-01-01");
            this._TBG_ID = string.Empty;
            this._TBS_ID = string.Empty;
       }
        /// <summary>
        /// 不良记录ID（全球唯一码）
        /// </summary>
        public String TBPE_ID
        {
            set { _TBPE_ID = value; }
            get { return _TBPE_ID; }
        }
        /// <summary>
        /// 产品状态ID（全球唯一码）
        /// </summary>
        public String TBPS_ID
        {
            set { _TBPS_ID = value; }
            get { return _TBPS_ID; }
        }
        /// <summary>
        /// 不良代码ID（T_Bllb_errorCode_tbec）
        /// </summary>
        public String TBEC_ID
        {
            set { _TBEC_ID = value; }
            get { return _TBEC_ID; }
        }
        /// <summary>
        /// 不良判定人
        /// </summary>
        public String ERROR_MAN
        {
            set { _ERROR_MAN = value; }
            get { return _ERROR_MAN; }
        }
        /// <summary>
        /// 不良时间
        /// </summary>
        public DateTime ERROR_TIME
        {
            set { _ERROR_TIME = value; }
            get { return _ERROR_TIME; }
        }
        /// <summary>
        /// 不良原因ID（T_Bllb_errorReason_tber）
        /// </summary>
        public String TBER_ID
        {
            set { _TBER_ID = value; }
            get { return _TBER_ID; }
        }
        /// <summary>
        /// 维修方法ID（T_Bllb_repairMethod_tbrm）
        /// </summary>
        public String TBRM_ID
        {
            set { _TBRM_ID = value; }
            get { return _TBRM_ID; }
        }
        /// <summary>
        /// 是否误判（Y/N）
        /// </summary>
        public String NO_ERROR
        {
            set { _NO_ERROR = value; }
            get { return _NO_ERROR; }
        }
        /// <summary>
        /// 维修人
        /// </summary>
        public String REPAIR_MAN
        {
            set { _REPAIR_MAN = value; }
            get { return _REPAIR_MAN; }
        }
        /// <summary>
        /// 维修时间
        /// </summary>
        public DateTime REPAIR_TIME
        {
            set { _REPAIR_TIME = value; }
            get { return _REPAIR_TIME; }
        }
        /// <summary>
        /// 工序ID
        /// </summary>
        public string TBG_ID
        {
            get
            {
                return _TBG_ID;
            }

            set
            {
                _TBG_ID = value;
            }
        }
        /// <summary>
        /// 工位ID
        /// </summary>
        public string TBS_ID
        {
            get
            {
                return _TBS_ID;
            }

            set
            {
                _TBS_ID = value;
            }
        }
    }
}