using System;
using System.Drawing;

using Vintasoft.Imaging.Office.OpenXml.Editor;
using Vintasoft.Imaging.Office.OpenXml.Editor.Docx;

namespace ReportGeneratorDemo
{
    /// <summary>
    /// Generates "Color Table" report.
    /// </summary>
    public static class ColorTableReport
    {

        /// <summary>
        /// Generates DOCX report using DOCX document editor.
        /// </summary>
        /// <param name="documentEditor">The DOCX document editor.</param>
        /// <param name="fontSize">Size of the font.</param>
        /// <param name="fromColor">Start color.</param>
        /// <param name="toColor">End color.</param>
        public static void Generate(DocxDocumentEditor documentEditor, Color fromColor, Color toColor)
        {
            // set from/to fields
            documentEditor.Body["%FROM%"] = fromColor.ToString();
            documentEditor.Body["%TO%"] = toColor.ToString();

            // set date/time fields
            documentEditor.Body["%DATE%"] = DateTime.Now.ToShortDateString();
            documentEditor.Body["%TIME%"] = DateTime.Now.ToShortTimeString();

            // get data table
            OpenXmlDocumentTable table = documentEditor.Tables[0];

            // color table size
            int size = table[0].ChildElements.Count - 1;

            // add rows to the table
            for (int i = 0; i < size; i++)
                table[i].InsertCopyAfterSelf();

            // set text of first row and first column
            for (int i = 0; i < size; i++)
            {
                string val = Math.Round(100 * i / (float)(size - 1)).ToString();
                table[1 + i, 0].Text = val;
                table[0, 1 + i].Text = val;
            }

            // set cell colors
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    table[x + 1, y + 1].SetFillColor(GetColor(size, x, y, fromColor, toColor));
                }
            }
        }

        /// <summary>
        /// Gets the color of cell at specified location.
        /// </summary>
        /// <param name="tableSize">The table size.</param>
        /// <param name="x">X coordiante.</param>
        /// <param name="y">Y coordiante.</param>
        /// <param name="fromColor">Start color.</param>
        /// <param name="toColor">End color.</param>
        private static Color GetColor(int tableSize, int x, int y, Color fromColor, Color toColor)
        {
            float c = (float)(Math.Sqrt(x * x + y * y) / Math.Sqrt(2 * (tableSize - 1) * (tableSize - 1)));
            byte r = ToByte(fromColor.R + ((int)toColor.R - fromColor.R) * c);
            byte g = ToByte(fromColor.G + ((int)toColor.G - fromColor.G) * c);
            byte b = ToByte(fromColor.B + ((int)toColor.B - fromColor.B) * c);
            return Color.FromArgb(r, g, b);
        }

        /// <summary>
        /// Converts float value to byte.
        /// </summary>
        /// <param name="value">The value.</param>
        private static byte ToByte(float value)
        {
            int result = (int)Math.Round(value);
            if (result < 0)
                return 0;
            if (result > 255)
                return 255;
            return (byte)result;
        }

    }
}
