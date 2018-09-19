using Common.DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Common.BLL
{
    /// <summary>
    /// 物料代码业务层操作类
    /// </summary>
    public partial class BLL_MdcdatMaterial
    {
        DAL_MdcdatMaterial mdcdatMaterial_DAL = new DAL_MdcdatMaterial();

        /// <summary>
        /// 根据条件进行连接查询
        /// </summary>
        /// <param name="objs"></param>
        /// <returns></returns>
        public DataTable Select(params object[] objs)
        {
            return mdcdatMaterial_DAL.GetList(objs);
        }
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <returns></returns>
        public DataTable Select(string strWhere)
        {
            return mdcdatMaterial_DAL.GetList(strWhere);
        }
        /// <summary>
        /// 根据料号查询品名和规格
        /// </summary>
        /// <returns></returns>
        public DataTable SelectNameAndSpec(string MaterialCode)
        {
            return mdcdatMaterial_DAL.GetNameAndSpec(MaterialCode);
        }
        /// <summary>
        /// 查询条码和规则
        /// </summary>
        /// <returns></returns>
        public DataTable SelectCodeAndRule(string strWhere)
        {
            return mdcdatMaterial_DAL.GetCodeAndRule(strWhere);
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="_obj"></param>
        /// <returns></returns>
        public bool Insert(List<MdcdatMaterial> lstObj)
        {
            return mdcdatMaterial_DAL.InsertObj(lstObj);
        }
    }
}
