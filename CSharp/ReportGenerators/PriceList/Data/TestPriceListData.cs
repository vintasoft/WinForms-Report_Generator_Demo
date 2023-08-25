namespace ReportGeneratorDemo
{
    /// <summary>
    /// Contains test information for price list example.
    /// </summary>
    public class TestPriceListData
    {

        #region Methods

        /// <summary>
        /// Returns the price list test data.
        /// </summary>
        /// <returns>The price list test data.</returns>
        public static PriceListItem[] GetTestData()
        {
            return new PriceListItem[] {
                new PriceListItem("VintaSoft Imaging .NET SDK, Developer license for Desktop PCs", "vsimaging-icon.png", 219.95f),
                new PriceListItem("VintaSoft Imaging .NET SDK, Developer license for Servers", "vsimaging-icon.png", 549.95f),
                new PriceListItem("VintaSoft Imaging .NET SDK, Site license for Desktop PCs", "vsimaging-icon.png", 659.95f),
                new PriceListItem("VintaSoft Imaging .NET SDK, Site license for Servers", "vsimaging-icon.png", 1649.95f),
                new PriceListItem("VintaSoft Imaging .NET SDK, Single Server license", "vsimaging-icon.png", 164.95f),
                new PriceListItem("VintaSoft Annotation .NET Plug-in, Site license for Desktop PCs", "vsannotation-icon.png", 449.95f),
                new PriceListItem("VintaSoft Office .NET Plug-in, Site license for Desktop PCs", "vsoffice-icon.png", 569.95f),
                new PriceListItem("VintaSoft PDF .NET Plug-in (Reader+Writer), Site license for Desktop PCs", "vspdf-icon.png", 1499.95f),
                new PriceListItem("VintaSoft PDF .NET Plug-in (Reader+Writer+VisualEditor), Site license for Desktop PCs", "vspdf-icon.png",2999.95f),
                new PriceListItem("VintaSoft JBIG2 .NET Plug-in, Site license for Desktop PCs", "vsjbig2-icon.png",1139.95f),
                new PriceListItem("VintaSoft JPEG2000 .NET Plug-in, Site license for Desktop PCs", "vsjpeg2000-icon.png", 689.95f),
                new PriceListItem("VintaSoft Document Cleaup .NET Plug-in, Site license for Desktop PCs", "vsdoccleanup-icon.png", 569.95f),
                new PriceListItem("VintaSoft OCR .NET Plug-in, Site license for Desktop PCs", "vsocr-icon.png", 509.95f),
                new PriceListItem("VintaSoft DICOM .NET Plug-in (Codec+MPR), Site license for Desktop PCs", "vsdicom-icon.png", 1199.95f),
                new PriceListItem("VintaSoft Forms Processing .NET Plug-in, Site license for Desktop PCs", "vsformsprocessing-icon.png", 509.95f),
                new PriceListItem("VintaSoft Barcode .NET SDK (1D+2D Reader+Writer), Site license for Desktop PCs", "vsbarcode-icon.png", 1379.95f),
                new PriceListItem("VintaSoft Twain .NET SDK, Developer license", "vstwain-icon.png", 179.95f),
                new PriceListItem("VintaSoft Twain .NET SDK, Site license", "vstwain-icon.png", 539.95f),
                new PriceListItem("VintaSoft Twain .NET SDK, Single URL license", "vstwain-icon.png", 149.95f),
                new PriceListItem("VintaSoft Twain ActiveX, Developer license", "vstwain-icon.png", 99.95f),
                new PriceListItem("VintaSoft Twain ActiveX, Site license", "vstwain-icon.png", 299.95f),
                new PriceListItem("VintaSoft Twain ActiveX, Single URL license", "vstwain-icon.png", 119.95f)
            };
        }

        #endregion

    }
}
