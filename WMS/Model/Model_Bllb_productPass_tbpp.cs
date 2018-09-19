/*************************************************************
* 版权所有 ＠ 薛建武 
* 创建时间：2017/8/3 13:56:27
 *************************************************************/
using System;
namespace Model
{
   /// <summary>
   /// 对象类 T_Bllb_productPass_tbpp[产品过站记录表]
   /// </summary>
   [Serializable]
   public class Model_Bllb_productPass_tbpp
   {
        private String _TBPP_ID;// 产品过站记录ID（全球唯一码）
        private String _TBPS_ID;// 产品状态ID（T_Bllb_productStatus_tbps）
        private String _TBG_ID;// 过站工序ID（T_Bllb_Group_tbg）
        private DateTime _PASS_TIME;// 
        private String _STATE_FLAG;// 产品状态（0：正常；1：不良）
        private String _PLCode;//线别代码
        private string _TBS_ID;//工位ID
        public Model_Bllb_productPass_tbpp()
       {
            this._TBPP_ID="";
            this._TBPS_ID="";
            this._TBG_ID="";
            this._PASS_TIME=DateTime.Parse("1900-01-01");
            this._STATE_FLAG="";
            this._PLCode = "";
            this._TBS_ID = string.Empty;
        }
        /// <summary>
        /// 产品过站记录ID（全球唯一码）
        /// </summary>
        public String TBPP_ID
        {
            set { _TBPP_ID = value; }
            get { return _TBPP_ID; }
        }
        /// <summary>
        /// 产品状态ID（T_Bllb_productStatus_tbps）
        /// </summary>
        public String TBPS_ID
        {
            set { _TBPS_ID = value; }
            get { return _TBPS_ID; }
        }
        /// <summary>
        /// 过站工序ID（T_Bllb_Group_tbg）
        /// </summary>
        public String TBG_ID
        {
            set { _TBG_ID = value; }
            get { return _TBG_ID; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime PASS_TIME
        {
            set { _PASS_TIME = value; }
            get { return _PASS_TIME; }
        }
        /// <summary>
        /// 产品状态（0：正常；1：不良）
        /// </summary>
        public String STATE_FLAG
        {
            set { _STATE_FLAG = value; }
            get { return _STATE_FLAG; }
        }
        /// <summary>
        /// 线别代码
        /// </summary>
        public string PLCode
        {
            get
            {
                return _PLCode;
            }

            set
            {
                _PLCode = value;
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