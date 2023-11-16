using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using System.Threading.Tasks;
using GroupDocs.Translation.Cloud.SDK.NET.Model.Requests;
using GroupDocs.Translation.Cloud.SDK.NET.Model;
using GroupDocs.Translation.Cloud.SDK.NET;

namespace PDFTranslatorApp
{
    public partial class Form1 : Form
    {
        private string pdfFilePath;
        private string sourceLanguage;
        private string targetLanguage;
        private List<string> targetLanguages = new List<string>(); // Declare it at the class level


        private Dictionary<string, string> languageNames = new Dictionary<string, string>
        {
            { "en", "English" },
            { "es", "Spanish" },
            { "fr", "French" },
            { "de", "German" },
            { "ur", "Urdu" },
            { "ps", "Pashto" },
            { "fa", "Farsi" }
            // Add more languages as needed
        };
        private string outputPath = Directory.GetCurrentDirectory();

        public Form1()
        {
            InitializeComponent();
            Start();
        }

        public void Start()
        {

            // Convert the Dictionary to a List of key-value pairs
            List<KeyValuePair<string, string>> languageList = languageNames.ToList();

            // Set the ComboBox's DataSource, DisplayMember, and ValueMember
            sourceLanguageComboBox.DataSource = languageList;
            sourceLanguageComboBox.DisplayMember = "Value"; // Display the language name
            sourceLanguageComboBox.ValueMember = "Key";     // Store the language code

            // Repeat the same for targetLanguageComboBox if needed.
            targetLanguageComboBox.DataSource = languageList.ToList();
            targetLanguageComboBox.DisplayMember = "Value";
            targetLanguageComboBox.ValueMember = "Key";

            //Debug
            /*
                        Console.WriteLine("Source Language Items:");
                        foreach (var item in sourceLanguageComboBox.Items)
                        {
                            Console.WriteLine($"Value: {((KeyValuePair<string, string>)item).Value}, Key: {((KeyValuePair<string, string>)item).Key}");
                        }

                        Console.WriteLine("Target Language Items:");
                        foreach (var item in targetLanguageComboBox.Items)
                        {
                            Console.WriteLine($"Value: {((KeyValuePair<string, string>)item).Value}, Key: {((KeyValuePair<string, string>)item).Key}");
                        }*/

        }

        private void selectPdf_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "PDF Files|*.pdf";
                openFileDialog.Title = "Select a PDF File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pdfFilePath = openFileDialog.FileName;
                    selectPdf.Text = pdfFilePath;
                }
            }
        }

        private void sourceLanguageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sourceLanguageComboBox.SelectedItem == null)
            {
                var selectedItem = sourceLanguageComboBox.SelectedItem;
                var itemKey = (KeyValuePair<string, string>)selectedItem;

                Console.WriteLine($"Value: {((KeyValuePair<string, string>)itemKey).Value}, Key: {((KeyValuePair<string, string>)itemKey).Key}");

                sourceLanguage = itemKey.Value;
                sourceLanguageLabel.Text = sourceLanguage; // Update the source language label
            }
            else
            {
                MessageBox.Show("Error: The selected source language is null or not assigned.");
            }
        }

        private void targetLanguageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (targetLanguageComboBox.SelectedItem != null)
            {
                var selectedItem = (KeyValuePair<string, string>)targetLanguageComboBox.SelectedItem;
                targetLanguage = selectedItem.Key;

                Console.WriteLine($"Value: {((KeyValuePair<string, string>)selectedItem).Value}, Key: {((KeyValuePair<string, string>)selectedItem).Key}");

                // Clear the list and add the selected target language
                targetLanguages.Clear();
                targetLanguages.Add(targetLanguage);

                targetLanguageLabel.Text = targetLanguage; // Update the target language label
            }
            else
            {
                MessageBox.Show("Error: The selected target language is null or not assigned.");
            }
        }
        private async void translateButton_Click(object sender, EventArgs e)
        {
            try
            {
                var outputPath = "C:\\Users\\DropBearsLLC\\Desktop\\Python Translator\\C#\\translated.pdf"; // Define the output path for the translated PDF
                await TranslatePdfFileAsync(pdfFilePath, outputPath);
                MessageBox.Show("Translation completed. The translated PDF is saved as 'translated.pdf'.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        public async Task TranslatePdfFileAsync(string pdfFilePath, string outputPath)
        {
            // Initialize the GroupDocs Translation API configuration with your credentials

            Configuration conf = new Configuration();
            conf.ClientId = "3c3a5f75-09e4-4fa7-a982-7b9c8fbc531c";
            conf.ClientSecret = "6f84693a57c90c77412320124d69d489";

            TranslationApi api = new TranslationApi(conf);
            FileApi fileApi = new FileApi(conf);

            // Define local paths to upload and download files
            string uploadPath = pdfFilePath; // You can use the provided pdfFilePath directly
            string downloadPath = outputPath; // Specify the path where the translated PDF should be saved

            // Read the PDF file into a stream
            using (Stream stream = File.Open(uploadPath, FileMode.Open))
            {
                // Upload the PDF file to the GroupDocs Translation API
                UploadFileRequest uploadRequest = new UploadFileRequest
                {
                    File = stream,
                    path = Path.GetFileName(uploadPath), // Get just the file name
                    storageName = sourceLanguage + targetLanguage + "" // Specify the storage name if needed
                };

                FilesUploadResult uploadResult = fileApi.UploadFile(uploadRequest);
                Console.WriteLine("File uploaded: " + uploadResult.Uploaded[0]);

                // Prepare the request to translate the uploaded PDF file
                string name = Path.GetFileName(uploadPath);
                string uploadName = sourceLanguage + targetLanguage + name; // You can set it as needed
                string folder = ""; // Specify the folder name if needed
                string pair = sourceLanguage + "-" + targetLanguage; // Replace with the desired language pair
                string format = "pdf";
                string outformat = "pdf";
                string storage = "Temp Storage";
                string saveFile = Path.GetFileName(outputPath); // Get the name of the output file
                string savePath = sourceLanguage + targetLanguage + "translated";
                bool isValid = false;
                bool masters = false;
                bool optimizePdf = false;
                string origin = ".NET";
                bool details = false;

                Dictionary<int, List<List<string>>> frontMatterDict = new Dictionary<int, List<List<string>>>()
        {
            { 0, new List<List<string>>()
                {
                    new List<string>() { "title" },
                    new List<string>() { "frontmatter", "title" },
                    new List<string>() { "frontmatter", "description" }
                }
            }
        };

                Dictionary<int, List<string>> shortCodeDict = new Dictionary<int, List<string>>()
        {
            { 0, new List<string>() { "1", "3" } }
        };

                List<int> elements = new List<int>();

                // Create the translation request
                TranslateDocumentRequest request = api.CreateDocumentRequest(uploadName, folder, pair, format, outformat, storage, saveFile, savePath, masters, elements, origin, optimizePdf);

                // Execute the translation task
                TranslationResponse response = api.RunTranslationTask(request);
                Console.WriteLine(response.Message);

                // Download the translated file
                DownloadFileRequest downloadRequest = new DownloadFileRequest
                {
                    storageName = storage,
                    path = saveFile
                };

                Stream result = fileApi.DownloadFile(downloadRequest);
                Console.WriteLine("Translated file downloaded");

                // Save the translated file to the specified output path
                using (FileStream file = new FileStream(downloadPath, FileMode.Create, FileAccess.Write))
                {
                    result.CopyTo(file);
                }

                Console.WriteLine("Translated file saved");
            }
        }
    }
}


