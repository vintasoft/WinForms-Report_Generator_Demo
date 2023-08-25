using System.Collections.Generic;
using System.Text;

namespace ReportGeneratorDemo
{
    /// <summary>
    /// Represents an information about a company.
    /// </summary>
    public class Company
    {

        #region Properties

        string _companyName;
        /// <summary>
        /// Gets or sets the company name.
        /// </summary>
        public string CompanyName
        {
            get
            {
                return _companyName;
            }
            set
            {
                _companyName = value;
            }
        }

        string _name;
        /// <summary>
        /// Gets or sets the person name.
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        string _city;
        /// <summary>
        /// Gets or sets the company location city.
        /// </summary>
        public string City
        {
            get
            {
                return _city;
            }
            set
            {
                _city = value;
            }
        }

        string _address;
        /// <summary>
        /// Gets or sets the company location adress.
        /// </summary>
        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
            }
        }

        List<string> _phones = new List<string>();
        /// <summary>
        /// Gets the company phone numbers.
        /// </summary>
        public List<string> Phones
        {
            get
            {
                return _phones;
            }
        }

        #endregion



        #region Methods

        /// <summary>
        /// Gets the phone numbers.
        /// </summary>
        internal string GetPhones()
        {
            if (Phones.Count == 1)
                return Phones[0];
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < Phones.Count - 1; i++)
            {
                result.Append(Phones[i]);
                result.Append(", ");
            }
            result.Append(Phones[Phones.Count - 1]);
            return result.ToString();
        }

        #endregion

    }
}
