using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using QLNhaHangNhau.DAO;
using QLNhaHangNhau.DTO;

namespace QLNhaHangNhau
{
    public partial class fReserverTable : Form
    {
        public Account CurrentUser { get; set; }
        public Table Table_reserve { get; set; }
        private bool valid_name = false;
        private bool valid_phone = false;
        public fReserverTable()
        {
            InitializeComponent();
            this.btnCancelReserveTable.Click += btnCancelReserveTable_Click;
            this.btnSaveReserveTable.Click += btnSaveReserveTable_Click;
            this.txbNameCus.Validating += new System.ComponentModel.CancelEventHandler(txbNameCus_validating);
            this.txbPhoneNumCus.Validating += new System.ComponentModel.CancelEventHandler(txbPhoneNumCus_validating);
            Console.WriteLine("hahaha");
        }

        public fReserverTable(Account currentUser, Table table_clicked)
        {
            this.CurrentUser = currentUser;
            this.Table_reserve = table_clicked;
            InitializeComponent();
            this.txbNameCus.Validating += new System.ComponentModel.CancelEventHandler(txbNameCus_validating);
            this.txbPhoneNumCus.Validating += new System.ComponentModel.CancelEventHandler(txbPhoneNumCus_validating);
            this.btnCancelReserveTable.Click += btnCancelReserveTable_Click;
            this.btnSaveReserveTable.Click += btnSaveReserveTable_Click;
        }

        #region Method

        public void ResetForm()
        {
            this.txbNameCus.Clear();
            this.txbPhoneNumCus.Clear();
            this.numCus.Value = 1;
            this.valid_name = false;
            this.valid_phone = false;
            this.errorProvider.Clear();
            this.txbNameCus.Focus();
        }

        #endregion

        #region event
        private void txbPhoneNumCus_validating(object? sender, EventArgs e)
        {
            if (txbPhoneNumCus.Text == string.Empty)
            {
                errorProvider.SetError(txbPhoneNumCus, "Vui lòng SĐT");
            }
            else if (!txbPhoneNumCus.Text.All(char.IsDigit))
            {
                errorProvider.SetError(txbPhoneNumCus, "SĐT chỉ chứa số");
            }
            else if (txbPhoneNumCus.Text.Length != 10)
            {
                errorProvider.SetError(txbPhoneNumCus, "SĐT độ dài không hợp lệ");
            }
            else
            {
                errorProvider.Clear();
                valid_phone = true;
            }
        }

        private void txbNameCus_validating(object? sender, EventArgs e)
        {
            if (txbNameCus.Text == string.Empty)
            {
                errorProvider.SetError(txbNameCus, "Vui lòng nhập tên");
            }
            else if (char.IsDigit(txbNameCus.Text[0]))
            {
                errorProvider.SetError(txbNameCus, "Tên không thể bắt đầu với số");
            }
            else
            {
                errorProvider.Clear();
                valid_name = true;
            }
        }

        private void btnSaveReserveTable_Click(object sender, EventArgs e)
        {
            if (valid_name && valid_phone)
            {
                string name = txbNameCus.Text;
                string phone = txbPhoneNumCus.Text;
                int numOfCus = (int)numCus.Value;

                // Store in database
                string query = """
                    INSERT INTO ChiTietBan (BanID, NhanVienID, SLKhach, SDTKhach ,TenKhach)
                    OUTPUT INSERTED.id
                    VALUES (@tableID, @employeeID, @numCus, @SDT ,@nameCus)
                    """;
                SqlCommand cmd = new SqlCommand(query);
                cmd.Parameters.AddWithValue("@tableID", Table_reserve.Id);
                cmd.Parameters.AddWithValue("@employeeID", CurrentUser.Employee.Id);
                cmd.Parameters.AddWithValue("@numCus", numOfCus);
                cmd.Parameters.AddWithValue("@SDT", phone);
                cmd.Parameters.AddWithValue("@nameCus", name);

                // Get table detail id and attach it to a table
                // Update table status in database
                
                int tableDetailID = (int)DataProvider.Instance.ExecuteScalar(cmd);
                // Console.WriteLine($"{tableDetailID} just inserted");
               
                Table_reserve.TableDetailID = tableDetailID;
                Table_reserve.Status = 1;
                
                // For testing 
                //if (TableDAO.Instance.UpadateTableStatus(table_reserve))
                //{
                //    Console.WriteLine("Upadate ban thanh cong");
                //}

                TableDAO.Instance.UpadateTableStatus(Table_reserve);
                
                // Update the main form after the table has been reserved
                var tupleControls = (ValueTuple<Panel, Button, ListView>)this.Tag;
                Panel pnlInfoTable = tupleControls.Item1;
                Button btn = tupleControls.Item2;
                ListView lstReceipt = tupleControls.Item3;

                //pnlInfoTable.Controls.Remove(this);
                lstReceipt.Items.Clear();
                //pnlInfoTable.Controls.Add(lstReceipt);
                btn.Text = "";
                btn.Text = Table_reserve.Name + Environment.NewLine;
                btn.Text += "Có khách";
               // btn.BackColor = Color.Orange;

                // Cap nhat lại là bàn đã có người
                btn.PerformClick();
            }
            else
            {
                MessageBox.Show("Đang còn lỗi", "Thông báo");
            }
        }

        private void btnCancelReserveTable_Click(object sender, EventArgs e)
        {
            Console.WriteLine("BTN Cancel call");
            var tupleControls = (ValueTuple<Panel, Button, ListView>)this.Tag;
            Panel pnlInfoTable = tupleControls.Item1;
            ListView lstReceipt = tupleControls.Item3;

            pnlInfoTable.Controls.Remove(this);
            lstReceipt.Items.Clear();
            pnlInfoTable.Controls.Add(lstReceipt);
        }

        #endregion
    }
}



/// FIX Reserve table, Show Order List, Add Focus Feature 
/// Need: add food ...
