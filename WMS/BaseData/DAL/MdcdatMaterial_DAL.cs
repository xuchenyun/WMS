using CIT.MES;
using CIT.Wcf.Utils;
using Common.Helper;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseData.DAL
{
    public partial class MdcdatMaterial_DAL
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataTable QueryMaterialInfo(string strWhere)
        {

            //string strSql = string.Format(@"select MaterialCode,MaterialName,case Type when 0 then '红胶' when 1 then '锡膏' when 2 then 'MSD' when 3 then '普通' else null end as Type,
            //case a.HouseCode when (select Storage_SN  from T_Bllb_Storage_tbs where Storage_SN=a.HouseCode) then (select Storage_Name  from T_Bllb_Storage_tbs where Storage_SN=a.HouseCode) else ''  end HouseCode,ShelfLifeTime,Spec,
            //case a.HouseCode1 when (select Storage_SN  from T_Bllb_Storage_tbs where Storage_SN=a.HouseCode1) then (select Storage_Name  from T_Bllb_Storage_tbs where Storage_SN=a.HouseCode1)  else ''  end HouseCode,
            //case a.HouseCode2 when (select Storage_SN  from T_Bllb_Storage_tbs where Storage_SN=a.HouseCode2) then (select Storage_Name  from T_Bllb_Storage_tbs where Storage_SN=a.HouseCode2)  else ''  end HouseCode,
            //case IsMSD when 0 then '是' when 1 then '否' end IsMSD,SecondMaterialClass,SafeQty,IsSendCheck,case IncomingType when 0 then '自供' when 1 then '客供' end as IncomingType,PackageType,PackagingMax,PackagingMin from MdcdatMaterial a  {0}", strWhere);
            string strSql = string.Format(@"
SELECT  X.MaterialCode ,
        X.MaterialName ,
        X.Type ,
        X.HouseCode ,
        X.ShelfLifeTime ,
        X.Spec ,
        Y.HouseCode1 ,
        Z.HouseCode2 ,
        X.IsMSD ,
        X.SecondMaterialClass ,
        X.SafeQty ,
        X.IsSendCheck ,
		X.IncomingType ,
        X.PackageType ,
        X.PackagingMax ,
        X.PackagingMin
FROM    ( SELECT    MaterialCode ,
                    MaterialName ,
                    Type ,
                    CASE a.HouseCode
                      WHEN b.Storage_SN THEN b.Storage_Name
                      ELSE ''
                    END HouseCode ,
                    ShelfLifeTime ,
                    Spec ,
                    CASE IsMSD
                      WHEN '0' THEN '是'
                      WHEN '1' THEN '否'
                    END IsMSD ,
                    SecondMaterialClass ,
                    SafeQty ,
                    IsSendCheck ,
                    CASE IncomingType
                      WHEN '0' THEN '自供'
                      WHEN '1' THEN '客供'
                    END AS IncomingType ,
                    PackageType ,
                    PackagingMax ,
                    PackagingMin
          FROM      MdcdatMaterial a
                    LEFT JOIN T_Bllb_Storage_tbs AS b ON a.HouseCode = b.Storage_SN
        ) X
        INNER JOIN ( SELECT MaterialCode,
                            CASE a.HouseCode1
                            WHEN b.Storage_SN THEN b.Storage_Name
                            ELSE ''
                            END HouseCode1 
                     FROM   MdcdatMaterial a
                            LEFT JOIN T_Bllb_Storage_tbs AS b ON a.HouseCode1 = b.Storage_SN
                   ) Y ON X.MaterialCode = Y.MaterialCode
        INNER JOIN ( SELECT MaterialCode,
                            CASE a.HouseCode2
                            WHEN b.Storage_SN THEN b.Storage_Name
                            ELSE ''
                            END HouseCode2 
                     FROM   MdcdatMaterial a
                            LEFT JOIN T_Bllb_Storage_tbs AS b ON a.HouseCode2 = b.Storage_SN
                   ) Z ON Y.MaterialCode = Z.MaterialCode
 {0}", strWhere);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 查询仓库
        /// </summary>
        /// <returns></returns>
        public static DataTable QueryHouseCode()
        {
            string strSql = string.Format("select Storage_SN, Storage_Name from T_Bllb_Storage_tbs");
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool Insert(MdcdatMaterial M)
        {
            string strSql = string.Format("Insert into MdcdatMaterial(MaterialCode,MaterialName,Type,HouseCode,HouseCode1,HouseCode2,IsMSD,IsSendCheck,SecondMaterialClass,IncomingType,PackageType,PackagingMax,PackagingMin,ShelfLifeTime,SafeQty,Creator,CreateTime) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}',getdate())", M.MaterialCode, M.MaterialName, M.Type, M.HouseCode, M.HouseCode1, M.HouseCode2, M.IsMSD, M.IsSendCheck, M.SecondMaterialClass, M.INCOMINGTYPE, M.PackageType, M.PackagingMax, M.PackagingMin, M.ShelfLifeTime, M.SafeQty, PubUtils.uContext.UserID);
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool Update(MdcdatMaterial M)
        {
            string strSql = string.Format(@"update MdcdatMaterial set MaterialCode='{0}',MaterialName='{1}',Type='{2}',HouseCode='{3}',HouseCode1='{4}',HouseCode2='{5}',IsMSD='{6}',IsSendCheck='{7}',SecondMaterialClass='{8}',IncomingType='{9}',PackageType='{10}',PackagingMax='{11}',PackagingMin='{12}',ShelfLifeTime='{13}',SafeQty='{14}',Updator='{15}',UpdateTime=getdate() where MaterialCode='{0}'", M.MaterialCode, M.MaterialName, M.Type, M.HouseCode, M.HouseCode1, M.HouseCode2, M.IsMSD, M.IsSendCheck, M.SecondMaterialClass, M.INCOMINGTYPE, M.PackageType, M.PackagingMax, M.PackagingMin, SqlInput.ChangeNullToInt(M.ShelfLifeTime, 0), SqlInput.ChangeNullToInt(M.SafeQty, 0), PubUtils.uContext.UserID);
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public static bool Delete(string where)
        {
            string strSql = string.Format(@"delete MdcdatMaterial {0} ", where);
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 类型带出辅材等级
        /// </summary>
        /// <returns></returns>
        public static DataTable GetSecMaterialClass(string Type)
        {
            string strSql = string.Format(@"select distinct Class from T_Bllb_SecondClass_tbsc where Type='{0}'", Type);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
    }
}
