using System;
using System.Collections.Generic;

using Vintasoft.Imaging;
using Vintasoft.Imaging.Office.OpenXml.Editor;
using Vintasoft.Imaging.Office.OpenXml.Editor.Xlsx;

namespace ReportGeneratorDemo
{
    /// <summary>
    /// Generates XLSX invoice.
    /// </summary>
    public static class XlsxInvoiceGenerator
    {

        /// <summary>
        /// Generates XLSX invoice using XLSX document editor.
        /// </summary>
        /// <param name="documentEditor">The XLSX document editor.</param>
        /// <param name="fontSize">Size of the font.</param>
        /// <param name="itemCount">Invoice item count.</param>
        public static void Generate(XlsxDocumentEditor documentEditor, int itemCount)
        {
            // generate test data
            InvoiceData invoiceData = TestInvoiceData.GetTestData(itemCount);

#if !REMOVE_BARCODE_SDK
            // create QR code image 200x200 px
            using (VintasoftImage qrCodeImage = invoiceData.GetBarcodeImage(200))
            {
                // set barcode image to image element at index 1
                documentEditor.Images[1].SetImage(qrCodeImage);
            }
#endif

            // gets first sheet
            XlsxDocumentSheet sheet = documentEditor.Sheets[0];


            // fill the document header
            sheet["[company_name]"] = invoiceData.Company.CompanyName;
            sheet["[company_address]"] = invoiceData.Company.Address;
            sheet["[company_city]"] = invoiceData.Company.City;
            sheet["[company_phone]"] = invoiceData.Company.GetPhones();
            sheet["[invoice_number]"] = invoiceData.InvoiceNumber;
            sheet["[invoice_date]"] = DateTime.Now.ToShortDateString();


            // fill "Customer Information" table
            SetCompanyInformation(sheet, "billing", invoiceData.BillingAddress);
            SetCompanyInformation(sheet, "shipping", invoiceData.ShippingAddress);


            // fill "Shipping Method" table
            sheet["[shipping_method]"] = invoiceData.ShippingMethod;


            // cell with bold borders 
            OpenXmlDocumentTableCell boldBorderCell = sheet.FindCell("[bold]");
            // cell with normal borders 
            OpenXmlDocumentTableCell normalBorderCell = sheet.FindCell("[normal]");

            // fill "Order Information" table
            XlsxDocumentSheetRow templateRow = sheet.FindRow("[p_n]");
            int orderItemNumber = 1;
            List<OpenXmlDocumentTableRow> boldRows = new List<OpenXmlDocumentTableRow>();
            foreach (InvoiceItem orderItem in invoiceData.OrderItems)
            {
                // copy template row and insert copy after template row
                XlsxDocumentSheetRow currentRow = templateRow;
                templateRow = (XlsxDocumentSheetRow)templateRow.InsertCopyAfterSelf();

                // fill data of current row
                currentRow.FindCell("[p_n]").Number = orderItemNumber;
                currentRow.FindCell("[p_description]").Text = orderItem.Product;
                currentRow.FindCell("[p_qty]").Number = orderItem.Quantity;
                currentRow.FindCell("[p_unit_price]").Number = orderItem.Price;
                currentRow.FindCell("[p_price_total]").Number = orderItem.TotalPrice;

                // if order item quantity is greater than 8
                if (orderItem.Quantity > 8)
                {
                    // add row to a list of bold rows
                    boldRows.Add(currentRow);
                }

                // if item is first item
                if (orderItemNumber == 1)
                {
                    // set normal border for row template
                    templateRow.SetBorder(normalBorderCell, 0, 5);
                }

                orderItemNumber++;
            }
            // remove template row
            templateRow.Remove();
            // for each row in list of bold rows
            foreach (OpenXmlDocumentTableRow row in boldRows)
            {
                // use bold text in row
                row.SetTextProperties(OpenXmlTextProperties.BoldText);
                // use bold borders in row
                row.SetBorder(boldBorderCell, 0, 5);
            }
            // fill order information summary fields
            sheet.FindCell("[subtotal]").Number = invoiceData.Subtotal;
            sheet.FindCell("[tax]").Number = invoiceData.Tax;
            sheet.FindCell("[shipping]").Number = invoiceData.Shipping;
            sheet.FindCell("[grand_total]").Number = invoiceData.GrandTotal;

            // remove border template table
            OpenXmlDocumentElement removingRow = normalBorderCell.Row.Prev;
            for (int i = 0; i < 4; i++)
            {
                OpenXmlDocumentElement row = removingRow;
                removingRow = removingRow.Next;
                row.Remove();
            }


            // fill "Notes" table
            sheet["[date]"] = DateTime.Now.ToShortDateString();
            sheet["[time]"] = DateTime.Now.ToLongTimeString();
            sheet["[application]"] = MainForm.Title;
            sheet["[item_count]"] = itemCount.ToString();
        }        

        /// <summary>
        /// Sets the company information.
        /// </summary>
        /// <param name="sheet">The sheet.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="company">The company.</param>
        private static void SetCompanyInformation(OpenXmlDocumentTable sheet, string fieldName, Company company)
        {
            string fieldFormat = string.Format("[{0}_{1}]", fieldName, "{0}");
            sheet[string.Format(fieldFormat, "company")] = company.CompanyName;
            sheet[string.Format(fieldFormat, "name")] = company.Name;
            sheet[string.Format(fieldFormat, "address")] = company.Address;
            sheet[string.Format(fieldFormat, "phone")] = company.GetPhones();
            sheet[string.Format(fieldFormat, "city")] = company.City;
        }

    }
}
