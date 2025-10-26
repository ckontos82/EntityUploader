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

            // Wire events ONCE
            usernameTxtBox.TextChanged += usernameTxtBox_TextChanged;
            passwordTextBox.TextChanged += passwordTextBox_TextChanged;
            txtFolderPath.TextChanged += txtFolderPath_TextChanged;

            // Initial UI state
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
                    txtFolderPath.Text = dlg.SelectedPath; // fires TextChanged -> updates button
                    lstLog.Items.Add($"Folder set: {dlg.SelectedPath}");
                    // Optional explicit call (safe but not required):
                    // UpdateSendButtonEnabled();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }   

        private void txtFolderPath_TextChanged(object? sender, EventArgs e) => UpdateSendButtonEnabled();
        private void usernameTxtBox_TextChanged(object? sender, EventArgs e) => UpdateSendButtonEnabled();
        private void passwordTextBox_TextChanged(object? sender, EventArgs e) => UpdateSendButtonEnabled();
    }
}
