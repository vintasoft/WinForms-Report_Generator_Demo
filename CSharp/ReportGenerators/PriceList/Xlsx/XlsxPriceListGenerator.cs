using System;
using System.IO;

using DemosCommonCode;

using Vintasoft.Imaging.Office.OpenXml.Editor;
using Vintasoft.Imaging.Office.OpenXml.Editor.Xlsx;

namespace ReportGeneratorDemo
{
    /// <summary>
    /// Generates XLSX price list.
    /// </summary>
    public static class XlsxPriceListGenerator
    {
        /// <summary>
        /// Generates price list using the XLSX document editor.
        /// </summary>
        /// <param name="documentEditor">The XLSX document editor.</param>
        public static void Generate(XlsxDocumentEditor documentEditor)
        {
            // set current date in document
            documentEditor.Body["[date]"] = DateTime.Now.ToShortDateString();

            // get price list items
            PriceListItem[] priceListItems = TestPriceListData.GetTestData();

            // get the first sheet in document
            XlsxDocumentSheet sheet = documentEditor.Sheets[0];

            // get template row in document
            XlsxDocumentSheetRow templateRow = sheet.FindRow("[n]");
            int itemNumber = 1;
            // for each item in price list
            foreach (PriceListItem item in priceListItems)
            {
                // copy template row and insert copy after template row
                XlsxDocumentSheetRow currentRow = templateRow;
                templateRow = (XlsxDocumentSheetRow)templateRow.InsertCopyAfterSelf();

                // fill data in current row
                currentRow.FindCell("[n]").Number = itemNumber;
                currentRow.FindCell("[product]").Text = item.Product;
                currentRow.FindCell("[price]").Number = item.Price;

                // get image object, which stores product image, in current row
                OpenXmlDocumentImage image = sheet.FindImages(currentRow)[0];
                // if product has image
                if (!string.IsNullOrEmpty(item.ImageId))
                {
                    // get product image from resource
                    using (Stream imageStream = DemosResourcesManager.GetResourceAsStream(item.ImageId))
                    {
                        // set product image in image object
                        image.SetImage(imageStream);
                    }
                }
                else
                {
                    // remove image object from current row
                    image.Remove();
                }

                itemNumber++;
            }
            
            // remove template row from result document
            templateRow.Remove();
        }
    }
}
