using System.Drawing;
using System.Linq;
using Vintasoft.Imaging;
using Vintasoft.Imaging.ImageProcessing.Color;
using Vintasoft.Imaging.Office.OpenXml.Editor;
using Vintasoft.Imaging.Office.OpenXml.Editor.Docx;
using Vintasoft.Imaging.Utils;

namespace ReportGeneratorDemo
{
    /// <summary>
    /// Demonstrates fuctionally of <see cref="DocxDocumentEditor"/> class.
    /// </summary>
    public static class DocxEditorExample
    {

        /// <summary>
        /// Generates DOCX document using DOCX document editor.
        /// </summary>
        /// <param name="documentEditor">The DOCX document editor.</param>
        public static void Generate(DocxDocumentEditor documentEditor)
        {
            OpenXmlDocumentElement documentBody = documentEditor.Body;
            OpenXmlDocumentTable[] documentTables = documentEditor.Tables;

            OpenXmlTextProperties grayTextProperties = new OpenXmlTextProperties();
            grayTextProperties.Color = Color.Gray;

            // set Headers and Footers
            OpenXmlDocumentElement header = documentEditor.CreateHeader();
            header.Text = string.Format("VintaSoft Office .NET Plugin, DOCX Editor Example. {0}", System.DateTime.Now);
            header.SetTextProperties(grayTextProperties);
            OpenXmlDocumentElement footer = documentEditor.CreateFooter();
            footer.Text = "VintaSoft Imaging .NET SDK";
            footer.SetTextProperties(grayTextProperties);
            footer.SetTextProperties(OpenXmlTextProperties.BoldText);
            documentEditor.SetHeaderFooterConfiguration(header, footer);

            //
            // 1. Text replace.
            //

            // replace first occurrence
            documentBody["[field1]"] = "value1";

            // replace all occurrences
            documentBody.ReplaceText("[field2]", "value2");

            // get text content that corresponds to the [field3] and set text
            OpenXmlTextContent field3Content = documentBody.FindText("[field3]");
            field3Content.Text = "value3";

            // replace field to the multiline text
            documentBody["[multiline_field]"] = "\nline1\nline2\nline3";


            //
            // 2. Change text properties.
            //

            // set text color
            documentBody.FindText("COLOR").Substring(0, 2).SetTextProperties(CreateColorTextProperties(Color.Red));
            documentBody.FindText("COLOR").Substring(2, 1).SetTextProperties(CreateColorTextProperties(Color.Green));
            documentBody.FindText("COLOR").Substring(3, 2).SetTextProperties(CreateColorTextProperties(Color.Blue));

            // highlight text
            OpenXmlTextProperties highlightedTextProperties = new OpenXmlTextProperties();
            highlightedTextProperties.Highlight = OpenXmlTextHighlightType.Green;
            documentBody.FindText("highlighted text").SetTextProperties(highlightedTextProperties);

            // set text "bold text" as bold text
            documentBody.FindText("bold text").SetTextProperties(OpenXmlTextProperties.BoldText);

            // set text "italic text" as italic text
            documentBody.FindText("italic text").SetTextProperties(OpenXmlTextProperties.ItalicText);

            // set text "underline text" as underline text
            OpenXmlTextProperties underlineTextProperties = new OpenXmlTextProperties();
            underlineTextProperties.Underline = OpenXmlTextUnderlineType.Single;
            underlineTextProperties.UnderlineColor = Color.Red;
            documentBody.FindText("underline text").SetTextProperties(underlineTextProperties);

            // set text "strike text" as striked out text
            documentBody.FindText("strike text").SetTextProperties(OpenXmlTextProperties.StrikeText);

            // change font size
            OpenXmlTextProperties setTextSize = new OpenXmlTextProperties();
            setTextSize.FontSize = 16;
            documentBody.FindText("text with size 16pt").Substring(0, 4).SetTextProperties(setTextSize);

            // change text style
            OpenXmlTextProperties setTextStyle = new OpenXmlTextProperties();
            setTextStyle.Style = documentEditor.Styles.FindByName("RedStyle");
            documentBody.FindText("RedStyle").SetTextProperties(setTextStyle);

            // change character spacing
            OpenXmlTextProperties setCharacterSpacing = new OpenXmlTextProperties();
            setCharacterSpacing.CharacterSpacing = 2;
            documentBody.FindText("spacing is 2pt").FindText("spacing").SetTextProperties(setCharacterSpacing);
            setCharacterSpacing.CharacterSpacing = -1;
            documentBody.FindText("spacing is -1pt").FindText("spacing").SetTextProperties(setCharacterSpacing);

            // change character horizontal scaling
            OpenXmlTextProperties setCharacterHorizontalScaling = new OpenXmlTextProperties();
            setCharacterHorizontalScaling.CharacterHorizontalScaling = 0.5f;
            documentBody.FindText("horizontal scaling is 0.5").FindText("horizontal scaling").SetTextProperties(setCharacterHorizontalScaling);
            setCharacterHorizontalScaling.CharacterHorizontalScaling = 2;
            documentBody.FindText("horizontal scaling is 2").FindText("horizontal scaling").SetTextProperties(setCharacterHorizontalScaling);

            //
            // 3. Change paragraph properties.
            //
            // set paragraph justification
            OpenXmlParagraphProperties justificationParagraphProperties = new OpenXmlParagraphProperties();
            justificationParagraphProperties.Justification = OpenXmlParagraphJustification.Left;
            documentBody.FindText("Left Justification").SetParagraphProperties(justificationParagraphProperties);
            justificationParagraphProperties.Justification = OpenXmlParagraphJustification.Center;
            documentBody.FindText("Center Justification").SetParagraphProperties(justificationParagraphProperties);
            justificationParagraphProperties.Justification = OpenXmlParagraphJustification.Right;
            documentBody.FindText("Right Justification").SetParagraphProperties(justificationParagraphProperties);

            // set paragraph properties
            OpenXmlParagraphProperties indentationParagraphProperties = new OpenXmlParagraphProperties();
            indentationParagraphProperties.SpacingBeforeParagraph = 10;
            indentationParagraphProperties.FirstLineIndentation = 50;
            indentationParagraphProperties.RightIndentation = 50;
            indentationParagraphProperties.LeftIndentation = 100;
            indentationParagraphProperties.FillColor = Color.LightBlue;
            indentationParagraphProperties.Justification = OpenXmlParagraphJustification.Both;
            documentBody.FindText("This paragraph has left indentation 100pt").SetParagraphProperties(indentationParagraphProperties);

            // set numbering properties
            OpenXmlParagraphProperties numberingParagraphProperties = new OpenXmlParagraphProperties();
            numberingParagraphProperties.LeftIndentation = 50;
            numberingParagraphProperties.Numeration = documentEditor.Numbering.Items[4];
            OpenXmlTextContent textContent = documentBody.FindText("This is numbering list:");
            OpenXmlDocumentParagraph paragraph = textContent.GetParagraphs().Last();
            for (int itemNumber = 1; itemNumber <= 5; itemNumber++)
            {
                paragraph = (OpenXmlDocumentParagraph)paragraph.InsertCopyAfterSelf();
                paragraph.Text = "Item " + itemNumber;
                paragraph.SetParagraphProperties(numberingParagraphProperties);
            }

            //
            // 4. Copy table row
            //

            OpenXmlDocumentTable table = documentTables[0];
            OpenXmlDocumentTableRow templateRow = table[1];
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
                if ((i % 2) == 1)
                {
                    // set row height to 10mm
                    rowCopy.Height = UnitOfMeasureConverter.ConvertToPoints(10, Vintasoft.Imaging.UnitOfMeasure.Millimeters);
                }
            }

            // remove template row
            templateRow.Remove();


            //
            // 5. Copy table border properties from another table.
            //

            // get cell border templates
            OpenXmlDocumentTable bordersTemplateTable = documentTables[1];
            OpenXmlDocumentTableCell boldBorderTemplate = bordersTemplateTable.FindCell("[bold]");
            OpenXmlDocumentTableCell colorBorderTemplate = bordersTemplateTable.FindCell("[color]");

            // remove border template table
            bordersTemplateTable.Remove();

            // get test table
            table = documentTables[2];

            // set borders from template cells
            table.FindRow("[bold_row]").SetBorder(boldBorderTemplate);
            table.FindCell("[bold_cell]").SetBorder(boldBorderTemplate);
            table.FindRow("[color_row]").SetBorder(colorBorderTemplate);
            table.FindCell("[color_cell]").SetBorder(colorBorderTemplate);

            // set outside border inside table
            table.SetOutsideBorder(table.FindCell("[bold_first]"), table.FindCell("[bold_last]"), boldBorderTemplate);

            //
            // 6. Set hyperlink in text.
            //
            OpenXmlTextContent hyperlinkTextContent = documentBody.FindText("VintaSoft Web Site");
            documentEditor.SetHyperlink(hyperlinkTextContent, "https://www.vintasoft.com");
            OpenXmlTextProperties hyperlinkTextProperties = new OpenXmlTextProperties();
            hyperlinkTextProperties.IsUnderline = true;
            hyperlinkTextProperties.Color = Color.Blue;
            hyperlinkTextContent.SetTextProperties(hyperlinkTextProperties);

            //
            // 7. Change and delete image.
            //

            // find image after text "image must be inverted:"
            OpenXmlDocumentImage imageElement = documentBody.FindText("image must be inverted:").FindAfter<OpenXmlDocumentImage>();
            // gets as VintasoftImage from image element
            using (VintasoftImage image = imageElement.GetImage())
            {
                // invert image
                InvertCommand invert = new InvertCommand();
                invert.ExecuteInPlace(image);

                // set image of image element as new resource
                imageElement.SetImage(image, true);
            }

            // remove image that is located after "image must be deleted:" text
            documentBody.FindText("image must be deleted:").FindAfter<OpenXmlDocumentImage>().Remove();
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
