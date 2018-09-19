/*************************************************************
* 版权所有 ＠ 薛建武 
* 创建时间：2017/7/26 19:57:43
 *************************************************************/
using System;
namespace Model
{
   /// <summary>
   /// 对象类 T_Bllb_sampleQty_tbsq[样本代码--样品数范围表]
   /// </summary>
   [Serializable]
   public class Model_Bllb_sampleQty_tbsq
   {
     private String _TBSQ_ID;
     private String _QC_STEP;
     private int _BEGIN_QTY;
     private int _END_QTY;

       public Model_Bllb_sampleQty_tbsq()
       {
       this._TBSQ_ID="";
       this._QC_STEP="";
       this._BEGIN_QTY=0;
       this._END_QTY=0;

       }
        /// <summary>
        /// 
        /// </summary>
        public String TBSQ_ID
        {
            set { _TBSQ_ID = value; }
            get { return _TBSQ_ID; }
        }
        /// <summary>
        /// 抽检阶（IQC、FQC等）
        /// </summary>
        public String QC_STEP
        {
            set { _QC_STEP = value; }
            get { return _QC_STEP; }
        }
        /// <summary>
        /// 样品数起始值
        /// </summary>
        public int BEGIN_QTY
        {
            set { _BEGIN_QTY = value; }
            get { return _BEGIN_QTY; }
        }
        /// <summary>
        /// 样品数终止值
        /// </summary>
        public int END_QTY
        {
            set { _END_QTY = value; }
            get { return _END_QTY; }
        }
   }
}