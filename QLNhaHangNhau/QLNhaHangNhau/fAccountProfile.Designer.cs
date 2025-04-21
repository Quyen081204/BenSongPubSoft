namespace QLNhaHangNhau
{
    partial class fAccountProfile
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
            panel2 = new Panel();
            txbShowName = new TextBox();
            lblHienThi = new Label();
            panel1 = new Panel();
            txtUsername = new TextBox();
            label1 = new Label();
            panel3 = new Panel();
            txbPassword = new TextBox();
            lblPassWord = new Label();
            panel4 = new Panel();
            textBox1 = new TextBox();
            lblNewpass = new Label();
            panel5 = new Panel();
            textBox2 = new TextBox();
            label3 = new Label();
            btnExit = new Button();
            btnUpdate = new Button();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(txbShowName);
            panel2.Controls.Add(lblHienThi);
            panel2.Location = new Point(0, 75);
            panel2.Name = "panel2";
            panel2.Size = new Size(543, 67);
            panel2.TabIndex = 2;
            // 
            // txbShowName
            // 
            txbShowName.Location = new Point(185, 22);
            txbShowName.Name = "txbShowName";
            txbShowName.ReadOnly = true;
            txbShowName.Size = new Size(252, 23);
            txbShowName.TabIndex = 0;
            // 
            // lblHienThi
            // 
            lblHienThi.AutoSize = true;
            lblHienThi.Location = new Point(44, 25);
            lblHienThi.Name = "lblHienThi";
            lblHienThi.Size = new Size(71, 15);
            lblHienThi.TabIndex = 0;
            lblHienThi.Text = "Tên hiển thị:";
            // 
            // panel1
            // 
            panel1.Controls.Add(txtUsername);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(543, 67);
            panel1.TabIndex = 1;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(185, 22);
            txtUsername.Name = "txtUsername";
            txtUsername.ReadOnly = true;
            txtUsername.Size = new Size(252, 23);
            txtUsername.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(44, 25);
            label1.Name = "label1";
            label1.Size = new Size(88, 15);
            label1.TabIndex = 0;
            label1.Text = "Tên đăng nhập:";
            // 
            // panel3
            // 
            panel3.Controls.Add(txbPassword);
            panel3.Controls.Add(lblPassWord);
            panel3.Location = new Point(0, 148);
            panel3.Name = "panel3";
            panel3.Size = new Size(543, 67);
            panel3.TabIndex = 3;
            // 
            // txbPassword
            // 
            txbPassword.Location = new Point(185, 22);
            txbPassword.Name = "txbPassword";
            txbPassword.Size = new Size(252, 23);
            txbPassword.TabIndex = 0;
            txbPassword.UseSystemPasswordChar = true;
            // 
            // lblPassWord
            // 
            lblPassWord.AutoSize = true;
            lblPassWord.Location = new Point(44, 25);
            lblPassWord.Name = "lblPassWord";
            lblPassWord.Size = new Size(60, 15);
            lblPassWord.TabIndex = 0;
            lblPassWord.Text = "Mật khẩu:";
            // 
            // panel4
            // 
            panel4.Controls.Add(textBox1);
            panel4.Controls.Add(lblNewpass);
            panel4.Location = new Point(0, 221);
            panel4.Name = "panel4";
            panel4.Size = new Size(543, 67);
            panel4.TabIndex = 4;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(185, 22);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(252, 23);
            textBox1.TabIndex = 0;
            textBox1.UseSystemPasswordChar = true;
            // 
            // lblNewpass
            // 
            lblNewpass.AutoSize = true;
            lblNewpass.Location = new Point(44, 25);
            lblNewpass.Name = "lblNewpass";
            lblNewpass.Size = new Size(84, 15);
            lblNewpass.TabIndex = 0;
            lblNewpass.Text = "Mật khẩu mới:";
            // 
            // panel5
            // 
            panel5.Controls.Add(textBox2);
            panel5.Controls.Add(label3);
            panel5.Location = new Point(0, 294);
            panel5.Name = "panel5";
            panel5.Size = new Size(543, 67);
            panel5.TabIndex = 5;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(185, 22);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(252, 23);
            textBox2.TabIndex = 0;
            textBox2.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(44, 25);
            label3.Name = "label3";
            label3.Size = new Size(107, 15);
            label3.TabIndex = 0;
            label3.Text = "Nhập lại mật khẩu:";
            // 
            // btnExit
            // 
            btnExit.Location = new Point(362, 377);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(75, 23);
            btnExit.TabIndex = 6;
            btnExit.Text = "Thoát";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(256, 377);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 6;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // fAccountProfile
            // 
            AcceptButton = btnUpdate;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnExit;
            ClientSize = new Size(555, 430);
            Controls.Add(btnExit);
            Controls.Add(panel5);
            Controls.Add(btnUpdate);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Name = "fAccountProfile";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thông tin cá nhân";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private TextBox txbShowName;
        private Label lblHienThi;
        private Panel panel1;
        private TextBox txtUsername;
        private Label label1;
        private Panel panel3;
        private TextBox txbPassword;
        private Label lblPassWord;
        private Panel panel4;
        private TextBox textBox1;
        private Label lblNewpass;
        private Panel panel5;
        private TextBox textBox2;
        private Label label3;
        private Button btnExit;
        private Button btnUpdate;
    }
}