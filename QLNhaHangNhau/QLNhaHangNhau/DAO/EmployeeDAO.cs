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

        public List<Employee> GetAllEmployeeAdmin() 
        {
            string query = "SELECT * FROM NhanVien";
            SqlCommand cmd = new SqlCommand(query);
           
            DataTable dt = DataProvider.Instance.ExecuteQuery(cmd);
            List<Employee> listEmployee = new List<Employee>();
            foreach (DataRow item in dt.Rows)
            {
                listEmployee.Add(new Employee(item));
            }
            return listEmployee;
        }

        public bool UpdateRoleOfEmployee(int id, int roleId)
        {
            string query = "UPDATE NhanVien SET ChucVuID = @roleId WHERE id = @id";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@roleId", roleId);

            int result = DataProvider.Instance.ExecuteNonQuery(cmd);

            return result > 0;
        }

        public int CreateEmployee(string firstName, string lastName, int sex, int roleId, DateTime date)
        {
            string query = "INSERT INTO NhanVien (ho, ten, GioiTinh, ChucVuID, Joined_date) OUTPUT Inserted.id VALUES (@firstName, @lastName, @sex, @roleId, @date)";
            SqlCommand cmd = new SqlCommand(query);
        
            cmd.Parameters.AddWithValue("@firstName", firstName);
            cmd.Parameters.AddWithValue("@lastName", lastName);
            cmd.Parameters.AddWithValue("@sex", sex);
            cmd.Parameters.AddWithValue("@roleId", roleId);
            cmd.Parameters.AddWithValue("@date", date);

            int idEm = (int)DataProvider.Instance.ExecuteScalar(cmd);

            return idEm;
        }
    }
}
