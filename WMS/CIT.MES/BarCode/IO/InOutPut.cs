using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

using System.Data;
using CIT.Wcf.Utils;
using System.Xml.Serialization;
using CIT.Interface;

namespace CIT.MES.IO
{
    public class InOutPut
    {
        /// <summary>
        /// 将设计器中的对像列表保存到文件中
        /// </summary>
        /// <param name="designer">所要保存的设计器</param>
        /// <param name="fileName">要保存的文件名称</param>
        public static void SaveFile(Designer designer, string Name)
        {
            if (Name.Trim().Length > 0)
            {
                Name = Name.Replace("当前模板名称为:", "");
                ObjectSerializer osave = new ObjectSerializer(designer.Items, designer.Width, designer.Height, designer.PrinterConfig, designer.PageRows, designer.RowHeight);

                //定义一个流
                MemoryStream stream = new MemoryStream();
                //定义一个格式化器
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(stream, osave);  //序列化
                byte[] array = null;
                array = new byte[stream.Length];
                //将二进制流写入数组
                stream.Position = 0;
                stream.Read(array, 0, (int)stream.Length);
                //关闭流
                stream.Close();

                CmdParameter[] cmd = new CmdParameter[1];
                CmdParameter cmd1 = new CmdParameter();
                cmd1.ParameterName = "val";
                cmd1.Value = array;
                cmd[0] = cmd1;
                NMS.ExecTransql(PubUtils.uContext, "if exists( select *from mdcdatbarcodetemplet where name='" + Name + "') begin update  mdcdatbarcodetemplet set context=@val,updator='" + PubUtils.uContext.UserName + "',updatetime=getdate() where name='" + Name + "' end else begin insert into mdcdatbarcodetemplet(fguid,name,context,creator,createtime)values('','" + Name + "',@val,'" + PubUtils.uContext.UserName + "',getdate()) end", cmd);

            }

            //using (FileStream fs = new FileStream(fileName, FileMode.Create))
            //{
            //    BinaryFormatter bf = new BinaryFormatter();
            //    bf.Serialize(fs, osave);
            //    fs.Close();
            //    bf = null;
            //}

        }

        //修正因对象实例化太多占用大量内容导致程序卡死。2017-05-26 by simon.li
        static Designer ds = new Designer();
        public static bool PrintTemplet(string templetName, Dictionary<string, string> dic)
        {
            DataTable dt = NMS.QueryDataTable(PubUtils.uContext, "select * from mdcdatbarcodetemplet where name='" + templetName + "'");
            if (dt.Rows.Count > 0)
            {
                byte[] Val = (byte[])dt.Rows[0]["context"];
                //ds = new Designer();
                OpenFile(ds, Val);
                foreach (var item in ds.Items)
                {
                    if (item is BarCode.DrawBarcodes)
                    {
                        BarCode.DrawBarcodes bd = item as BarCode.DrawBarcodes;
                        foreach (var printItem in bd.printItem)
                        {
                            if (dic.ContainsKey(printItem.ID))
                            {
                                printItem.Value = dic[printItem.ID];
                            }
                        }
                    }
                    else if (item is DrawItem.DrawText)
                    {
                        DrawItem.DrawText bd = item as DrawItem.DrawText;

                        foreach (var printItem in bd.printItem)
                        {
                            if (dic.ContainsKey(printItem.ID))
                            {
                                printItem.Value = dic[printItem.ID];
                            }
                        }

                    }
                }
                ds.PrintPage(1);
                return true;
            }
            return false;
        }
        static BinaryFormatter formatter;
        /// <summary>
        /// 打开保存的文件
        /// 在打开保存的文件,此函数会返回保存的类
        /// 在将类的数据返回给设计器的时候需刷新
        /// 设计器和放在设计器的容器
        /// 刷新设计器是将对像显示出来
        /// 刷新设计器容器是重绘标尺
        /// </summary>
        /// <param name="fileName">打开的文件名称</param>
        /// <returns>文件是否成功打开</returns>
        public static bool OpenFile(Designer designer, byte[] val)
        {
            bool opensuccess = false;
             formatter = new BinaryFormatter();
            formatter.AssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple;
            ObjectSerializer saveObject;

            //定义一个流
            MemoryStream stream = new MemoryStream(val);

            //定义一个格式化器
            BinaryFormatter bf = new BinaryFormatter();

            saveObject = bf.Deserialize(stream) as ObjectSerializer;  //反序列化


            stream.Close();

            //try
            //{
            designer.Items = saveObject.ItemList;
            designer.Width = saveObject.Width;
            designer.Height = saveObject.Height;
            designer.PrinterConfig = saveObject.PrinterConfig;
            designer.RowHeight = saveObject.RowHeight;
            designer.PageRows = saveObject.RowCount;
            designer.Refresh();
            opensuccess = true;
            //}
            //catch (Exception ex)
            //{
            //    System.Windows.Forms.MessageBox.Show(ex.Message, "出错提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            //}

            formatter = null;
            return opensuccess;
        }
    }
}
