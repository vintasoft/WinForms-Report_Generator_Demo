using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

using Vintasoft.Imaging.Office.OpenXml.Editor;
using Vintasoft.Imaging.Office.OpenXml.Editor.Docx;

namespace ReportGeneratorDemo
{
    /// <summary>
    /// Generates "Loaded Assemblies" report.
    /// </summary>
    public static class LoadedAssembliesReport
    {

        /// <summary>
        /// Generates report uses specified document editor.
        /// </summary>
        /// <param name="documentEditor">The document editor.</param>
        public static void Generate(DocxDocumentEditor documentEditor)
        {
            // set date/time fields
            documentEditor.Body["%DATE%"] = DateTime.Now.ToShortDateString();
            documentEditor.Body["%TIME%"] = DateTime.Now.ToShortTimeString();

            // get data table
            OpenXmlDocumentTable table = documentEditor.Tables[0];
            OpenXmlDocumentTable borderTemplateTable = documentEditor.Tables[1];

            // get row template
            OpenXmlDocumentTableRow rowTemplate = table[2];

            // get loaded assemblies
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

            // for each loaded assembly
            int assemblyNumber = 0;
            foreach (Assembly assembly in assemblies)
            {
                // assembly number
                assemblyNumber++;

                // create current row from row template                
                OpenXmlDocumentTableRow currentRow = (OpenXmlDocumentTableRow)rowTemplate.InsertCopyBeforeSelf();

                // get row data for current assembly
                Dictionary<string, TableCellData> rowData = GetTableRowData(assembly, assemblyNumber);

                // fill row data
                foreach (string key in rowData.Keys)
                {
                    // set cell properties for specified key (text, font properties, fill color)
                    rowData[key].Set(currentRow.FindCell(key));
                }

                // if assembly has entry point
                if (assembly.EntryPoint != null)
                {
                    // set all text to bold in current row
                    currentRow.SetTextProperties(OpenXmlTextProperties.BoldText);

                    // set row border from %ENTRY_POINT_ROW_BORDER% cell of border template table
                    currentRow.SetBorder(borderTemplateTable.FindCell("%ENTRY_POINT_ROW_BORDER%"));
                }
            }

            // remove row template
            rowTemplate.Remove();

            // remove border template table
            borderTemplateTable.Remove();
        }

        /// <summary>
        /// Returns table row data for specified assembly.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <param name="number">The assebly number.</param>
        /// <returns>Dictionary that contains row data.</returns>
        private static Dictionary<string, TableCellData> GetTableRowData(Assembly assembly, int number)
        {
            // table row data for assembly
            Dictionary<string, TableCellData> rowData = new Dictionary<string, TableCellData>();

            // number
            rowData["%N%"] = new TableCellData(number.ToString());

            // get assembly name
            AssemblyName name = assembly.GetName();

            // full name
            rowData["%FULL_NAME%"] = new TableCellData(name.ToString());

            // version
            rowData["%VERSION%"] = new TableCellData(name.Version.ToString());

            // architecture
            TableCellData architectureCell = new TableCellData(name.ProcessorArchitecture.ToString());
            if (name.ProcessorArchitecture != ProcessorArchitecture.MSIL)
            {
                // set fill color of current cell
                architectureCell.FillColor = Color.FromArgb(255, 128, 128);
            }
            rowData["%ARCHITECTURE%"] = architectureCell;

            // entry point
            TableCellData entryPointCell = new TableCellData();
            if (assembly.EntryPoint != null)
            {
                entryPointCell.Text = "YES";
                // set fill color of current cell
                entryPointCell.FillColor = Color.FromArgb(128, 255, 128);
                // set all text to bold text in current row
                entryPointCell.TextProperties = OpenXmlTextProperties.BoldText;
            }
            else
            {
                entryPointCell.Text = "NO";
            }
            rowData["%ENTRY_POINT%"] = entryPointCell;

            // GAC
            TableCellData gacCell = new TableCellData();
            if (assembly.GlobalAssemblyCache)
            {
                gacCell.Text = "YES";
                // set fill color of current cell
                gacCell.FillColor = Color.FromArgb(128, 255, 128);
            }
            else
            {
                gacCell.Text = "NO";
            }
            rowData["%GAC%"] = gacCell;

            // types
            rowData["%TYPES%"] = new TableCellData(assembly.GetTypes().Length.ToString());

            return rowData;
        }

    }
}
