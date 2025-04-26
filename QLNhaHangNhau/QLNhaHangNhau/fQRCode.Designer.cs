namespace QLNhaHangNhau
{
    partial class fQRCode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fQRCode));
            picBoxQRCode = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)picBoxQRCode).BeginInit();
            SuspendLayout();
            // 
            // picBoxQRCode
            // 
            picBoxQRCode.Location = new Point(0, 0);
            picBoxQRCode.Name = "picBoxQRCode";
            picBoxQRCode.Size = new Size(100, 50);
            picBoxQRCode.TabIndex = 0;
            picBoxQRCode.TabStop = false;
            // 
            // fQRCode
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 361);
            Controls.Add(picBoxQRCode);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "fQRCode";
            Text = "MoMo";
            ((System.ComponentModel.ISupportInitialize)picBoxQRCode).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox picBoxQRCode;
    }
}