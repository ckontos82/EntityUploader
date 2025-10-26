using Microsoft.VisualBasic;
using System.Net.Http.Headers;
using System.Text;
using static System.Net.WebRequestMethods;

namespace EntityUploader
{
    public partial class Form1 : Form
    {
        private static readonly HttpClient httpClient = new HttpClient
        {
            Timeout = TimeSpan.FromMinutes(30)
        };

        private CancellationTokenSource? _cts;
        private const string ApiEndpoint = "https://9b7289cf-8d8d-4a03-9f76-64172a825504.mock.pstmn.io/api/upload";

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
                    Log($"Folder set: {dlg.SelectedPath}");
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
                Log($"Authentication succeeded.");
            }
            else
            {
                MessageBox.Show("Authentication failed.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                Log("Authentication failed.");
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

        private async void btnSend_Click(object sender, EventArgs e)
        {

            var folder = txtFolderPath.Text.Trim();
            if (!Directory.Exists(folder))
            {
                MessageBox.Show("Folder does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var files = Directory.EnumerateFiles(folder)
                         .Where(f => !System.IO.File.Exists(f + ".sent"))
                         .ToList();

            if (files.Count == 0)
            {
                MessageBox.Show("No files to send in the selected folder.", 
                    "Information", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);
                return;
            }

            _cts = new CancellationTokenSource();
            ToggleUI(isBusy: true);

            try
            {
                progressBar.Maximum = files.Count;
                progressBar.Value = 0;

                Log($"Sending {files.Count} files");
                int ok = 0, fail = 0;

                foreach (var path in files)
                {
                    var fileName = Path.GetFileName(path);

                    try
                    {

                        await SendFileAsync(path, _cts.Token);

                        // mark as sent with sidecar file
                        System.IO.File.WriteAllText(path + ".sent", DateTimeOffset.Now.ToString("O"));

                        ok++;
                        Log($"OK: {fileName}");
                    }
                    catch (OperationCanceledException)
                    {
                        Log("Canceled by user.");
                        progressBar.Value = progressBar.Maximum;
                        break;
                    }
                    catch (Exception ex)
                    {
                        fail++;
                        Log($"FAIL: {fileName} — {ex.Message}");
                    }
                    finally
                    {
                        if (progressBar.Value < progressBar.Maximum)
                            progressBar.Value += 1;
                    }

                    _cts.Token.ThrowIfCancellationRequested();
                }

                Log($"Done. Success: {ok}, Failed: {fail}");
            }
            finally
            {
                ToggleUI(isBusy: false);
                _cts?.Dispose();
                _cts = null;
            }
        }

        private async Task SendFileAsync(string filePath, CancellationToken ct)
        {
            using var form = new MultipartFormDataContent();

            var fileContent = new StreamContent(System.IO.File.OpenRead(filePath));
            fileContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            form.Add(fileContent, "file", Path.GetFileName(filePath));

            using var resp = await httpClient.PostAsync(ApiEndpoint, form, ct);
            if (!resp.IsSuccessStatusCode)
            {
                var body = await resp.Content.ReadAsStringAsync(ct);
                throw new InvalidOperationException($"HTTP {(int)resp.StatusCode} {resp.ReasonPhrase}. Body: {TrimForLog(body)}");
            }
        }

        private async void btnCancel_Click(object sender, EventArgs e)
        {
            // signal cooperative cancellation
            _cts?.Cancel();
            Log("Cancel requested…");
            // UI stays disabled until the loop unwinds; then ToggleUi(false) will run in finally
        }

        private static string TrimForLog(string s, int max = 300)
        {
            if (string.IsNullOrWhiteSpace(s)) return string.Empty;
            s = s.Replace("\r", " ").Replace("\n", " ");
            return s.Length <= max ? s : s.Substring(0, max) + "…";
        }

        private void Log(string message)
        {
            lstLog.Items.Add($"[{DateTime.Now:HH:mm:ss}] {message}");
            lstLog.TopIndex = lstLog.Items.Count - 1; // auto-scroll
        }

        private void ToggleUI(bool isBusy)
        {
            btnBrowse.Enabled = !isBusy;
            btnSend.Enabled = !isBusy && Directory.Exists(txtFolderPath.Text);
            btnCancel.Enabled = isBusy;
            UseWaitCursor = isBusy;
        }
    }
}
