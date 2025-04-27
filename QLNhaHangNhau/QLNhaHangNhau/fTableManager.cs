using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLNhaHangNhau.DAO;
using QLNhaHangNhau.DTO;
using System.Text.RegularExpressions;

namespace QLNhaHangNhau
{
    public partial class fTableManager : Form
    {
        public Account CurrentUser { get; set; }
        private fReserverTable fReserverTable;
        private Color vacantColor = Color.AliceBlue;
        private Color focusColor = SystemColors.ControlLight;
        private Color fullColor = Color.Orange;
        private Button? prevButton = null;
        // Hien thi vn dong
        CultureInfo culture = new CultureInfo("vi-VN");

        public fTableManager()
        {
            InitializeComponent();
            LoadTable();
            LoadMenu();
            fReserverTable = new fReserverTable();
            fReserverTable.CurrentUser = this.CurrentUser;
            fReserverTable.TopLevel = false;
            fReserverTable.FormBorderStyle = FormBorderStyle.None;
        }

        public fTableManager(Account currentUser)
        {
            this.CurrentUser = currentUser;
            InitializeComponent();
            WhetherEnableAdminTab();
            LoadTable();
            LoadMenu();
            fReserverTable = new fReserverTable();
            fReserverTable.CurrentUser = this.CurrentUser;
            fReserverTable.TopLevel = false;
            fReserverTable.FormBorderStyle = FormBorderStyle.None;
        }

        #region Method

        private void WhetherEnableAdminTab()
        {
            adminToolStripMenuItem.Enabled = CurrentUser.Employee.RoleID == 4;
        }

        private void ReserveTable(Button btn, Table table_clicked)
        {
            fReserverTable.Tag = (pnlInfoTable, btn, lstReceipt);
            fReserverTable.Table_reserve = table_clicked;
            pnlInfoTable.Controls.Add(fReserverTable);
            fReserverTable.Show();
            fReserverTable.ResetForm();
        }

        private void ShowOrderList(int? tableDetailID)
        {

            lstReceipt.Items.Clear();
            if (tableDetailID != null)
            {
                List<TableOrderFood> tableOrderFoods = TableOrderFoodDAO.GetInstance().GetListFoodTableOrdered((int)tableDetailID);
                double totalPrice = 0;
                foreach (var item in tableOrderFoods)
                {
                    ListViewItem lsvItem = new ListViewItem(item.FoodName);
                    lsvItem.SubItems.Add(item.Count.ToString());
                    lsvItem.SubItems.Add(item.Price.ToString());
                    lsvItem.SubItems.Add(item.TotalPrice.ToString());
                    totalPrice += item.TotalPrice;
                    lstReceipt.Items.Add(lsvItem);
                }
                if (tableOrderFoods.Count > 0)
                {
                    Add_info_total_price("Tổng:", totalPrice.ToString("F0"));
                    Add_info_total_price("Thuế VAT:", "10%", 0);
                    float VAT = 0.1f;
                    totalPrice = totalPrice + totalPrice * VAT;
                    Add_info_total_price("Thực tổng:", totalPrice.ToString("F0"), 0);

                }
                // Adding total price in the GUI with specific Viet Nam currency format
                CultureInfo culture = new CultureInfo("vi-VN");
                txbTotalPrice.Text = totalPrice.ToString("c", culture);
            }
        }

        private void Add_info_total_price(string key, string value, int space = 2)
        {
            for (int i = 0; i < space; i++)
            {
                ListViewItem lsvItem = new ListViewItem("");
                lstReceipt.Items.Add(lsvItem);
            }
            ListViewItem lsvItem3 = new ListViewItem("");
            lsvItem3.SubItems.Add("");
            lsvItem3.SubItems.Add(key);
            lsvItem3.SubItems.Add(value);
            lstReceipt.Items.Add(lsvItem3);
        }

        private void LoadTable()
        {
            List<Table> tableList = TableDAO.Instance.LoadTableList();
            foreach (Table table in tableList)
            {
                Button btn = new Button() { Width = TableDAO.TableWidth, Height = TableDAO.TableHeight };
                btn.Text = table.Name + Environment.NewLine;
                btn.Click += table_clicked;
                btn.Tag = table;
                if (table.Status == 1)
                {
                    btn.Text += "Có khách";
                    btn.BackColor = fullColor;
                }
                else
                {
                    btn.Text += "Trống" + Environment.NewLine;
                    btn.Text += $"SL {table.Capacity}";

                    btn.BackColor = vacantColor;
                }

                fpnTable.Controls.Add(btn);
            }
        }
        private void LoadMenu()
        {
            List<Menu> listMenu = MenuDAO.GetInstance().GetListMenu();
            cbMenu.DataSource = listMenu;
            cbMenu.DisplayMember = "Name";
        }

        private void LoadFoodByMenuID(int menuID)
        {
            List<Food> listFood = FoodDAO.GetInstance().GetFoodByMenuID(menuID);
            cbFood.DataSource = listFood;
            cbFood.DisplayMember = "Name";
        }

        #endregion

        #region Events
        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAccountProfile fAccountProfile = new fAccountProfile();
            fAccountProfile.ShowDialog();
            this.Show();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin fAdmin = new fAdmin();
            fAdmin.ShowDialog();
        }

        private void table_clicked(object sender, EventArgs e)
        {
            // Reset
            txbTotalPrice.Text = "0";
            btnAddFood.Tag = null;
            btnReduceFood.Tag = null;
            btnCheckOutCash.Tag = null;
            btnCheckOutMomo.Tag = null;

            numAddFood.Value = numAddFood.Minimum;
            numDiscount.Value = numDiscount.Minimum;

            Button btn = sender as Button;
            Table table_clicked = null;


            // Doi lai mau cho nut vua bam
            if (prevButton != null)
            {
                prevButton.BackColor = ((Table)prevButton.Tag).Status == 1 ? fullColor : vacantColor;
            }

            prevButton = btn;

            btn.BackColor = focusColor;

            if (btn != null && btn.Tag is Table)
            {
                table_clicked = (Table)btn.Tag;
            }

            // Hien thi Form dat ban cho khach
            if (table_clicked != null && table_clicked.Status == 0) // Ban con trong
            {
                // Disable button that need customer
                btnAddFood.Enabled = false;
                btnReduceFood.Enabled = false;
                numDiscount.Enabled = false;
                btnSwitchTable.Enabled = false;
                btnCheckOutCash.Enabled = false;
                btnCheckOutMomo.Enabled = false;
                numAddFood.Enabled = false;
                btnDiscount.Enabled = false;

                // Temporarily remove receipt
                pnlInfoTable.Controls.Remove(lstReceipt);
                ReserveTable(btn, table_clicked);
            }

            // Ban da co khach
            if (table_clicked.Status == 1)
            {
                // Enable button
                // Disable button that need customer
                btnAddFood.Enabled = true;
                btnReduceFood.Enabled = true;
                numDiscount.Enabled = true;
                btnSwitchTable.Enabled = true;
                btnCheckOutCash.Enabled = true;
                btnCheckOutMomo.Enabled = true;
                numAddFood.Enabled = true;
                btnDiscount.Enabled = true;

                pnlInfoTable.Controls.Remove(fReserverTable);
                pnlInfoTable.Controls.Add(lstReceipt);

                // When adding food we know which table has ordered food
                btnAddFood.Tag = table_clicked;
                btnReduceFood.Tag = table_clicked;

                // When checkout we know which table need checkout
                btnCheckOutCash.Tag = table_clicked;
                btnCheckOutMomo.Tag = table_clicked;

                ShowOrderList(table_clicked.TableDetailID);
            }
        }

        private void cbMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbMenu = sender as ComboBox;
            if (cbMenu.SelectedItem == null)
                return;
            // Get the menu obj is being selected
            Menu selected = cbMenu.SelectedItem as Menu;
            int menuID = selected.ID;
            // Load the list food by the selected menu
            LoadFoodByMenuID(menuID);
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            Button btnAddFood = sender as Button;
            Table table_clicked = (Table)btnAddFood.Tag;

            if (table_clicked != null && table_clicked is Table)
            {
                Food food = cbFood.SelectedItem as Food;
                int sl = (int)numAddFood.Value;
                if (food != null)
                {
                    int rowAffected = OrderDetailDAO.GetInstance().AddFoodForTableByID((int)table_clicked.TableDetailID, food.ID, sl);
                    // Neu them mon thanh cong thi reload lai danh sach mon
                    if (rowAffected > 0)
                    {
                        // Reset value numAddFood
                        numAddFood.Value = numAddFood.Minimum;
                        ShowOrderList(table_clicked.TableDetailID);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn bàn", "Thông báo");
            }
        }

        private void btnReduceFood_Click(object sender, EventArgs e)
        {
            Button btnAddFood = sender as Button;
            Table table_clicked = (Table)btnAddFood.Tag;

            if (table_clicked != null && table_clicked is Table)
            {
                Food food = cbFood.SelectedItem as Food;
                int sl = (int)numAddFood.Value;
                int? currentQuantity = OrderDetailDAO.GetInstance().GetCurrentQuantity((int)table_clicked.TableDetailID, food.ID);

                // Neu sau khi giam so luong con lai bang khong thi xoa mon an do
                if (currentQuantity == null)
                {
                    MessageBox.Show("Bàn hiện tại chưa đặt món cần giảm", "Thông báo");
                    return;
                }
                else
                {
                    if (sl == currentQuantity)
                    {
                        if (MessageBox.Show("Bạn có muốn xóa món này ?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            int rowAffected = OrderDetailDAO.GetInstance().RemoveFoodFromTable((int)table_clicked.TableDetailID, food.ID);
                            if (rowAffected > 0)
                            {
                                // Reset value of numAddFood
                                numAddFood.Value = numAddFood.Minimum;
                                ShowOrderList(table_clicked.TableDetailID);
                            }
                            return;
                        }
                    }
                }

                // Giam so luong mon va kiem tra so luong giam co hop le hay khong
                if (food != null)
                {
                    int rowAffected = OrderDetailDAO.GetInstance().ReduceFoodForTableByID((int)table_clicked.TableDetailID, food.ID, sl);
                    if (rowAffected > 0)
                    {
                        // Reset value of numAddFood
                        numAddFood.Value = numAddFood.Minimum;
                        ShowOrderList(table_clicked.TableDetailID);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn bàn", "Thông báo");
            }
        }

        private void btnDiscount_Click(object sender, EventArgs e)
        {
            if (prevButton != null)
            {
                double percent_discount = (int)numDiscount.Value / 100.0;

                int total_price_before_discount = int.Parse(Regex.Replace(txbTotalPrice.Text, @"[^\d]", ""));
                double total_price_after_discount = total_price_before_discount * (1 - percent_discount);

                txbTotalPrice.Text = total_price_after_discount.ToString("c", culture);
                // reset
                numDiscount.Value = numDiscount.Minimum;
            }
            else
            {
                MessageBox.Show("Vui lòng chọn bàn !!!", "Thông báo");
            }
        }

        private void btnCheckOutCash_Click(object sender, EventArgs e)
        {
            Console.WriteLine("== cash cash ==");
            // Neu chua co ban nao duoc chon

            if (prevButton == null)
            {
                MessageBox.Show("Chưa có bàn được chọn !!!", "Thông báo");
                return;
            }

            Button btnCheckOutCash = sender as Button;
            Table table_clicked = null;

            if (btnCheckOutCash != null && btnCheckOutCash.Tag is Table)
            {
                table_clicked = (Table)btnCheckOutCash.Tag;
            }

            if (table_clicked != null)
            {
                // Ban da co nguoi nhung chua order gi
                if (Regex.Replace(txbTotalPrice.Text, @"[^\d]", "") == "0")
                {
                    MessageBox.Show("Bàn chưa có order đồ ăn", "Thông báo");
                }
                else
                {
                    // Tinh toan discount gia lap nut discount bam
                    int discount = (int)numDiscount.Value;
                    btnDiscount.PerformClick();

                    // Hop le tien hanh tao hoa don va thanh toan
                    int total_price = int.Parse(Regex.Replace(txbTotalPrice.Text, @"[^\d]", ""));
                    int status = 1; // Success
                    string payment_method = "CASH";
                    Bill bill = new Bill(CurrentUser.Employee.Id, (int)table_clicked.TableDetailID, discount , payment_method, total_price, status);
                    // Tao hoa don
                    int rowAffected = BillDAO.GetInstance().CreateBillCash(bill);
                    if (rowAffected > 0)
                    {
                        // Cap nhat trang thai ban
                        TableDAO.Instance.TableStatusReset(table_clicked);

                        // Cap nhat trang thai btn cho ban vua thanh toan
                        prevButton.Text = string.Empty;
                        prevButton.Text = table_clicked.Name + Environment.NewLine;
                        prevButton.Text += "Trống" + Environment.NewLine;
                        prevButton.Text += $"SL {table_clicked.Capacity}";

                        // Cap nhat ListView
                        lstReceipt.Items.Clear();

                        // Cap nhat num discount
                        numDiscount.Value = numDiscount.Minimum;

                        MessageBox.Show($"Thanh toán thành công {txbTotalPrice.Text}", "Thông báo");

                        // Reset txbTotalPrice
                        txbTotalPrice.Text = "0";
                    }
                    else
                    {
                        MessageBox.Show("Thanh toán thất bại", "Thông báo");
                    }
                }
            }
            else
            {
                MessageBox.Show("Bàn còn trống !!!", "Thông báo");
            }

        }

        private async void btnCheckOutMomo_Click(object sender, EventArgs e)
        {
            Console.WriteLine("== momo momo ==");
            // Neu chua co ban nao duoc chon

            if (prevButton == null)
            {
                MessageBox.Show("Chưa có bàn được chọn !!!", "Thông báo");
                return;
            }

            Button btnCheckOutMomo = sender as Button;
            Table table_clicked = null;

            if (btnCheckOutMomo != null && btnCheckOutMomo.Tag is Table)
            {
                table_clicked = (Table)btnCheckOutMomo.Tag;
            }

            if (table_clicked != null)
            {
                // Ban da co nguoi nhung chua order gi
                if (Regex.Replace(txbTotalPrice.Text, @"[^\d]", "") == "0")
                {
                    MessageBox.Show("Bàn chưa có order đồ ăn", "Thông báo");
                }
                else 
                {
                    // Tinh toan discount gia lap nut discount bam
                    int discount = (int)numDiscount.Value;
                    btnDiscount.PerformClick();

                    // Hop le tien hanh tao hoa don va thanh toan
                    int total_price = int.Parse(Regex.Replace(txbTotalPrice.Text, @"[^\d]", ""));

                    Payment pay_bill = new Payment();
                    pay_bill.amount = total_price;

                    //Goi api toi momo
                    Bitmap qrCodeImage = PaymentDAO.GetInstance().ProcessPayment(pay_bill);

                    if (qrCodeImage != null)
                    {
                        // Hien thi ma qrcode
                        fQRCode fQRCode = new fQRCode(qrCodeImage);
                        fQRCode.Show();

                        // Delay 1p30s de ng dung thanh toan
                        await Task.Delay(15000);

                        fQRCode.Close();

                        await Task.Delay(5000);
                        // Kiem tra thanh toan trong 2 phut -> lien tuc gui request toi api back end 
                        bool isPaid = await PaymentDAO.GetInstance().CheckPayment(pay_bill.orderId);

                        if (isPaid == true)
                        {
                            // Thanh toan thanh cong
                            // Luu bill

                            int status = 1; // Success
                            string payment_method = "MOMO";
                            Bill bill = new Bill(CurrentUser.Employee.Id, (int)table_clicked.TableDetailID, discount, payment_method, total_price, status);
                            // Tao hoa don
                            int billIDInserted = BillDAO.GetInstance().CreateBillOnline(bill);

                            // Luu payment
                            pay_bill.BillID = billIDInserted;
                            pay_bill.Status = "PAID";
                            pay_bill.UpdateAt = DateTime.Now;
                            int rowPaymentAffected = PaymentDAO.GetInstance().CreatePayment(pay_bill);

                            if (billIDInserted > 0 && rowPaymentAffected > 0)
                            {
                                // Cap nhat trang thai ban
                                TableDAO.Instance.TableStatusReset(table_clicked);

                                // Cap nhat trang thai btn cho ban vua thanh toan
                                prevButton.Text = string.Empty;
                                prevButton.Text = table_clicked.Name + Environment.NewLine;
                                prevButton.Text += "Trống" + Environment.NewLine;
                                prevButton.Text += $"SL {table_clicked.Capacity}";

                                // Cap nhat ListView
                                lstReceipt.Items.Clear();

                                // Cap nhat num discount
                                numDiscount.Value = numDiscount.Minimum;

                                MessageBox.Show($"Thanh toán thành công {txbTotalPrice.Text}", "Thông báo");

                                // Reset txbTotalPrice
                                txbTotalPrice.Text = "0";
                            }
                            else
                            {
                                MessageBox.Show("Thanh toán thất bại", "Thông báo");
                            }
                        }
                        else
                        {
                            MessageBox.Show($"Thanh toán hóa đơn {table_clicked.Name} thất bại !!!", "Thông báo");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Da co loi xay ra khi tao qr code");
                    }
                }
            }
            else
            {
               
            }

            
        }
        #endregion
    }

}
