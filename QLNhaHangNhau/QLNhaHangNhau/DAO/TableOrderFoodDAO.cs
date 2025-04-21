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
    public class TableOrderFoodDAO
    {
        private static TableOrderFoodDAO instance;

        public static TableOrderFoodDAO GetInstance() 
        { 
            if (instance == null)
            {
                instance = new TableOrderFoodDAO();
            }

            return instance;
        }

        private TableOrderFoodDAO()
        {
            
        }

        public List<TableOrderFood> GetListFoodTableOrdered(int tableDetailID)
        {
            string query = """
                SELECT TenMonAn as foodName, SoLuong as SL,GiaBan as price, SoLuong * GiaBan as totalPrice
                FROM MonAn, OrderMon
                WHERE OrderMon.MonAnID = MonAn.id and OrderMon.ChiTietBanID = @tableDetailID
                """;

            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@tableDetailID", tableDetailID);

            DataTable dt = DataProvider.Instance.ExecuteQuery(cmd);
            List<TableOrderFood> listTableOrderFoods = new List<TableOrderFood>();

            foreach(DataRow row in dt.Rows)
            {
                TableOrderFood t = new TableOrderFood(row);
                listTableOrderFoods.Add(t);
            }

            return listTableOrderFoods;
        }
    }
}
