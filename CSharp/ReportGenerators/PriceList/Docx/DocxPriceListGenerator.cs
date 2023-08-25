using System;
using System.IO;

using DemosCommonCode;

using Vintasoft.Imaging.Office.OpenXml.Editor;
using Vintasoft.Imaging.Office.OpenXml.Editor.Docx;

namespace ReportGeneratorDemo
{
    /// <summary>
    /// Generates DOCX price list.
    /// </summary>
    public static class DocxPriceListGenerator
    {

        /// <summary>
        /// Generates price list using the DOCX document editor.
        /// </summary>
        /// <param name="documentEditor">The DOCX document editor.</param>
        public static void Generate(DocxDocumentEditor documentEditor)
        {
            // set current date in document
            documentEditor.Body["[date]"] = DateTime.Now.ToShortDateString();

            // get price list items
            PriceListItem[] priceListItems = TestPriceListData.GetTestData();

            // get price list table in document
            OpenXmlDocumentTable table = documentEditor.Tables[0];

            // get template row in document
            OpenXmlDocumentTableRow templateRow = table[1];
            int itemNumber = 1;
            // for each item in price list
            foreach (PriceListItem item in priceListItems)
            {
                // copy template row and insert copy after template row
                OpenXmlDocumentTableRow currentRow = templateRow;
                templateRow = (OpenXmlDocumentTableRow)templateRow.InsertCopyAfterSelf();

                // fill data in current row
                currentRow["[n]"] = itemNumber.ToString();
                currentRow["[product]"] = item.Product;
                currentRow["[price]"] = string.Format("{0:f2} EUR", item.Price);

                // get image object, which stores product image, in current row
                OpenXmlDocumentImage image = table.FindImages(currentRow)[0];
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
