/*************************************************************
* 版权所有 ＠ 薛建武 
* 创建时间：2017/7/13 18:38:25
 *************************************************************/
using System;
namespace Model
{
   /// <summary>
   /// 对象类 T_Bllb_keyType_tbkt[关键件类型]
   /// </summary>
   [Serializable]
   public class Model_Bllb_keyType_tbkt
   {
     private String _TBKT_ID;
     private String _KEY_NAME;
     private String _KEY_TYPE;

       public Model_Bllb_keyType_tbkt()
       {
       this._TBKT_ID="";
       this._KEY_NAME="";
       this._KEY_TYPE="";

       }
        /// <summary>
        /// 关键件类型ID（全球唯一码）
        /// </summary>
        public String TBKT_ID
        {
            set { _TBKT_ID = value; }
            get { return _TBKT_ID; }
        }
        /// <summary>
        /// 关键件类型名称
        /// </summary>
        public String KEY_NAME
        {
            set { _KEY_NAME = value; }
            get { return _KEY_NAME; }
        }
        /// <summary>
        /// 类型（0：产品，1：关键件，2：随机卡）
        /// </summary>
        public String KEY_TYPE
        {
            set { _KEY_TYPE = value; }
            get { return _KEY_TYPE; }
        }
   }
}