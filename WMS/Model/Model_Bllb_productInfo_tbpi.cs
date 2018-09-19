/*************************************************************
* 版权所有 ＠ 薛建武 
* 创建时间：2017/8/3 13:56:08
 *************************************************************/
using System;
namespace Model
{
   /// <summary>
   /// 对象类 T_Bllb_productInfo_tbpi[产品信息表]
   /// </summary>
   [Serializable]
   public class Model_Bllb_productInfo_tbpi
   {
        private String _TBPI_ID;// 产品信息ID（全球唯一码）
        private String _TBPS_ID;// 产品状态ID（T_Bllb_productStatus_tbps）
        private String _SERIAL_NUMBER;// 产品条码
        private Decimal _QTY;// 数量
        private String _OVER_FLAG;// 流程结束（Y/N)
        private String _LAST_FLAG;// 最新记录（Y/N）
        private String _ERROR_FLAG;// 是否不良（Y/N）
        private String _REPAIR_FLAG;// 是否维修过（Y/N）
        private String _SCRAP_FLAG;// 是否报废（Y/N）
        private String _SfcNo;// 制令单（SfcDatProduct ）
        private string _ONCE_OVER_FLAG;//是否曾经流程结束（Y/N）（针对流程结束又原单返工情况）
        private string _OLD_SERIAL_NUMBER;//旧的产品条码
        private string _AUXILIARY_FLAG;//是否辅助线产品
        public Model_Bllb_productInfo_tbpi()
       {
            this._TBPI_ID="";
            this._TBPS_ID="";
            this._SERIAL_NUMBER="";
            this._QTY=0;
            this._OVER_FLAG="";
            this._LAST_FLAG="";
            this._ERROR_FLAG="";
            this._REPAIR_FLAG="";
            this._SCRAP_FLAG="";
            this._SfcNo="";
            this._OLD_SERIAL_NUMBER = "";
            this._AUXILIARY_FLAG = string.Empty;
       }
        /// <summary>
        /// 产品信息ID（全球唯一码）
        /// </summary>
        public String TBPI_ID
        {
            set { _TBPI_ID = value; }
            get { return _TBPI_ID; }
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
        /// 产品条码
        /// </summary>
        public String SERIAL_NUMBER
        {
            set { _SERIAL_NUMBER = value; }
            get { return _SERIAL_NUMBER; }
        }
        /// <summary>
        /// 数量
        /// </summary>
        public Decimal QTY
        {
            set { _QTY = value; }
            get { return _QTY; }
        }
        /// <summary>
        /// 流程结束（Y/N)
        /// </summary>
        public String OVER_FLAG
        {
            set { _OVER_FLAG = value; }
            get { return _OVER_FLAG; }
        }
        /// <summary>
        /// 最新记录（Y/N）
        /// </summary>
        public String LAST_FLAG
        {
            set { _LAST_FLAG = value; }
            get { return _LAST_FLAG; }
        }
        /// <summary>
        /// 是否不良（Y/N）
        /// </summary>
        public String ERROR_FLAG
        {
            set { _ERROR_FLAG = value; }
            get { return _ERROR_FLAG; }
        }
        /// <summary>
        /// 是否维修过（Y/N）
        /// </summary>
        public String REPAIR_FLAG
        {
            set { _REPAIR_FLAG = value; }
            get { return _REPAIR_FLAG; }
        }
        /// <summary>
        /// 是否报废（Y/N）
        /// </summary>
        public String SCRAP_FLAG
        {
            set { _SCRAP_FLAG = value; }
            get { return _SCRAP_FLAG; }
        }
        /// <summary>
        /// 制令单（SfcDatProduct ）
        /// </summary>
        public String SfcNo
        {
            set { _SfcNo = value; }
            get { return _SfcNo; }
        }
        /// <summary>
        /// 是否曾经流程结束（Y/N）（针对流程结束又原单返工情况）
        /// </summary>
        public string ONCE_OVER_FLAG
        {
            get
            {
                return _ONCE_OVER_FLAG;
            }

            set
            {
                _ONCE_OVER_FLAG = value;
            }
        }
        /// <summary>
        /// 旧的产品条码
        /// </summary>
        public string OLD_SERIAL_NUMBER
        {
            get
            {
                return _OLD_SERIAL_NUMBER;
            }

            set
            {
                _OLD_SERIAL_NUMBER = value;
            }
        }
        /// <summary>
        /// 是否为辅助线产品
        /// </summary>
        public string AUXILIARY_FLAG
        {
            get
            {
                return _AUXILIARY_FLAG;
            }

            set
            {
                _AUXILIARY_FLAG = value;
            }
        }
    }
}