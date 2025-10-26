using Microsoft.VisualBasic;
using System.Text;

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

            usernameTxtBox.TextChanged += usernameTxtBox_TextChanged;
            passwordTextBox.TextChanged += passwordTextBox_TextChanged;
            txtFolderPath.TextChanged += txtFolderPath_TextChanged;

            UpdateSendButtonEnabled();

            if (progressBar != null)
            {
                progressBar.Minimum = 0;
                progressBar.Value = 0;
            }
        }

        private void UpdateSendButtonEnabled()
        {
            bool hasFolder = Directory.Exists(txtFolderPath.Text);
            bool hasUser = !string.IsNullOrWhiteSpace(usernameTxtBox.Text);
            bool hasPassword = !string.IsNullOrWhiteSpace(passwordTextBox.Text);

            btnSend.Enabled = hasFolder && hasUser && hasPassword;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (var dlg = new FolderBrowserDialog())
            {
                if (Directory.Exists(txtFolderPath.Text))
                    dlg.SelectedPath = txtFolderPath.Text;

                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    txtFolderPath.Text = dlg.SelectedPath;
                    lstLog.Items.Add($"{DateTime.Now}: Folder set: {dlg.SelectedPath}");
                }
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://postman-echo.com/basic-auth");
            var username = usernameTxtBox.Text;
            var password = passwordTextBox.Text;
            var bytes = Encoding.ASCII.GetBytes($"{username}:{password}");
            var base64 = Convert.ToBase64String(bytes);

            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64);
            var response = await httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Authentication succeeded.", 
                    "Success", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);
                lstLog.Items.Add($"{DateTime.Now}: Authentication succeeded.");
            }
            else
            {
                MessageBox.Show("Authentication failed.", 
                    "Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);
                lstLog.Items.Add($"{DateTime.Now}: Authentication failed.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void txtFolderPath_TextChanged(object? sender, EventArgs e) => UpdateSendButtonEnabled();
        private void usernameTxtBox_TextChanged(object? sender, EventArgs e) => UpdateSendButtonEnabled();
        private void passwordTextBox_TextChanged(object? sender, EventArgs e) => UpdateSendButtonEnabled();

        private void button3_Click(object sender, EventArgs e)
        {
            var message = MessageBox.Show("Are you sure you want to clear the log?", "Confirm Clear Log",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (message == DialogResult.Yes)
                lstLog.Items.Clear();
        }
    }
}
