using System.Drawing;
using Vintasoft.Imaging.ImageColors;
using Vintasoft.Imaging.Office.OpenXml.Editor;
using Vintasoft.Imaging.Office.OpenXml.Editor.Docx;

namespace ReportGeneratorDemo
{
    /// <summary>
    /// Example that shows how to edit chart data.
    /// </summary>
    public static class DocxChartEditExample
    {

        /// <summary>
        /// Generates DOCX document with chart using the DOCX document editor.
        /// </summary>
        /// <param name="documentEditor">The DOCX document editor.</param>
        public static void Generate(DocxDocumentEditor documentEditor)
        {
            // colors, which must be displayed in chart
            Color[] colors = new Color[] {
                Color.Gray,
                Color.Red,
                Color.LightGreen,
                Color.Blue,
                Color.YellowGreen,
                Color.MediumAquamarine
            };

            // text of series
            string[] seriesText = new string[colors.Length];
            for (int i = 0; i < seriesText.Length; i++)
                seriesText[i] = colors[i].Name;

            // text of categories
            string[] categoriesText = new string[] { "Red channel", "Green channel", "Blue channel", "Luminance" };

            // create table of values
            double?[,] values = new double?[categoriesText.Length, seriesText.Length];
            for (int serIndex = 0; serIndex < colors.Length; serIndex++)
            {
                values[0, serIndex] = colors[serIndex].R;
                values[1, serIndex] = colors[serIndex].G;
                values[2, serIndex] = colors[serIndex].B;
                values[3, serIndex] = ColorBase.GetLuminance(colors[serIndex].R, colors[serIndex].G, colors[serIndex].B);
            }

            // for each chart in document
            foreach (OpenXmlDocumentChart chart in documentEditor.Charts)
            {
                // set chart title
                chart.Title = "Red/Green/Blue/Lum of a colors: " + chart.Title;

                // set chart data
                chart.ChartData.SetData(seriesText, categoriesText, values);

                // set colors of series
                OpenXmlDocumentChartDataSeries[] series = chart.ChartData.GetSeries();
                for (int i = 0; i < seriesText.Length; i++)
                {
                    series[i].SetFillColor(colors[i]);
                }
            }
        }

    }
}
