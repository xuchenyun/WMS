using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CIT.Client;
using System.Drawing.Printing;

namespace CIT.MES.Setting.PrintView
{
    public partial class FrmLineOutReel : BaseForm
    {
        //0307
        //DataTable dtprint = new DataTable();
        public FrmLineOutReel(DataTable dt, string line, string product, string wocode)
        {
            InitializeComponent();

            if (dt != null)
            {
                if (dt.Columns.Count < 4)
                    return;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ListViewItem lvitem2 = new ListViewItem();
                    lvitem2.Text = dt.Rows[i][0].ToString();
                    lvitem2.SubItems.Add(dt.Rows[i][1].ToString());
                    lvitem2.SubItems.Add(dt.Rows[i][2].ToString());
                    lvitem2.SubItems.Add(dt.Rows[i][3].ToString());
                    this.LbxListProject.Items.Add(lvitem2);
                }
            }
            else
                return;

            txt_dp.Text = line;
            txt_Product.Text = product;
            txt_wo.Text = wocode;

            int _width = this.LbxListProject.Width / 4;
            LbxListProject.Columns[0].Width = _width;
            LbxListProject.Columns[1].Width = _width;
            LbxListProject.Columns[2].Width = _width;
            LbxListProject.Columns[3].Width = _width;

            string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\Assets\setpoint\lor\SetPoint.xml";
            xmldoc.Load(path);


            txt_br.Text = xmldoc["Setup"]["txt_br"].InnerText;
            txt_qc.Text = xmldoc["Setup"]["txt_qc"].InnerText;
            txt_rec.Text = xmldoc["Setup"]["txt_rec"].InnerText;

            LabCompany.Text = xmldoc["Setup"]["LabCompany"].InnerText;
            LabTitle.Text = xmldoc["Setup"]["LabTitle"].InnerText;

            if (xmldoc["Setup"]["LabPN"].InnerText != "")
                LabPN.Text = xmldoc["Setup"]["LabPN"].InnerText;
            if (xmldoc["Setup"]["LabDesc"].InnerText != "")
                LabDesc.Text = xmldoc["Setup"]["LabDesc"].InnerText;
            if (xmldoc["Setup"]["LabQty"].InnerText != "")
                LabQty.Text = xmldoc["Setup"]["LabQty"].InnerText;
            if (xmldoc["Setup"]["LabUser"].InnerText != "")
                LabUser.Text = xmldoc["Setup"]["LabUser"].InnerText;

            if (xmldoc["Setup"]["Labdp"].InnerText != "")
                Labdp.Text = xmldoc["Setup"]["Labdp"].InnerText;
            if (xmldoc["Setup"]["LabProduct"].InnerText != "")
                LabProduct.Text = xmldoc["Setup"]["LabProduct"].InnerText;
            if (xmldoc["Setup"]["LabWo"].InnerText != "")
                LabWo.Text = xmldoc["Setup"]["LabWo"].InnerText;

            this.printDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDoc_PrintPage);
            //0307
            //dtprint = dt;
        }
        private void printDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                int aa = (int)(printDoc.DefaultPageSettings.PaperSize.Height / 100f * 25.4f);
                int bb = (int)(printDoc.DefaultPageSettings.PaperSize.Width / 100f * 25.4f);

                this.forPrint(this, ref e, ref xmldoc);
            }
            catch (Exception err)
            {
                MessageBox.Show("打印格式未被找到或已经损坏！");
                return;
            }


        }

        bool flag = true;


        int pageidx = 1;
        int curRowidx = 0;
        int pagesize = 40;
        int totalPage = 1;

        int PageHight = 0;
        int PageWidth = 0;
        private void forPrint(System.Windows.Forms.Control crl, ref System.Drawing.Printing.PrintPageEventArgs e, ref System.Xml.XmlDocument xmldoc)
        {
            string font = xmldoc["Setup"]["Font"].InnerText;
            float size = float.Parse(xmldoc["Setup"]["Size"].InnerText);
            for (int i = 0; i < crl.Controls.Count; i++)
            {
                if (crl.Controls[i].Controls.Count > 0)
                {
                    this.forPrint(crl.Controls[i], ref e, ref xmldoc);
                }
                if (crl.Controls[i].Name.Length <= 3 || crl.Controls[i].Name == "TbxID")
                {
                    continue;
                }
                if (crl.Controls[i].Name.Substring(0, 3) == "Cbx" || crl.Controls[i].Name.Substring(0, 4) == "txt_" || crl.Controls[i].Name.Substring(0, 3) == "Lab")
                {
                    try
                    {
                        float x = (float.Parse(xmldoc["Setup"][crl.Controls[i].Name].Attributes["x"].InnerText) + float.Parse(xmldoc["Setup"]["TheX"].InnerText)) * 40;
                        float y = (float.Parse(xmldoc["Setup"][crl.Controls[i].Name].Attributes["y"].InnerText) + float.Parse(xmldoc["Setup"]["TheY"].InnerText)) * 40;
                        bool exists = false;
                        foreach (System.Xml.XmlAttribute item in xmldoc["Setup"][crl.Controls[i].Name].Attributes)
                        {
                            if (item.Name == "fontsize")
                                exists = true;
                        }
                        if (exists)
                            e.Graphics.DrawString(crl.Controls[i].Text, new Font(font, int.Parse(xmldoc["Setup"][crl.Controls[i].Name].Attributes["fontsize"].InnerText)), Brushes.Black, x, y);
                        else
                            e.Graphics.DrawString(crl.Controls[i].Text, new Font(font, size), Brushes.Black, x, y);
                    }
                    catch (Exception err)
                    {
                        string ii = err.ToString();
                    }
                }
                if (crl.Controls[i].Name.Substring(0, 3) == "Lbx")
                {
                    int mm = 0;
                    ListView lvi = crl.Controls[i] as ListView;
                    for (int j = curRowidx; j < lvi.Items.Count; j++)
                    {
                        flag = true;
                        for (int k = 0; k < lvi.Items[j].SubItems.Count; k++)
                        {
                            try
                            {
                                //RectangleF crc = printDoc.PrinterSettings.DefaultPageSettings.PrintableArea;
                                //int aa = (int)(printDoc.DefaultPageSettings.PaperSize.Height / 100f * 25.4f);
                                //int bb = (int)(printDoc.DefaultPageSettings.PaperSize.Width / 100f * 25.4f);

                                //第一条数据
                                float x = (float.Parse(xmldoc["Setup"][crl.Controls[i].Name].Attributes["x"].InnerText) + float.Parse(xmldoc["Setup"]["TheX"].InnerText) + float.Parse(xmldoc["Setup"][crl.Controls[i].Name].Attributes["row" + k.ToString()].InnerText)) * 40;
                                float y = (float.Parse(xmldoc["Setup"][crl.Controls[i].Name].Attributes["y"].InnerText) + float.Parse(xmldoc["Setup"]["TheY"].InnerText) + float.Parse(xmldoc["Setup"][crl.Controls[i].Name].Attributes["cow1"].InnerText) * mm) * 40 - 20;
                                e.Graphics.DrawString(lvi.Items[j].SubItems[k].Text, new Font(font, size), Brushes.Black, x, y);
                            }
                            catch
                            { }
                        }


                        mm++;
                        curRowidx++;
                        if (curRowidx % pagesize == 0 && curRowidx > 1)
                        {
                            float x2 = (float.Parse(xmldoc["Setup"]["txt_line"].Attributes["x"].InnerText) + float.Parse(xmldoc["Setup"]["TheX"].InnerText));
                            float y2 = (float.Parse(xmldoc["Setup"]["txt_line"].Attributes["y"].InnerText) + float.Parse(xmldoc["Setup"]["TheY"].InnerText));

                            e.Graphics.DrawLine(new Pen(Color.Black), 0, y2, e.MarginBounds.Right, y2);
                            string strdatetime = DateTime.Now.ToLongDateString() + DateTime.Now.ToLongTimeString();

                            float x1 = (float.Parse(xmldoc["Setup"]["txt_button"].Attributes["x"].InnerText) + float.Parse(xmldoc["Setup"]["TheX"].InnerText));
                            float y1 = (float.Parse(xmldoc["Setup"]["txt_button"].Attributes["y"].InnerText) + float.Parse(xmldoc["Setup"]["TheY"].InnerText));

                            e.Graphics.DrawString(string.Format("当前{1}页,共计{2}页    打印时间:{0}", strdatetime, pageidx, totalPage), new Font(font, size), Brushes.Black, x1, y1, new StringFormat());


                            pageidx++;


                            e.HasMorePages = true;
                            return;
                            //e.Graphics.DrawLine (defaultPen,m_oTailRect.X,m_oTailRect.Top  +1,m_oTailRect.Right ,m_oTailRect.Top  +1);    
                        }
                        else if (curRowidx == LbxListProject.Items.Count)
                        {
                            float x2 = (float.Parse(xmldoc["Setup"]["txt_line"].Attributes["x"].InnerText) + float.Parse(xmldoc["Setup"]["TheX"].InnerText));
                            float y2 = (float.Parse(xmldoc["Setup"]["txt_line"].Attributes["y"].InnerText) + float.Parse(xmldoc["Setup"]["TheY"].InnerText));

                            e.Graphics.DrawLine(new Pen(Color.Black), 0, y2, e.MarginBounds.Right, y2);
                            string strdatetime = DateTime.Now.ToLongDateString() + DateTime.Now.ToLongTimeString();

                            float x1 = (float.Parse(xmldoc["Setup"]["txt_button"].Attributes["x"].InnerText) + float.Parse(xmldoc["Setup"]["TheX"].InnerText));
                            float y1 = (float.Parse(xmldoc["Setup"]["txt_button"].Attributes["y"].InnerText) + float.Parse(xmldoc["Setup"]["TheY"].InnerText));

                            e.Graphics.DrawString(string.Format("当前{1}页,共计{2}页 {0}", strdatetime, pageidx, totalPage), new Font(font, size), Brushes.Black, x1, y1, new StringFormat());


                            pageidx++;


                            e.HasMorePages = false;

                            curRowidx = 0;
                        }
                    }

                }

            }
        }

        /// <summary>    
        /// 居中显示文本信息    
        /// </summary>    
        private void CenterText(Graphics g, string t, Font f, Brush b, int x, int y)
        {
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            g.DrawString(t, f, b, new Rectangle() { X = x, Y = y }, sf);
        }

        /// <summary>    
        /// 居右显示文本信息    
        /// </summary>    
        private void RightText(Graphics g, string t, Font f, Brush b, RectangleF rect)
        {
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Far;
            sf.LineAlignment = StringAlignment.Center;
            g.DrawString(t, f, b, rect, sf);
        }

        /// <summary>    
        /// 居左显示文本信息    
        /// </summary>    
        private void LeftText(Graphics g, string t, Font f, Brush b, RectangleF rect)
        {
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Near;
            sf.LineAlignment = StringAlignment.Center;
            g.DrawString(t, f, b, rect, sf);
        }
        System.Drawing.Printing.PrintDocument printDoc = new System.Drawing.Printing.PrintDocument();
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1 = new PageSetupDialog();
        System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();

        private void btn_print_Click(object sender, EventArgs e)
        {
            pagesize = int.Parse(xmldoc["Setup"]["PageCnt"].InnerText);
            PageWidth = int.Parse(xmldoc["Setup"]["PageWidth"].InnerText);
            PageHight = int.Parse(xmldoc["Setup"]["PageHeight"].InnerText);
            int MarginsLeft = 0;
            int MarginsTop = 0;
            int MarginsRight = 0;
            int MarginsBottom = 0;
            try
            {
                if (xmldoc["Setup"]["MarginsLeft"].InnerText != "")
                {
                    MarginsLeft = int.Parse(xmldoc["Setup"]["MarginsLeft"].InnerText);
                }
                if (xmldoc["Setup"]["MarginsTop"].InnerText != "")
                {
                    MarginsTop = int.Parse(xmldoc["Setup"]["MarginsTop"].InnerText);
                }
                if (xmldoc["Setup"]["MarginsRight"].InnerText != "")
                {
                    MarginsRight = int.Parse(xmldoc["Setup"]["MarginsRight"].InnerText);
                }
                if (xmldoc["Setup"]["MarginsBottom"].InnerText != "")
                {
                    MarginsBottom = int.Parse(xmldoc["Setup"]["MarginsBottom"].InnerText);
                }
            }
            catch { }

            if (MarginsBottom != 0 && MarginsLeft != 0 && MarginsRight != 0 && MarginsTop != 0)
                this.printDoc.DefaultPageSettings.Margins = new Margins();


            this.printDoc.DefaultPageSettings.PaperSize = new PaperSize("Custom", (int)(PageWidth / 25.4 * 100), (int)(PageHight / 25.4 * 100));

            pageidx = 1;
            if (LbxListProject.Items.Count % pagesize == 0)
                totalPage = LbxListProject.Items.Count / pagesize;
            else
                totalPage = LbxListProject.Items.Count / pagesize + 1;

            //this.printDoc.DefaultPageSettings = this.pageSetupDialog1.PageSettings;
            if (xmldoc["Setup"]["PrintName"].InnerText.Length > 0)
                printDoc.DefaultPageSettings.PrinterSettings.PrinterName = xmldoc["Setup"]["PrintName"].InnerText;
            //this.printDoc.DefaultPageSettings.PrinterSettings.PrinterName = "pdfFactory Pro";

            //this.pageSetupDialog1.Document = this.printDoc;
            try
            {

                //0307
                this.printDoc.Print();
//                ToPrint toprint = new ToPrint();
//                toprint.PrintPriview(dtprint, @"柏瑞安
//                退料单");
            }
            catch
            {

            }
            this.Close();
        }

        private void LbxListProject_SizeChanged(object sender, EventArgs e)
        {
            int _width = this.LbxListProject.Width / 4;
            LbxListProject.Columns[0].Width = _width;
            LbxListProject.Columns[1].Width = _width;
            LbxListProject.Columns[2].Width = _width;
            LbxListProject.Columns[3].Width = _width;
        }
    }
}
