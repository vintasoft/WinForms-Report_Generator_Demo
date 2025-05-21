using System;
using System.Collections.Generic;

using Vintasoft.Imaging;
using Vintasoft.Imaging.Office.OpenXml.Editor;
using Vintasoft.Imaging.Office.OpenXml.Editor.Docx;

namespace ReportGeneratorDemo
{
    /// <summary>
    /// Generates DOCX invoice.
    /// </summary>
    public static class DocxInvoiceGenerator
    {

        /// <summary>
        /// Generates invoice using the DOCX document editor.
        /// </summary>
        /// <param name="documentEditor">The DOCX document editor.</param>
        /// <param name="itemCount">Invoice item count.</param>
        public static void Generate(DocxDocumentEditor documentEditor, int itemCount)
        {
            // generate test data
            InvoiceData invoiceData = TestInvoiceData.GetTestData(itemCount);

#if !REMOVE_BARCODE_SDK
            // create QR code image 200x200 px
            using (VintasoftImage qrCodeImage = invoiceData.GetBarcodeImage(200))
            {
                // set barcode image to the image element at index 1
                documentEditor.Images[1].SetImage(qrCodeImage);
            }
#endif

            // get all tables of document
            OpenXmlDocumentTable[] tables = documentEditor.Tables;

            OpenXmlDocumentTable headerTable = tables[0];
            // fill the document header
            headerTable["[company_name]"] = invoiceData.Company.CompanyName;
            headerTable["[company_address]"] = invoiceData.Company.Address;
            headerTable["[company_city]"] = invoiceData.Company.City;
            headerTable["[company_phone]"] = invoiceData.Company.GetPhones();
            headerTable["[invoice_number]"] = invoiceData.InvoiceNumber;
            headerTable["[invoice_date]"] = DateTime.Now.ToShortDateString();




            // fill the "Customer Information" table
            OpenXmlDocumentTable customerInformationTable = tables[1];
            SetCompanyInformation(customerInformationTable, "billing", invoiceData.BillingAddress);
            SetCompanyInformation(customerInformationTable, "shipping", invoiceData.ShippingAddress);


            // fill the "Shipping Method" table
            OpenXmlDocumentTable shippingMethodTable = tables[2];
            shippingMethodTable["[shipping_method]"] = invoiceData.ShippingMethod;


            // cell border templates (special table that contains information about border styles for "Order Information" table)
            OpenXmlDocumentTable cellBoderTemplatesTable = tables[tables.Length - 1];
            // cell with bold borders 
            OpenXmlDocumentTableCell boldBorderCell = cellBoderTemplatesTable.FindCell("[bold]");
            // cell with normal borders 
            OpenXmlDocumentTableCell normalBorderCell = cellBoderTemplatesTable.FindCell("[normal]");
            // remove cell templates table
            cellBoderTemplatesTable.Remove();

            // fill the "Order Information" table
            OpenXmlDocumentTable orderInformationTable = tables[3];
            OpenXmlDocumentTableRow templateRow = orderInformationTable[1];
            int orderItemNumber = 1;
            List<OpenXmlDocumentTableRow> boldRows = new List<OpenXmlDocumentTableRow>();
            foreach (InvoiceItem orderItem in invoiceData.OrderItems)
            {
                // copy template row and insert copy before template row
                OpenXmlDocumentTableRow currentRow = templateRow;
                templateRow = (OpenXmlDocumentTableRow)templateRow.InsertCopyAfterSelf();

                // fill data of current row
                currentRow["[p_n]"] = orderItemNumber.ToString();
                currentRow["[p_description]"] = orderItem.Product;
                currentRow["[p_qty]"] = orderItem.Quantity.ToString();
                currentRow["[p_unit_price]"] = invoiceData.GetPriceAsString(orderItem.Price);
                currentRow["[p_price_total]"] = invoiceData.GetPriceAsString(orderItem.TotalPrice);

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
                    templateRow.SetBorder(normalBorderCell);
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
                row.SetBorder(boldBorderCell);
            }
            // fill order information summary fields
            orderInformationTable["[subtotal]"] = invoiceData.GetPriceAsString(invoiceData.Subtotal);
            orderInformationTable["[tax]"] = invoiceData.GetPriceAsString(invoiceData.Tax);
            orderInformationTable["[shipping]"] = invoiceData.GetPriceAsString(invoiceData.Shipping);
            orderInformationTable["[grand_total]"] = invoiceData.GetPriceAsString(invoiceData.GrandTotal);


            // fill the "Notes" table
            OpenXmlDocumentTable notesTable = tables[4];
            notesTable["[date]"] = DateTime.Now.ToShortDateString();
            notesTable["[time]"] = DateTime.Now.ToLongTimeString();
            notesTable["[application]"] = MainForm.Title;
            notesTable["[item_count]"] = itemCount.ToString();
        }

        /// <summary>
        /// Sets the company information.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="company">The company.</param>
        private static void SetCompanyInformation(OpenXmlDocumentTable table, string fieldName, Company company)
        {
            string fieldFormat = string.Format("[{0}_{1}]", fieldName, "{0}");
            table[string.Format(fieldFormat, "company")] = company.CompanyName;
            table[string.Format(fieldFormat, "name")] = company.Name;
            table[string.Format(fieldFormat, "address")] = company.Address;
            table[string.Format(fieldFormat, "phone")] = company.GetPhones();
            table[string.Format(fieldFormat, "city")] = company.City;
        }

    }
}
