/*************************************************************
* 版权所有 ＠ 薛建武 
* 创建时间：2017/8/14 10:50:37
 *************************************************************/
using System;
namespace Model
{
   /// <summary>
   /// 对象类 T_Bllb_sampleProduct_tbap[检验单产品表]
   /// </summary>
   [Serializable]
   public class Model_Bllb_sampleProduct_tbap
   {
        private String _TBAP_ID;// ID
        private String _DOC_NO;// 检验单
        private String _TBPS_ID;// 产品状态ID
        private String _RESULT;// OK/NG
        private String _TEST_MAN;// 检测人员工号
        private DateTime _TEST_TIME;// 检测时间

       public Model_Bllb_sampleProduct_tbap()
       {
            this._TBAP_ID="";
            this._DOC_NO="";
            this._TBPS_ID="";
            this._RESULT="";
            this._TEST_MAN="";
            this._TEST_TIME=DateTime.Parse("1900-01-01");

       }
        /// <summary>
        /// ID
        /// </summary>
        public String TBAP_ID
        {
            set { _TBAP_ID = value; }
            get { return _TBAP_ID; }
        }
        /// <summary>
        /// 检验单
        /// </summary>
        public String DOC_NO
        {
            set { _DOC_NO = value; }
            get { return _DOC_NO; }
        }
        /// <summary>
        /// 产品状态ID
        /// </summary>
        public String TBPS_ID
        {
            set { _TBPS_ID = value; }
            get { return _TBPS_ID; }
        }
        /// <summary>
        /// OK/NG
        /// </summary>
        public String RESULT
        {
            set { _RESULT = value; }
            get { return _RESULT; }
        }
        /// <summary>
        /// 检测人员工号
        /// </summary>
        public String TEST_MAN
        {
            set { _TEST_MAN = value; }
            get { return _TEST_MAN; }
        }
        /// <summary>
        /// 检测时间
        /// </summary>
        public DateTime TEST_TIME
        {
            set { _TEST_TIME = value; }
            get { return _TEST_TIME; }
        }
   }
}