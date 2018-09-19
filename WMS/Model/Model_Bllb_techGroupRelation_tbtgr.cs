/*************************************************************
* 版权所有 ＠ 薛建武 
* 创建时间：2017/7/17 15:31:08
 *************************************************************/
using System;
namespace Model
{
   /// <summary>
   /// 对象类 T_Bllb_techGroupRelation_tbtgr[工艺工序关系表]
   /// </summary>
   [Serializable]
   public class Model_Bllb_techGroupRelation_tbtgr
   {
     private String _TBTGR_ID;
     private String _F_TBTG_ID;
     private String _TBTG_ID;
     private String _TBT_ID;


       public Model_Bllb_techGroupRelation_tbtgr()
       {
       this._TBTGR_ID="";
       this._F_TBTG_ID="";
       this._TBTG_ID="";
       this._TBT_ID="";
   

       }
        /// <summary>
        /// 工艺工序关系ID（全球唯一码）
        /// </summary>
        public String TBTGR_ID
        {
            set { _TBTGR_ID = value; }
            get { return _TBTGR_ID; }
        }
        /// <summary>
        /// 工艺工序ID（父级）（T_Bllb_technologyGroup_tbtg）
        /// </summary>
        public String F_TBTG_ID
        {
            set { _F_TBTG_ID = value; }
            get { return _F_TBTG_ID; }
        }
        /// <summary>
        /// 工艺工序ID（子级）（T_Bllb_technologyGroup_tbtg）
        /// </summary>
        public String TBTG_ID
        {
            set { _TBTG_ID = value; }
            get { return _TBTG_ID; }
        }
        /// <summary>
        /// 工艺ID（T_Bllb_technology_tbt）
        /// </summary>
        public String TBT_ID
        {
            set { _TBT_ID = value; }
            get { return _TBT_ID; }
        }
     
   }
}