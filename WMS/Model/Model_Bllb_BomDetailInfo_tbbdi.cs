/*************************************************************
* 版权所有 ＠ 薛建武 
* 创建时间：2017/10/27 17:39:28
 *************************************************************/
using System;
namespace Model
{
   /// <summary>
   /// 对象类 T_Bllb_BomDetailInfo_tbbdi[产品BOM明细信息表]
   /// </summary>
   [Serializable]
   public class Model_Bllb_BomDetailInfo_tbbdi
   {
        private String _TBBDI_ID;// ID
        private String _TBBMI_ID;// 产品BOM主表ID
        private String _MaterialCode;// 料号
        private Decimal _BOM_QTY;// 数量

       public Model_Bllb_BomDetailInfo_tbbdi()
       {
            this._TBBDI_ID="";
            this._TBBMI_ID="";
            this._MaterialCode="";
            this._BOM_QTY=0.00m;

       }
        /// <summary>
        /// ID
        /// </summary>
        public String TBBDI_ID
        {
            set { _TBBDI_ID = value; }
            get { return _TBBDI_ID; }
        }
        /// <summary>
        /// 产品BOM主表ID
        /// </summary>
        public String TBBMI_ID
        {
            set { _TBBMI_ID = value; }
            get { return _TBBMI_ID; }
        }
        /// <summary>
        /// 料号
        /// </summary>
        public String MaterialCode
        {
            set { _MaterialCode = value; }
            get { return _MaterialCode; }
        }
        /// <summary>
        /// 数量
        /// </summary>
        public Decimal BOM_QTY
        {
            set { _BOM_QTY = value; }
            get { return _BOM_QTY; }
        }
   }
}