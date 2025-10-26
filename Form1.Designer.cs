namespace EntityUploader
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnBrowse = new Button();
            txtFolderPath = new TextBox();
            label1 = new Label();
            btnSend = new Button();
            button1 = new Button();
            label2 = new Label();
            progressBar = new ProgressBar();
            lstLog = new ListBox();
            label3 = new Label();
            passwordTextBox = new TextBox();
            usernameTxtBox = new TextBox();
            label4 = new Label();
            button2 = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(12, 79);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(117, 33);
            btnBrowse.TabIndex = 0;
            btnBrowse.Text = "Select Folder";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // txtFolderPath
            // 
            txtFolderPath.Location = new Point(12, 27);
            txtFolderPath.Name = "txtFolderPath";
            txtFolderPath.PlaceholderText = "Selected folder will appear here";
            txtFolderPath.ReadOnly = true;
            txtFolderPath.Size = new Size(815, 23);
            txtFolderPath.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(90, 15);
            label1.TabIndex = 2;
            label1.Text = "Selected Folder:";
            // 
            // btnSend
            // 
            btnSend.Location = new Point(12, 141);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(90, 33);
            btnSend.TabIndex = 3;
            btnSend.Text = "Send Data";
            btnSend.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Enabled = false;
            button1.Location = new Point(12, 180);
            button1.Name = "button1";
            button1.Size = new Size(90, 33);
            button1.TabIndex = 4;
            button1.Text = "Cancel";
            button1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(515, 79);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 6;
            label2.Text = "Progress:";
            // 
            // progressBar
            // 
            progressBar.Location = new Point(515, 98);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(586, 24);
            progressBar.TabIndex = 7;
            // 
            // lstLog
            // 
            lstLog.FormattingEnabled = true;
            lstLog.ItemHeight = 15;
            lstLog.Location = new Point(515, 172);
            lstLog.Name = "lstLog";
            lstLog.Size = new Size(586, 619);
            lstLog.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(515, 154);
            label3.Name = "label3";
            label3.Size = new Size(30, 15);
            label3.TabIndex = 9;
            label3.Text = "Log:";
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(12, 343);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PlaceholderText = "Password";
            passwordTextBox.Size = new Size(271, 23);
            passwordTextBox.TabIndex = 11;
            passwordTextBox.UseSystemPasswordChar = true;
            // 
            // usernameTxtBox
            // 
            usernameTxtBox.Location = new Point(12, 314);
            usernameTxtBox.Name = "usernameTxtBox";
            usernameTxtBox.PlaceholderText = "Username";
            usernameTxtBox.Size = new Size(271, 23);
            usernameTxtBox.TabIndex = 12;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 296);
            label4.Name = "label4";
            label4.Size = new Size(124, 15);
            label4.TabIndex = 13;
            label4.Text = "Enter your credentials:";
            // 
            // button2
            // 
            button2.Location = new Point(12, 372);
            button2.Name = "button2";
            button2.Size = new Size(117, 41);
            button2.TabIndex = 14;
            button2.Text = "Test Connection";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(995, 797);
            button3.Name = "button3";
            button3.Size = new Size(106, 41);
            button3.TabIndex = 15;
            button3.Text = "Clear Log";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1113, 852);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(label4);
            Controls.Add(usernameTxtBox);
            Controls.Add(passwordTextBox);
            Controls.Add(label3);
            Controls.Add(lstLog);
            Controls.Add(progressBar);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(btnSend);
            Controls.Add(label1);
            Controls.Add(txtFolderPath);
            Controls.Add(btnBrowse);
            Name = "Form1";
            Text = "Entity Uploader";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBrowse;
        private TextBox txtFolderPath;
        private Label label1;
        private Button btnSend;
        private Button button1;
        private Label label2;
        private ProgressBar progressBar;
        private ListBox lstLog;
        private Label label3;
        private TextBox textBox1;
        private TextBox passwordTextBox;
        private TextBox usernameTxtBox;
        private Label label4;
        private Button button2;
        private Button button3;
    }
}
