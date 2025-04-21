using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using QLNhaHangNhau.DTO;

namespace QLNhaHangNhau.DAO
{
    public class OrderDetailDAO
    {
        private static OrderDetailDAO instance;

        public static OrderDetailDAO GetInstance()
        {
           if (instance == null)
            {
                instance = new OrderDetailDAO();    
            }
           return instance;
        }

        private OrderDetailDAO()
        {
            
        }

        public List<OrderDetail> GetListOrderDetailByTableDetailID(int tableDetailID)
        {
            string query = "SELECT * FROM OrderMon WHERE ChiTietBanID = @tableDetailID";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@tableDetailID", tableDetailID);

            DataTable dt = DataProvider.Instance.ExecuteQuery(cmd);
            List<OrderDetail> listOrderDetail = new List<OrderDetail>();

            foreach(DataRow row in dt.Rows)
            {
                OrderDetail o = new OrderDetail(row);
                listOrderDetail.Add(o);
            }

            return listOrderDetail;
        }

        public int AddFoodForTableByID(int tableDetailID, int foodID, int sl)
        {
            // Check if the table has already order that food
            string query = "EXEC AddFoodForATable @tableDetailID, @foodID, @sl";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@tableDetailID", tableDetailID);
            cmd.Parameters.AddWithValue("@foodID", foodID);
            cmd.Parameters.AddWithValue("@sl", sl);
            int rowAffected = DataProvider.Instance.ExecuteNonQuery(cmd);
            return rowAffected;
        }

        public int ReduceFoodForTableByID(int tableDetailID, int foodID, int sl)
        {
            // Check if the table has already order that food
            string query = "EXEC ReduceFoodForATable @tableDetailID, @foodID, @sl";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@tableDetailID", tableDetailID);
            cmd.Parameters.AddWithValue("@foodID", foodID);
            cmd.Parameters.AddWithValue("@sl", sl);
            int rowAffected = DataProvider.Instance.ExecuteNonQuery(cmd);
            return rowAffected;
            //if (rowAffected > 0)
            //    Console.WriteLine("== Reduce food sucessfully ==");
            //else
            //    Console.WriteLine("== Fail reduce food ==");
        }

        public int RemoveFoodFromTable(int tableDetailID, int foodID)
        {
            string query = "DELETE OrderMon WHERE ChiTietBanID = @tableDetailID AND MonAnID = @foodID";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@tableDetailID", tableDetailID);
            cmd.Parameters.AddWithValue("@foodID", foodID);
            int rowAffected = DataProvider.Instance.ExecuteNonQuery(cmd);
            return rowAffected;
            //if (rowAffected > 0)
            //    Console.WriteLine("== Remove food sucessfully ==");
            //else
            //    Console.WriteLine("== Fail remove food ==");
        }

        public int? GetCurrentQuantity(int tableDetailID, int foodID)
        {
            string query = "SELECT SoLuong FROM OrderMon WHERE ChiTietBanID = @tableDetailID AND MonAnID = @foodID";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@tableDetailID", tableDetailID);
            cmd.Parameters.AddWithValue("@foodID", foodID);
            object result = DataProvider.Instance.ExecuteScalar(cmd);
            int? currentQuantity = null;
            if (result != null)
            {
                currentQuantity = (int)result;
            }
            return currentQuantity;
        }
    }
}
