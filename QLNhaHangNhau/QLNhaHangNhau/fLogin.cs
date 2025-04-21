using QLNhaHangNhau.DAO;
using QLNhaHangNhau.DTO;

namespace QLNhaHangNhau
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();

            //CreateAccount();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txbUsername.Text;
            string password = txbPassword.Text;
            if(Login(username,password))
            {
                Account currentUser = AccountDAO.Instance.GetAccountByUserName(username);
                //Console.WriteLine(currentUser);
                fTableManager fTableManager = new fTableManager(currentUser);
                this.Hide();
                fTableManager.ShowDialog();
                this.Show();
            }
            else
            {
                if(MessageBox.Show("Tài khoản hoặc mật khẩu không đúng vui lòng thử lại", "Thông báo") == DialogResult.OK)
                {
                    txbUsername.Clear();
                    txbPassword.Clear();
                    txbUsername.Focus();
                }        
            }
        }


        private bool Login(string username, string password)
        {
            return AccountDAO.Instance.Login(username, password);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.Cancel) 
            {
                e.Cancel = true;
            }
        }

        private void CreateAccount()
        {
            string username = "lyly";
            string password = "123";

            string hashedPass = BCrypt.Net.BCrypt.EnhancedHashPassword(password);
            string cmd = "INSERT INTO Account (username, password, NhanVienID) VALUES ( @username , @password , @nvID )";
            int nvid = 3;
            DAO.DataProvider.Instance.ExecuteNonQuery(cmd, new string[] { username, hashedPass, nvid.ToString() });
        }
    }
}
