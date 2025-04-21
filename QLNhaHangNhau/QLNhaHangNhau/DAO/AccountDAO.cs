using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using QLNhaHangNhau.DTO;

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
    }
}
