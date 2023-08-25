namespace ReportGeneratorDemo
{
    partial class MainForm
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
            Vintasoft.Imaging.Utils.WinFormsSystemClipboard winFormsSystemClipboard1 = new Vintasoft.Imaging.Utils.WinFormsSystemClipboard();
            Vintasoft.Imaging.Codecs.Decoders.RenderingSettings renderingSettings1 = new Vintasoft.Imaging.Codecs.Decoders.RenderingSettings();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewInPDFReaderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewInOfficeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadedAssembliesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateInvoiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemsCountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemsCountComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.generateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateXLSXTemplateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generatePricelistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateDOCXTemplateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generatePriceListXLSXTemplateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.examplesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dOCXEditorEampleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xLSXEditorExamleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.imageViewer1 = new Vintasoft.Imaging.UI.ImageViewer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.imageViewerToolStrip1 = new DemosCommonCode.Imaging.ImageViewerToolStrip();
            this.dOCXChartEditorExampleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.reportToolStripMenuItem,
            this.generateInvoiceToolStripMenuItem,
            this.generatePricelistToolStripMenuItem,
            this.examplesToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveAsToolStripMenuItem,
            this.viewInPDFReaderToolStripMenuItem,
            this.viewInOfficeToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Enabled = false;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // viewInPDFReaderToolStripMenuItem
            // 
            this.viewInPDFReaderToolStripMenuItem.Enabled = false;
            this.viewInPDFReaderToolStripMenuItem.Name = "viewInPDFReaderToolStripMenuItem";
            this.viewInPDFReaderToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.viewInPDFReaderToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.viewInPDFReaderToolStripMenuItem.Text = "View in PDF reader";
            this.viewInPDFReaderToolStripMenuItem.Click += new System.EventHandler(this.viewInPDFReaderToolStripMenuItem_Click);
            // 
            // viewInOfficeToolStripMenuItem
            // 
            this.viewInOfficeToolStripMenuItem.Enabled = false;
            this.viewInOfficeToolStripMenuItem.Name = "viewInOfficeToolStripMenuItem";
            this.viewInOfficeToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.viewInOfficeToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.viewInOfficeToolStripMenuItem.Text = "View in Office";
            this.viewInOfficeToolStripMenuItem.Click += new System.EventHandler(this.viewInOfficeToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(188, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // reportToolStripMenuItem
            // 
            this.reportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colorTableToolStripMenuItem,
            this.loadedAssembliesToolStripMenuItem});
            this.reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            this.reportToolStripMenuItem.Size = new System.Drawing.Size(104, 20);
            this.reportToolStripMenuItem.Text = "Generate Report";
            // 
            // colorTableToolStripMenuItem
            // 
            this.colorTableToolStripMenuItem.Name = "colorTableToolStripMenuItem";
            this.colorTableToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.colorTableToolStripMenuItem.Text = "Color Table";
            this.colorTableToolStripMenuItem.Click += new System.EventHandler(this.tableBasedColorTableToolStripMenuItem_Click);
            // 
            // loadedAssembliesToolStripMenuItem
            // 
            this.loadedAssembliesToolStripMenuItem.Name = "loadedAssembliesToolStripMenuItem";
            this.loadedAssembliesToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.loadedAssembliesToolStripMenuItem.Text = "Loaded Assemblies";
            this.loadedAssembliesToolStripMenuItem.Click += new System.EventHandler(this.loadedAssembliesToolStripMenuItem_Click);
            // 
            // generateInvoiceToolStripMenuItem
            // 
            this.generateInvoiceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemsCountToolStripMenuItem,
            this.generateToolStripMenuItem,
            this.generateXLSXTemplateToolStripMenuItem});
            this.generateInvoiceToolStripMenuItem.Name = "generateInvoiceToolStripMenuItem";
            this.generateInvoiceToolStripMenuItem.Size = new System.Drawing.Size(107, 20);
            this.generateInvoiceToolStripMenuItem.Text = "Generate Invoice";
            // 
            // itemsCountToolStripMenuItem
            // 
            this.itemsCountToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemsCountComboBox});
            this.itemsCountToolStripMenuItem.Name = "itemsCountToolStripMenuItem";
            this.itemsCountToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.itemsCountToolStripMenuItem.Text = "Items Count";
            // 
            // itemsCountComboBox
            // 
            this.itemsCountComboBox.Items.AddRange(new object[] {
            "1",
            "5",
            "10",
            "20",
            "25",
            "50",
            "100",
            "200"});
            this.itemsCountComboBox.Name = "itemsCountComboBox";
            this.itemsCountComboBox.Size = new System.Drawing.Size(121, 23);
            this.itemsCountComboBox.Text = "25";
            // 
            // generateToolStripMenuItem
            // 
            this.generateToolStripMenuItem.Name = "generateToolStripMenuItem";
            this.generateToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.generateToolStripMenuItem.Text = "Generate (DOCX template)";
            this.generateToolStripMenuItem.Click += new System.EventHandler(this.generateInvoiceDOCXToolStripMenuItem_Click);
            // 
            // generateXLSXTemplateToolStripMenuItem
            // 
            this.generateXLSXTemplateToolStripMenuItem.Name = "generateXLSXTemplateToolStripMenuItem";
            this.generateXLSXTemplateToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.generateXLSXTemplateToolStripMenuItem.Text = "Generate (XLSX template)";
            this.generateXLSXTemplateToolStripMenuItem.Click += new System.EventHandler(this.generateInvoiceXLSXTemplateToolStripMenuItem_Click);
            // 
            // generatePricelistToolStripMenuItem
            // 
            this.generatePricelistToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateDOCXTemplateToolStripMenuItem,
            this.generatePriceListXLSXTemplateToolStripMenuItem});
            this.generatePricelistToolStripMenuItem.Name = "generatePricelistToolStripMenuItem";
            this.generatePricelistToolStripMenuItem.Size = new System.Drawing.Size(116, 20);
            this.generatePricelistToolStripMenuItem.Text = "Generate Price List";
            // 
            // generateDOCXTemplateToolStripMenuItem
            // 
            this.generateDOCXTemplateToolStripMenuItem.Name = "generateDOCXTemplateToolStripMenuItem";
            this.generateDOCXTemplateToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.generateDOCXTemplateToolStripMenuItem.Text = "Generate (DOCX template)";
            this.generateDOCXTemplateToolStripMenuItem.Click += new System.EventHandler(this.generatePriceListDOCXTemplateToolStripMenuItem_Click);
            // 
            // generatePriceListXLSXTemplateToolStripMenuItem
            // 
            this.generatePriceListXLSXTemplateToolStripMenuItem.Name = "generatePriceListXLSXTemplateToolStripMenuItem";
            this.generatePriceListXLSXTemplateToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.generatePriceListXLSXTemplateToolStripMenuItem.Text = "Generate (XLSX template)";
            this.generatePriceListXLSXTemplateToolStripMenuItem.Click += new System.EventHandler(this.generatePriceListXLSXTemplateToolStripMenuItem_Click);
            // 
            // examplesToolStripMenuItem
            // 
            this.examplesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dOCXEditorEampleToolStripMenuItem,
            this.xLSXEditorExamleToolStripMenuItem,
            this.dOCXChartEditorExampleToolStripMenuItem});
            this.examplesToolStripMenuItem.Name = "examplesToolStripMenuItem";
            this.examplesToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.examplesToolStripMenuItem.Text = "Examples";
            // 
            // dOCXEditorEampleToolStripMenuItem
            // 
            this.dOCXEditorEampleToolStripMenuItem.Name = "dOCXEditorEampleToolStripMenuItem";
            this.dOCXEditorEampleToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.dOCXEditorEampleToolStripMenuItem.Text = "DOCX Editor Example";
            this.dOCXEditorEampleToolStripMenuItem.Click += new System.EventHandler(this.docxEditorExampleToolStripMenuItem_Click);
            // 
            // xLSXEditorExamleToolStripMenuItem
            // 
            this.xLSXEditorExamleToolStripMenuItem.Name = "xLSXEditorExamleToolStripMenuItem";
            this.xLSXEditorExamleToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.xLSXEditorExamleToolStripMenuItem.Text = "XLSX Editor Example";
            this.xLSXEditorExamleToolStripMenuItem.Click += new System.EventHandler(this.xlsxEditorExamleToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.aboutToolStripMenuItem.Text = "About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 540);
            this.panel1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.imageViewer1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 28);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(784, 512);
            this.panel3.TabIndex = 1;
            // 
            // imageViewer1
            // 
            this.imageViewer1.Clipboard = winFormsSystemClipboard1;
            this.imageViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageViewer1.ImageRenderingSettings = renderingSettings1;
            this.imageViewer1.ImageRotationAngle = 0;
            this.imageViewer1.Location = new System.Drawing.Point(0, 0);
            this.imageViewer1.Name = "imageViewer1";
            this.imageViewer1.ShortcutCut = System.Windows.Forms.Shortcut.None;
            this.imageViewer1.ShortcutDelete = System.Windows.Forms.Shortcut.None;
            this.imageViewer1.ShortcutInsert = System.Windows.Forms.Shortcut.None;
            this.imageViewer1.ShortcutSelectAll = System.Windows.Forms.Shortcut.None;
            this.imageViewer1.Size = new System.Drawing.Size(784, 512);
            this.imageViewer1.TabIndex = 0;
            this.imageViewer1.Text = "imageViewer1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.imageViewerToolStrip1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(784, 28);
            this.panel2.TabIndex = 0;
            // 
            // imageViewerToolStrip1
            // 
            this.imageViewerToolStrip1.AssociatedZoomTrackBar = null;
            this.imageViewerToolStrip1.CanOpenFile = false;
            this.imageViewerToolStrip1.CanPrint = false;
            this.imageViewerToolStrip1.ImageViewer = this.imageViewer1;
            this.imageViewerToolStrip1.ScanButtonEnabled = true;
            this.imageViewerToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.imageViewerToolStrip1.Name = "imageViewerToolStrip1";
            this.imageViewerToolStrip1.PageCount = 0;
            this.imageViewerToolStrip1.PrintButtonEnabled = false;
            this.imageViewerToolStrip1.SaveButtonEnabled = true;
            this.imageViewerToolStrip1.Size = new System.Drawing.Size(784, 25);
            this.imageViewerToolStrip1.TabIndex = 0;
            this.imageViewerToolStrip1.Text = "imageViewerToolStrip1";
            this.imageViewerToolStrip1.UseImageViewerImages = true;
            this.imageViewerToolStrip1.SaveFile += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // dOCXChartEditorExampleToolStripMenuItem
            // 
            this.dOCXChartEditorExampleToolStripMenuItem.Name = "dOCXChartEditorExampleToolStripMenuItem";
            this.dOCXChartEditorExampleToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.dOCXChartEditorExampleToolStripMenuItem.Text = "DOCX Chart Editor Example";
            this.dOCXChartEditorExampleToolStripMenuItem.Click += new System.EventHandler(this.docxChartEditorExampleToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 564);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VintaSoft Report Generator Demo";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem viewInPDFReaderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private Vintasoft.Imaging.UI.ImageViewer imageViewer1;
        private System.Windows.Forms.Panel panel2;
        private DemosCommonCode.Imaging.ImageViewerToolStrip imageViewerToolStrip1;
        private System.Windows.Forms.ToolStripMenuItem generateInvoiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemsCountToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox itemsCountComboBox;
        private System.Windows.Forms.ToolStripMenuItem generateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorTableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadedAssembliesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewInOfficeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateXLSXTemplateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem examplesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dOCXEditorEampleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xLSXEditorExamleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generatePricelistToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateDOCXTemplateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generatePriceListXLSXTemplateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dOCXChartEditorExampleToolStripMenuItem;
    }
}