namespace File_Management_v2
{
    partial class ImagePreview
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            picBoxImagePreview = new PictureBox();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)picBoxImagePreview).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // picBoxImagePreview
            // 
            picBoxImagePreview.Dock = DockStyle.Fill;
            picBoxImagePreview.Location = new Point(0, 0);
            picBoxImagePreview.Name = "picBoxImagePreview";
            picBoxImagePreview.Size = new Size(800, 450);
            picBoxImagePreview.SizeMode = PictureBoxSizeMode.AutoSize;
            picBoxImagePreview.TabIndex = 0;
            picBoxImagePreview.TabStop = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(picBoxImagePreview);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 450);
            panel1.TabIndex = 1;
            // 
            // ImagePreview
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Name = "ImagePreview";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "ImagePreview";
            TopMost = true;
            ((System.ComponentModel.ISupportInitialize)picBoxImagePreview).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        public PictureBox picBoxImagePreview;
    }
}