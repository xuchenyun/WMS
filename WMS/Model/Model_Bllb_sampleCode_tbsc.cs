/*************************************************************
* 版权所有 ＠ 薛建武 
* 创建时间：2017/7/26 20:02:42
 *************************************************************/
using System;
namespace Model
{
   /// <summary>
   /// 对象类 T_Bllb_sampleCode_tbsp[样本代码表]
   /// </summary>
   [Serializable]
   public class Model_Bllb_sampleCode_tbsc
   {
     private String _TBSC_ID;
     private String _SAMPLE_CODE;
     private String _TBSQ_ID;
        private string _TBCL_ID;
        private string _TBCL_LEVEL;
        private string _QC_STEP;
       public Model_Bllb_sampleCode_tbsc()
       {
       this._TBSC_ID="";
       this._SAMPLE_CODE="";
       this._TBSQ_ID="";
            this._TBCL_ID = "";
            this._TBCL_LEVEL = "";
            this._QC_STEP = "";
       }
        /// <summary>
        /// 样本代码ID（全球唯一码）
        /// </summary>
        public String TBSC_ID
        {
            set { _TBSC_ID = value; }
            get { return _TBSC_ID; }
        }
       
        /// <summary>
        /// 样本代码（比如：A、B等）
        /// </summary>
        public String SAMPLE_CODE
        {
            set { _SAMPLE_CODE = value; }
            get { return _SAMPLE_CODE; }
        }
        /// <summary>
        /// 样品数范围ID（T_Bllb_sampleQty_tbsq）
        /// </summary>
        public String TBSQ_ID
        {
            set { _TBSQ_ID = value; }
            get { return _TBSQ_ID; }
        }
        /// <summary>
        /// 检验水准ID（T_Bllb_checkLevel_tbcl）
        /// </summary>
        public string TBCL_ID
        {
            get
            {
                return _TBCL_ID;
            }

            set
            {
                _TBCL_ID = value;
            }
        }
        /// <summary>
        /// 检验水平
        /// </summary>
        public string TBCL_LEVEL
        {
            get
            {
                return _TBCL_LEVEL;
            }

            set
            {
                _TBCL_LEVEL = value;
            }
        }
        /// <summary>
        /// 检验水准名称
        /// </summary>
        public string TBCL_NAME { get; set; }
        /// <summary>
        /// 抽检阶（IQC、FQC等）
        /// </summary>
        public string QC_STEP
        {
            get
            {
                return _QC_STEP;
            }

            set
            {
                _QC_STEP = value;
            }
        }
    }
}