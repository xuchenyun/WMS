/*************************************************************
* 版权所有 ＠ 薛建武 
* 创建时间：2017/8/14 10:50:31
 *************************************************************/
using System;
namespace Model
{
   /// <summary>
   /// 对象类 T_Bllb_SampleDoc_tbsd[检验单表]
   /// </summary>
   [Serializable]
   public class Model_Bllb_SampleDoc_tbsd
   {
        private String _DOC_NO;// 检验单号
        private String _ProductCode;// 产品代码
        private String _TBMS_ID;// 机种抽样方案ID（T_Bllb_modelSample_tbms）
        private int _DOC_QTY;// 送检数
        private int _PLAN_SAMPLE_QTY;// 应抽数
        private int _SAMPLE_QTY;// 已抽数
        private String _PLCode;// 线别代码
        private String _RESULT;// 判定结果（0:空值（未判定）、1：允收、2：拒收）
        private String _RESULT_MAN;// 判定人员工号
        private String _SfcNo;// 制令单
        private DateTime _CREATE_TIME;// 创建时间
        private DateTime _RESULT_TIME;// 判定时间
        private String _OVER_FLAG;// 检验单产品数已满（Y/N）
        private int _AC = 0;
        private int _RE = 1;
       public Model_Bllb_SampleDoc_tbsd()
       {
            this._DOC_NO="";
            this._ProductCode="";
            this._TBMS_ID="";
            this._DOC_QTY=0;
            this._PLAN_SAMPLE_QTY=0;
            this._SAMPLE_QTY=0;
            this._PLCode="";
            this._RESULT="'‘0’";
            this._RESULT_MAN="";
            this._SfcNo="";
            this._CREATE_TIME=DateTime.Parse("1900-01-01");
            this._RESULT_TIME=DateTime.Parse("1900-01-01");
            this._OVER_FLAG="";

       }
        /// <summary>
        /// 检验单号
        /// </summary>
        public String DOC_NO
        {
            set { _DOC_NO = value; }
            get { return _DOC_NO; }
        }
        /// <summary>
        /// 产品代码
        /// </summary>
        public String ProductCode
        {
            set { _ProductCode = value; }
            get { return _ProductCode; }
        }
        /// <summary>
        /// 机种抽样方案ID（T_Bllb_modelSample_tbms）
        /// </summary>
        public String TBMS_ID
        {
            set { _TBMS_ID = value; }
            get { return _TBMS_ID; }
        }
        /// <summary>
        /// 送检数
        /// </summary>
        public int DOC_QTY
        {
            set { _DOC_QTY = value; }
            get { return _DOC_QTY; }
        }
        /// <summary>
        /// 应抽数
        /// </summary>
        public int PLAN_SAMPLE_QTY
        {
            set { _PLAN_SAMPLE_QTY = value; }
            get { return _PLAN_SAMPLE_QTY; }
        }
        /// <summary>
        /// 已抽数
        /// </summary>
        public int SAMPLE_QTY
        {
            set { _SAMPLE_QTY = value; }
            get { return _SAMPLE_QTY; }
        }
        /// <summary>
        /// 线别代码
        /// </summary>
        public String PLCode
        {
            set { _PLCode = value; }
            get { return _PLCode; }
        }
        /// <summary>
        /// 判定结果（0:空值（未判定）、1：允收、2：拒收）
        /// </summary>
        public String RESULT
        {
            set { _RESULT = value; }
            get { return _RESULT; }
        }
        /// <summary>
        /// 判定人员工号
        /// </summary>
        public String RESULT_MAN
        {
            set { _RESULT_MAN = value; }
            get { return _RESULT_MAN; }
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
        /// 创建时间
        /// </summary>
        public DateTime CREATE_TIME
        {
            set { _CREATE_TIME = value; }
            get { return _CREATE_TIME; }
        }
        /// <summary>
        /// 判定时间
        /// </summary>
        public DateTime RESULT_TIME
        {
            set { _RESULT_TIME = value; }
            get { return _RESULT_TIME; }
        }
        /// <summary>
        /// 检验单产品数已满（Y/N）
        /// </summary>
        public String OVER_FLAG
        {
            set { _OVER_FLAG = value; }
            get { return _OVER_FLAG; }
        }
        /// <summary>
        /// 允收数
        /// </summary>
        public int AC
        {
            get
            {
                return _AC;
            }

            set
            {
                _AC = value;
            }
        }
        /// <summary>
        /// 拒收数
        /// </summary>
        public int RE
        {
            get
            {
                return _RE;
            }

            set
            {
                _RE = value;
            }
        }
    }
}