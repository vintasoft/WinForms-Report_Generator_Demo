using System.Drawing;

using Vintasoft.Imaging.Office.OpenXml.Editor;

namespace ReportGeneratorDemo
{
    /// <summary>
    /// Provides data and properties of Open XML table cell.
    /// </summary>
    public class TableCellData
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TableCellData"/> class.
        /// </summary>
        public TableCellData()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TableCellData"/> class.
        /// </summary>
        /// <param name="text">The text of cell.</param>
        public TableCellData(string text)
        {
            Text = text;
        }

        #endregion



        #region Properties

        string _text;
        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
            }
        }

        Color? _fillColor;
        /// <summary>
        /// Gets or sets the fill color.
        /// </summary>
        public Color? FillColor
        {
            get
            {
                return _fillColor;
            }
            set
            {
                _fillColor = value;
            }
        }

        OpenXmlTextProperties _textProperties;
        /// <summary>
        /// Gets or sets the text properties.
        /// </summary>
        public OpenXmlTextProperties TextProperties
        {
            get
            {
                return _textProperties;
            }
            set
            {
                _textProperties = value;
            }
        }

        #endregion



        #region Methods

        /// <summary>
        /// Sets the properties of specified table cell.
        /// </summary>
        /// <param name="cell">The table cell to set properties.</param>
        public void Set(OpenXmlDocumentTableCell cell)
        {
            if (Text != null)
                cell.Text = Text;
            if (TextProperties != null)
                cell.SetTextProperties(TextProperties);
            if (FillColor != null)
                cell.SetFillColor(FillColor);
        }

        #endregion

    }
}
