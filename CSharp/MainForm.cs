using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

using Vintasoft.Imaging;
using Vintasoft.Imaging.UI.VisualTools;
using Vintasoft.Imaging.Office.OpenXml.Editor;
using Vintasoft.Imaging.Codecs.Decoders;
using Vintasoft.Imaging.Codecs.Encoders;

using DemosCommonCode;
using DemosCommonCode.Imaging.Codecs;
using DemosCommonCode.Imaging;
using Vintasoft.Imaging.Office.OpenXml.Editor.Xlsx;
using Vintasoft.Imaging.Office.OpenXml.Editor.Docx;

namespace ReportGeneratorDemo
{
    /// <summary>
    /// Main form of Report Generator Demo.
    /// </summary>
    public partial class MainForm : Form
    {

        #region Fields

        /// <summary>
        /// Template of application title.
        /// </summary>
        internal static string Title = string.Format("VintaSoft Report Generator Demo v{0}", ImagingGlobalSettings.ProductVersion);

        /// <summary>
        /// The OpenXML document editor.
        /// </summary>
        OpenXmlDocumentEditor _documentEditor;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            // register the evaluation license for VintaSoft Imaging .NET SDK
            Vintasoft.Imaging.ImagingGlobalSettings.Register("REG_USER", "REG_EMAIL", "EXPIRATION_DATE", "REG_CODE");

            InitializeComponent();

            DemosTools.CatchVisualToolExceptions(imageViewer1);

            Text = Title;

            // create text selection tool
            TextSelectionTool textSelectionTool = new TextSelectionTool();
            textSelectionTool.IsKeyboardSelectionEnabled = true;
            textSelectionTool.IsMouseSelectionEnabled = true;

            // create document navigation tool
            DocumentNavigationTool navigationTool = new DocumentNavigationTool();
            navigationTool.ActionExecutor = new PageContentActionCompositeExecutor(new UriActionExecutor(), navigationTool.ActionExecutor);

            // set viewer tool as composition of document navigation tool and text selection tool
            imageViewer1.VisualTool = new CompositeVisualTool(navigationTool, textSelectionTool);
        }

        #endregion



        #region Methods

        #region 'File' menu

        /// <summary>
        /// Handles the Click event of saveAsToolStripMenuItem object.
        /// </summary>
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // get document editor
                OpenXmlDocumentEditor documentEditor = _documentEditor;
                // if document editor exists
                if (documentEditor != null)
                {
                    // set the filters for "Save file" dialog

                    CodecsFileFilters.SetSaveFileDialogFilter(saveFileDialog, true, false);
                    if (documentEditor is DocxDocumentEditor)
                        saveFileDialog.Filter += "|DOCX Documents|*.docx";
                    else
                        saveFileDialog.Filter += "|XLSX Documents|*.xlsx";
                    saveFileDialog.FilterIndex = 3;

                    // if "Ok" button is clicked in "Save file" dialog
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // get extension of saving file
                        string fileExtension = Path.GetExtension(saveFileDialog.FileName).ToUpperInvariant();
                        // if DOCX document must be created
                        if (fileExtension == ".DOCX")
                        {
                            // if document editore is NOT DOCX document editor
                            if (!(documentEditor is DocxDocumentEditor))
                            {
                                throw new InvalidOperationException("DOCX editor is not created.");
                            }

                            // save DOCX file
                            documentEditor.Save(saveFileDialog.FileName);
                        }
                        // if XLSX document must be created
                        else if (fileExtension == ".XLSX")
                        {
                            // if document editore is NOT XLSX document editor
                            if (!(documentEditor is XlsxDocumentEditor))
                            {
                                throw new InvalidOperationException("XLSX editor is not created.");
                            }

                            // save XLSX file
                            documentEditor.Save(saveFileDialog.FileName);
                        }
                        // if PDF document must be created
                        else if (fileExtension == ".PDF")
                        {
                            // export document to PDF file
                            ExportToPdf(documentEditor, saveFileDialog.FileName);
                        }
                        // if image file must be created
                        else
                        {
                            RenderingSettings rendringSettings = new RenderingSettings(new Resolution(200));
                            documentEditor.Export(saveFileDialog.FileName, new DocumentLayoutSettings(), rendringSettings);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Handles the Click event of viewInPDFReaderToolStripMenuItem object.
        /// </summary>
        private void viewInPDFReaderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // get document editor
                OpenXmlDocumentEditor documentEditor = _documentEditor;
                // if document editor exists
                if (documentEditor != null)
                {
                    string filename = "temp.pdf";
                    // export document to PDF file
                    ExportToPdf(documentEditor, filename);

                    // open PDF file in default system PDF reader
                    ProcessStartInfo processInfo = new ProcessStartInfo(filename);
                    processInfo.UseShellExecute = true;
                    Process.Start(processInfo);
                }
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Handles the Click event of viewInOfficeToolStripMenuItem object.
        /// </summary>
        private void viewInOfficeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // get document editor
                OpenXmlDocumentEditor documentEditor = _documentEditor;
                // if document editor exists
                if (documentEditor != null)
                {
                    string filename = documentEditor is DocxDocumentEditor ? "temp.docx" : "temp.xlsx";
                    // save document to DOCX/XLSX file
                    documentEditor.Save(filename);

                    // open DOCX/XLSX in default system application
                    ProcessStartInfo processInfo = new ProcessStartInfo(filename);
                    processInfo.UseShellExecute = true;
                    Process.Start(processInfo);
                }
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Handles the Click event of exitToolStripMenuItem object.
        /// </summary>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion


        #region 'Generate Report' menu

        /// <summary>
        /// Handles the Click event of tableBasedColorTableToolStripMenuItem object.
        /// </summary>
        private void tableBasedColorTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // open template DOCX document for "Color table" report
            using (Stream templateStream = DemosResourcesManager.GetResourceAsStream("ColorTable_template.docx"))
            {
                // create DOCX editor
                DocxDocumentEditor editor = CreateDocxEditor(templateStream);

                // generate "Color table" report
                ColorTableReport.Generate(editor, System.Drawing.Color.Blue, System.Drawing.Color.Lime);

                // display generated report in image viewer 
                DisplayDocument(editor);
            }
        }

        /// <summary>
        /// Handles the Click event of loadedAssembliesToolStripMenuItem object.
        /// </summary>
        private void loadedAssembliesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // open template DOCX document for "Loaded Assemblies" report
            using (Stream templateStream = DemosResourcesManager.GetResourceAsStream("LoadAssemblies_template.docx"))
            {
                // create DOCX editor
                DocxDocumentEditor editor = CreateDocxEditor(templateStream);

                // generate "Loaded Assemblies" report
                LoadedAssembliesReport.Generate(editor);

                // display generated report in image viewer 
                DisplayDocument(editor);
            }
        }

        #endregion


        #region 'Generate invoice' menu

        /// <summary>
        /// Handles the Click event of generateInvoiceDOCXToolStripMenuItem object.
        /// </summary>
        private void generateInvoiceDOCXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // open template DOCX document for invoice
                using (Stream templateStream = DemosResourcesManager.GetResourceAsStream("Invoice_template.docx"))
                {
                    // create DOCX editor
                    DocxDocumentEditor editor = CreateDocxEditor(templateStream);

                    // generate invoice
                    DocxInvoiceGenerator.Generate(editor, int.Parse(itemsCountComboBox.Text));

                    // display generated invoice in image viewer 
                    DisplayDocument(editor);
                }
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Handles the Click event of generateInvoiceXLSXTemplateToolStripMenuItem object.
        /// </summary>
        private void generateInvoiceXLSXTemplateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // open template XLSX document for invoice
                using (Stream templateStream = DemosResourcesManager.GetResourceAsStream("Invoice_template.xlsx"))
                {
                    // create XLSX editor
                    XlsxDocumentEditor editor = CreateXlsxEditor(templateStream);

                    // generate invoice
                    XlsxInvoiceGenerator.Generate(editor, int.Parse(itemsCountComboBox.Text));

                    // display generated invoice in image viewer 
                    DisplayDocument(editor);
                }
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }

        #endregion


        #region 'Generate Pricelist' menu

        /// <summary>
        /// Handles the Click event of generatePriceListDOCXTemplateToolStripMenuItem object.
        /// </summary>
        private void generatePriceListDOCXTemplateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // open template DOCX document for price list
                using (Stream templateStream = DemosResourcesManager.GetResourceAsStream("PriceList_template.docx"))
                {
                    // create DOCX editor
                    DocxDocumentEditor editor = CreateDocxEditor(templateStream);

                    // generate invoice
                    DocxPriceListGenerator.Generate(editor);

                    // display generated invoice in image viewer 
                    DisplayDocument(editor);
                }
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Handles the Click event of generatePriceListXLSXTemplateToolStripMenuItem object.
        /// </summary>
        private void generatePriceListXLSXTemplateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // open template XLSX document for price list
                using (Stream templateStream = DemosResourcesManager.GetResourceAsStream("PriceList_template.xlsx"))
                {
                    // create DOCX editor
                    XlsxDocumentEditor editor = CreateXlsxEditor(templateStream);

                    // generate invoice
                    XlsxPriceListGenerator.Generate(editor);

                    // display generated invoice in image viewer 
                    DisplayDocument(editor);
                }
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }

        #endregion


        #region 'Examples' menu

        /// <summary>
        /// Handles the Click event of docxEditorExampleToolStripMenuItem object.
        /// </summary>
        private void docxEditorExampleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // open template DOCX document for example DOCX document
                using (Stream templateStream = DemosResourcesManager.GetResourceAsStream("Example_template.docx"))
                {
                    // create DOCX editor
                    DocxDocumentEditor editor = CreateDocxEditor(templateStream);

                    // generate example DOCX document
                    DocxEditorExample.Generate(editor);

                    // display example DOCX document in image viewer 
                    DisplayDocument(editor);
                }
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Handles the Click event of xlsxEditorExamleToolStripMenuItem object.
        /// </summary>
        private void xlsxEditorExamleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // open template XLSX document for example XLSX document
                using (Stream templateStream = DemosResourcesManager.GetResourceAsStream("Example_template.xlsx"))
                {
                    // create XLSX editor
                    XlsxDocumentEditor editor = CreateXlsxEditor(templateStream);

                    // generate example XLSX document
                    XlsxEditorExample.Generate(editor);

                    // display example XLSX document in image viewer 
                    DisplayDocument(editor);
                }
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }


        /// <summary>
        /// Handles the Click event of docxChartEditorExampleToolStripMenuItem object.
        /// </summary>
        private void docxChartEditorExampleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // open template DOCX document for example DOCX document
                using (Stream templateStream = DemosResourcesManager.GetResourceAsStream("Chart_template.docx"))
                {
                    // create DOCX editor
                    DocxDocumentEditor editor = CreateDocxEditor(templateStream);

                    // generate example DOCX document
                    DocxChartEditExample.Generate(editor);

                    // display example DOCX document in image viewer 
                    DisplayDocument(editor);
                }
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }

        #endregion


        #region 'Help' menu

        /// <summary>
        /// Handles the Click event of aboutToolStripMenuItem object.
        /// </summary>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AboutBoxForm aboutDialog = new AboutBoxForm())
            {
                aboutDialog.ShowDialog();
            }
        }

        #endregion


        #region Common

        /// <summary>
        /// Exports document to a PDF file.
        /// </summary>
        /// <param name="documentEditor">The document editor.</param>
        /// <param name="filename">The PDF filename.</param>
        private void ExportToPdf(OpenXmlDocumentEditor documentEditor, string filename)
        {
            PdfEncoder encoder = new PdfEncoder();

            encoder.Settings.Compression = PdfImageCompression.Auto;

            encoder.Settings.JpegQuality = 90;

            documentEditor.Export(filename, encoder);
        }


        /// <summary>
        /// Creates DOCX document editor on specified stream.
        /// </summary>
        /// <param name="stream">The stream that contains DOCX document.</param>
        private DocxDocumentEditor CreateDocxEditor(Stream stream)
        {
            if (_documentEditor != null)
                _documentEditor.Dispose();

            DocxDocumentEditor documentEditor = new DocxDocumentEditor(stream);
            SetDocumentProperties(documentEditor);

            _documentEditor = documentEditor;

            return documentEditor;
        }

        /// <summary>
        /// Creates XLSX document editor on specified stream.
        /// </summary>
        /// <param name="stream">The stream that contains XLSX document.</param>
        private XlsxDocumentEditor CreateXlsxEditor(Stream stream)
        {
            if (_documentEditor != null)
                _documentEditor.Dispose();

            XlsxDocumentEditor documentEditor = new XlsxDocumentEditor(stream);
            SetDocumentProperties(documentEditor);

            _documentEditor = documentEditor;

            return documentEditor;
        }

        /// <summary>
        /// Sets the document properties.
        /// </summary>
        /// <param name="documentEditor">The document editor.</param>
        private void SetDocumentProperties(OpenXmlDocumentEditor documentEditor)
        {
            documentEditor.DocumentProperties.Creator = Title;
            documentEditor.DocumentProperties.LastModifiedBy = Environment.UserName;
        }


        /// <summary>
        /// Dispalys document.
        /// </summary>
        /// <param name="documentEditor">The document editor.</param>
        private void DisplayDocument(OpenXmlDocumentEditor documentEditor)
        {
            Stream documentStream = new MemoryStream();
            documentEditor.Save(documentStream);

            imageViewer1.Images.ClearAndDisposeItems();
            imageViewer1.Images.Add(documentStream, true);

            EnableSaveMenu();
        }

        /// <summary>
        /// Enables the save/view menu.
        /// </summary>
        private void EnableSaveMenu()
        {
            saveAsToolStripMenuItem.Enabled = true;
            viewInOfficeToolStripMenuItem.Enabled = true;
            viewInPDFReaderToolStripMenuItem.Enabled = true;
        }





        #endregion

        #endregion

    }
}
