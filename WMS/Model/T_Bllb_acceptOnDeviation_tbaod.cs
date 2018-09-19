using System;
namespace Model
{
    /// <summary>
    /// 让步接受表
    /// </summary>
    [Serializable]
    public partial class T_Bllb_acceptOnDeviation_tbaod
    {
        public T_Bllb_acceptOnDeviation_tbaod()
        { }
        #region Model
        private string _tbaod_id;
        private string _doc_no;
        private string _apply_man;
        private DateTime? _apply_time;
        private string _apply_memo;
        private string _approve_result;
        private string _approve_man;
        private DateTime? _approve_time;
        private string _approve_memo;
        private DateTime? _apply_time_min;
        private DateTime? _apply_time_max;
        /// <summary>
        /// 让步接受ID(唯一码)
        /// </summary>
        public string TBAOD_ID
        {
            set { _tbaod_id = value; }
            get { return _tbaod_id; }
        }
        /// <summary>
        /// 检验单
        /// </summary>
        public string DOC_NO
        {
            set { _doc_no = value; }
            get { return _doc_no; }
        }
        /// <summary>
        /// 申请人(员工号)
        /// </summary>
        public string APPLY_MAN
        {
            set { _apply_man = value; }
            get { return _apply_man; }
        }
        /// <summary>
        /// 申请时间
        /// </summary>
        public DateTime? APPLY_TIME
        {
            set { _apply_time = value; }
            get { return _apply_time; }
        }
        /// <summary>
        /// 申请说明
        /// </summary>
        public string APPLY_MEMO
        {
            set { _apply_memo = value; }
            get { return _apply_memo; }
        }
        /// <summary>
        /// 审批结果(2:拒收; 3:让步接收)
        /// </summary>
        public string APPROVE_RESULT
        {
            set { _approve_result = value; }
            get { return _approve_result; }
        }
        /// <summary>
        /// 审批人(员工号)
        /// </summary>
        public string APPROVE_MAN
        {
            set { _approve_man = value; }
            get { return _approve_man; }
        }
        /// <summary>
        /// 审批时间
        /// </summary>
        public DateTime? APPROVE_TIME
        {
            set { _approve_time = value; }
            get { return _approve_time; }
        }
        /// <summary>
        /// 审批说明
        /// </summary>
        public string APPROVE_MEMO
        {
            set { _approve_memo = value; }
            get { return _approve_memo; }
        }
        /// <summary>
        /// 申请时间查询最小时间
        /// </summary>
        public DateTime? APPLY_TIME_MIN
        {
            get { return _apply_time_min; }
            set { _apply_time_min = value; }
        }
        /// <summary>
        /// 申请时间查询最大时间
        /// </summary>
        public DateTime? APPLY_TIME_MAX
        {
            set { _apply_time_max = value; }
            get { return _apply_time_max; }
        }
        #endregion Model

    }
}

