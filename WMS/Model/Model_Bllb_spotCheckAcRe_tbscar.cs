/*************************************************************
* 版权所有 ＠ 薛建武 
* 创建时间：2017/7/28 16:44:24
 *************************************************************/
using System;
namespace Model
{
   /// <summary>
   /// 对象类 T_Bllb_spotCheckAcRe_tbscar[样本的aql对应AC和RE值表]
   /// </summary>
   [Serializable]
   public class Model_Bllb_spotCheckAcRe_tbscar
   {
        private String _TBSCAR_ID;// ID
        private Decimal _AQL_VALUE;// Aql值
        private String _TBSCQ_ID;// 样本数量ID（T_Bllb_spotCheckQty_tbscq）
        private String _AC;// 允收数
        private String _RE;// 拒收数
        private String _TBCT_ID;//检验方案ID
        private string _QC_STEP;//抽检阶（IQC、FQC等）
        public Model_Bllb_spotCheckAcRe_tbscar()
       {
            this._TBSCAR_ID="";
            this._AQL_VALUE=0;
            this._TBSCQ_ID="";
            this._AC="";
            this._RE="";
            this._TBCT_ID = "";
            this._QC_STEP = "";
       }
        /// <summary>
        /// ID
        /// </summary>
        public String TBSCAR_ID
        {
            set { _TBSCAR_ID = value; }
            get { return _TBSCAR_ID; }
        }
        /// <summary>
        /// Aql值
        /// </summary>
        public Decimal AQL_VALUE
        {
            set { _AQL_VALUE = value; }
            get { return _AQL_VALUE; }
        }
        /// <summary>
        /// 样本数量ID（T_Bllb_spotCheckQty_tbscq）
        /// </summary>
        public String TBSCQ_ID
        {
            set { _TBSCQ_ID = value; }
            get { return _TBSCQ_ID; }
        }
        /// <summary>
        /// 允收数
        /// </summary>
        public String AC
        {
            set { _AC = value; }
            get { return _AC; }
        }
        /// <summary>
        /// 拒收数
        /// </summary>
        public String RE
        {
            set { _RE = value; }
            get { return _RE; }
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