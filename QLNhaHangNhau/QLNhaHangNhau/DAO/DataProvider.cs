using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace QLNhaHangNhau.DAO
{
    public class DataProvider
    {
        private string cnstr = "Data Source=.;Initial Catalog=QLQuanNhau;Integrated Security=True;Trust Server Certificate=True";
        private static DataProvider instance;

        public static DataProvider Instance 
        { 

            get {
                if (instance == null) instance = new DataProvider();
                return instance;
            }  
        }

        private DataProvider() { }

        public DataTable ExecuteQuery(string query, object[] parameters = null)
        {
            DataTable dt = new DataTable();
            using (var conn = new SqlConnection(cnstr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);

                if (parameters != null)
                {
                    string[] list_param = query.Split(' ');
                    int i = 0;
                    foreach (string param in list_param)
                    {
                        if (param.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(param, parameters[i]);
                            i++;
                        }
                    }
                }
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                
                conn.Close();
            }

            return dt;
        }

        public DataTable ExecuteQuery(SqlCommand cmd)
        {
            DataTable dt = new DataTable();
            using (var conn = new SqlConnection(cnstr))
            {
                conn.Open();
                cmd.Connection = conn;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

                conn.Close();
            }

            return dt;
        }

        public int ExecuteNonQuery(string query, object[]? parameters = null)
        {
            int data;
            using (var conn = new SqlConnection(cnstr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);

                if (parameters != null)
                {
                    string[] list_param = query.Split(' ');
                    int i = 0;
                    foreach (string param in list_param)
                    {
                        if (param.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(param, parameters[i]);
                            i++;
                        }
                    }
                }

                data = cmd.ExecuteNonQuery();
            }
            return data;
        }

        public int ExecuteNonQuery(SqlCommand cmd)
        {
            int data = 0;
            try
            {
                using (var conn = new SqlConnection(cnstr))
                {
                    conn.Open();
                    cmd.Connection = conn;

                    data = cmd.ExecuteNonQuery();
                }
               
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return data;
        }


        public object ExecuteScalar(string query, object[]? parameters =null)
        {
            object data;
            using (var conn = new SqlConnection(cnstr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);

                if (parameters != null)
                {
                    string[] list_param = query.Split(' ');
                    int i = 0;
                    foreach (string param in list_param)
                    {
                        if (param.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(param, parameters[i]);
                            i++;
                        }
                    }
                }

                data = cmd.ExecuteScalar();
            }
            return data;
        }

        public object ExecuteScalar(SqlCommand cmd)
        {
            object data;
            using (var conn = new SqlConnection(cnstr))
            {
                conn.Open();
                cmd.Connection = conn;

                data = cmd.ExecuteScalar();
            }
            return data;
        }
    }
}
