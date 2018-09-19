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
    public class BLL_Bllb_ConMaterial_tbcm
    {
        /// <summary>
        ///增加
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        public static bool Insert(List<T_Bllb_ConMaterial_tbcm> Model)
        {
            StringBuilder strbuilder_insert = new StringBuilder();
            foreach (T_Bllb_ConMaterial_tbcm model in Model)
            {
                strbuilder_insert.AppendFormat(@"
INSERT INTO dbo.T_Bllb_ConMaterial_tbcm
        ( TBCM_Product ,
          TBCM_ProductName ,
          TBCM_MaterialCode ,
          TBCM_MaterialName ,
          TBCM_Type ,
          TBCM_Remark ,
          TBCM_ID ,
          TBCM_Creator ,
          TBCM_CreateTime
        )
VALUES  ( N'{0}' , -- TBCM_Product - nvarchar(50)
          N'{1}' , -- TBCM_ProductName - nvarchar(50)
          N'{2}' , -- TBCM_MaterialCode - nvarchar(50)
          N'{3}' , -- TBCM_MaterialName - nvarchar(50)
          N'{4}' , -- TBCM_Type - nvarchar(50)
          N'{5}' , -- TBCM_Remark - nvarchar(50)
          newid() , -- TBCM_ID - nvarchar(50)
          N'{6}' , -- TBCM_Creator - nvarchar(50)
          GETDATE()  -- TBCM_CreateTime - datetime
        )", model.TBCM_Product, model.TBCM_ProductName, model.TBCM_MaterialCode, model.TBCM_MaterialName, model.TBCM_Type, model.TBCM_Remark, PubUtils.uContext.UserID);
            }
            if (strbuilder_insert.Length > 0)
            {
                return NMS.ExecTransql(PubUtils.uContext, strbuilder_insert.ToString());
            }
            return true;
        }

        public static DataTable Query(string strWhere)
        {
            string strQuery = string.Format(@"
SELECT  TBCM_Product ,
        TBCM_ProductName ,
        TBCM_MaterialCode ,
        TBCM_MaterialName ,
        TBCM_Type ,
        TBCM_Remark ,
        TBCM_ID ,
        CASE TBCM_Creator
          WHEN b.UserID THEN b.UserName
        END 'TBCM_Creator' ,
        TBCM_CreateTime
FROM    dbo.T_Bllb_ConMaterial_tbcm AS a
        LEFT JOIN dbo.SysDatUser AS b ON a.TBCM_Creator = b.UserID{0}", strWhere);
            return NMS.QueryDataTable(PubUtils.uContext, strQuery);
        }

        /// <summary>
        /// 根据类型查询物料信息
        /// </summary>
        /// <param name="strwhere"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static DataTable QueryMaterialCodeByType(string strwhere, string type)
        {
            StringBuilder strbuilder_query = new StringBuilder();
            if (type == "锡膏" || type == "红胶")
            {
                strbuilder_query.AppendFormat(@"SELECT *  FROM dbo.MdcdatMaterial {0}", strwhere);
                return NMS.QueryDataTable(PubUtils.uContext, strbuilder_query.ToString());
            }
            else if (type == "钢网" || type == "刮刀")
            {
                strbuilder_query.AppendFormat(@"SELECT *  FROM dbo.T_Bllb_ManufactureNum_tbmn {0}", strwhere);
                return NMS.QueryDataTable(PubUtils.uContext, strbuilder_query.ToString());
            }
            return null;
        }
        /// <summary>
        /// 机种与物料的关系是否存在
        /// </summary>
        /// <param name="product"></param>
        /// <param name="materialcode"></param>
        /// <returns></returns>
        public static bool GetRelationProMat(string product, string materialcode)
        {
            string strsql = string.Format(@"select *  from T_Bllb_ConMaterial_tbcm where TBCM_Product='{0}'
and TBCM_MaterialCode='{1}' ", product, materialcode);
            if (NMS.QueryDataTable(PubUtils.uContext, strsql).Rows.Count > 0)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static bool Delete(string strWhere)
        {
            string strSql = string.Format(@"delete from T_Bllb_ConMaterial_tbcm {0}", strWhere);
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }

        public static bool Is_Right_Type(string materialcode, string type, out string msg)
        {
            string strSql = string.Format(@"SELECT *  FROM dbo.MdcdatMaterial WHERE MaterialCode='{0}'", materialcode);
            DataTable dt = NMS.QueryDataTable(PubUtils.uContext, strSql);
            if (dt.Rows.Count > 0)
            {
                if (type == dt.Rows[0]["Type"].ToString())
                {
                    msg = "OK";
                    return true;
                }
                else
                {
                    msg = "类型不一致";
                    return false;
                }
            }
            else
            {
                msg = "物料不存在";
                return false;
            }
        }
    }
}
