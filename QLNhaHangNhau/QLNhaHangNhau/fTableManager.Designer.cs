namespace QLNhaHangNhau
{
    partial class fTableManager
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
            pnlInfoTable = new Panel();
            lstReceipt = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            panel3 = new Panel();
            btnReduceFood = new Button();
            numAddFood = new NumericUpDown();
            btnAddFood = new Button();
            cbFood = new ComboBox();
            cbMenu = new ComboBox();
            panel4 = new Panel();
            btnCheckOutCash = new Button();
            btnCheckOutMomo = new Button();
            txbTotalPrice = new TextBox();
            btnSwitchTable = new Button();
            numDiscount = new NumericUpDown();
            btnDiscount = new Button();
            fpnTable = new FlowLayoutPanel();
            adminToolStripMenuItem = new ToolStripMenuItem();
            thôngTinTàiKhoảnToolStripMenuItem = new ToolStripMenuItem();
            thôngTinCáNhânToolStripMenuItem = new ToolStripMenuItem();
            đăngXuấtToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1 = new MenuStrip();
            pnlInfoTable.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numAddFood).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numDiscount).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlInfoTable
            // 
            pnlInfoTable.Controls.Add(lstReceipt);
            pnlInfoTable.Location = new Point(342, 94);
            pnlInfoTable.Name = "pnlInfoTable";
            pnlInfoTable.Size = new Size(361, 279);
            pnlInfoTable.TabIndex = 2;
            // 
            // lstReceipt
            // 
            lstReceipt.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4 });
            lstReceipt.Dock = DockStyle.Fill;
            lstReceipt.GridLines = true;
            lstReceipt.Location = new Point(0, 0);
            lstReceipt.Name = "lstReceipt";
            lstReceipt.Size = new Size(361, 279);
            lstReceipt.TabIndex = 3;
            lstReceipt.UseCompatibleStateImageBehavior = false;
            lstReceipt.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Tên món ăn";
            columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Số lượng";
            columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Đơn giá";
            columnHeader3.Width = 80;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Thành tiền";
            columnHeader4.Width = 80;
            // 
            // panel3
            // 
            panel3.Controls.Add(btnReduceFood);
            panel3.Controls.Add(numAddFood);
            panel3.Controls.Add(btnAddFood);
            panel3.Controls.Add(cbFood);
            panel3.Controls.Add(cbMenu);
            panel3.Location = new Point(342, 27);
            panel3.Name = "panel3";
            panel3.Size = new Size(361, 61);
            panel3.TabIndex = 3;
            // 
            // btnReduceFood
            // 
            btnReduceFood.Location = new Point(204, 35);
            btnReduceFood.Name = "btnReduceFood";
            btnReduceFood.Size = new Size(95, 23);
            btnReduceFood.TabIndex = 4;
            btnReduceFood.Text = "Bớt món";
            btnReduceFood.UseVisualStyleBackColor = true;
            btnReduceFood.Click += btnReduceFood_Click;
            // 
            // numAddFood
            // 
            numAddFood.Location = new Point(314, 23);
            numAddFood.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numAddFood.Name = "numAddFood";
            numAddFood.Size = new Size(44, 23);
            numAddFood.TabIndex = 3;
            numAddFood.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnAddFood
            // 
            btnAddFood.Location = new Point(204, 3);
            btnAddFood.Name = "btnAddFood";
            btnAddFood.Size = new Size(95, 23);
            btnAddFood.TabIndex = 2;
            btnAddFood.Text = "Thêm món";
            btnAddFood.UseVisualStyleBackColor = true;
            btnAddFood.Click += btnAddFood_Click;
            // 
            // cbFood
            // 
            cbFood.FormattingEnabled = true;
            cbFood.Location = new Point(3, 35);
            cbFood.Name = "cbFood";
            cbFood.Size = new Size(186, 23);
            cbFood.TabIndex = 0;
            // 
            // cbMenu
            // 
            cbMenu.FormattingEnabled = true;
            cbMenu.Location = new Point(3, 3);
            cbMenu.Name = "cbMenu";
            cbMenu.Size = new Size(186, 23);
            cbMenu.TabIndex = 1;
            cbMenu.SelectedIndexChanged += cbMenu_SelectedIndexChanged;
            // 
            // panel4
            // 
            panel4.Controls.Add(btnCheckOutCash);
            panel4.Controls.Add(btnCheckOutMomo);
            panel4.Controls.Add(txbTotalPrice);
            panel4.Controls.Add(btnSwitchTable);
            panel4.Controls.Add(numDiscount);
            panel4.Controls.Add(btnDiscount);
            panel4.Location = new Point(342, 397);
            panel4.Name = "panel4";
            panel4.Size = new Size(361, 82);
            panel4.TabIndex = 4;
            // 
            // btnCheckOutCash
            // 
            btnCheckOutCash.Location = new Point(288, 56);
            btnCheckOutCash.Name = "btnCheckOutCash";
            btnCheckOutCash.Size = new Size(70, 23);
            btnCheckOutCash.TabIndex = 10;
            btnCheckOutCash.Text = "Cash";
            btnCheckOutCash.UseVisualStyleBackColor = true;
            btnCheckOutCash.Click += btnCheckOutCash_Click;
            // 
            // btnCheckOutMomo
            // 
            btnCheckOutMomo.Location = new Point(204, 56);
            btnCheckOutMomo.Name = "btnCheckOutMomo";
            btnCheckOutMomo.Size = new Size(70, 23);
            btnCheckOutMomo.TabIndex = 9;
            btnCheckOutMomo.Text = "Momo";
            btnCheckOutMomo.UseVisualStyleBackColor = true;
            btnCheckOutMomo.Click += btnCheckOutMomo_Click;
            // 
            // txbTotalPrice
            // 
            txbTotalPrice.Font = new Font("Times New Roman", 12.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txbTotalPrice.Location = new Point(204, 17);
            txbTotalPrice.Name = "txbTotalPrice";
            txbTotalPrice.ReadOnly = true;
            txbTotalPrice.Size = new Size(154, 27);
            txbTotalPrice.TabIndex = 8;
            txbTotalPrice.Text = "0";
            txbTotalPrice.TextAlign = HorizontalAlignment.Right;
            // 
            // btnSwitchTable
            // 
            btnSwitchTable.Location = new Point(3, 15);
            btnSwitchTable.Name = "btnSwitchTable";
            btnSwitchTable.Size = new Size(85, 64);
            btnSwitchTable.TabIndex = 7;
            btnSwitchTable.Text = "Chuyển bàn";
            btnSwitchTable.UseVisualStyleBackColor = true;
            btnSwitchTable.Click += btnSwitchTable_Click;
            // 
            // numDiscount
            // 
            numDiscount.Location = new Point(104, 56);
            numDiscount.Name = "numDiscount";
            numDiscount.Size = new Size(85, 23);
            numDiscount.TabIndex = 4;
            numDiscount.TextAlign = HorizontalAlignment.Center;
            // 
            // btnDiscount
            // 
            btnDiscount.Location = new Point(104, 15);
            btnDiscount.Name = "btnDiscount";
            btnDiscount.Size = new Size(85, 31);
            btnDiscount.TabIndex = 5;
            btnDiscount.Text = "Giảm giá";
            btnDiscount.UseVisualStyleBackColor = true;
            btnDiscount.Click += btnDiscount_Click;
            // 
            // fpnTable
            // 
            fpnTable.AutoScroll = true;
            fpnTable.Location = new Point(0, 27);
            fpnTable.Name = "fpnTable";
            fpnTable.Size = new Size(336, 452);
            fpnTable.TabIndex = 0;
            // 
            // adminToolStripMenuItem
            // 
            adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            adminToolStripMenuItem.Size = new Size(55, 20);
            adminToolStripMenuItem.Text = "Admin";
            adminToolStripMenuItem.Click += adminToolStripMenuItem_Click;
            // 
            // thôngTinTàiKhoảnToolStripMenuItem
            // 
            thôngTinTàiKhoảnToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { thôngTinCáNhânToolStripMenuItem, đăngXuấtToolStripMenuItem });
            thôngTinTàiKhoảnToolStripMenuItem.Name = "thôngTinTàiKhoảnToolStripMenuItem";
            thôngTinTàiKhoảnToolStripMenuItem.Size = new Size(122, 20);
            thôngTinTàiKhoảnToolStripMenuItem.Text = "Thông tin tài khoản";
            // 
            // thôngTinCáNhânToolStripMenuItem
            // 
            thôngTinCáNhânToolStripMenuItem.Name = "thôngTinCáNhânToolStripMenuItem";
            thôngTinCáNhânToolStripMenuItem.Size = new Size(170, 22);
            thôngTinCáNhânToolStripMenuItem.Text = "Thông tin cá nhân";
            thôngTinCáNhânToolStripMenuItem.Click += thôngTinCáNhânToolStripMenuItem_Click;
            // 
            // đăngXuấtToolStripMenuItem
            // 
            đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            đăngXuấtToolStripMenuItem.Size = new Size(170, 22);
            đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { adminToolStripMenuItem, thôngTinTàiKhoảnToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(715, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fTableManager
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(715, 491);
            Controls.Add(fpnTable);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(pnlInfoTable);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "fTableManager";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Phần mềm quản lý nhà hàng nhậu Bên Sông";
            pnlInfoTable.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numAddFood).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numDiscount).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel pnlInfoTable;
        private ListView lstReceipt;
        private Panel panel3;
        private Panel panel4;
        private FlowLayoutPanel fpnTable;
        private Button btnAddFood;
        private ComboBox cbFood;
        private ComboBox cbMenu;
        private NumericUpDown numAddFood;
        private NumericUpDown numDiscount;
        private Button btnDiscount;
        private Button btnSwitchTable;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private TextBox txbTotalPrice;
        private Button btnReduceFood;
        private Button btnCheckOutCash;
        private Button btnCheckOutMomo;
        private ToolStripMenuItem adminToolStripMenuItem;
        private ToolStripMenuItem thôngTinTàiKhoảnToolStripMenuItem;
        private ToolStripMenuItem thôngTinCáNhânToolStripMenuItem;
        private ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private MenuStrip menuStrip1;
    }
}