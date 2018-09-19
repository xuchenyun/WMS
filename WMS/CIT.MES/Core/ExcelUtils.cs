using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Data.Common;
using System.Xml;
using CIT.Client;
using CIT.Wcf.Utils;
using System.Text.RegularExpressions;
using CIT.Interface;
using System.Windows.Forms;

namespace CIT.MES.Core
{
    public class ExcelUtils
    {
        public static List<SlotFile> OpenCSV(string filePath, int FristrowIndex = 0)
        {
            XmlNodeList list = XMLHelper.GetXmlNodeListByXpath(@".\SlotFileConfig.xml", "//slot//element");
            //Encoding encoding = Encoding.ASCII(filePath); //Encoding.ASCII;//
            System.Data.DataTable dt = new System.Data.DataTable();
            FileStream fs = new FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);

            StreamReader sr = new StreamReader(fs, Encoding.Default);
            //StreamReader sr = new StreamReader(fs, Encoding.ASCII);
            //string fileContent = sr.ReadToEnd();
            //encoding = sr.CurrentEncoding;
            //记录每次读取的一行记录
            string strLine = "";
            //记录每行记录中的各字段内容
            string[] aryLine = null;
            List<SlotFile> Slot = new List<SlotFile>();
            SlotFile _slot = new SlotFile();
            bool getSlot = false;
            string ereel = "";
            while ((strLine = sr.ReadLine()) != null)
            {
                //先进行替换，然后在解析
                foreach (XmlNode item in list)
                {
                    if (item.Attributes.Count > 0)
                    {
                        strLine = strLine.Replace(item.Attributes[0].Value.ToString(), item.InnerText);
                    }
                }
                //strLine = Common.ConvertStringUTF8(strLine, encoding);
                //strLine = Common.ConvertStringUTF8(strLine);
                try
                {
                    strLine = strLine.Replace("\"", "");
                    if (strLine.Replace(" ", "").ToLower().Contains("mcfile:"))
                    {
                        _slot = new SlotFile();
                        dt = new DataTable();



                        dt.Columns.Add("table", Type.GetType("System.String"));
                        dt.Columns.Add("address", Type.GetType("System.String"));
                        dt.Columns.Add("partsname", Type.GetType("System.String"));
                        dt.Columns.Add("chipname", Type.GetType("System.String"));
                        dt.Columns.Add("partcomment", Type.GetType("System.String"));
                        dt.Columns.Add("lr", Type.GetType("System.String"));
                        dt.Columns.Add("feedername", Type.GetType("System.String"));
                        dt.Columns.Add("package", Type.GetType("System.String"));
                        dt.Columns.Add("numberofuse", Type.GetType("System.String"));
                        //dt.Columns.Add("mountcomment", Type.GetType("System.String"));
                        if (strLine.Contains("="))
                        {

                            string[] temp = strLine.Replace(" ", "").ToUpper().Replace("MCFILE:", "").Split('=');
                            if (temp.Length != 2)
                            {
                                throw new Exception("料站表格式异常,请联系工程部.");
                            }
                            _slot.Product = temp[0].Replace(",", "");
                            _slot.BoradSide = temp[1].Replace(",", "").Split('-')[0];
                            _slot.Line = "SMT-" + temp[1].Replace(",", "").Split('-')[1];
                        }
                        else
                        {

                            #region 新增从配置文件读取料站表分割字符 2017.06.14 by simon.li
                            char sp = '-';
                            DataTable dtPrint = NMS.QueryDataTable(CIT.MES.PubUtils.uContext, "select val1 from SysDatConfig where key1='MSlotCut';");

                            if (dtPrint.Rows.Count > 0)
                            {
                                try
                                {
                                    sp = dtPrint.Rows[0][0].ToString()[0];
                                }
                                catch
                                {
                                    sp = '-';
                                }
                            }

                            string[] temp = strLine.Replace(" ", "").ToUpper().Replace("MCFILE:", "").Split(sp);
                            if (temp.Length != 3)
                            {
                                throw new Exception("料站表格式异常,请联系工程部.");
                            }
                            _slot.Product = temp[0].Replace(",", "");
                            _slot.BoradSide = temp[1].Replace(",", "");
                            _slot.Line = "SMT-" + temp[2].Replace(",", "");

                            #endregion

                        }
                    }
                    if (strLine.Replace(" ", "").ToLower().Contains("mc:"))
                    {
                        _slot.MachineID = strLine.Replace(" ", "").ToUpper().Replace("MC:", "").Replace(",", "");
                    }
                    if (strLine.ToLower().Replace(" ", "").Contains("traylayoutdata"))
                    {
                        getSlot = false;
                        _slot.SlotDT = dt;
                        Slot.Add(_slot);
                    }
                    if (getSlot)
                    {
                        aryLine = strLine.Split(',');
                        if (aryLine.Length >= 8)
                        {
                            DataRow dr = dt.NewRow();
                            for (int i = 0; i < 9; i++)
                            {
                                if (i == 1)
                                {
                                    if (aryLine[i].Replace(" ", "").Length == 0)
                                    {
                                        aryLine[i] = ereel;
                                    }
                                    else
                                    {
                                        ereel = aryLine[i].ToUpper().Replace("TRAY", "");
                                    }

                                }
                                dr[i] = aryLine[i];
                            }
                            dt.Rows.Add(dr);
                        }
                    }
                    string[] lz = strLine.ToLower().Replace(" ", "").Split(',');
                    if (lz.Length >= 3)
                    {
                        if (lz[0] == "table" && lz[1] == "address" && lz[2] == "partsname")
                        {
                            getSlot = true;
                        }
                    }

                }
                catch (Exception ee) { MsgBox.Error(ee.Message); }
            }
            //if (aryLine != null && aryLine.Length > 0)
            //{
            //    dt.DefaultView.Sort = tableHead[0] + " " + "asc";
            //}

            sr.Close();
            fs.Close();
            return Slot;
        }

        public static List<SlotFile> OpenCMCSV(string filePath, int FristrowIndex = 0)
        {
            XmlNodeList list = XMLHelper.GetXmlNodeListByXpath(@".\SlotFileConfig.xml", "//slot//element");
            //Encoding encoding = Encoding.ASCII(filePath); //Encoding.ASCII;//
            System.Data.DataTable dt = new System.Data.DataTable();
            FileStream fs = new FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);

            StreamReader sr = new StreamReader(fs, Encoding.Default);
            //StreamReader sr = new StreamReader(fs, Encoding.ASCII);
            //string fileContent = sr.ReadToEnd();
            //encoding = sr.CurrentEncoding;
            //记录每次读取的一行记录
            string strLine = "";
            //记录每行记录中的各字段内容
            string[] aryLine = null;
            List<SlotFile> Slot = new List<SlotFile>();
            SlotFile _slot = new SlotFile();
            bool getSlot = false;
            string ereel = "";
            while ((strLine = sr.ReadLine()) != null)
            {
                //先进行替换，然后在解析
                foreach (XmlNode item in list)
                {
                    if (item.Attributes.Count > 0)
                    {
                        strLine = strLine.Replace(item.Attributes[0].Value.ToString(), item.InnerText);
                    }
                }
                //strLine = Common.ConvertStringUTF8(strLine, encoding);
                //strLine = Common.ConvertStringUTF8(strLine);
                try
                {
                    strLine = strLine.Replace("\"", "");
                    if (strLine.Replace(" ", "").ToLower().Contains("mcfile:"))
                    {
                        _slot = new SlotFile();
                        dt = new DataTable();

                        dt.Columns.Add("machinename", Type.GetType("System.String"));
                        dt.Columns.Add("table", Type.GetType("System.String"));
                        dt.Columns.Add("address", Type.GetType("System.String"));
                        dt.Columns.Add("lr", Type.GetType("System.String"));
                        dt.Columns.Add("partsname", Type.GetType("System.String"));
                        dt.Columns.Add("feedername", Type.GetType("System.String"));
                        dt.Columns.Add("numberofuse", Type.GetType("System.String"));

                        //dt.Columns.Add("table", Type.GetType("System.String"));
                        //dt.Columns.Add("address", Type.GetType("System.String"));
                        //dt.Columns.Add("partsname", Type.GetType("System.String"));
                        //dt.Columns.Add("chipname", Type.GetType("System.String"));
                        //dt.Columns.Add("partcomment", Type.GetType("System.String"));
                        //dt.Columns.Add("lr", Type.GetType("System.String"));
                        //dt.Columns.Add("feedername", Type.GetType("System.String"));
                        //dt.Columns.Add("package", Type.GetType("System.String"));
                        //dt.Columns.Add("numberofuse", Type.GetType("System.String"));
                        //dt.Columns.Add("mountcomment", Type.GetType("System.String"));
                        if (strLine.Contains("="))
                        {

                            string[] temp = strLine.Replace(" ", "").ToUpper().Replace("MCFILE:", "").Split('=');
                            if (temp.Length != 2)
                            {
                                throw new Exception("料站表格式异常,请联系工程部.");
                            }
                            _slot.Product = temp[0].Replace(",", "");
                            _slot.BoradSide = temp[1].Replace(",", "").Split('-')[0];
                            _slot.Line = "SMT-" + temp[1].Replace(",", "").Split('-')[1];
                        }
                        else
                        {

                            #region 新增从配置文件读取料站表分割字符 2017.06.14 by simon.li
                            char sp = '-';
                            DataTable dtPrint = NMS.QueryDataTable(CIT.MES.PubUtils.uContext, "select val1 from SysDatConfig where key1='MSlotCut';");

                            if (dtPrint.Rows.Count > 0)
                            {
                                try
                                {
                                    sp = dtPrint.Rows[0][0].ToString()[0];
                                }
                                catch
                                {
                                    sp = '-';
                                }
                            }

                            string[] temp = strLine.Replace(" ", "").ToUpper().Replace("MCFILE:", "").Split(sp);
                            if (temp.Length != 3)
                            {
                                throw new Exception("料站表格式异常,请联系工程部.");
                            }
                            _slot.Product = temp[0].Replace(",", "");
                            _slot.BoradSide = temp[1].Replace(",", "");
                            _slot.Line = "SMT-" + temp[2].Replace(",", "");

                            #endregion

                        }
                    }
                    if (strLine.Replace(" ", "").ToLower().Contains("mc:"))
                    {
                        _slot.MachineID = strLine.Replace(" ", "").ToUpper().Replace("MC:", "").Replace(",", "");
                    }
                    if (strLine.ToLower().Replace(" ", "").Contains("traylayoutdata"))
                    {
                        getSlot = false;
                        _slot.SlotDT = dt;
                        Slot.Add(_slot);
                    }
                    if (getSlot)
                    {
                        aryLine = strLine.Split(',');
                        if (aryLine.Length >= 8)
                        {
                            DataRow dr = dt.NewRow();
                            for (int i = 0; i < 9; i++)
                            {
                                if (i == 1)
                                {
                                    if (aryLine[i].Replace(" ", "").Length == 0)
                                    {
                                        aryLine[i] = ereel;
                                    }
                                    else
                                    {
                                        ereel = aryLine[i].ToUpper().Replace("TRAY", "");
                                    }

                                }
                                dr[i] = aryLine[i];
                            }
                            dt.Rows.Add(dr);
                        }
                    }
                    string[] lz = strLine.ToLower().Replace(" ", "").Split(',');
                    if (lz.Length >= 3)
                    {
                        if (lz[0] == "table" && lz[1] == "address" && lz[2] == "partsname")
                        {
                            getSlot = true;
                        }
                    }

                }
                catch (Exception ee) { MsgBox.Error(ee.Message); }
            }
            //if (aryLine != null && aryLine.Length > 0)
            //{
            //    dt.DefaultView.Sort = tableHead[0] + " " + "asc";
            //}

            sr.Close();
            fs.Close();
            return Slot;
        }

        public static List<SlotFile> OpenTxtSX(string filePath, int FristrowIndex = 0)
        {
            List<SlotFile> Slot = new List<SlotFile>();
            char sp = '-';
            DataTable dtPrint = NMS.QueryDataTable(CIT.MES.PubUtils.uContext, "select val1 from SysDatConfig where key1='MSlotCut';");

            if (dtPrint.Rows.Count > 0)
            {
                try
                {
                    sp = dtPrint.Rows[0][0].ToString()[0];
                }
                catch
                {
                    sp = '-';
                }
            }


            try
            {
                SlotFile slot = new SlotFile();
                string filename = System.IO.Path
                .GetFileNameWithoutExtension(filePath);

                StreamReader sr = new StreamReader(filePath);
                //string data = sr.ReadToEnd();

                string ProductInfo = filename;
                slot.Product = ProductInfo.Split(sp)[0];
                slot.BoradSide = ProductInfo.Split(sp)[1];
                slot.Line = "SMT-" + ProductInfo.Split(sp)[2];
                //slot.MachineID = GetValue(data, "MNAME=", "\r").Replace(" ", "");

                DataTable dt = new DataTable();
                dt.Columns.Add("machinename", Type.GetType("System.String"));
                dt.Columns.Add("table", Type.GetType("System.String"));
                dt.Columns.Add("address", Type.GetType("System.String"));
                dt.Columns.Add("lr", Type.GetType("System.String"));
                dt.Columns.Add("partsname", Type.GetType("System.String"));
                dt.Columns.Add("feedername", Type.GetType("System.String"));
                dt.Columns.Add("numberofuse", Type.GetType("System.String"));
                string strLine = "";
                while ((strLine = sr.ReadLine()) != null)
                {
                    string[] strs = strLine.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    if (strs.Length == 8 && strs.Contains("PART.NAME"))
                    {

                    }
                    else
                        if (strs.Length == 8)
                    {
                        if (strs[2].Length > 0 && strs[6].Length > 0)
                        {
                            dt.Rows.Add(new object[] { "", "", strs[0], strs[0].Contains('F') ? "L" : "R", strs[2], strs[1], (int.Parse(strs[6]) / 2).ToString() });
                        }
                    }
                }
                slot.SlotDT = dt;

                Slot.Add(slot);
            }
            catch
            {

            }
            return Slot;
        }

        public static List<SlotFile> OpenPOSBM(string filePath, int FristrowIndex = 0)
        {
            List<SlotFile> Slot = new List<SlotFile>();
            char sp = '-';
            DataTable dtPrint = NMS.QueryDataTable(CIT.MES.PubUtils.uContext, "select val1 from SysDatConfig where key1='MSlotCut';");

            if (dtPrint.Rows.Count > 0)
            {
                try
                {
                    sp = dtPrint.Rows[0][0].ToString()[0];
                }
                catch
                {
                    sp = '-';
                }
            }


            try
            {
                SlotFile slot = new SlotFile();

                StreamReader sr = new StreamReader(filePath);
                string data = sr.ReadToEnd();

                string ProductInfo = GetValue(data, "NAME=", "\r").Replace(" ", "");
                slot.Product = ProductInfo.Split(sp)[0];
                slot.BoradSide = ProductInfo.Split(sp)[1];
                slot.Line = "SMT-" + ProductInfo.Split(sp)[2];
                slot.MachineID = GetValue(data, "MNAME=", "\r").Replace(" ", "");

                DataTable dt = new DataTable();
                dt.Columns.Add("machinename", Type.GetType("System.String"));
                dt.Columns.Add("table", Type.GetType("System.String"));
                dt.Columns.Add("address", Type.GetType("System.String"));
                dt.Columns.Add("lr", Type.GetType("System.String"));
                dt.Columns.Add("partsname", Type.GetType("System.String"));
                dt.Columns.Add("feedername", Type.GetType("System.String"));
                dt.Columns.Add("numberofuse", Type.GetType("System.String"));

                string[] pns = GetValue(data, "%SETUP", "%IPCDATA").Replace("\n", "").Split(new char[] { '\r' }, StringSplitOptions.RemoveEmptyEntries);

                string[] psds = GetValue(data, "%NCDATA", "%SETUP").Replace("\n", "").Split(new char[] { '\r' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in pns)
                {
                    string machinename = slot.MachineID;
                    string table = "1";
                    string address = "Z" + GetValue(item, "Z", "PC");
                    string lr = "L";
                    string partsname = GetValue(item, "PN", "ST0VO").Replace("(", "").Replace(")", "").Replace(" ", "");
                    string feedername = GetValue(item, "PC", "PN").Replace("(", "").Replace(")", "").Replace(" ", "");
                    string numberofuse = psds.Where(s => s.Contains(address)).Count().ToString();
                    dt.Rows.Add(new object[] { machinename, table, address, lr, partsname, feedername, numberofuse });
                }
                slot.SlotDT = dt;

                Slot.Add(slot);
            }
            catch
            {

            }
            return Slot;
        }

        /// <summary>
        /// 获得字符串中开始和结束字符串中间得值
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="s">开始</param>
        /// <param name="e">结束</param>
        /// <returns></returns> 
        public static string GetValue(string str, string s, string e)
        {
            Regex rg = new Regex("(?<=(" + s + "))[.\\s\\S]*?(?=(" + e + "))", RegexOptions.Multiline | RegexOptions.Singleline);
            return rg.Match(str).Value;
        }


        //NPM料站表导入
        public static List<SlotFile> OpenCSVNPM(string filePath, int FristrowIndex = 0)
        {
            XmlNodeList list = XMLHelper.GetXmlNodeListByXpath(@".\SlotFileConfig.xml", "//slot//element");
            //Encoding encoding = Encoding.ASCII(filePath); //Encoding.ASCII;//
            System.Data.DataTable dt = new System.Data.DataTable();
            FileStream fs = new FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            StreamReader sr = new StreamReader(fs, Encoding.Default);
            //StreamReader sr = new StreamReader(fs, Encoding.ASCII);
            //string fileContent = sr.ReadToEnd();
            //encoding = sr.CurrentEncoding;
            //记录每次读取的一行记录
            string strLine = "";
            //记录每行记录中的各字段内容
            string[] aryLine = null;
            List<SlotFile> Slot = new List<SlotFile>();
            SlotFile _slot = new SlotFile();
            bool getSlot = false;
            string ereel = "";
            while ((strLine = sr.ReadLine()) != null)
            {
                //先进行替换，然后在解析
                foreach (XmlNode item in list)
                {
                    if (item.Attributes.Count > 0)
                    {
                        //2018.1.22 Zach  bug修复  未设置对象引用   
                        if (item.Attributes[0].Value != null || item.InnerText != null)
                            strLine = strLine.Replace(item.Attributes[0].Value.ToString(), item.InnerText);
                    }
                }
                //strLine = Common.ConvertStringUTF8(strLine, encoding);
                //strLine = Common.ConvertStringUTF8(strLine);
                try
                {
                    strLine = strLine.Replace("\"", "");
                    if (strLine.Replace(" ", "").ToLower().Contains("mcfile:"))
                    {
                        _slot = new SlotFile();
                        dt = new DataTable();
                        dt.Columns.Add("machinename", Type.GetType("System.String"));
                        dt.Columns.Add("table", Type.GetType("System.String"));
                        dt.Columns.Add("address", Type.GetType("System.String"));
                        dt.Columns.Add("lr", Type.GetType("System.String"));
                        dt.Columns.Add("partsname", Type.GetType("System.String"));
                        dt.Columns.Add("feedername", Type.GetType("System.String"));
                        dt.Columns.Add("numberofuse", Type.GetType("System.String"));
                        dt.Columns.Add("ReplaceMaterial", Type.GetType("System.String"));
                        //dt.Columns.Add("mountcomment", Type.GetType("System.String"));
                        if (strLine.Contains("="))
                        {

                            string[] temp = strLine.Replace(" ", "").ToUpper().Replace("MCFILE:", "").Split('=');
                            if (temp.Length != 2)
                            {
                                throw new Exception("料站表格式异常,请联系工程部.");
                            }
                            _slot.Product = temp[0].Replace(",", "");
                            _slot.BoradSide = temp[1].Replace(",", "").Split('-')[0];
                            _slot.Line = "SMT-" + temp[1].Replace(",", "").Split('-')[1];
                        }
                        else
                        {

                            #region 新增从配置文件读取料站表分割字符 2017.06.14 by simon.li
                            char sp = '-';
                            DataTable dtPrint = NMS.QueryDataTable(CIT.MES.PubUtils.uContext, "select val1 from SysDatConfig where key1='MSlotCut';");

                            if (dtPrint.Rows.Count > 0)
                            {
                                try
                                {
                                    sp = dtPrint.Rows[0][0].ToString()[0];
                                }
                                catch
                                {
                                    sp = '-';
                                }
                            }

                            string[] temp = strLine.Replace(" ", "").ToUpper().Replace("MCFILE:", "").Split(sp);
                            if (temp.Length != 3)
                            {
                                throw new Exception("料站表格式异常,请联系工程部.");
                            }
                            _slot.Product = temp[0].Replace(",", "");
                            _slot.BoradSide = temp[1].Replace(",", "");
                            _slot.Line = "SMT-" + temp[2].Replace(",", "");

                            #endregion
                        }
                    }
                    //新增版本
                    if (strLine.Replace(",", "").Contains("版本"))
                    {
                        _slot.VarVer = strLine.Replace(",", "").Replace("版本", "").Replace(" ", "");
                    }
                    if (getSlot && strLine.ToLower().Replace(" ", "").Length == 0)
                    {
                        getSlot = false;
                        _slot.SlotDT = dt;
                        Slot.Add(_slot);
                    }
                    if (getSlot)
                    {
                        string[] aryRefNos = strLine.Replace("，", ",").Split(',');
                        string strRefNo = GetRefNo(aryRefNos);//获取是否
                        //if (!string.IsNullOrEmpty(strRefNo))
                        //    aryLine = strLine.Replace(string.Format("{0}", GetRefNo(aryRefNos)), "").Split(',');

                        //料站表 主料中含有点位信息  主料自动去除点位BUG修复  2018.09.03 Zach
                        if (!string.IsNullOrEmpty(strRefNo))
                        {
                            try
                            {
                                if (!strLine.Split(',')[5].Contains(strRefNo))
                                    aryLine = strLine.Replace(string.Format("{0}", GetRefNo(aryRefNos)), "").Split(',');
                                else
                                {
                                    var list_remove = strLine.Split(',').ToList().FindAll(x => x.Length < 5 && x.Contains(strRefNo));
                                    aryLine = strLine.Split(',');
                                    foreach (var str in list_remove)
                                    {
                                        aryLine[aryLine.ToList().IndexOf(str)] = string.Empty;
                                    }
                                }
                            }
                            catch
                            {
                                aryLine = strLine.Replace(string.Format("{0}", GetRefNo(aryRefNos)), "").Split(',');
                            }
                        }
                        else
                            aryLine = strLine.Replace("，", ",").Split(',');
                        if (aryLine.Length >= 7)
                        {
                            if (aryLine[5].Length != 0)
                            {
                                DataRow dr = dt.NewRow();
                                for (int i = 0; i < 9; i++)
                                {
                                    if (i > 0)
                                    {
                                        if (i < 8)
                                            dr[i - 1] = aryLine[i];
                                        else
                                            dr[i - 1] =/* aryLine[i + 4];*/GetReplaceMaterial(aryLine);
                                    }
                                }
                                dt.Rows.Add(dr);
                            }
                        }
                    }
                    string[] lz = strLine.ToLower().Replace(" ", "").Split(',');
                    if (lz.Length >= 3)
                    {
                        if (lz[0] == "MachineID".ToLower() && lz[1] == "MC".ToLower() && lz[2] == "table".ToLower())
                        {
                            getSlot = true;
                        }
                    }
                }
                catch (Exception ex) { }
            }
            if (Slot.Count < 1 && dt.Rows.Count > 0)
            {
                _slot.SlotDT = dt;
                Slot.Add(_slot);
            }
            //if (aryLine != null && aryLine.Length > 0)
            //{
            //    dt.DefaultView.Sort = tableHead[0] + " " + "asc";
            //}

            sr.Close();
            fs.Close();
            return Slot;
        }

        private static string GetRefNo(string[] aryLine)
        {
            StringBuilder strRefNo = new StringBuilder();
            for (int i = 0; i < aryLine.Length; i++)
            {
                if (i >= 8 && aryLine[i].Length <= 5 && aryLine[i].Length != 0)
                {
                    if (strRefNo.Length == 0)
                    {
                        strRefNo.Append(aryLine[i]);
                    }
                    else
                    {
                        strRefNo.Append("," + aryLine[i]);
                    }
                }
            }
            if (strRefNo.Length > 0)
                return strRefNo.ToString();
            else
                return string.Empty;
        }

        /// <summary>
        /// 获得替代料
        /// </summary>
        /// <param name="strArray"></param>
        /// <returns></returns>
        private static string GetReplaceMaterial(string[] strArray)
        {
            StringBuilder replaceMaterial = new StringBuilder();
            for (int i = 0; i < strArray.Length; i++)
            {
                if (i >= 11)
                {
                    if (replaceMaterial.Length == 0)
                        replaceMaterial.Append(strArray[i]);
                    else
                        replaceMaterial.Append("," + strArray[i]);
                }
            }
            if (replaceMaterial.Length > 0)
                return replaceMaterial.ToString();
            else
                return string.Empty;
        }

        public static string GetLotCSV(string filePath, int StartrowIndex = 0)
        {

            string Lot = "";
            FileStream fs = new FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);

            //StreamReader sr = new StreamReader(fs, Encoding.UTF8);
            StreamReader sr = new StreamReader(fs, Encoding.ASCII);
            //string fileContent = sr.ReadToEnd();
            //encoding = sr.CurrentEncoding;
            //记录每次读取的一行记录
            string strLine = "";
            //记录每行记录中的各字段内容
            //标示列数
            //标示是否是读取的第一行
            int rowIndex = 0;
            //逐行读取CSV中的数据
            while ((strLine = sr.ReadLine()) != null)
            {
                if (rowIndex >= StartrowIndex)
                {
                    if (strLine.ToUpper().Contains("LOT"))
                    {
                        Lot = strLine;
                        break;
                    }
                }
            }

            sr.Close();
            fs.Close();
            return Lot;
        }

        //德尔NPM料表导入
        public static List<SlotFile> OpenCSVNPMFZB(string filePath)
        {
            DataTable dt = OpenCSV(filePath);
            SlotFile _slot = null;
            List<SlotFile> Slot = new List<SlotFile>();

            foreach (DataRow item in dt.Rows)
            {
                if (item[0].ToString().ToUpper().Replace(" ", "").Contains("MCFILE:"))
                {
                    if (_slot != null)
                    {
                        Slot.Add(_slot);
                    }



                    char sp = '-';
                    DataTable dtPrint = NMS.QueryDataTable(CIT.MES.PubUtils.uContext, "select val1 from SysDatConfig where key1='MSlotCut';");

                    if (dtPrint.Rows.Count > 0)
                    {
                        try
                        {
                            sp = dtPrint.Rows[0][0].ToString()[0];
                        }
                        catch
                        {
                            sp = '-';
                        }
                    }

                    _slot = new SlotFile();
                    _slot.SlotDT = new DataTable();
                    _slot.SlotDT.Columns.Add("machinename", Type.GetType("System.String"));
                    _slot.SlotDT.Columns.Add("table", Type.GetType("System.String"));
                    _slot.SlotDT.Columns.Add("address", Type.GetType("System.String"));
                    _slot.SlotDT.Columns.Add("lr", Type.GetType("System.String"));
                    _slot.SlotDT.Columns.Add("partsname", Type.GetType("System.String"));
                    _slot.SlotDT.Columns.Add("feedername", Type.GetType("System.String"));
                    _slot.SlotDT.Columns.Add("numberofuse", Type.GetType("System.String"));
                    string[] temp = item[0].ToString().Replace(" ", "").ToUpper().Replace("MCFILE:", "").Split(sp);
                    if (temp.Length != 3)
                    {
                        throw new Exception("料站表格式异常,请联系工程部.");
                    }
                    _slot.Product = temp[0].Replace(",", "");
                    _slot.BoradSide = temp[1].Replace(",", "");
                    _slot.Line = "SMT-" + temp[2].Replace(",", "");
                }
                else if (_slot != null && item[5].ToString().Replace(" ", "").Length > 0 && !item[5].ToString().Contains("Parts Name"))
                {
                    object[] itemArray = item.ItemArray.Skip(1).Take(7).ToArray();
                    if (item.ItemArray[9].ToString().Replace(" ", "").Length > 0)
                    {
                        string rpn = itemArray[4].ToString();
                        string pn = item.ItemArray[9].ToString();
                        itemArray[4] = item.ItemArray[9].ToString();

                        CmdParameter[] parms = {
                            new CmdParameter(){ParameterName="@Product",Value=_slot.Product},
                            new CmdParameter(){ParameterName="@PN",Value=pn},
                            new CmdParameter(){ParameterName="@ReplaceModel",Value=0},
                            new CmdParameter(){ParameterName="@ReplaceType",Value= 1},
                            new CmdParameter(){ParameterName="@RStartTime",Value= ""},
                            new CmdParameter(){ParameterName="@REndTime",Value= ""},
                            new CmdParameter(){ParameterName="@Creator",Value=PubUtils.uContext.UserID},
                                 };
                        bool flag = Wcf.Utils.NMS.ExecProcedures(PubUtils.uContext, "SfcDatReplacePN_insert", CommandType.StoredProcedure, true, parms);

                        string guid = Wcf.Utils.NMS.QueryDataTable(PubUtils.uContext, "select Fguid from SfcDatReplacePN where Product =@Product and PN=@PN and ReplaceModel=@ReplaceModel and ReplaceType=@ReplaceType", parms).Rows[0][0].ToString();


                        parms = new CmdParameter[] {
                            new CmdParameter(){ParameterName="@fguid",Value=guid},
                            new CmdParameter(){ParameterName="@MainPN",Value=pn},
                            new CmdParameter(){ParameterName="@RPN",Value=rpn},
                            new CmdParameter(){ParameterName="@Rindex",Value= 1},
                            new CmdParameter(){ParameterName="@Creator",Value=PubUtils.uContext.UserID},
                                 };

                        flag = Wcf.Utils.NMS.ExecProcedures(PubUtils.uContext, "SfcDatReplacePNDetail_insert", CommandType.StoredProcedure, true, parms);

                    }
                    _slot.SlotDT.Rows.Add(_slot.SlotDT.NewRow().ItemArray = itemArray);
                }
            }

            Slot.Add(_slot);
            return Slot;
        }


        public static DataTable OpenCSV(string filePath)//从csv读取数据返回table
        {
            System.Text.Encoding encoding = GetType(filePath); //Encoding.ASCII;//
            DataTable dt = new DataTable();
            System.IO.FileStream fs = new System.IO.FileStream(filePath, System.IO.FileMode.Open,
                System.IO.FileAccess.Read);

            System.IO.StreamReader sr = new System.IO.StreamReader(fs, encoding);

            //记录每次读取的一行记录
            string strLine = "";
            //记录每行记录中的各字段内容
            string[] aryLine = null;

            //逐行读取CSV中的数据
            while ((strLine = sr.ReadLine()) != null)
            {
                XmlNodeList list = XMLHelper.GetXmlNodeListByXpath(@".\SlotFileConfig.xml", "//slot//element");

                foreach (XmlNode item in list)
                {
                    if (item.Attributes.Count > 0)
                    {
                        strLine = strLine.Replace(item.Attributes[0].Value.ToString(), item.InnerText);
                    }
                }

                aryLine = strToAry(strLine);
                while (dt.Columns.Count < aryLine.Length)
                {
                    dt.Columns.Add(new DataColumn("Column" + dt.Columns.Count));
                }
                dt.Rows.Add(dt.NewRow().ItemArray = aryLine);
            }
            sr.Close();
            fs.Close();
            return dt;
        }
        /// 给定文件的路径，读取文件的二进制数据，判断文件的编码类型
        /// <param name="FILE_NAME">文件路径</param>
        /// <returns>文件的编码类型</returns>

        public static System.Text.Encoding GetType(string FILE_NAME)
        {
            System.IO.FileStream fs = new System.IO.FileStream(FILE_NAME, System.IO.FileMode.Open,
                System.IO.FileAccess.Read);
            System.Text.Encoding r = GetType(fs);
            fs.Close();
            return r;
        }

        /// 通过给定的文件流，判断文件的编码类型
        /// <param name="fs">文件流</param>
        /// <returns>文件的编码类型</returns>
        public static System.Text.Encoding GetType(System.IO.FileStream fs)
        {
            byte[] Unicode = new byte[] { 0xFF, 0xFE, 0x41 };
            byte[] UnicodeBIG = new byte[] { 0xFE, 0xFF, 0x00 };
            byte[] UTF8 = new byte[] { 0xEF, 0xBB, 0xBF }; //带BOM
            System.Text.Encoding reVal = System.Text.Encoding.Default;

            System.IO.BinaryReader r = new System.IO.BinaryReader(fs, System.Text.Encoding.Default);
            int i;
            int.TryParse(fs.Length.ToString(), out i);
            byte[] ss = r.ReadBytes(i);
            if (IsUTF8Bytes(ss) || (ss[0] == 0xEF && ss[1] == 0xBB && ss[2] == 0xBF))
            {
                reVal = System.Text.Encoding.UTF8;
            }
            else if (ss[0] == 0xFE && ss[1] == 0xFF && ss[2] == 0x00)
            {
                reVal = System.Text.Encoding.BigEndianUnicode;
            }
            else if (ss[0] == 0xFF && ss[1] == 0xFE && ss[2] == 0x41)
            {
                reVal = System.Text.Encoding.Unicode;
            }
            r.Close();
            return reVal;
        }

        /// 判断是否是不带 BOM 的 UTF8 格式
        /// <param name="data"></param>
        /// <returns></returns>
        private static bool IsUTF8Bytes(byte[] data)
        {
            int charByteCounter = 1;　 //计算当前正分析的字符应还有的字节数
            byte curByte; //当前分析的字节.
            for (int i = 0; i < data.Length; i++)
            {
                curByte = data[i];
                if (charByteCounter == 1)
                {
                    if (curByte >= 0x80)
                    {
                        //判断当前
                        while (((curByte <<= 1) & 0x80) != 0)
                        {
                            charByteCounter++;
                        }
                        //标记位首位若为非0 则至少以2个1开始 如:110XXXXX...........1111110X　
                        if (charByteCounter == 1 || charByteCounter > 6)
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    //若是UTF-8 此时第一位必须为1
                    if ((curByte & 0xC0) != 0x80)
                    {
                        return false;
                    }
                    charByteCounter--;
                }
            }
            if (charByteCounter > 1)
            {
                throw new Exception("非预期的byte格式");
            }
            return true;
        }
        private static string[] strToAry(string strLine)
        {
            string rep = "@" + Guid.NewGuid().ToString() + "@";

            strLine = strLine.Replace("\"\"", rep);   //替换所有文本引号

            string strItem = "";
            int iFenHao = 0;
            System.Collections.ArrayList lstStr = new System.Collections.ArrayList();
            for (int i = 0; i < strLine.Length; i++)
            {
                string strA = strLine.Substring(i, 1);
                if (strA == "\"")
                {
                    iFenHao = iFenHao + 1;
                }
                if (iFenHao == 2)
                {
                    iFenHao = 0;
                }
                if (strA == "," && iFenHao == 0)
                {
                    lstStr.Add(strItem.Replace("\"", "").Replace(rep, "\""));
                    strItem = "";
                }
                else
                {
                    strItem = strItem + strA;
                }
            }
            if (strItem.Length > 0)
                lstStr.Add(strItem);
            return (String[])lstStr.ToArray(typeof(string));
        }



    }
    public class SlotFile
    {
        public DataTable SlotDT { get; set; }
        public string Product { get; set; }
        public string BoradSide { get; set; }
        public string Line { get; set; }
        public string MachineID { get; set; }
        /// <summary>
        /// 版本   2018-06-17 11:39:31 Zach新增
        /// </summary>
        public string VarVer { get; set; }
    }
}
