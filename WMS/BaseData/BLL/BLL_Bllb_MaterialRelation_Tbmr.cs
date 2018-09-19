/*
  版权:  @Zach.zhong
  生成日期:2018/6/14   
  说明: T_Bllb_MaterialRelation_Tbmr表业务层操作类                      
*/
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using CIT.Wcf.Utils;
using CIT.MES;

namespace BaseData.BLL
{
    public class BLL_Bllb_MaterialRelation_Tbmr
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="strWhere">where条件</param>
        /// <returns></returns>
		public static DataTable Query(string strWhere)
        {

            string sqlcmd = string.Format(@"
SELECT  LocalMaterialCode ,
        SupplyMaterialCode ,
        Supply ,
        Remark ,
        TBMR_ID
FROM    [dbo].[T_Bllb_MaterialRelation_Tbmr] {0}", strWhere);
            return NMS.QueryDataTable(PubUtils.uContext, sqlcmd);
        }
        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="model">T_Bllb_MaterialRelation_Tbmr表实体</param>
        /// <returns></returns>
		public static bool Insert(T_Bllb_MaterialRelation_Tbmr model)
        {
            string sqlcmd = string.Format(@"
INSERT  INTO T_Bllb_MaterialRelation_Tbmr
        ( LocalMaterialCode ,
          SupplyMaterialCode ,
          Supply ,
          Remark ,
          TBMR_ID
        )
VALUES  ( '{0}' ,
          '{1}' ,
          '{2}' ,
          '{3}' ,
          '{4}'
        )", model.LocalMaterialCode, model.SupplyMaterialCode, model.Supply, model.Remark, model.TBMR_ID);
            return NMS.ExecTransql(PubUtils.uContext, sqlcmd);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
		public static bool Delete(string strWhere)
        {
            string sqlcmd = string.Format(@"
DELETE  FROM T_Bllb_MaterialRelation_Tbmr {0} ", strWhere);
            return NMS.ExecTransql(PubUtils.uContext, sqlcmd);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model">T_Bllb_MaterialRelation_Tbmr表实体</param>
        /// <returns></returns>
		public static bool Update(T_Bllb_MaterialRelation_Tbmr model)
        {
            string sqlcmd = string.Format(@"
update T_Bllb_MaterialRelation_Tbmr set 
LocalMaterialCode='{0}',
SupplyMaterialCode='{1}',
Supply='{2}',
Remark='{3}'	
where TBMR_ID='{4}'", model.LocalMaterialCode, model.SupplyMaterialCode, model.Supply, model.Remark, model.TBMR_ID);
            return NMS.ExecTransql(PubUtils.uContext, sqlcmd);
        }


    }
}
