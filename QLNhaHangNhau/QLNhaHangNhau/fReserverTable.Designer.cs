namespace QLNhaHangNhau
{
    partial class fReserverTable
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
            components = new System.ComponentModel.Container();
            errorProvider = new ErrorProvider(components);
            panel2 = new Panel();
            btnCancelReserveTable = new Button();
            btnSaveReserveTable = new Button();
            panel1 = new Panel();
            txbPhoneNumCus = new TextBox();
            txbNameCus = new TextBox();
            label3 = new Label();
            label2 = new Label();
            numCus = new NumericUpDown();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numCus).BeginInit();
            SuspendLayout();
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnCancelReserveTable);
            panel2.Controls.Add(btnSaveReserveTable);
            panel2.Location = new Point(2, 162);
            panel2.Name = "panel2";
            panel2.Size = new Size(341, 66);
            panel2.TabIndex = 1;
            // 
            // btnCancelReserveTable
            // 
            btnCancelReserveTable.Location = new Point(245, 23);
            btnCancelReserveTable.Name = "btnCancelReserveTable";
            btnCancelReserveTable.Size = new Size(75, 23);
            btnCancelReserveTable.TabIndex = 7;
            btnCancelReserveTable.Text = "Cancel";
            btnCancelReserveTable.UseVisualStyleBackColor = true;
            // 
            // btnSaveReserveTable
            // 
            btnSaveReserveTable.Location = new Point(110, 23);
            btnSaveReserveTable.Name = "btnSaveReserveTable";
            btnSaveReserveTable.Size = new Size(75, 23);
            btnSaveReserveTable.TabIndex = 6;
            btnSaveReserveTable.Text = "Save";
            btnSaveReserveTable.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(txbPhoneNumCus);
            panel1.Controls.Add(txbNameCus);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(numCus);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(2, 13);
            panel1.Name = "panel1";
            panel1.Size = new Size(341, 143);
            panel1.TabIndex = 2;
            // 
            // txbPhoneNumCus
            // 
            txbPhoneNumCus.Location = new Point(110, 56);
            txbPhoneNumCus.Name = "txbPhoneNumCus";
            txbPhoneNumCus.Size = new Size(210, 23);
            txbPhoneNumCus.TabIndex = 5;
            txbPhoneNumCus.Text = "0123456789";
            // 
            // txbNameCus
            // 
            txbNameCus.Location = new Point(110, 9);
            txbNameCus.Name = "txbNameCus";
            txbNameCus.Size = new Size(210, 23);
            txbNameCus.TabIndex = 4;
            txbNameCus.Text = "tester";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 103);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 3;
            label3.Text = "Số lượng:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 59);
            label2.Name = "label2";
            label2.Size = new Size(30, 15);
            label2.TabIndex = 2;
            label2.Text = "SĐT:";
            // 
            // numCus
            // 
            numCus.Location = new Point(110, 101);
            numCus.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numCus.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numCus.Name = "numCus";
            numCus.Size = new Size(210, 23);
            numCus.TabIndex = 1;
            numCus.TextAlign = HorizontalAlignment.Center;
            numCus.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 12);
            label1.Name = "label1";
            label1.Size = new Size(66, 15);
            label1.TabIndex = 0;
            label1.Text = "Tên khách: ";
            // 
            // fReserverTable
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(345, 240);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "fReserverTable";
            Text = "fReserverTable";
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numCus).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private ErrorProvider errorProvider;
        private Panel panel2;
        private Button btnCancelReserveTable;
        private Button btnSaveReserveTable;
        private Panel panel1;
        private TextBox txbPhoneNumCus;
        private TextBox txbNameCus;
        private Label label3;
        private Label label2;
        private NumericUpDown numCus;
        private Label label1;
    }
}