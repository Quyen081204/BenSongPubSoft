namespace QLNhaHangNhau
{
    partial class fSwitchTable
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
            fpnlSwitchTable = new FlowLayoutPanel();
            panel1 = new Panel();
            panel2 = new Panel();
            label1 = new Label();
            btnSwitch = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // fpnlSwitchTable
            // 
            fpnlSwitchTable.Location = new Point(0, 52);
            fpnlSwitchTable.Name = "fpnlSwitchTable";
            fpnlSwitchTable.Size = new Size(584, 315);
            fpnlSwitchTable.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(584, 46);
            panel1.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnSwitch);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 373);
            panel2.Name = "panel2";
            panel2.Size = new Size(584, 40);
            panel2.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 12.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(218, 9);
            label1.Name = "label1";
            label1.Size = new Size(147, 19);
            label1.TabIndex = 0;
            label1.Text = "Bàn có thể chuyển";
            // 
            // btnSwitch
            // 
            btnSwitch.Location = new Point(243, 0);
            btnSwitch.Name = "btnSwitch";
            btnSwitch.Size = new Size(122, 37);
            btnSwitch.TabIndex = 0;
            btnSwitch.Text = "Chuyển bàn";
            btnSwitch.UseVisualStyleBackColor = true;
            btnSwitch.Click += btnSwitch_Click;
            // 
            // fSwitchTable
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 413);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(fpnlSwitchTable);
            Name = "fSwitchTable";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chuyển bàn";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel fpnlSwitchTable;
        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private Button btnSwitch;
    }
}