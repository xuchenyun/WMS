/*
  版权:  @Zach.zhong
  生成日期:2018/1/17   
  说明: T_Work_Number表业务层操作类                      
*/
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CIT.Wcf.Utils;
using CIT.Interface;
using Model;

namespace BaseData.BLL
{
    public class Bll_Work_Number
    {
        /// <summary>
        /// 校验机种是否存在
        /// </summary>
        /// <param name="varWorkOrder"></param>
        /// <returns></returns>
        public static bool IsExitsWorkOrder(string varWorkOrder)
        {
            string sqlcmd = string.Format("select * from T_Work_Number where WoCode='{0}'", varWorkOrder);
            return NMS.QueryDataTable(CIT.MES.PubUtils.uContext, sqlcmd).Rows.Count > 0 ? true : false;
        }

        /// <summary>
        /// 校验机种是否存在
        /// </summary>
        /// <param name="varProduct"></param>
        /// <returns></returns>
        public static DataTable CheckProduct(string varProduct)
        {
            string sqlcmd = string.Format(@"
            if  not exists (select *  from MdcdatProduct where ProductCode = '{0}')
                  begin
                    select '0','机种错误' return
                  end
            else
                  begin
                    select '1',ProductName from MdcdatProduct where ProductCode='{0}' return
                  end
", varProduct);
            return NMS.QueryDataTable(CIT.MES.PubUtils.uContext, sqlcmd);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="strWhere">where条件</param>
        /// <returns></returns>
		public static DataTable Query(string strWhere)
        {
            string sqlcmd = string.Format(@"select WoCode,Version, ProductCode,ProductName,PlanQty,AQty,BQty,TQty,C_PartNumber,
case Status when '0' then '开立' when '1' then '生产' when '2' then '完工' end Status,
case MaterialModel when '0' then '客供料' when '1' then '自购料' end MaterialModel,Creator,CreateTime,Remark from T_Work_Number {0}", strWhere);
            return NMS.QueryDataTable(CIT.MES.PubUtils.uContext, sqlcmd);
        }
        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="model">T_Work_Number表实体</param>
        /// <returns></returns>
		public static bool Insert(T_Work_Number model)
        {
            string sqlcmd = string.Format(@"insert into T_Work_Number(WoCode,ProductCode,ProductName,PlanQty,AQty,BQty,TQty,Status,MaterialModel,Creator,CreateTime,Remark,C_PartNumber,Version)
values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}',getdate(),'{10}','{11}','{12}')", model.WoCode, model.ProductCode, model.ProductName, model.PlanQty, model.AQty, model.BQty,
model.TQty, model.Status, model.MaterialModel, model.Creator, model.Remark,model.C_PartNumber,model.Version);
            return NMS.ExecTransql(CIT.MES.PubUtils.uContext, sqlcmd);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="WoCode">WoCode 注：WoCode必须能够唯一标识</param>
        /// <returns></returns>
		public static bool Delete(string WoCode)
        {
            string sqlcmd = string.Format("delete from T_Work_Number where WoCode='{0}'", WoCode);
            return NMS.ExecTransql(CIT.MES.PubUtils.uContext, sqlcmd);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model">T_Work_Number表实体</param>
        /// <returns></returns>
		public static bool Update(T_Work_Number model)
        {
            string sqlcmd = string.Format(@"update T_Work_Number set 
				ProductCode='{1}',
                ProductName='{2}',
				PlanQty='{3}',
				AQty='{4}',
				BQty='{5}',
				TQty='{6}',
				Status='{7}',
				MaterialModel='{8}',
				Creator='{9}',
				Remark='{10}'
				where WoCode='{0}'", model.WoCode, model.ProductCode, model.ProductName, model.PlanQty, model.AQty, model.BQty,
model.TQty, model.Status, model.MaterialModel, model.Creator, model.Remark);
            return NMS.ExecTransql(CIT.MES.PubUtils.uContext, sqlcmd);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model">T_Work_Number表实体</param>
        /// <returns></returns>
        public static bool UpdateC_PartNumber(T_Work_Number model)
        {
            string sqlcmd = string.Format(@"update T_Work_Number set 
				C_PartNumber='{1}'
				where WoCode='{0}'", model.WoCode, model.C_PartNumber);
            return NMS.ExecTransql(CIT.MES.PubUtils.uContext, sqlcmd);
        }
        /// <summary>
        /// 查询物料
        /// </summary>
        /// <returns></returns>
        public static DataTable QueryMaterialInfo(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT MaterialCode,MaterialName,Spec FROM MdcdatMaterial ");
            if (strWhere != string.Empty)
            {
                strSql.Append(" where " + strWhere);
            }
            return NMS.QueryDataTable(CIT.MES.PubUtils.uContext, strSql.ToString());
        }

        /// <summary>
        /// 新增物料信息
        /// </summary>
        /// <param name="_obj"></param>
        /// <returns></returns>
        public static bool SaveMateialInfo(List<MdcdatMaterial> listObj)
        {
            StringBuilder strSql = new StringBuilder();
            foreach (MdcdatMaterial _obj in listObj)
            {
                strSql.Append(string.Format(@"insert into MdcdatMaterial ( MaterialCode,MaterialName,Spec)values('{0}','{1}','{2}')",
                    _obj.MaterialCode, _obj.MaterialName, _obj.Spec));
            }
            return NMS.ExecTransql(CIT.MES.PubUtils.uContext, strSql.ToString());
        }

        public static DataTable Query_Bom(string strWhere)
        {
            string strSql = string.Format(@"
SELECT 'False' CheckID,'0' Flag, T.TBWB_ID,T.MaterialCode,M.MaterialName,M.Spec,T.BOM_QTY FROM T_Bllb_wocodeBom_tbwb T 
LEFT JOIN MdcdatMaterial M ON T.MaterialCode=M.MaterialCode {0}", strWhere);
            return NMS.QueryDataTable(CIT.MES.PubUtils.uContext, strSql);
        }

        /// <summary>
        /// 添加工单BOM表
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool Insert_Bom(Model_Bllb_wocodeBom_tbwb obj)
        {
            string strSql = string.Format(@"INSERT INTO T_Bllb_wocodeBom_tbwb(
                                        TBWB_ID,WoCode,MaterialCode,
                                        BOM_QTY)
                                        VALUES( 
                                        '{0}',
                                        '{1}',
                                        '{2}',
                                        '{3}')",
                                         obj.TBWB_ID,
                                         obj.WoCode,
                                         obj.MaterialCode,
                                         obj.BOM_QTY);
            return CIT.Wcf.Utils.NMS.ExecTransql(CIT.MES.PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 删除工单BOM表
        /// </summary>
        /// <param name="obj">ModelT_Bllb_wocodeBom_tbwb对象</param>
        /// <returns></returns>
        public static bool Delete_Bom(string strWhere)
        {
            string strSql = string.Format(@"DELETE FROM T_Bllb_wocodeBom_tbwb {0}", strWhere);
            return CIT.Wcf.Utils.NMS.ExecTransql(CIT.MES.PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 修改工单BOM表
        /// </summary>
        /// <param name="obj">Model_T_Bllb_wocodeBom_tbwb对象</param>
        /// <returns></returns>
        public static bool Update_Bom(Model_Bllb_wocodeBom_tbwb obj)
        {
            string strSql = string.Format(@"UPDATE T_Bllb_wocodeBom_tbwb SET
                                        BOM_QTY='{1}',WoCode='{2}'
                                        where
                                        TBWB_ID='{0}'
                                        ",
                                      obj.TBWB_ID,
                                      obj.BOM_QTY,
                                      obj.WoCode);
            return CIT.Wcf.Utils.NMS.ExecTransql(CIT.MES.PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 同步BOM
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public static DataTable QuerySyncBom(string product)
        {
            string strSql = string.Format(@"
SELECT  'False' AS CheckId ,
        '1' AS Flag ,
        T.MaterialCode ,
        M.MaterialName ,
        T.BOM_QTY
FROM    SfcDatProduct AS S
        LEFT JOIN T_Bllb_wocodeBom_tbwb AS T ON S.WoCode = T.WoCode
        LEFT JOIN MdcdatMaterial AS M ON M.MaterialCode = T.MaterialCode
WHERE   S.Product = '{0}'
        AND S.DEFUALT_BOM_FLAG = 'Y' ", product);
            return NMS.QueryDataTable(CIT.MES.PubUtils.uContext, strSql);
        }
    }
}
