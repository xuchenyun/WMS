using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using  CIT.MES.IO;

namespace CIT.MES.Control
{
    public partial class frmSetting : Form
    {
        public frmSetting(PrintConfig confg)
        {
            InitializeComponent();
            pconfig = confg;
        }

        private PrintConfig pconfig;

        private void frmSetting_Load(object sender, EventArgs e)
        {
            for (int i=0; i < PrinterSettings.InstalledPrinters.Count; i++)
            {
                cbPrintName.Items.Add(PrinterSettings.InstalledPrinters[i]);
            }
            if (cbPrintName.Items.Count > 0)
            {
                cbPrintName.SelectedItem = pconfig.PrintName;
            }
            numX.Value = pconfig.XOFFSET;
            numY.Value = pconfig.YOFFSET;
            numZoom.Value = (decimal)pconfig.ZOOM;
            numCopies.Value = pconfig.Copies;

            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            pconfig.XOFFSET = (int)numX.Value;
            pconfig.YOFFSET = (int)numY.Value;
            pconfig.PrintName = cbPrintName.SelectedItem.ToString();
            pconfig.ZOOM = (float)numZoom.Value;
            pconfig.Copies = (int)numCopies.Value;
            this.Close();
            
        }

       
    }
}
