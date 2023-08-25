namespace ReportGeneratorDemo
{
    /// <summary>
    /// Represents a price list item.
    /// </summary>
    public class PriceListItem
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PriceListItem"/> class.
        /// </summary>
        /// <param name="product">The product name.</param>
        /// <param name="imageId">Th image ID.</param>
        /// <param name="price">The product price.</param>
        public PriceListItem(string product, string imageId, float price)
        {
            _product = product;
            _imageId = imageId;
            _price = price;
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

        string _imageId;
        /// <summary>
        /// Gets the image Id.
        /// </summary>
        public string ImageId
        {
            get
            {
                return _imageId;
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

        #endregion

    }
}
