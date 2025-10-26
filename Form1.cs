using System.Drawing.Text;

namespace EntityUploader
{
    public partial class Form1 : Form
    {
        private static readonly HttpClient httpClient = new HttpClient
        {
            Timeout = TimeSpan.FromMinutes(30)
        };

        private CancellationTokenSource? _cts;
        private const string ApiEndpoint = "https://9b7289cf-8d8d-4a03-9f76-64172a825504.mock.pstmn.io";
        public Form1()
        {
            InitializeComponent();

            txtFolderPath.Text = Properties.Settings.Default.LastFolder ?? string.Empty;
            btnSend.Enabled = Directory.Exists(txtFolderPath.Text);

            if (progressBar != null)
            {
                progressBar.Minimum = 0;
                progressBar.Value = 0;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonPickFolder_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select a folder containing entity files";
                folderDialog.ShowNewFolderButton = false;
                folderDialog.UseDescriptionForTitle = true;
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = folderDialog.SelectedPath;
                    // Handle the selected folder path
                    MessageBox.Show($"Selected folder: {selectedPath}");
                    txtFolderPath.Text = selectedPath;
                    btnSend.Enabled = Directory.Exists(txtFolderPath.Text);
                }
            }
        }
    }
}
