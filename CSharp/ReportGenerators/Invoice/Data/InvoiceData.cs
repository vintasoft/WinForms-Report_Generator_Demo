using Vintasoft.Imaging;

using System.Collections.Generic;
using System.Globalization;

namespace ReportGeneratorDemo
{
    /// <summary>
    /// Represents an invoice data.
    /// </summary>
    public class InvoiceData
    {

        #region Constructors    
        
        /// <summary>
        /// Initializes the <see cref="InvoiceData"/> class.
        /// </summary>
        static InvoiceData()
        {
            Vintasoft.Barcode.GdiAssembly.Init();
        }

        #endregion



        #region Properties

        List<InvoiceItem> _orderItems = new List<InvoiceItem>();
        /// <summary>
        /// Gets the list of order items.
        /// </summary>
        public List<InvoiceItem> OrderItems
        {
            get
            {
                return _orderItems;
            }
        }

        string _invoiceNumber;
        /// <summary>
        /// Gets or sets the invoice number.
        /// </summary>
        public string InvoiceNumber
        {
            get
            {
                return _invoiceNumber;
            }
            set
            {
                _invoiceNumber = value;
            }
        }

        string _shippingMethod = "Email";
        /// <summary>
        /// Gets or sets the shipping method.
        /// </summary>
        public string ShippingMethod
        {
            get
            {
                return _shippingMethod;
            }
            set
            {
                _shippingMethod = value;
            }
        }

        Company _billingAddress = new Company();
        /// <summary>
        /// Gets or sets the company billing address.
        /// </summary>
        public Company BillingAddress
        {
            get
            {
                return _billingAddress;
            }
            set
            {
                _billingAddress = value;
            }
        }

        Company _shippingAddress = new Company();
        /// <summary>
        /// Gets or sets the company shipping address.
        /// </summary>
        public Company ShippingAddress
        {
            get
            {
                return _shippingAddress;
            }
            set
            {
                _shippingAddress = value;
            }
        }

        Company _company = new Company();
        /// <summary>
        /// Gets or sets the object that represents information about the company.
        /// </summary>
        public Company Company
        {
            get
            {
                return _company;
            }
            set
            {
                _company = value;
            }
        }

        string _currency = "EUR";
        /// <summary>
        /// Gets or sets the currency to be used in the invoice.
        /// </summary>
        public string Currency
        {
            get
            {
                return _currency;
            }
            set
            {
                _currency = value;
            }
        }

        /// <summary>
        /// Gets the subtotal value.
        /// </summary>
        public float Subtotal
        {
            get
            {
                float value = 0;
                for (int i = 0; i < _orderItems.Count; i++)
                    value += _orderItems[i].TotalPrice;
                return value;
            }
        }

        float _tax = 0;
        /// <summary>
        /// Gets or sets the tax value.
        /// </summary>
        public float Tax
        {
            get
            {
                return _tax;
            }
            set
            {
                _tax = value;
            }
        }

        float _shipping = 0;
        /// <summary>
        /// Gets or sets the shipping price.
        /// </summary>
        public float Shipping
        {
            get
            {
                return _shipping;
            }
            set
            {
                _shipping = value;
            }
        }

        /// <summary>
        /// Gets the grandtotal value.
        /// </summary>
        public float GrandTotal
        {
            get
            {
                return Subtotal + _shipping + _tax;
            }
        }

        #endregion



        #region Methods

        /// <summary>
        /// Returns the price as a string.
        /// </summary>
        /// <param name="price">The price.</param>
        /// <returns>The price in string representation.</returns>
        public string GetPriceAsString(float price)
        {
            return string.Format("{0} {1}", price.ToString("f2", CultureInfo.InvariantCulture), Currency);
        }

#if !REMOVE_BARCODE_SDK
        /// <summary>
        /// Creates the QR code image.
        /// </summary>
        /// <param name="size">The barcode size.</param>
        /// <returns>An instance of<see cref="VintasoftImage"/> class that contains QR code image.</returns>
        internal VintasoftImage GetBarcodeImage(int size)
        {
            Vintasoft.Barcode.BarcodeWriter writer = new Vintasoft.Barcode.BarcodeWriter();

            writer.Settings.Barcode = Vintasoft.Barcode.BarcodeType.QR;

            writer.Settings.Value = string.Format("INVOICE={0};TOTAL={1}", InvoiceNumber, GetPriceAsString(GrandTotal));

            writer.Settings.SetWidth(size);

            VintasoftImage result = new VintasoftImage(writer.GetBarcodeAsVintasoftBitmap(), true);
            result.Crop(new System.Drawing.Rectangle(0, 0, result.Width, result.Width));

            return result;
        }
#endif

        #endregion

    }
}
