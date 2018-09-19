/*************************************************************
* 版权所有 ＠ 薛建武 
* 创建时间：2017/8/25 10:10:47
 *************************************************************/
using System;
namespace Model
{
   /// <summary>
   /// 对象类 T_Bllb_wocodeBom_tbwb[工单BOM表]
   /// </summary>
   [Serializable]
   public class Model_Bllb_wocodeBom_tbwb
   {
        private String _TBWB_ID;// 工单BOM的ID
        private String _WoCode;// 工单(SfcDatProduct)
        private String _MaterialCode;// 物料代码
        private Decimal _BOM_QTY;// BOM用量
        private string _MaterialName;//物料名称
        private string _Spec;//规格
        private string _Units;//单位
        private Decimal _ALL_QTY;//应发数量
        private string _SfcNo;//制令单
        public Model_Bllb_wocodeBom_tbwb()
       {
            this._TBWB_ID="";
            this._WoCode="";
            this._MaterialCode="";
            this._BOM_QTY=0.00m;
            this._MaterialName = string.Empty;
            this._Spec = string.Empty;
            this._Units = string.Empty;
            this._SfcNo = string.Empty;
       }
        /// <summary>
        /// 工单BOM的ID
        /// </summary>
        public String TBWB_ID
        {
            set { _TBWB_ID = value; }
            get { return _TBWB_ID; }
        }
        /// <summary>
        /// 工单(SfcDatProduct)
        /// </summary>
        public String WoCode
        {
            set { _WoCode = value; }
            get { return _WoCode; }
        }
        /// <summary>
        /// 物料代码
        /// </summary>
        public String MaterialCode
        {
            set { _MaterialCode = value; }
            get { return _MaterialCode; }
        }
        /// <summary>
        /// BOM用量
        /// </summary>
        public Decimal BOM_QTY
        {
            set { _BOM_QTY = value; }
            get { return _BOM_QTY; }
        }
        /// <summary>
        /// 物料名称
        /// </summary>
        public string MaterialName
        {
            get
            {
                return _MaterialName;
            }

            set
            {
                _MaterialName = value;
            }
        }
        /// <summary>
        /// 规格
        /// </summary>
        public string Spec
        {
            get
            {
                return _Spec;
            }

            set
            {
                _Spec = value;
            }
        }
        /// <summary>
        /// 单位
        /// </summary>
        public string Units
        {
            get
            {
                return _Units;
            }

            set
            {
                _Units = value;
            }
        }
        /// <summary>
        /// 应发数量
        /// </summary>
        public decimal ALL_QTY
        {
            get
            {
                return _ALL_QTY;
            }

            set
            {
                _ALL_QTY = value;
            }
        }
        /// <summary>
        /// 制令单
        /// </summary>
        public string SfcNo
        {
            get
            {
                return _SfcNo;
            }

            set
            {
                _SfcNo = value;
            }
        }
    }
}