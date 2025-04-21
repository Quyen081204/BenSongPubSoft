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
            string query = "SELECT * FROM Food";
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
            string query = "SELECT * FROM MonAn WHERE MenuID = @menuID";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@menuID", menuID);
            DataTable dt = DataProvider.Instance.ExecuteQuery(cmd);
            List<Food> listFood = new List<Food>();
            foreach(DataRow row in dt.Rows)
            {
                Food food = new Food(row);
                listFood.Add(food);
            }

            return listFood;
        }
    }
}
