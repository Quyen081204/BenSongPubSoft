using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using QLNhaHangNhau.DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLNhaHangNhau.DAO
{
    public class FoodDAO
    {
        private static FoodDAO instance;
        public static FoodDAO GetInstance()
        {
            if (instance == null)
            {
                instance = new FoodDAO();
            }

            return instance;
        }

        private FoodDAO() { }

        public List<Food> GetListFood()
        {
            string query = "SELECT * FROM MonAn";
            SqlCommand cmd = new SqlCommand(query);
            DataTable dt = DataProvider.Instance.ExecuteQuery(cmd);
            List<Food> listFood = new List<Food>();
            foreach (DataRow row in dt.Rows)
            {
                Food food = new Food(row);
                listFood.Add(food);
            }
            return listFood;
        }

        public List<Food> GetFoodByMenuID(int menuID)
        {
            string query = "SELECT * FROM MonAn WHERE MenuID = @menuID AND Active = @status";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@menuID", menuID);
            cmd.Parameters.AddWithValue("@status", "Đang bán");
            DataTable dt = DataProvider.Instance.ExecuteQuery(cmd);
            List<Food> listFood = new List<Food>();
            foreach(DataRow row in dt.Rows)
            {
                Food food = new Food(row);
                listFood.Add(food);
            }

            return listFood;
        }

        public DataTable GetAllFood()
        {
            string query = """
                        SELECT F.id ,F.TenMonAn AS [Tên món], F.GiaBan AS [Gía bán], M.TenMenu AS [Menu], F.Active AS [Tình trạng]
                        FROM MonAn F, Menu M
                        WHERE F.MenuID = M.id
                        ORDER BY F.id
                """;
            SqlCommand cmd = new SqlCommand(query);
            DataTable dt = DataProvider.Instance.ExecuteQuery(cmd);
           
            return dt;
        }

        public Food GetFoodById(int id)
        {
            string query = """
                        SELECT * FROM MonAn WHERE id = @id
                """;
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@id", id);
            DataTable dt = DataProvider.Instance.ExecuteQuery(cmd);

            Food f = new Food();
            foreach(DataRow row in dt.Rows)
            {
                f.ID = (int)row["id"];
                f.Name = row["TenMonAn"].ToString();
                f.MenuID = (int)row["MenuID"];
                f.Price = (double)row["GiaBan"];
            }

            return f;
        }

        public bool UpdateFood(int id, string name, double price, int menuID)
        {
            string query = """
                        UPDATE MonAn 
                        SET TenMonAn = @name, GiaBan = @price, MenuID = @menuID
                        WHERE id = @id
                """;

            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@menuID", menuID);

            int result = DataProvider.Instance.ExecuteNonQuery(cmd);

            return result > 0;
        }

        public bool StopSellingFood(int id)
        {
            string query = """
                        UPDATE MonAn
                        SET Active = @status
                        WHERE id = @id
                """;

            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@status", "Ngưng bán");
            cmd.Parameters.AddWithValue("@id", id);

            int result = DataProvider.Instance.ExecuteNonQuery(cmd);

            return result > 0;
        }

        public bool ReSellingFood(int id)
        {
            string query = """
                        UPDATE MonAn
                        SET Active = @status
                        WHERE id = @id
                """;

            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@status", "Đang bán");
            cmd.Parameters.AddWithValue("@id", id);

            int result = DataProvider.Instance.ExecuteNonQuery(cmd);

            return result > 0;
        }

        public DataTable SearchFoodByKeyWord(string menu, string prop, string keyword, DataTable dt)
        {
            Console.WriteLine("=> Search food");
            //Console.WriteLine(menu);
            //Console.WriteLine(prop);
            //Console.WriteLine(keyword);
            if (menu != "All")
            {
                if (keyword != "")
                {
                    var rows = dt.AsEnumerable().Where(row =>
                    {
                        bool filterMenu = row.Field<string>("Menu") == menu;
                        if (prop != "Gía bán")
                        {
                            return filterMenu && prop != null ? (row.Field<string>(prop).Contains(keyword)) : false;
                        }

                        return filterMenu && double.TryParse(keyword, out double price) ? (row.Field<double>(prop) == price) : false;
                    });

                    DataTable filteredTable = rows.Any() ? rows.CopyToDataTable() : dt.Clone();

                    return filteredTable;
                }
                else
                {
                    var rows = dt.AsEnumerable().Where(row => row.Field<string>("Menu") == menu);

                    DataTable filteredTable = rows.Any() ? rows.CopyToDataTable() : dt.Clone();

                    return filteredTable;
                }
                
            }
            else
            {
                if (keyword != "")
                {
                    var rows = dt.AsEnumerable().Where(row =>
                    {
                        if (prop != "Gía bán")
                        {
                            return row.Field<string>(prop).Contains(keyword);
                        }

                        return double.TryParse(keyword, out double price) ? (row.Field<double>(prop) == price) : false;
                    });

                    DataTable filteredTable = rows.Any() ? rows.CopyToDataTable() : dt.Clone();

                    return filteredTable;
                }
                else
                {
                    return dt;
                }
                
            }
        }

        public Food CreateFood(string name, double price, int menuId)
        {
            string query = "INSERT INTO MonAn (TenMonAn, GiaBan, MenuID) OUTPUT Inserted.id VALUES (@name, @price, @menuId)";

            SqlCommand cmd = new SqlCommand(query);

            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@menuId", menuId);

            int idFood = (int)DataProvider.Instance.ExecuteScalar(cmd);
            Food newFood = new Food(idFood, name, menuId, price);
            
            return newFood;
        }
    }
}
