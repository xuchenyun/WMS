/*************************************************************
* 版权所有 ＠ 薛建武 
* 创建时间：2017/8/10 10:01:12
 *************************************************************/
using System;
namespace Model
{
   /// <summary>
   /// 对象类 T_Bllb_groupStatistics_tbgs[过站统计]
   /// </summary>
   [Serializable]
   public class Model_Bllb_groupStatistics_tbgs
   {
        private String _SfcNo;// 制令单
        private String _TBTG_ID;// 工艺工序ID（T_Bllb_technologyGroup_tbtg）
        private Decimal _PASS_NUM;// 过站次数（有计算同一个产品重复过站）
        private Decimal _ERROR_NUM;// 打不良次数（一次打多个不良累计1）

       public Model_Bllb_groupStatistics_tbgs()
       {
            this._SfcNo="";
            this._TBTG_ID="";
            this._PASS_NUM=0;
            this._ERROR_NUM=0;

       }
        /// <summary>
        /// 制令单
        /// </summary>
        public String SfcNo
        {
            set { _SfcNo = value; }
            get { return _SfcNo; }
        }
        /// <summary>
        /// 工艺工序ID（T_Bllb_technologyGroup_tbtg）
        /// </summary>
        public String TBTG_ID
        {
            set { _TBTG_ID = value; }
            get { return _TBTG_ID; }
        }
        /// <summary>
        /// 过站次数（有计算同一个产品重复过站）
        /// </summary>
        public Decimal PASS_NUM
        {
            set { _PASS_NUM = value; }
            get { return _PASS_NUM; }
        }
        /// <summary>
        /// 打不良次数（一次打多个不良累计1）
        /// </summary>
        public Decimal ERROR_NUM
        {
            set { _ERROR_NUM = value; }
            get { return _ERROR_NUM; }
        }
   }
}