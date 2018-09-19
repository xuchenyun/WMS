/*************************************************************
* 版权所有 ＠ 薛建武 
* 创建时间：2017/7/12 17:45:42
 *************************************************************/
using System;
namespace Model
{
   /// <summary>
   /// 对象类 T_Bllb_station_tbs[工位表]
   /// </summary>
   [Serializable]
   public class Model_Bllb_station_tbs
   {
     private String _TBS_ID;
     private String _WORKSTATION_SN;
     private String _WORKSTATION_NAME;
     private String _TBG_ID;
     private String _PLCode;
    
       public Model_Bllb_station_tbs()
       {
       this._TBS_ID="";
       this._WORKSTATION_SN="";
       this._WORKSTATION_NAME="";
       this._TBG_ID="";
       this._PLCode="";
     
       }
        /// <summary>
        /// 工位ID
        /// </summary>
        public String TBS_ID
        {
            set { _TBS_ID = value; }
            get { return _TBS_ID; }
        }
        /// <summary>
        /// 工位SN
        /// </summary>
        public String WORKSTATION_SN
        {
            set { _WORKSTATION_SN = value; }
            get { return _WORKSTATION_SN; }
        }
        /// <summary>
        /// 工位名称
        /// </summary>
        public String WORKSTATION_NAME
        {
            set { _WORKSTATION_NAME = value; }
            get { return _WORKSTATION_NAME; }
        }
        /// <summary>
        /// 工序ID（T_Bllb_group_tbg）
        /// </summary>
        public String TBG_ID
        {
            set { _TBG_ID = value; }
            get { return _TBG_ID; }
        }
        /// <summary>
        /// 线别代码（MdcDatProductLine）
        /// </summary>
        public String PLCode
        {
            set { _PLCode = value; }
            get { return _PLCode; }
        }
        
    }
}