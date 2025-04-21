using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Abstractions;
using QLNhaHangNhau.DTO;

namespace QLNhaHangNhau.DAO
{
    public class EmployeeDAO
    {
        private static EmployeeDAO instance;
        private EmployeeDAO() { }

        public static EmployeeDAO GetInstance() 
        {
            if (instance == null) { instance = new EmployeeDAO(); }

            return instance;
        }

        public Employee GetEmployeeByID(int id)
        {
            string query = "SELECT * FROM NhanVien WHERE id = @id";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@id", id);
            DataTable dt = DataProvider.Instance.ExecuteQuery(cmd);

            foreach (DataRow item in dt.Rows) 
            {
                return new Employee(item);
            }

            return null;
        }

    }
}
