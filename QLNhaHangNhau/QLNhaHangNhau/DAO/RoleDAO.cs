using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using QLNhaHangNhau.DTO;

namespace QLNhaHangNhau.DAO
{
    public class RoleDAO
    {
        private static RoleDAO instance;

        public static RoleDAO GetInstance()
        {
            if (instance == null)
            {
                instance = new RoleDAO();
            }

            return instance;
        }

        private RoleDAO() { }
        
        public Role GetRoleById(int id)
        {
            string query = "SELECT * FROM ChucVu WHERE id = @id";

            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@id", id);
            DataTable dt = DataProvider.Instance.ExecuteQuery(cmd);
            
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    return new Role(row);
                }
            }
            
            return null;
        }
        public List<Role> GetAllRole()
        {
            string query = "SELECT * FROM ChucVu";

            SqlCommand cmd = new SqlCommand(query);

            DataTable dt = DataProvider.Instance.ExecuteQuery(cmd);
            List<Role> listRole = new List<Role>();

            foreach(DataRow row in dt.Rows)
            {
                listRole.Add(new Role(row));
            }
            return listRole;
        }

        public bool UpdateRole(int id, string name)
        {
            string query = "UPDATE ChucVu SET TenChucVu = @name WHERE id = @id";

            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);

            int result = DataProvider.Instance.ExecuteNonQuery(cmd);
            
            return result > 0;
        }

        public int CreateRole(string name)
        {
            string query = "INSERT INTO ChucVu (TenChucVu) OUTPUT Inserted.id VALUES (@name)";

            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@name", name);

            int idNewRole = (int)DataProvider.Instance.ExecuteScalar(cmd);
            return idNewRole;
        }
    }
}
