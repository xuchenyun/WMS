namespace CIT.MES.Setting.PrintView
{
    partial class FrmBackReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.mes = new CIT.MES.DAL.mes();
            this.mesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.mes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "back";
            reportDataSource1.Value = this.mesBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CIT.MES.Setting.PrintView.backreport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(877, 550);
            this.reportViewer1.TabIndex = 0;
            // 
            // mes
            // 
            this.mes.DataSetName = "mes";
            this.mes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // mesBindingSource
            // 
            this.mesBindingSource.DataSource = this.mes;
            this.mesBindingSource.Position = 0;
            // 
            // FrmBackReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 550);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmBackReport";
            this.Text = "FrmBackReport";
            this.Load += new System.EventHandler(this.FrmBackReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource mesBindingSource;
        private DAL.mes mes;



    }
}