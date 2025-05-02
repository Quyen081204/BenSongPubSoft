using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLNhaHangNhau.DAO;
using QLNhaHangNhau.DTO;

namespace QLNhaHangNhau
{
    public partial class fAccountProfile : Form
    {
        private Account loginAccount;
        public fAccountProfile(DTO.Account account)
        {
            InitializeComponent();
            this.loginAccount = account;
            LoadProfile();
        }

        private void LoadProfile()
        {
            this.txtUsername.Text = this.loginAccount.Username;
            this.txbShowName.Text = this.loginAccount.Employee.Name;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool checkOldPass = false;
            bool checkRepeatPass = false;
            if (txbPassword.Text != "" && txbNewPassword.Text != "" && txbRepeatNewPass.Text != "")
            {
                // Check if current password is true
                string currentPass = txbPassword.Text;
                if (BCrypt.Net.BCrypt.EnhancedVerify(currentPass, loginAccount.Password))
                {
                    lblOldPassMsg.Text = "";
                    checkOldPass = true;
                }
                else
                {
                    lblOldPassMsg.Text = "Mật khẩu hiện tại không đúng";
                    lblOldPassMsg.ForeColor = Color.Red;
                }

                // Check if repeatPass is same as newpass
                if (txbRepeatNewPass.Text == txbNewPassword.Text)
                {
                    lblRepeatPassMsg.Text = "";
                    checkRepeatPass = true;
                }
                else
                {
                    lblRepeatPassMsg.Text = "Mật khẩu được nhập lại không trùng với mật khẩu mới";
                    lblRepeatPassMsg.ForeColor = Color.Red;
                }

                if (checkOldPass && checkRepeatPass)
                {
                    // Update
                    int result = AccountDAO.Instance.UpdatePassword(loginAccount, txbNewPassword.Text);

                    if (result > 0)
                    {
                        txbPassword.Text = "";
                        txbNewPassword.Text = "";
                        txbRepeatNewPass.Text = "";
                        MessageBox.Show("Cập nhật mật khẩu thành công", "Thông báo");
                    }
                    else 
                        MessageBox.Show("Cập nhật mật khẩu thất bại !!!", "Thông báo");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin yêu cầu !!!", "Thông báo");
            }
        }

     
    }
}
