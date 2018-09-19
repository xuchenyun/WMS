/*************************************************************
* 版权所有 ＠ 薛建武 
* 创建时间：2017/7/28 16:43:27
 *************************************************************/
using System;
namespace Model
{
   /// <summary>
   /// 对象类 T_Bllb_spotCheckQty_tbscq[样本代码和抽检数关系表]
   /// </summary>
   [Serializable]
   public class Model_Bllb_spotCheckQty_tbscq
   {
        private String _TBSCQ_ID;// ID
        private String _TBCT_ID;// 检验方案ID（T_Bllb_checkType_tbct）
        private String _QC_STEP;// 抽检阶（IQC、FQC）
        private String _SAMPLE_CODE;// 样品代码
        private Decimal _SAMPLE_QTY;// 样本数（抽检数）
       public Model_Bllb_spotCheckQty_tbscq()
       {
            this._TBSCQ_ID="";
            this._QC_STEP="";
            this._SAMPLE_CODE="";
            this._SAMPLE_QTY=0;
            this.TBCT_ID = string.Empty;
       }
        /// <summary>
        /// ID
        /// </summary>
        public String TBSCQ_ID
        {
            set { _TBSCQ_ID = value; }
            get { return _TBSCQ_ID; }
        }
       
        /// <summary>
        /// 检验方案名称
        /// </summary>
        public string TBCT_TYPE { get; set; }
        /// <summary>
        /// 抽检阶（IQC、FQC）
        /// </summary>
        public String QC_STEP
        {
            set { _QC_STEP = value; }
            get { return _QC_STEP; }
        }
        /// <summary>
        /// 样品代码
        /// </summary>
        public String SAMPLE_CODE
        {
            set { _SAMPLE_CODE = value; }
            get { return _SAMPLE_CODE; }
        }
        /// <summary>
        /// 样本数（抽检数）
        /// </summary>
        public Decimal SAMPLE_QTY
        {
            set { _SAMPLE_QTY = value; }
            get { return _SAMPLE_QTY; }
        }
        /// <summary>
        /// 检验方案ID
        /// </summary>
        public string TBCT_ID
        {
            get
            {
                return _TBCT_ID;
            }

            set
            {
                _TBCT_ID = value;
            }
        }
    }
}