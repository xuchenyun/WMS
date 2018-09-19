/*************************************************************
* 版权所有 ＠ 薛建武 
* 创建时间：2017/8/3 13:40:37
 *************************************************************/
using System;
namespace Model
{
   /// <summary>
   /// 对象类 T_Bllb_productKey_tbpk[产品关键件组装信息表]
   /// </summary>
   [Serializable]
   public class Model_Bllb_productKey_tbpk
   {
        private String _TBPK_ID;// 产品关键件ID（全球唯一码）
        private String _TBPS_ID;// 产品状态ID（T_Bllb_productStatus_tbps）
        private String _KEY_SN;// 关键件条码
        private String _TBKT_ID;// 关键件类型ID（T_Bllb_keyType_tbkt）
        private String _TBG_ID;// 过站工序ID（T_Bllb_Group_tbg）
        private DateTime _CREATE_TIME;// 组装时间
        private String _UserID;// 员工号

       public Model_Bllb_productKey_tbpk()
       {
            this._TBPK_ID="";
            this._TBPS_ID="";
            this._KEY_SN="";
            this._TBKT_ID="";
            this._TBG_ID="";
            this._CREATE_TIME=DateTime.Parse("1900-01-01");
            this._UserID="";

       }
        /// <summary>
        /// 产品关键件ID（全球唯一码）
        /// </summary>
        public String TBPK_ID
        {
            set { _TBPK_ID = value; }
            get { return _TBPK_ID; }
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
        /// 关键件条码
        /// </summary>
        public String KEY_SN
        {
            set { _KEY_SN = value; }
            get { return _KEY_SN; }
        }
        /// <summary>
        /// 关键件类型ID（T_Bllb_keyType_tbkt）
        /// </summary>
        public String TBKT_ID
        {
            set { _TBKT_ID = value; }
            get { return _TBKT_ID; }
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
        /// 组装时间
        /// </summary>
        public DateTime CREATE_TIME
        {
            set { _CREATE_TIME = value; }
            get { return _CREATE_TIME; }
        }
        /// <summary>
        /// 员工号
        /// </summary>
        public String UserID
        {
            set { _UserID = value; }
            get { return _UserID; }
        }
   }
}