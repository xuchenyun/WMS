/*************************************************************
* 版权所有 ＠ 薛建武 
* 创建时间：2017/8/3 13:56:36
 *************************************************************/
using System;
namespace Model
{
   /// <summary>
   /// 对象类 T_Bllb_productStatus_tbps[产品状态表]
   /// </summary>
   [Serializable]
   public class Model_Bllb_productStatus_tbps
   {
        private String _TBPS_ID;// 产品状态ID（唯一码）
        private String _TBTG_ID;// 最后过站工艺工序ID（T_Bllb_technologyGroup_tbtg）
        private String _PLCode;// 线别代码（MdcDatProductLine）
        private String _SfcNo;// 制令单（SfcDatProduct)
        private DateTime _PASS_TIME;//过站时间
        private String _RE_TBTG_ID;//返工或回流的下一个工序
        private string _WIP_TBTG_ID;//下一个在制工艺工序ID
        public Model_Bllb_productStatus_tbps()
       {
            this._TBPS_ID="";
            this._TBTG_ID="";
            this._PLCode="";
            this._SfcNo="";
            this._PASS_TIME = DateTime.Now;
            this._RE_TBTG_ID = string.Empty;
            this._WIP_TBTG_ID = string.Empty;

       }
        /// <summary>
        /// 产品状态ID（唯一码）
        /// </summary>
        public String TBPS_ID
        {
            set { _TBPS_ID = value; }
            get { return _TBPS_ID; }
        }
        /// <summary>
        /// 最后过站工艺工序ID（T_Bllb_technologyGroup_tbtg）
        /// </summary>
        public String TBTG_ID
        {
            set { _TBTG_ID = value; }
            get { return _TBTG_ID; }
        }
        /// <summary>
        /// 线别代码（MdcDatProductLine）
        /// </summary>
        public String PLCode
        {
            set { _PLCode = value; }
            get { return _PLCode; }
        }
        /// <summary>
        /// 制令单（SfcDatProduct)
        /// </summary>
        public String SfcNo
        {
            set { _SfcNo = value; }
            get { return _SfcNo; }
        }
        /// <summary>
        /// 过站时间
        /// </summary>
        public DateTime PASS_TIME
        {
            get
            {
                return _PASS_TIME;
            }

            set
            {
                _PASS_TIME = value;
            }
        }
        /// <summary>
        /// 下一个工序
        /// </summary>
        public string RE_TBTG_ID
        {
            get
            {
                return _RE_TBTG_ID;
            }

            set
            {
                _RE_TBTG_ID = value;
            }
        }
        /// <summary>
        /// 在制工艺工序ID
        /// </summary>
        public string WIP_TBTG_ID
        {
            get
            {
                return _WIP_TBTG_ID;
            }

            set
            {
                _WIP_TBTG_ID = value;
            }
        }
    }
}