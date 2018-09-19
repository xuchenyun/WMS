using BaseData.DAL;
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
    public class MdcDatProductLine_BLL
    {
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>

        public DataTable Select(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT 'false' as 'CHK', PLCode,PLName,Step FROM MdcDatProductLine");
            if (strWhere != string.Empty)
            {
                strSql.Append(strWhere);
            }
            return NMS.QueryDataTable(PubUtils.uContext, strSql.ToString());
        }
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="ProductLine"></param>
        /// <returns></returns>
        public bool Insert(MdcDatProductLine ProductLine)
        {
            string strSql = string.Format("INSERT INTO MdcDatProductLine(PLCode,PLName,Step)VALUES('{0}','{1}','{2}')", ProductLine.PLCode, ProductLine.PLName, ProductLine.Step);
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 编辑数据
        /// </summary>
        /// <param name="ProductLine"></param>
        /// <returns></returns>
        public bool Update(MdcDatProductLine ProductLine)
        {
            string strSql = string.Format("Update MdcDatProductLine SET PLName='{0}',Step='{1}' WHERE PLCode='{2}'", ProductLine.PLName, ProductLine.Step, ProductLine.PLCode);
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public bool Delete(string strWhere)
        {
            string strSql = string.Format("Delete MdcDatProductLine {0}", strWhere);
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 检测线别代码是否已经存在
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable  IsExist(string strWhere)
        {
            string strSql = string.Format(" select * from MdcDatProductLine {0}", strWhere);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);

        }
    }
}
