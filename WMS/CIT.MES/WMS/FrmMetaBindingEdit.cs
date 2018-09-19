using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CIT.Client;
using CIT.Wcf.Utils;
using CIT.MES.Common.Helper;

namespace CIT.WMS.BRIO
{
    public partial class FrmMetaBindingEdit : BaseForm
    {
        public FrmMetaBindingEdit()
        {
            InitializeComponent();
            int SH = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;
            int SW = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;
            this.Location = new Point(SW, SH);

            foreach (DataRow row in NMS.QueryDataTable(CIT.MES.PubUtils.uContext, "select ShelfType from sysDatshelftype").Rows)
            {
                cboShelfType.Items.Add(row[0]);
            }

            DataTable dt = NMS.QueryDataTable(CIT.MES.PubUtils.uContext, "select * from sysDatMPNcustomer");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cbx_customerID.Items.Add(dt.Rows[i][0].ToString());
            }
            FrmType = false;
            txt_MaterialType.SelectedIndex = 0;
        }
        /// <summary>
        /// 编辑 Or 新增
        /// </summary>
        bool FrmType = false;

        public FrmMetaBindingEdit(string newpn)
        {
            InitializeComponent();
            int SH = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;
            int SW = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;
            this.Location = new Point(SW, SH);

            DataTable dt = NMS.QueryDataTable(CIT.MES.PubUtils.uContext, "select * from sysDatMPNcustomer");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cbx_customerID.Items.Add(dt.Rows[i][0].ToString());
            }
            txt_old.Enabled = false;
            txt_new.Enabled = false;
            txt_new.Text = newpn;
            cbx_customerID.Enabled = false;
            dt = NMS.QueryDataTable(CIT.MES.PubUtils.uContext, "select * from mdcdatmpn where newpn='" + newpn + "'");
            if (dt.Rows.Count > 0)
            {
                cbx_customerID.Text = dt.Rows[0]["CustomerType"].ToString();
                txt_old.Text = dt.Rows[0]["oldpn"].ToString();
                txt_Qty.Text = dt.Rows[0]["MaterialMinCount"].ToString();
                txt_SupplierName.Text = dt.Rows[0]["SupplierName"].ToString();
                txt_ManufacturerLocation.Text = dt.Rows[0]["ManufacturerLocation"].ToString();
                txt_MaterialType.Text = dt.Rows[0]["MaterialType"].ToString();
                txt_Purchase.Text = dt.Rows[0]["Purchase"].ToString();
                txt_partcode1.Text = dt.Rows[0]["partcode1"].ToString();
                txt_PartCode2.Text = dt.Rows[0]["partcode2"].ToString();
                txt_PartCode3.Text = dt.Rows[0]["partcode3"].ToString();
                txt_PartCode4.Text = dt.Rows[0]["partcode4"].ToString();
                txt_PartCode5.Text = dt.Rows[0]["partcode5"].ToString();
                txt_PartCode6.Text = dt.Rows[0]["partcode6"].ToString();
                txt_PartCode7.Text = dt.Rows[0]["partcode7"].ToString();
                txt_PartCode8.Text = dt.Rows[0]["partcode8"].ToString();
                txt_PartCode9.Text = dt.Rows[0]["partcode9"].ToString();
                txt_PartCode10.Text = dt.Rows[0]["partcode10"].ToString();
                txt_PartCode11.Text = dt.Rows[0]["partcode11"].ToString();
                txt_PartCode12.Text = dt.Rows[0]["partcode12"].ToString();
                txt_PartCode13.Text = dt.Rows[0]["partcode13"].ToString();
                txt_PartCode14.Text = dt.Rows[0]["partcode14"].ToString();
                txt_sPartCod15.Text = dt.Rows[0]["partcode15"].ToString();
                cboMSDLevel.SelectedItem = dt.Rows[0]["MSDLevel"].ToString();
                cboShelfType.SelectedItem = dt.Rows[0]["ShelfType"].ToString();
                try
                {
                    chkIsBing.Checked = dt.Rows[0]["IsBing"] == null ? false : (bool)dt.Rows[0]["IsBing"];
                }
                catch
                {

                }

                try
                {
                    chkIsEnable.Checked = (bool)dt.Rows[0]["IsEnable"];
                }
                catch
                {

                }
                txtWarehouseLocation.Text = dt.Rows[0]["WarehouseLocation"].ToString();
                txtPasteMinCount.Text = dt.Rows[0]["PasteMinCount"].ToString();
                txtShelfLife.Text = dt.Rows[0]["ShelfLife"].ToString();
                if (dt.Rows[0]["MorePack"].ToString().ToLower() == "y")
                {
                    chx_morepage.Checked = true;
                }
                else
                {
                    chx_morepage.Checked = false;
                }
                //2018.02.27 Zach 是否送检
                string sql_isSendCheck = string.Format("select IsSendCheck from dbo.MdcdatMaterial where  MaterialCode='{0}'", newpn);
                DataTable dt_isSendCheck = NMS.QueryDataTable(CIT.MES.PubUtils.uContext, sql_isSendCheck);
                if (dt_isSendCheck.Rows.Count > 0)
                {
                    if (StringChange.ChangeNullToString(dt_isSendCheck.Rows[0]["IsSendCheck"]) == "是")
                    {
                        chk_isSendCheck.Checked = true;
                    }
                    else
                    {
                        chk_isSendCheck.Checked = false;
                    }
                   
                }

            }
            FrmType = true;
            this.txt_partcode1.TextChanged += new System.EventHandler(this.txt_partcode1_TextChanged);
            this.txt_PartCode2.TextChanged += new System.EventHandler(this.txt_PartCode2_TextChanged);
            this.txt_PartCode3.TextChanged += new System.EventHandler(this.txt_PartCode3_TextChanged);
            this.txt_PartCode4.TextChanged += new System.EventHandler(this.txt_PartCode4_TextChanged);
            this.txt_PartCode5.TextChanged += new System.EventHandler(this.txt_PartCode5_TextChanged);
            this.txt_PartCode6.TextChanged += new System.EventHandler(this.txt_PartCode6_TextChanged);
            this.txt_sPartCod15.TextChanged += new System.EventHandler(this.txt_PartCode15_TextChanged);
            this.txt_PartCode7.TextChanged += new System.EventHandler(this.txt_PartCode7_TextChanged);
            this.txt_PartCode8.TextChanged += new System.EventHandler(this.txt_PartCode8_TextChanged);
            this.txt_PartCode9.TextChanged += new System.EventHandler(this.txt_PartCode9_TextChanged);
            this.txt_PartCode10.TextChanged += new System.EventHandler(this.txt_PartCode10_TextChanged);
            this.txt_PartCode11.TextChanged += new System.EventHandler(this.txt_PartCode11_TextChanged);
            this.txt_PartCode12.TextChanged += new System.EventHandler(this.txt_PartCode12_TextChanged);
            this.txt_PartCode13.TextChanged += new System.EventHandler(this.txt_PartCode13_TextChanged);
            this.txt_PartCode14.TextChanged += new System.EventHandler(this.txt_PartCode14_TextChanged);

        }

        private void btn_no_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (cbx_customerID.Text.Length == 0)
            {
                MsgBox.Error("请选择客户编号.");
                cbx_customerID.Focus();
                return;
            }
            //如果是锡膏判断最小回温量
            if (txt_MaterialType.Text.Trim() == "锡膏")
            {
                try
                {
                    if (int.Parse(txtPasteMinCount.Text.Trim()) == 0)
                    {
                        MsgBox.Error("最小回温数量大于0");
                        txtPasteMinCount.Focus();
                        return;
                    }
                }
                catch
                {
                    MsgBox.Error("最小回温数量大于0");
                    txtPasteMinCount.Focus();
                    txtPasteMinCount.Text = "0";
                    return;
                }
            }
            if (txt_new.Text.Length == 0)
            {
                MsgBox.Error("新物料编号不可为空.");
                txt_new.Focus();
                return;
            }
            try
            {
                if (txt_Qty.Text.Trim() == "")
                    txt_Qty.Text = "1";
                if (txtShelfLife.Text.Trim() == "")
                    txtShelfLife.Text = "1";
                int qty = int.Parse(txt_Qty.Text);
                if (qty > 20000)
                {
                    MsgBox.Error("数量不可大于20000");
                    txt_Qty.Focus();
                    return;
                }
            }
            catch { }
            if (!FrmType)
            {
                if (!CheckNewPN()) return;
            }
            if (!CheckMPN()) return;
            if (!FrmType)
            {
                string sql = string.Format(@"
if not exists(select * from MdcdatMaterial where MaterialCode='{0}')
begin  insert into MdcdatMaterial(MaterialCode,createtime,IsSendCheck)values('{0}',getdate(),'{31}')  end
insert into MdcDatMPN (newPN,oldPN,MaterialMinCount,MorePack,CustomerType,PartCode1,PartCode2,PartCode3,PartCode4,PartCode5,PartCode6,PartCode7,PartCode8,PartCode9,PartCode10,PartCode11,PartCode12,PartCode13,PartCode14,PartCode15,Recordtime,PNYorN,[Type],SupplierName,ManufacturerLocation,MaterialType,Purchase,MSDLevel,ShelfType,IsEnable,WarehouseLocation,PasteMinCount,ShelfLife,IsBing)
            values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}',GETDATE(),'N','0','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}')", txt_new.Text, txt_old.Text, txt_Qty.Text, chx_morepage.Checked ? "Y" : "N", cbx_customerID.Text,
                                                      txt_partcode1.Text, txt_PartCode2.Text, txt_PartCode3.Text, txt_PartCode4.Text, txt_PartCode5.Text, txt_PartCode6.Text, txt_PartCode7.Text, txt_PartCode8.Text,
                                                      txt_PartCode9.Text, txt_PartCode10.Text, txt_PartCode11.Text, txt_PartCode12.Text, txt_PartCode13.Text, txt_PartCode14.Text, txt_sPartCod15.Text, txt_SupplierName.Text, txt_ManufacturerLocation.Text.Trim(), txt_MaterialType.Text.Trim(), txt_Purchase.Text.Trim(), cboMSDLevel.Text, cboShelfType.Text, chkIsEnable.Checked ? "1" : "0", txtWarehouseLocation.Text.Trim()
                                                      , txtPasteMinCount.Text.Trim(), txtShelfLife.Text.Trim(), chkIsBing.Checked ? "1" : "0", chk_isSendCheck.Checked ? "是" : "否");
                //
                bool flag = NMS.ExecTransql(CIT.MES.PubUtils.uContext, sql);
                if (flag)
                {
                    lab_msg.Text = "注册成功.";
                    foreach (var item in this.Controls)
                    {
                        if (item is TextBox)
                        {
                            string name = ((TextBox)item).Name;
                            if (name.ToLower().Contains("partcode"))
                            {
                                ((TextBox)item).Text = "";
                            }
                        }
                    }
                    txt_new.Text = "";
                    txt_old.Text = "";
                    txt_Qty.Text = "";

                    txt_new.Focus();
                }
                else
                {
                    MsgBox.Error("维护失败.");
                }
            }
            else
            {
                string sql = string.Format(@"update MdcDatMPN set PartCode15='{1}',Recordtime=getdate(),MaterialMinCount='{2}',MSDLevel='{3}',ShelfType='{4}',IsEnable='{5}',MorePack='{6}',PasteMinCount='{7}',ShelfLife='{8}',IsBing='{9}' WHERE NEWPN='{0}' 
                update MdcdatMaterial set IsSendCheck='{10}' where MaterialCode='{0}'
                ", txt_new.Text, txt_sPartCod15.Text, txt_Qty.Text, cboMSDLevel.Text, cboShelfType.Text, chkIsEnable.Checked ? "1" : "0", chx_morepage.Checked ? "Y" : "N", txtPasteMinCount.Text.Trim(), txtShelfLife.Text.Trim(), chkIsBing.Checked ? "1" : "0", chk_isSendCheck.Checked ? "是" : "否");
                bool flag = NMS.ExecTransql(CIT.MES.PubUtils.uContext, sql);
                if (flag)
                {
                    lab_msg.Text = "更新成功.";
                    this.Close();
                }
                else
                {
                    MsgBox.Error("更新失败.");
                }
                this.Close();
            }
        }

        private void cbx_customerID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        bool CheckNewPN()
        {
            DataTable dt = NMS.QueryDataTable(CIT.MES.PubUtils.uContext, "select newpn,oldpn,MaterialMinCount from MdcDatMPN where newpn='" + txt_new.Text + "' ");
            if (dt != null && dt.Rows.Count > 0)
            {
                MsgBox.Error("物料已经维护,请勿重复维护.");
                txt_new.SelectAll();
                txt_new.Focus();
                return false;
            }
            return true;
        }
        bool CheckMPN()
        {
            StringBuilder str = new StringBuilder();
            str.Append("(");
            for (int i = 1; i < 16; i++)
            {
                str.Append(" partcode" + i.ToString() + "='{0}' or ");
            }
            str.Remove(str.Length - 3, 3);
            str.Append(")");

            foreach (var item in txGroupBox2.Controls)
            {
                if (item.GetType().FullName == "System.Windows.Forms.TextBox")
                {
                    string name = ((TextBox)item).Name;
                    if (name.ToLower().Contains("partcode"))
                    {
                        string partcode = ((TextBox)item).Text;
                        //if (partcode.Length != 0)
                        {
                            if (((TextBox)item).Tag != null && ((TextBox)item).Tag.ToString() == "ok")
                            {
                                if (partcode.Length != 0)
                                {
                                    string customerid = cbx_customerID.Text;
                                    DataTable dt = NMS.QueryDataTable(CIT.MES.PubUtils.uContext, string.Format("select newpn,oldpn,MaterialMinCount from MdcDatMPN where customertype='{1}' and " + str.ToString(), partcode, cbx_customerID.Text));
                                    if (dt != null && dt.Rows.Count > 0)
                                    {
                                        MsgBox.Error("存在MPN信息【" + ((TextBox)item).Text + "】,请勿重复维护.");
                                        return false;
                                    }
                                }
                                if (FrmType)
                                {
                                    string index = ((TextBox)item).Name.ToLower().Replace("txt_partcode", "");
                                    //更新数据
                                    string sql = string.Format(@"update MdcDatMPN set oldPN='{1}',MaterialMinCount='{2}',MorePack='{3}',CustomerType='{4}',PartCode" + index + @"='{5}',PartCode15='{6}',MSDLevel='{7}',ShelfType='{8}',IsEnable='{9}',Recordtime=getdate(),PNYorN='N',[Type]='0',PasteMinCount='{10}',ShelfLife='{11}' WHERE NEWPN='{0}' 
                                    ", txt_new.Text, txt_old.Text, txt_Qty.Text, chx_morepage.Checked ? "Y" : "N", cbx_customerID.Text, ((TextBox)item).Text, txt_sPartCod15.Text, cboMSDLevel.Text, cboShelfType.Text, chkIsEnable.Checked ? "1" : "0", txtPasteMinCount.Text.Trim(), txtShelfLife.Text.Trim());
                                    bool flag = NMS.ExecTransql(CIT.MES.PubUtils.uContext, sql);
                                    if (flag)
                                    {
                                        lab_msg.Text = "更新成功.";
                                        this.Close();
                                    }
                                    else
                                    {
                                        MsgBox.Error("更新失败.");
                                    }
                                }
                            }
                        }
                    }
                }
            }

            foreach (var item in txGroupBox1.Controls)
            {
                if (item.GetType().FullName == "System.Windows.Forms.TextBox")
                {
                    string name = ((TextBox)item).Name;
                    if (name.ToLower().Contains("partcode"))
                    {
                        string partcode = ((TextBox)item).Text;
                        //if (partcode.Length != 0)
                        {
                            if (((TextBox)item).Tag != null && ((TextBox)item).Tag.ToString() == "ok")
                            {
                                if (partcode.Length != 0)
                                {
                                    string customerid = cbx_customerID.Text;
                                    DataTable dt = NMS.QueryDataTable(CIT.MES.PubUtils.uContext, string.Format("select newpn,oldpn,MaterialMinCount from MdcDatMPN where customertype='{1}' and " + str.ToString(), partcode, cbx_customerID.Text));
                                    if (dt != null && dt.Rows.Count > 0)
                                    {
                                        MsgBox.Error("存在MPN信息【" + ((TextBox)item).Text + "】,请勿重复维护.");
                                        return false;
                                    }
                                }
                                if (FrmType)
                                {
                                    string index = ((TextBox)item).Name.ToLower().Replace("txt_partcode", "");
                                    //更新数据
                                    string sql = string.Format(@"update MdcDatMPN set oldPN='{1}',MaterialMinCount='{2}',MorePack='{3}',CustomerType='{4}',PartCode" + index + @"='{5}',PartCode15='{6}',MSDLevel='{7}',ShelfType='{8}',IsEnable='{9}',Recordtime=getdate(),PNYorN='N',[Type]='0',PasteMinCount='{10}',ShelfLife='{11}' WHERE NEWPN='{0}' 
                                    ", txt_new.Text, txt_old.Text, txt_Qty.Text, chx_morepage.Checked ? "Y" : "N", cbx_customerID.Text, ((TextBox)item).Text, txt_sPartCod15.Text, cboMSDLevel.Text, cboShelfType.Text, chkIsEnable.Checked ? "1" : "0", txtPasteMinCount.Text.Trim(), txtShelfLife.Text.Trim());
                                    bool flag = NMS.ExecTransql(CIT.MES.PubUtils.uContext, sql);
                                    if (flag)
                                    {
                                        lab_msg.Text = "更新成功.";
                                        this.Close();
                                    }
                                    else
                                    {
                                        MsgBox.Error("更新失败.");
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return true;
        }

        private void txt_new_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                bool flag = CheckNewPN();
                if (flag)
                {
                    txt_Qty.SelectAll();
                    txt_Qty.Focus();
                }
            }
        }

        private void txt_Qty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;
            //小数点的处理。
            if ((int)e.KeyChar == 46)                           //小数点
            {
                if (txt_Qty.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(txt_Qty.Text, out oldf);
                    b2 = float.TryParse(txt_Qty.Text + e.KeyChar.ToString(), out f);
                    if (b2 == false)
                    {
                        if (b1 == true)
                            e.Handled = true;
                        else
                            e.Handled = false;
                    }
                }
            }
            if (e.KeyChar == 13)
            {
                if (txt_Qty.Text.Length > 0)
                {
                    txt_SupplierName.SelectAll();
                    txt_SupplierName.Focus();
                }
                else
                {
                    txt_Qty.Focus();
                }
            }

        }

        private void txt_partcode1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txt_PartCode2.SelectAll();
                txt_PartCode2.Focus();
            }
        }

        private void txt_PartCode2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txt_PartCode3.SelectAll();
                txt_PartCode3.Focus();
            }
        }

        private void txt_PartCode3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txt_PartCode4.SelectAll();
                txt_PartCode4.Focus();
            }
        }

        private void txt_PartCode4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txt_PartCode5.SelectAll();
                txt_PartCode5.Focus();
            }
        }

        private void txt_PartCode5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txt_PartCode6.SelectAll();
                txt_PartCode6.Focus();
            }
        }

        private void txt_PartCode6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {

                txt_PartCode7.SelectAll();
                txt_PartCode7.Focus();
            }
        }

        private void txt_PartCode7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txt_PartCode8.SelectAll();
                txt_PartCode8.Focus();
            }
        }
        private void txt_PartCode8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txt_PartCode9.SelectAll();
                txt_PartCode9.Focus();
            }
        }
        private void txt_PartCode9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txt_PartCode10.SelectAll();
                txt_PartCode10.Focus();
            }
        }

        private void txt_PartCode10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txt_PartCode11.SelectAll();
                txt_PartCode11.Focus();
            }
        }

        private void txt_PartCode11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txt_PartCode12.SelectAll();
                txt_PartCode12.Focus();
            }
        }
        private void txt_PartCode12_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txt_PartCode13.SelectAll();
                txt_PartCode13.Focus();
            }
        }
        private void txt_PartCode13_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txt_PartCode14.SelectAll();
                txt_PartCode14.Focus();
            }
        }

        private void txt_PartCode14_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txt_sPartCod15.SelectAll();
                txt_sPartCod15.Focus();
            }
        }
        private void txt_PartCode15_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                chx_morepage.Focus();
            }
        }

        private void txt_partcode1_TextChanged(object sender, EventArgs e)
        {
            txt_partcode1.Tag = "ok";
        }

        private void txt_PartCode2_TextChanged(object sender, EventArgs e)
        {
            txt_PartCode2.Tag = "ok";
        }

        private void txt_PartCode3_TextChanged(object sender, EventArgs e)
        {
            txt_PartCode3.Tag = "ok";
        }

        private void txt_PartCode4_TextChanged(object sender, EventArgs e)
        {
            txt_PartCode4.Tag = "ok";
        }

        private void txt_PartCode5_TextChanged(object sender, EventArgs e)
        {
            txt_PartCode5.Tag = "ok";
        }

        private void txt_PartCode6_TextChanged(object sender, EventArgs e)
        {
            txt_PartCode6.Tag = "ok";
        }

        private void txt_PartCode7_TextChanged(object sender, EventArgs e)
        {
            txt_PartCode7.Tag = "ok";
        }

        private void txt_PartCode8_TextChanged(object sender, EventArgs e)
        {
            txt_PartCode8.Tag = "ok";
        }

        private void txt_PartCode9_TextChanged(object sender, EventArgs e)
        {
            txt_PartCode9.Tag = "ok";
        }

        private void txt_PartCode10_TextChanged(object sender, EventArgs e)
        {
            txt_PartCode10.Tag = "ok";
        }

        private void txt_PartCode11_TextChanged(object sender, EventArgs e)
        {
            txt_PartCode11.Tag = "ok";
        }

        private void txt_PartCode12_TextChanged(object sender, EventArgs e)
        {
            txt_PartCode12.Tag = "ok";
        }

        private void txt_PartCode13_TextChanged(object sender, EventArgs e)
        {
            txt_PartCode13.Tag = "ok";
        }

        private void txt_PartCode14_TextChanged(object sender, EventArgs e)
        {
            txt_PartCode14.Tag = "ok";
        }

        private void txt_PartCode15_TextChanged(object sender, EventArgs e)
        {
            txt_sPartCod15.Tag = "ok";
        }

        private void txt_SupplierName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txt_ManufacturerLocation.SelectAll();
                txt_ManufacturerLocation.Focus();
            }

        }

        private void txt_ManufacturerLocation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txt_MaterialType.SelectAll();
                txt_MaterialType.Focus();
            }

        }

        private void txt_Purchase_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txt_partcode1.SelectAll();
                txt_partcode1.Focus();
            }
        }

        private void txt_MaterialType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_Purchase.SelectAll();
            txt_Purchase.Focus();
        }
    }
}
