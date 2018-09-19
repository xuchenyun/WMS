using CIT.Wcf.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CIT.MES.Common.Helper
{
    public class PageHelper
    {
        /// <summary>
        /// 获得分页数据
        /// </summary>
        /// <param name="orderby">排序字段</param>
        /// <param name="tablename">表名</param>
        /// <param name="pageIndex">当前页索引</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="strWhere">搜索条件 eg : and 1=1</param>
        /// <returns></returns>
        public static DataTable GetPagedata(string orderby, string tablename, int pageIndex, int pageSize, string strWhere)
        {
            int start = (pageIndex - 1) * pageSize;
            int end = pageIndex * pageSize;
            string sql = string.Format(@"select * from(select row_number() over(order by {0}) as num,* from {1}) as t where t.num>={2} and t.num<={3} {4}", orderby, tablename, start, end, strWhere);
            DataTable da = NMS.QueryDataTable(PubUtils.uContext, sql);
            return da;
        }

        /// <summary>
        /// 计算总的页数
        /// </summary>
        /// <param name="pageSize">每页显示记录数</param>
        /// <param name="tablename">表名</param>
        /// <returns></returns>
        public static int GetPageCount(int pageSize, string tablename, out int recordCount)
        {
            string sql = string.Format("select count(*) from {0}", tablename);
            recordCount = Convert.ToInt32(NMS.GetTableCount(PubUtils.uContext, sql));//获取总的记录数
            int pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount / pageSize));
            return pageCount;
        }
    }
}
