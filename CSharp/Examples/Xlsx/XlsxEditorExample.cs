using System.Drawing;

using Vintasoft.Imaging;
using Vintasoft.Imaging.ImageProcessing.Color;
using Vintasoft.Imaging.Office.OpenXml.Editor;
using Vintasoft.Imaging.Office.OpenXml.Editor.Xlsx;
using Vintasoft.Imaging.Utils;

namespace ReportGeneratorDemo
{
    /// <summary>
    /// Demonstrates fuctionally of <see cref="XlsxDocumentEditor"/> class.
    /// </summary>
    public static class XlsxEditorExample
    {

        /// <summary>
        /// Generates XLSX document using XLSX document editor.
        /// </summary>
        /// <param name="documentEditor">The XLSX document editor.</param>
        public static void Generate(XlsxDocumentEditor documentEditor)
        {
            // gets first sheet
            XlsxDocumentSheet sheet = documentEditor.Sheets[0];

            // set the sheet name
            sheet.Name = "XLSX Editor Examples";


            //
            // 1. Text replace.
            //

            // replace first occurrence
            sheet["[sheet_name]"] = sheet.Name;
            sheet["[field1]"] = "value1";

            // replace all occurrences
            sheet.ReplaceText("[field2]", "value2");

            // get text content that corresponds to the [field3] and set text
            OpenXmlTextContent field3Content = sheet.FindText("[field3]");
            field3Content.Text = "value3";

            // replace field to the multiline text
            sheet["[multiline_field]"] = "\nline1\nline2\nline3";


            //
            // 2. Change text properties.
            //

            // set text color
            sheet.FindText("COLOR").Substring(0, 2).SetTextProperties(CreateColorTextProperties(Color.Red));
            sheet.FindText("COLOR").Substring(2, 1).SetTextProperties(CreateColorTextProperties(Color.Green));
            sheet.FindText("COLOR").Substring(3, 2).SetTextProperties(CreateColorTextProperties(Color.Blue));

            // set text "bold text" as bold text
            sheet.FindText("bold text").SetTextProperties(OpenXmlTextProperties.BoldText);

            // set text "italic text" as italic text
            sheet.FindText("italic text").SetTextProperties(OpenXmlTextProperties.ItalicText);

            // set text "underline text" as underline text
            sheet.FindText("underline text").SetTextProperties(OpenXmlTextProperties.UnderlineText);

            // set text "strike text" as striked out text
            sheet.FindText("strike text").SetTextProperties(OpenXmlTextProperties.StrikeText);

            // change font size
            OpenXmlTextProperties setTextSize = new OpenXmlTextProperties();
            setTextSize.FontSize = 16;
            sheet.FindText("text with size 16pt").Substring(0, 4).SetTextProperties(setTextSize);


            //
            // 3. Find cell by reference (A1 format).
            //

            sheet.FindCellByName("B11").SetFillColor(Color.Red);
            sheet.FindCellByName("D11").SetFillColor(Color.Yellow);
            sheet.FindCellByName("C12").SetFillColor(Color.Green);
            sheet.FindCellByName("D13").SetFillColor(Color.Blue);
            sheet.FindCellByName("B13").SetFillColor(Color.Pink);


            //
            // 4. Set cell formula.
            //

            XlsxDocumentSheetCell cellD16 = sheet.FindCellByName("D16");
            cellD16.Formula = "SUM(B16,C16)";
            cellD16.Number = sheet.FindCellByName("B16").Number + sheet.FindCellByName("C16").Number;


            //
            // 5. Copy table row
            //

            OpenXmlDocumentTableRow templateRow = sheet.FindRow("[cell1]");
            Color[] colors = new Color[] { Color.Red, Color.Green, Color.Blue, Color.Orange, Color.Yellow };
            for (int i = 0; i < colors.Length; i++)
            {
                // insert copy of template row before template row
                OpenXmlDocumentTableRow rowCopy = (OpenXmlDocumentTableRow)templateRow.InsertCopyBeforeSelf();

                // set row data
                rowCopy[0].Text = string.Format("Copy {0} ({1})", i, colors[i]);
                rowCopy["[cell1]"] = string.Format("cell data {0}", i);

                // set cell colors
                rowCopy[1].SetFillColor(colors[i]);
                rowCopy[2].SetFillColor(colors[i]);

                // if color has odd index in colors array
                if (i % 2 == 1)
                {
                    // set row height to 10mm
                    rowCopy.Height = UnitOfMeasureConverter.ConvertToPoints(10, Vintasoft.Imaging.UnitOfMeasure.Millimeters);
                }
            }

            // remove template row
            templateRow.Remove();


            //
            // 6. Copy cell border properties.
            //

            // get cell border templates
            OpenXmlDocumentTableCell boldBorderTemplate = sheet.FindCell("[bold]");
            OpenXmlDocumentTableCell colorBorderTemplate = sheet.FindCell("[color]");

            // set borders from template cells
            sheet.FindCell("[bold_cell]").SetBorder(boldBorderTemplate);
            sheet.FindCell("[color_cell]").SetBorder(colorBorderTemplate);

            // set outside border inside table
            sheet.SetOutsideBorder(sheet.FindCell("[color_first]"), sheet.FindCell("[color_last]"), colorBorderTemplate);
            sheet.SetOutsideBorder(sheet.FindCell("[bold_first]"), sheet.FindCell("[bold_last]"), boldBorderTemplate);

            // remove border template table
            OpenXmlDocumentElement removingRow = boldBorderTemplate.Row.Prev;
            for (int i = 0; i < 5; i++)
            {
                OpenXmlDocumentElement row = removingRow;
                removingRow = removingRow.Next;
                row.Remove();
            }


            //
            // 7. Change and delete image.
            //

            // find image in row that contains text "image must be inverted:"
            OpenXmlDocumentImage imageElement = sheet.FindImages(sheet.FindRow("image must be inverted:"))[0];
            // gets as VintasoftImage from image element
            using (VintasoftImage image = imageElement.GetImage())
            {
                // invert image
                InvertCommand invert = new InvertCommand();
                invert.ExecuteInPlace(image);

                // set image of image element as new resource
                imageElement.SetImage(image, true);
            }

            // remove image in row that contains text "image must be deleted:"
            sheet.FindImages(sheet.FindRow("image must be deleted:"))[0].Remove();
        }

        /// <summary>
        /// Creates the color text properties.
        /// </summary>
        /// <param name="color">The color.</param>
        private static OpenXmlTextProperties CreateColorTextProperties(Color color)
        {
            OpenXmlTextProperties result = new OpenXmlTextProperties();
            result.Color = color;
            return result;
        }

    }
}
