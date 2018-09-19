using CIT.MES;
using CIT.Wcf.Utils;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseData.BLL
{
    public class BLL_T_Bllb_MaterialQuality_tbmq
    {
        /// <summary>
        /// 右键新增数据
        /// </summary>
        /// <param name="M"></param>
        /// <returns></returns>
        public bool AddStepAndQuality(T_Bllb_MaterialQuality_tbmq Step)
        {
            string strSql = string.Format("Insert into  T_Bllb_MaterialQuality_tbmq  (MaterialCode,Step,QualityLength) Values ('{0}','{1}','{2}')", Step.MaterialCode, Step.Step, Step.QualityLength);
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 右键修改数据
        /// </summary>
        /// <param name="M"></param>
        /// <returns></returns>
        public bool UpdateStepAndQulity(T_Bllb_MaterialQuality_tbmq Step, string OldStep)
        {
            string strSql = string.Format("Update T_Bllb_MaterialQuality_tbmq SET Step='{0}', QualityLength='{1}' WHERE MaterialCode='{2}' and Step='{3}'", Step.Step, Step.QualityLength, Step.MaterialCode, OldStep);
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 检测料号和阶别是否已经存在
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable IsExist(string strWhere)
        {
            string strSql = string.Format(" Select * from  T_Bllb_MaterialQuality_tbmq {0}", strWhere);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 右键删除
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public bool Delete(string strWhere)
        {
            string strSql = string.Format("Delete T_Bllb_MaterialQuality_tbmq {0}", strWhere);
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 检验阶别是否存在
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable IsStepExist(string strWhere)
        {
            string strSql = string.Format(" Select * from T_Bllb_MaterialQuality_tbmq {0}", strWhere);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
    }
}
