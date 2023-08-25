using System;

namespace ReportGeneratorDemo
{
    /// <summary>
    /// Contains test information for invoice example.
    /// </summary>
    public class TestInvoiceData
    {

        #region Methods

        /// <summary>
        /// Returns the invoice test data.
        /// </summary>
        /// <returns>The invoice test data.</returns>
        public static InvoiceData GetTestData(int orderItemsCount)
        {
            Company vintasoftCompany = new Company();
            vintasoftCompany.CompanyName = "Company Inc.";
            vintasoftCompany.Address = "Company address";
            vintasoftCompany.City = "Company City";
            vintasoftCompany.Phones.Add("+12345678912");
            vintasoftCompany.Phones.Add("+98765432198 (fax)");

            Company billingCompany = new Company();
            billingCompany.CompanyName = "Billing Global Company Inc.";
            billingCompany.Name = "Mr. X";
            billingCompany.Address = "Address1";
            billingCompany.City = "City1";
            billingCompany.Phones.Add("9876543210");
            billingCompany.Phones.Add("7654321098 (fax)");

            Company shipingCompany = new Company();
            shipingCompany.CompanyName = "Shipping Global Company Inc.";
            shipingCompany.Name = "Mr. Y";
            shipingCompany.Address = "Address2";
            shipingCompany.City = "City2";
            shipingCompany.Phones.Add("1122334455");
            shipingCompany.Phones.Add("5544332211 (fax)");

            InvoiceData data = new InvoiceData();

            Random random = new Random();
            data.InvoiceNumber = string.Format("{0}-{1}", random.Next(100000, 999999), random.Next(0, 9));

            data.Company = vintasoftCompany;
            data.BillingAddress = billingCompany;
            data.ShippingAddress = shipingCompany;

            InvoiceItem[] availableProducts = new InvoiceItem[] {
                new InvoiceItem("VintaSoft Imaging .NET SDK, Site license for Desktop PCs", 659.95f),
                new InvoiceItem("VintaSoft Annotation .NET Plug-in, Site license for Desktop PCs", 449.95f),
                new InvoiceItem("VintaSoft Office .NET Plug-in, Site license for Desktop PCs", 569.95f),
                new InvoiceItem("VintaSoft PDF .NET Plug-in (Reader+Writer), Site license for Desktop PCs", 1499.95f),
                new InvoiceItem("VintaSoft PDF .NET Plug-in (Reader+Writer+VisualEditor), Site license for Desktop PCs", 2999.95f),
                new InvoiceItem("VintaSoft JBIG2 .NET Plug-in, Site license for Desktop PCs", 1139.95f),
                new InvoiceItem("VintaSoft JPEG2000 .NET Plug-in, Site license for Desktop PCs", 689.95f),
                new InvoiceItem("VintaSoft Document Cleaup .NET Plug-in, Site license for Desktop PCs", 569.95f),
                new InvoiceItem("VintaSoft OCR .NET Plug-in, Site license for Desktop PCs", 509.95f),
                new InvoiceItem("VintaSoft DICOM .NET Plug-in (Codec+MPR), Site license for Desktop PCs", 1199.95f),
                new InvoiceItem("VintaSoft Forms Processing .NET Plug-in, Site license for Desktop PCs", 509.95f),
                new InvoiceItem("VintaSoft Barcode .NET SDK (1D+2D Reader+Writer), Site license for Desktop PCs", 1379.95f),
                new InvoiceItem("VintaSoft Twain .NET SDK, Site license", 539.95f)
            };

            for (int i = 0; i < orderItemsCount; i++)
            {
                int quantity = 1 + random.Next(10);
                int index = random.Next(availableProducts.Length - 1);
                data.OrderItems.Add(new InvoiceItem(availableProducts[index], quantity));
            }

            return data;
        }

        #endregion

    }
}
