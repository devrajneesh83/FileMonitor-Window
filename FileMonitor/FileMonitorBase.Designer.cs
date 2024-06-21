namespace FileMonitor
{
    partial class FileMonitorBase
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
            txtFilePath = new TextBox();
            btnBrowse = new Button();
            label1 = new Label();
            textBoxChanges = new RichTextBox();
            SuspendLayout();
            // 
            // txtFilePath
            // 
            txtFilePath.Location = new Point(68, 96);
            txtFilePath.Name = "txtFilePath";
            txtFilePath.Size = new Size(311, 27);
            txtFilePath.TabIndex = 0;
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(402, 96);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(107, 29);
            btnBrowse.TabIndex = 1;
            btnBrowse.Text = "Browse File";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ControlLight;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.Location = new Point(139, 31);
            label1.Name = "label1";
            label1.Size = new Size(311, 32);
            label1.TabIndex = 3;
            label1.Text = "Monitor Text File Changes";
            // 
            // textBoxChanges
            // 
            textBoxChanges.Location = new Point(68, 160);
            textBoxChanges.Name = "textBoxChanges";
            textBoxChanges.Size = new Size(441, 240);
            textBoxChanges.TabIndex = 4;
            textBoxChanges.Text = "";
            // 
            // FileMonitorBase
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(581, 450);
            Controls.Add(textBoxChanges);
            Controls.Add(label1);
            Controls.Add(btnBrowse);
            Controls.Add(txtFilePath);
            Name = "FileMonitorBase";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtFilePath;
        private Button btnBrowse;
        private Label label1;
        private TextBox textBox1;
        private RichTextBox textBoxChanges;
    }
}
