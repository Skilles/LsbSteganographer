namespace Stenographer
{
    partial class Steganographer
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
            this.encodeButton = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.decodeButton = new System.Windows.Forms.Button();
            this.textBox = new System.Windows.Forms.TextBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // encodeButton
            // 
            this.encodeButton.Location = new System.Drawing.Point(76, 466);
            this.encodeButton.Name = "encodeButton";
            this.encodeButton.Size = new System.Drawing.Size(134, 64);
            this.encodeButton.TabIndex = 0;
            this.encodeButton.Text = "Encode";
            this.encodeButton.UseVisualStyleBackColor = true;
            this.encodeButton.Click += new System.EventHandler(this.encodeButton_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.ErrorImage = global::Stenographer.Properties.Resources.error;
            this.pictureBox.InitialImage = global::Stenographer.Properties.Resources.error;
            this.pictureBox.Location = new System.Drawing.Point(12, 28);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(480, 320);
            this.pictureBox.TabIndex = 2;
            this.pictureBox.TabStop = false;
            // 
            // decodeButton
            // 
            this.decodeButton.Location = new System.Drawing.Point(289, 466);
            this.decodeButton.Name = "decodeButton";
            this.decodeButton.Size = new System.Drawing.Size(134, 64);
            this.decodeButton.TabIndex = 3;
            this.decodeButton.Text = "Decode";
            this.decodeButton.UseVisualStyleBackColor = true;
            this.decodeButton.Click += new System.EventHandler(this.decodeButton_Click);
            // 
            // textBox
            // 
            this.textBox.AcceptsReturn = true;
            this.textBox.Location = new System.Drawing.Point(76, 354);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.PlaceholderText = "Enter text to encrypt into the image";
            this.textBox.Size = new System.Drawing.Size(347, 106);
            this.textBox.TabIndex = 4;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "png";
            this.saveFileDialog.Filter = "Png Files|*.png;";
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "png";
            this.openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(507, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.Location = new System.Drawing.Point(76, 539);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(347, 15);
            this.statusLabel.TabIndex = 6;
            this.statusLabel.Text = "Status:";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Steganographer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 577);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.decodeButton);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.encodeButton);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Steganographer";
            this.Text = "Steganographer";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button encodeButton;
        private PictureBox pictureBox;
        private Button decodeButton;
        private TextBox textBox;
        private SaveFileDialog saveFileDialog;
        private OpenFileDialog openFileDialog;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem loadToolStripMenuItem;
        private Label statusLabel;
    }
}