/*************************************************************
* 版权所有 ＠ 薛建武 
* 创建时间：2017/7/14 14:14:29
 *************************************************************/
using System;
namespace Model
{
    /// <summary>
    /// 对象类 T_Bllb_techGroupStation_tbtgs[工艺工序工位表]
    /// </summary>
    [Serializable]
    public class Model_Bllb_techGroupStation_tbtgs
    {
        private String _TBTGS_ID;
        private String _TBTG_ID;
        private String _TBS_ID;
        private string _TBT_ID = "";
       
        public Model_Bllb_techGroupStation_tbtgs()
        {
            this._TBTGS_ID = "";
            this._TBTG_ID = "";
            this._TBS_ID = "";
            this._TBT_ID = "";
        }
        /// <summary>
        /// 工艺工序工位ID（全球唯一码）
        /// </summary>
        public String TBTGS_ID
        {
            set { _TBTGS_ID = value; }
            get { return _TBTGS_ID; }
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
        /// 工位ID（T_Bllb_station_tbs）
        /// </summary>
        public String TBS_ID
        {
            set { _TBS_ID = value; }
            get { return _TBS_ID; }
        }
        /// <summary>
        /// 工艺ID
        /// </summary>
        public string TBT_ID
        {
            get
            {
                return _TBT_ID;
            }

            set
            {
                _TBT_ID = value;
            }
        }
    }
}