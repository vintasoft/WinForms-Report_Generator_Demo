namespace ReportGeneratorDemo
{
    /// <summary>
    /// Represents an invoice order item.
    /// </summary>
    public class InvoiceItem
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceItem"/> class.
        /// </summary>
        /// <param name="product">The product name.</param>
        /// <param name="price">The product price.</param>
        public InvoiceItem(string product, float price)
        {
            _product = product;
            _quantity = 1;
            _price = price;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceItem"/> class.
        /// </summary>
        /// <param name="source">The source <see cref="InvoiceItem"/>.</param>
        /// <param name="quantity">The product quantity.</param>
        public InvoiceItem(InvoiceItem source, float quantity)
        {
            _product = source.Product;
            _price = source.Price;
            _quantity = quantity;
        }

        #endregion



        #region Properties

        string _product;
        /// <summary>
        /// Gets the product name.
        /// </summary>
        public string Product
        {
            get
            {
                return _product;
            }
        }

        float _quantity;
        /// <summary>
        /// Gets the product quantity.
        /// </summary>
        public float Quantity
        {
            get
            {
                return _quantity;
            }
        }

        float _price;
        /// <summary>
        /// Gets the product price.
        /// </summary>
        public float Price
        {
            get
            {
                return _price;
            }
        }

        /// <summary>
        /// Gets the product total price.
        /// </summary>
        public float TotalPrice
        {
            get
            {
                return _price * _quantity;
            }
        }

        #endregion

    }
}
