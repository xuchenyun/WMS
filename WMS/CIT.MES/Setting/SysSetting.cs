using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;

namespace CIT.MES.Setting
{
    #region 2017.06.14 by simon.li 新增常规设置类库
    public class SysSetting
    {
        //构造函数加载数据库配置文件
        public SysSetting()
        {
            setting = Wcf.Utils.NMS.QueryDataTable(PubUtils.uContext, "select * from SysDatConfig");


            var mSlotCut = setting.Select("key1='MSlotCut'");
            if (mSlotCut.Length > 0)
            {
                this.MSlotCut = mSlotCut[0]["val1"].ToString()[0];
            }
            else
            {
                Wcf.Utils.NMS.ExecTransql(PubUtils.uContext, "INSERT INTO SysDatConfig(key1,val1)VALUES('MSlotCut','-');", new Interface.CmdParameter[0]);
                this.MSlotCut = '-';
            }

            var isCheckErpWoState = setting.Select("key1='IsCheckErpWoState'");
            if (isCheckErpWoState.Length > 0)
            {
                this.IsCheckErpWoState = isCheckErpWoState[0]["val1"].ToString().ToLower() == "True" ? true : false;
            }
            else
            {
                Wcf.Utils.NMS.ExecTransql(PubUtils.uContext, "INSERT INTO SysDatConfig(key1,val1)VALUES('IsCheckErpWoState','True');", new Interface.CmdParameter[0]);
                this.IsCheckErpWoState = true;
            }


        }

        [CategoryAttribute("常规设置"), DescriptionAttribute("是否在开始备料的时候启用ERP工单状态校验\n【True : 启用】 【False : 禁用】，默认为启用")]
        public bool IsCheckErpWoState { get; set; }

        [CategoryAttribute("常规设置"), DescriptionAttribute("生产数据解析字符串\n用于料站表解析 【产品、面别、线别】 仅允许输入一个字符，默认字符为 '-' 。")]
        public char MSlotCut { get; set; }

        //数据库配置表
        private DataTable setting;

        public bool Save()
        {
            string sql = "";
            var mSlotCut = setting.Select("key1='MSlotCut'");
            if (mSlotCut[0]["val1"].ToString()[0] != this.MSlotCut)
            {
                sql += "update SysDatConfig set val1='" + this.MSlotCut + "' where key1='MSlotCut' ;";
                mSlotCut[0]["val1"] = this.MSlotCut;
            }

            var isCheckErpWoState = setting.Select("key1='IsCheckErpWoState'");
            if ((isCheckErpWoState[0]["val1"].ToString() == "True" ? true : false) != this.IsCheckErpWoState)
            {
                sql += "update SysDatConfig set val1='" + (this.IsCheckErpWoState ? "True" : "False") + "' where key1='IsCheckErpWoState' ;";
                isCheckErpWoState[0]["val1"] = (this.IsCheckErpWoState ? "True" : "False");
            }

            if (sql.Length > 0)
            {
                Wcf.Utils.NMS.ExecTransql(PubUtils.uContext, sql, new Interface.CmdParameter[0]);

            }
            return true;
        }
    } 
    #endregion
}
