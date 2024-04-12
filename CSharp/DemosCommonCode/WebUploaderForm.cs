using System;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace DemosCommonCode
{
    /// <summary>
    /// A form that allows to upload data to a web server.
    /// </summary>
    public partial class WebUploaderForm : Form
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WebUploaderForm"/> class.
        /// </summary>
        public WebUploaderForm()
        {
            InitializeComponent();
        }

        #endregion



        #region Methods

        #region UI

        /// <summary>
        /// Handles the Click event of closeButton object.
        /// </summary>
        private void closeButton_Click(object sender, EventArgs e)
        {
            // close the form
            Close();
        }

        #endregion


        /// <summary>
        /// Uploads data asynchronously.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="contentType">The content type.</param>
        /// <param name="stream">The data stream.</param>
        public void UploadAsync(string url, string contentType, Stream stream)
        {
            try
            {
                closeButton.Enabled = false;
                // create web client
                WebClient webClient = new WebClient();
                webClient.UploadDataCompleted += new UploadDataCompletedEventHandler(webClient_UploadDataCompleted);

                // set handlers
                AppendLog(string.Format("Content-Type={0}", contentType));
                webClient.Headers.Add("Content-Type", contentType);

                // read data
                byte[] data = new byte[(int)stream.Length];
                stream.Position = 0;
                stream.Read(data, 0, data.Length);

                // start asynchronous data uploading
                AppendLog(string.Format("Upload {0} bytes to {1}...", data.Length, url));
                webClient.UploadDataAsync(new Uri(url), data);
            }
            catch (Exception ex)
            {
                AppendLog(string.Format("Error: {0}", ex.ToString()));
            }
        }

        /// <summary>
        /// Data uploading is completed.
        /// </summary>
        private void webClient_UploadDataCompleted(object sender, UploadDataCompletedEventArgs e)
        {
            closeButton.Enabled = true;
            ((WebClient)sender).UploadDataCompleted -= webClient_UploadDataCompleted;
            if (e.Cancelled)
                AppendLog("Canceled.");
            if (e.Error != null)
                AppendLog(string.Format("Error: {0}", e.Error.Message));
            else
                AppendLog(string.Format("Response received: {0}", Encoding.ASCII.GetString(e.Result)));
        }

        /// <summary>
        /// Appends message to the log.
        /// </summary>
        /// <param name="text">The text.</param>
        private void AppendLog(string text)
        {
            logTextBox.AppendText(text + Environment.NewLine);
            logTextBox.ScrollToCaret();
        }

        #endregion

    }
}
