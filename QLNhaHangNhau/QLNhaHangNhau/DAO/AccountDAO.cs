using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using QLNhaHangNhau.DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QLNhaHangNhau.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        private AccountDAO() { }

        public static AccountDAO Instance {
            get 
            {
                if (instance == null)
                {
                    instance = new AccountDAO();
                }
                return instance;
            }    
            private set => instance = value; 
        }

        public bool Login(string username, string password)
        {
            string hashedPassword = (string)DataProvider.Instance.ExecuteScalar("SELECT password FROM Account WHERE username = @username", new string[] { username});

            if (hashedPassword != null)
            {
                if (BCrypt.Net.BCrypt.EnhancedVerify(password,hashedPassword))
                {
                    return true;    
                }                
            }

            return false;
        }

        public bool CheckActiveAccount(string username) 
        {
            if (GetAccountByUserName(username).Active == "Ngưng hoạt động")
            {
                return false;
            }
            return true;
        }

        public Account GetAccountByUserName(string userName) 
        {
            string query = "SELECT * FROM Account WHERE username = @username";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@username", userName);
            DataTable dt = DataProvider.Instance.ExecuteQuery(cmd);

            foreach (DataRow row in dt.Rows)
            {
                return new Account(row);
            }
            return null;
        }

        public int CreateAccount(string user_name, string pass ,int nv_id)
        {
            string username = user_name;
            string password = pass;

            string hashedPass = BCrypt.Net.BCrypt.EnhancedHashPassword(password);
            string cmd = "INSERT INTO Account (username, password, NhanVienID) OUTPUT Inserted.id VALUES ( @username , @password , @nvID )";
            int nvid = nv_id;
            int accId= (int)DataProvider.Instance.ExecuteScalar(cmd, new string[] { username, hashedPass, nvid.ToString() });
            return accId;
        }

        public int UpdatePassword(Account loginAccount, string newpass)
        {
            string hashedPass = BCrypt.Net.BCrypt.EnhancedHashPassword(newpass);
            string query = "UPDATE Account SET password = @newpass WHERE username = @username";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@newpass", hashedPass);
            cmd.Parameters.AddWithValue("@username", loginAccount.Username);

            int rowAffected = DataProvider.Instance.ExecuteNonQuery(cmd);

            if (rowAffected > 0)
            {
                // Update password
                loginAccount.Password = hashedPass;
                Console.WriteLine("Update password thanh cong");
            }
            else
            {
                Console.WriteLine("Update password that bai");
            }

            return rowAffected;
        }

        public List<Account> GetAllAccountAdmin()
        {
            string query = "SELECT * FROM Account";
            SqlCommand cmd = new SqlCommand(query);
            DataTable dt = DataProvider.Instance.ExecuteQuery(cmd);
            List<Account> listAccount = new List<Account>();

            foreach (DataRow row in dt.Rows) 
            {
                Account newAccount = new Account(row);
                listAccount.Add(newAccount);
            }

            return listAccount;
        }

        public bool UpdateUsernameAccount(int id, string username)
        {
            string query = """
                    UPDATE Account SET username = @username WHERE id = @id
                """;
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@id", id);

            int result = DataProvider.Instance.ExecuteNonQuery(cmd);

            return result > 0;
        }

        public bool DeactiveAccount(int id)
        {
            string query = """
                    UPDATE Account SET Active = @status WHERE id = @id
                """;
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@status", "Ngưng hoạt động");
            cmd.Parameters.AddWithValue("@id", id);

            int result = DataProvider.Instance.ExecuteNonQuery(cmd);

            return result > 0;
        }

        public bool ActiveAccount(int id)
        {
            string query = """
                    UPDATE Account SET Active = @status WHERE id = @id
                """;
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@status", "Đang hoạt động");
            cmd.Parameters.AddWithValue("@id", id);

            int result = DataProvider.Instance.ExecuteNonQuery(cmd);

            return result > 0;
        }

        public Account GetAccountById(int id)
        {
            string query = """
                    SELECT * FROM Account WHERE id = @id
                """;
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@id", id);

            DataTable dt = DataProvider.Instance.ExecuteQuery(cmd);
            foreach(DataRow row in dt.Rows)
            {
                return new Account(row);
            }
            return null;
        }

        public bool CheckExistUserName(string userName)
        {
            string query = """
                    SELECT 1 FROM Account WHERE username = @username
                """;
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@username", userName);

            object result = DataProvider.Instance.ExecuteScalar(cmd); // returns first column of first row

            if (result != null && result != DBNull.Value)
            {
                return true;
            }

            return false;
        }
    }
}
