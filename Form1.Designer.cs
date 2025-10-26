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
            btnBrowse.Click += buttonPickFolder_Click;
            // 
            // txtFolderPath
            // 
            txtFolderPath.Location = new Point(12, 50);
            txtFolderPath.Name = "txtFolderPath";
            txtFolderPath.PlaceholderText = "...";
            txtFolderPath.ReadOnly = true;
            txtFolderPath.Size = new Size(819, 23);
            txtFolderPath.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 32);
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
            label2.Location = new Point(180, 123);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 6;
            label2.Text = "Progress:";
            // 
            // progressBar
            // 
            progressBar.Location = new Point(180, 141);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(605, 33);
            progressBar.TabIndex = 7;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(869, 703);
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
    }
}
