using System;
namespace CIT.MES.Control
{
    partial class DocumentSpace
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsNew = new System.Windows.Forms.ToolStripButton();
            this.tsOpen = new System.Windows.Forms.ToolStripButton();
            this.tsSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsDelete = new System.Windows.Forms.ToolStripButton();
            this.tsTop = new System.Windows.Forms.ToolStripButton();
            this.tsBottom = new System.Windows.Forms.ToolStripButton();
            this.tsGrid = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsPrint = new System.Windows.Forms.ToolStripButton();
            this.tsView = new System.Windows.Forms.ToolStripButton();
            this.tsSet = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsInfo = new System.Windows.Forms.ToolStripButton();
            this.tsExit = new System.Windows.Forms.ToolStripButton();
            this.btn_Copy = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numWidth = new System.Windows.Forms.NumericUpDown();
            this.numHeight = new System.Windows.Forms.NumericUpDown();
            this.numRows = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.numRowHeight = new System.Windows.Forms.NumericUpDown();
            this.lab_templetName = new System.Windows.Forms.Label();
            this.itemList1 = new CIT.MES.Control.ItemList();
            this.drawToolBox1 = new CIT.MES.Control.DrawToolBox();
            this.designer1 = new CIT.MES.Designer();
            this.ruler2 = new CIT.MES.Control.Ruler();
            this.ruler1 = new CIT.MES.Control.Ruler();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRowHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScrollMargin = new System.Drawing.Size(5, 5);
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.ruler2);
            this.panel1.Controls.Add(this.ruler1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(50, 42);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1182, 866);
            this.panel1.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.AutoScroll = true;
            this.panel3.AutoScrollMargin = new System.Drawing.Size(5, 5);
            this.panel3.Controls.Add(this.designer1);
            this.panel3.Location = new System.Drawing.Point(76, 64);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1106, 801);
            this.panel3.TabIndex = 6;
            this.panel3.Scroll += new System.Windows.Forms.ScrollEventHandler(this.panel3_Scroll);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(-2, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(76, 52);
            this.panel2.TabIndex = 5;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsNew,
            this.tsOpen,
            this.tsSave,
            this.toolStripSeparator1,
            this.tsDelete,
            this.tsTop,
            this.tsBottom,
            this.tsGrid,
            this.toolStripSeparator3,
            this.tsPrint,
            this.tsView,
            this.tsSet,
            this.toolStripSeparator2,
            this.tsInfo,
            this.tsExit,
            this.btn_Copy});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(668, 42);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsNew
            // 
            this.tsNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsNew.Image = global::CIT.MES.Properties.Resources.add;
            this.tsNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsNew.Name = "tsNew";
            this.tsNew.Size = new System.Drawing.Size(28, 39);
            this.tsNew.Text = "新建";
            this.tsNew.ToolTipText = "新建";
            this.tsNew.Click += new System.EventHandler(this.tsNew_Click);
            // 
            // tsOpen
            // 
            this.tsOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsOpen.Image = global::CIT.MES.Properties.Resources.new16;
            this.tsOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsOpen.Name = "tsOpen";
            this.tsOpen.Size = new System.Drawing.Size(28, 39);
            this.tsOpen.Text = "打开设计";
            this.tsOpen.ToolTipText = "打开设计";
            this.tsOpen.Click += new System.EventHandler(this.tsOpen_Click);
            // 
            // tsSave
            // 
            this.tsSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsSave.Image = global::CIT.MES.Properties.Resources.save;
            this.tsSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSave.Name = "tsSave";
            this.tsSave.Size = new System.Drawing.Size(28, 39);
            this.tsSave.Text = "保存设计";
            this.tsSave.ToolTipText = "保存设计";
            this.tsSave.Click += new System.EventHandler(this.tsSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 42);
            // 
            // tsDelete
            // 
            this.tsDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsDelete.Image = global::CIT.MES.Properties.Resources.delbinding;
            this.tsDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsDelete.Name = "tsDelete";
            this.tsDelete.Size = new System.Drawing.Size(28, 39);
            this.tsDelete.Text = "删除选中的对像";
            this.tsDelete.Click += new System.EventHandler(this.tsDelete_Click);
            // 
            // tsTop
            // 
            this.tsTop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsTop.Image = global::CIT.MES.Properties.Resources.layer_to_front;
            this.tsTop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsTop.Name = "tsTop";
            this.tsTop.Size = new System.Drawing.Size(28, 39);
            this.tsTop.Text = "置顶";
            this.tsTop.Click += new System.EventHandler(this.tsTop_Click);
            // 
            // tsBottom
            // 
            this.tsBottom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBottom.Image = global::CIT.MES.Properties.Resources.layer_to_back;
            this.tsBottom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBottom.Name = "tsBottom";
            this.tsBottom.Size = new System.Drawing.Size(28, 39);
            this.tsBottom.Text = "置底";
            this.tsBottom.Click += new System.EventHandler(this.tsBottom_Click);
            // 
            // tsGrid
            // 
            this.tsGrid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsGrid.Image = global::CIT.MES.Properties.Resources.showgrid;
            this.tsGrid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsGrid.Name = "tsGrid";
            this.tsGrid.Size = new System.Drawing.Size(28, 39);
            this.tsGrid.Text = "显示网格";
            this.tsGrid.Click += new System.EventHandler(this.tsGrid_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 42);
            // 
            // tsPrint
            // 
            this.tsPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsPrint.Image = global::CIT.MES.Properties.Resources.print;
            this.tsPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsPrint.Name = "tsPrint";
            this.tsPrint.Size = new System.Drawing.Size(28, 39);
            this.tsPrint.Text = "打印";
            this.tsPrint.ToolTipText = "打印";
            this.tsPrint.Click += new System.EventHandler(this.tsPrint_Click);
            // 
            // tsView
            // 
            this.tsView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsView.Image = global::CIT.MES.Properties.Resources.query;
            this.tsView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsView.Name = "tsView";
            this.tsView.Size = new System.Drawing.Size(28, 39);
            this.tsView.Text = "打印预览";
            this.tsView.ToolTipText = "打印预览";
            this.tsView.Click += new System.EventHandler(this.tsView_Click);
            // 
            // tsSet
            // 
            this.tsSet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsSet.Image = global::CIT.MES.Properties.Resources.setting;
            this.tsSet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSet.Name = "tsSet";
            this.tsSet.Size = new System.Drawing.Size(28, 39);
            this.tsSet.Text = "设置";
            this.tsSet.ToolTipText = "设置";
            this.tsSet.Click += new System.EventHandler(this.tsSet_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 42);
            // 
            // tsInfo
            // 
            this.tsInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsInfo.Image = global::CIT.MES.Properties.Resources.info;
            this.tsInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsInfo.Name = "tsInfo";
            this.tsInfo.Size = new System.Drawing.Size(28, 39);
            this.tsInfo.Text = "关于";
            this.tsInfo.ToolTipText = "关于";
            this.tsInfo.Visible = false;
            this.tsInfo.Click += new System.EventHandler(this.tsInfo_Click);
            // 
            // tsExit
            // 
            this.tsExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsExit.Image = global::CIT.MES.Properties.Resources.delbinding;
            this.tsExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsExit.Name = "tsExit";
            this.tsExit.Size = new System.Drawing.Size(28, 39);
            this.tsExit.Text = "退出";
            this.tsExit.ToolTipText = "退出";
            this.tsExit.Visible = false;
            this.tsExit.Click += new System.EventHandler(this.tsExit_Click);
            // 
            // btn_Copy
            // 
            this.btn_Copy.Image = global::CIT.MES.Properties.Resources.png_1242;
            this.btn_Copy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Copy.Name = "btn_Copy";
            this.btn_Copy.Size = new System.Drawing.Size(28, 39);
            this.btn_Copy.ToolTipText = "另存";
            this.btn_Copy.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 30);
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyGrid1.LineColor = System.Drawing.SystemColors.ControlDark;
            this.propertyGrid1.Location = new System.Drawing.Point(1242, 38);
            this.propertyGrid1.Margin = new System.Windows.Forms.Padding(4);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(326, 354);
            this.propertyGrid1.TabIndex = 5;
            this.propertyGrid1.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid1_PropertyValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1262, 714);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 18);
            this.label1.TabIndex = 8;
            this.label1.Text = "Page Width:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1257, 753);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "Page Height:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1258, 790);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "Rows Count:";
            // 
            // numWidth
            // 
            this.numWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numWidth.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numWidth.Location = new System.Drawing.Point(1366, 706);
            this.numWidth.Margin = new System.Windows.Forms.Padding(4);
            this.numWidth.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.numWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numWidth.Name = "numWidth";
            this.numWidth.Size = new System.Drawing.Size(116, 29);
            this.numWidth.TabIndex = 9;
            this.numWidth.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numWidth.ValueChanged += new System.EventHandler(this.numWidth_ValueChanged);
            // 
            // numHeight
            // 
            this.numHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numHeight.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numHeight.Location = new System.Drawing.Point(1366, 746);
            this.numHeight.Margin = new System.Windows.Forms.Padding(4);
            this.numHeight.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.numHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numHeight.Name = "numHeight";
            this.numHeight.Size = new System.Drawing.Size(116, 29);
            this.numHeight.TabIndex = 9;
            this.numHeight.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numHeight.ValueChanged += new System.EventHandler(this.numHeight_ValueChanged);
            // 
            // numRows
            // 
            this.numRows.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numRows.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numRows.Location = new System.Drawing.Point(1366, 784);
            this.numRows.Margin = new System.Windows.Forms.Padding(4);
            this.numRows.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRows.Name = "numRows";
            this.numRows.Size = new System.Drawing.Size(116, 29);
            this.numRows.TabIndex = 9;
            this.numRows.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRows.ValueChanged += new System.EventHandler(this.numRows_ValueChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1482, 714);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "mm";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1482, 753);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 18);
            this.label5.TabIndex = 8;
            this.label5.Text = "mm";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1482, 790);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 18);
            this.label6.TabIndex = 8;
            this.label6.Text = "row";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1480, 828);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 18);
            this.label7.TabIndex = 8;
            this.label7.Text = "mm";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1250, 828);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 18);
            this.label8.TabIndex = 8;
            this.label8.Text = "Rows Height:";
            // 
            // numRowHeight
            // 
            this.numRowHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numRowHeight.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numRowHeight.Location = new System.Drawing.Point(1365, 822);
            this.numRowHeight.Margin = new System.Windows.Forms.Padding(4);
            this.numRowHeight.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numRowHeight.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numRowHeight.Name = "numRowHeight";
            this.numRowHeight.Size = new System.Drawing.Size(116, 29);
            this.numRowHeight.TabIndex = 9;
            this.numRowHeight.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numRowHeight.ValueChanged += new System.EventHandler(this.numRowHeight_ValueChanged);
            // 
            // lab_templetName
            // 
            this.lab_templetName.AutoSize = true;
            this.lab_templetName.Location = new System.Drawing.Point(686, 12);
            this.lab_templetName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lab_templetName.Name = "lab_templetName";
            this.lab_templetName.Size = new System.Drawing.Size(143, 18);
            this.lab_templetName.TabIndex = 11;
            this.lab_templetName.Text = "当前模板名称为:";
            // 
            // itemList1
            // 
            this.itemList1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemList1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.itemList1.ItemHeight = 20;
            this.itemList1.Location = new System.Drawing.Point(1242, 396);
            this.itemList1.Margin = new System.Windows.Forms.Padding(4);
            this.itemList1.Name = "itemList1";
            this.itemList1.Size = new System.Drawing.Size(324, 264);
            this.itemList1.TabIndex = 7;
            this.itemList1.SelectedIndexChanged += new System.EventHandler(this.itemList1_SelectedIndexChanged);
            this.itemList1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.itemList1_KeyDown);
            // 
            // drawToolBox1
            // 
            this.drawToolBox1.AutoSize = false;
            this.drawToolBox1.Dock = System.Windows.Forms.DockStyle.None;
            this.drawToolBox1.GripMargin = new System.Windows.Forms.Padding(20, 2, 2, 2);
            this.drawToolBox1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.drawToolBox1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.drawToolBox1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.drawToolBox1.Location = new System.Drawing.Point(0, 40);
            this.drawToolBox1.Margin = new System.Windows.Forms.Padding(4);
            this.drawToolBox1.Name = "drawToolBox1";
            this.drawToolBox1.Padding = new System.Windows.Forms.Padding(0);
            this.drawToolBox1.Size = new System.Drawing.Size(45, 410);
            this.drawToolBox1.TabIndex = 3;
            this.drawToolBox1.Text = "drawToolBox1";
            // 
            // designer1
            // 
            this.designer1.BackColor = System.Drawing.Color.White;
            this.designer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.designer1.CanSelectItem = true;
            this.designer1.IsDrawMousePosition = false;
            this.designer1.IsDrawSelectRectangle = true;
            this.designer1.Location = new System.Drawing.Point(0, 8);
            this.designer1.Margin = new System.Windows.Forms.Padding(4, 4, 45, 42);
            this.designer1.Name = "designer1";
            this.designer1.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.designer1.RowHeight = 15;
            this.designer1.ShowGrid = false;
            this.designer1.Size = new System.Drawing.Size(556, 377);
            this.designer1.TabIndex = 7;
            // 
            // ruler2
            // 
            this.ruler2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ruler2.BackColor = System.Drawing.Color.White;
            this.ruler2.ForeColor = System.Drawing.Color.Black;
            this.ruler2.Location = new System.Drawing.Point(0, 45);
            this.ruler2.Margin = new System.Windows.Forms.Padding(4);
            this.ruler2.Name = "ruler2";
            this.ruler2.RulerOrientation = CIT.MES.Orientation.Vertical;
            this.ruler2.Size = new System.Drawing.Size(75, 826);
            this.ruler2.StartPosition = 21;
            this.ruler2.StartValue = 0;
            this.ruler2.TabIndex = 4;
            this.ruler2.Text = "ruler2";
            // 
            // ruler1
            // 
            this.ruler1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ruler1.BackColor = System.Drawing.Color.White;
            this.ruler1.ForeColor = System.Drawing.Color.Black;
            this.ruler1.Location = new System.Drawing.Point(52, 0);
            this.ruler1.Margin = new System.Windows.Forms.Padding(4);
            this.ruler1.Name = "ruler1";
            this.ruler1.RulerOrientation = CIT.MES.Orientation.Horizontal;
            this.ruler1.Size = new System.Drawing.Size(1160, 63);
            this.ruler1.StartPosition = 22;
            this.ruler1.StartValue = 0;
            this.ruler1.TabIndex = 3;
            this.ruler1.Text = "ruler1";
            // 
            // DocumentSpace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lab_templetName);
            this.Controls.Add(this.numRowHeight);
            this.Controls.Add(this.numRows);
            this.Controls.Add(this.numHeight);
            this.Controls.Add(this.numWidth);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.itemList1);
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.drawToolBox1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DocumentSpace";
            this.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.Size = new System.Drawing.Size(1576, 912);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRowHeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DrawToolBox drawToolBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsNew;
        private System.Windows.Forms.ToolStripButton tsOpen;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private ItemList itemList1;
        private System.Windows.Forms.ToolStripButton tsSave;
        private System.Windows.Forms.ToolStripButton tsPrint;
        private System.Windows.Forms.ToolStripButton tsSet;
        private System.Windows.Forms.ToolStripButton tsInfo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsView;
        private System.Windows.Forms.ToolStripButton tsExit;
        private System.Windows.Forms.ToolStripButton tsDelete;
        private System.Windows.Forms.ToolStripButton tsTop;
        private System.Windows.Forms.ToolStripButton tsBottom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numWidth;
        private System.Windows.Forms.NumericUpDown numHeight;
        private System.Windows.Forms.NumericUpDown numRows;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numRowHeight;
        private Ruler ruler2;
        private Ruler ruler1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lab_templetName;
        private System.Windows.Forms.Panel panel3;
        private CIT.MES.Designer designer1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsGrid;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btn_Copy;


    }
}
