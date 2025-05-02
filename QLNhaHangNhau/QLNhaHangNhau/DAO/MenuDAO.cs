using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using QLNhaHangNhau.DTO;

namespace QLNhaHangNhau.DAO
{
    public class MenuDAO
    {
        private static MenuDAO instance;
        public static MenuDAO GetInstance()
        {
            if (instance == null)
            {
                instance = new MenuDAO();
            }

            return instance;
        }

        private MenuDAO() { }

        public List<Menu> GetListMenu()
        {
            string query = "SELECT * FROM Menu WHERE Active = @status";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@status", "Đang bán");
            DataTable dt = DataProvider.Instance.ExecuteQuery(cmd);
            List<Menu> listMenu = new List<Menu>(); 
            foreach(DataRow row in dt.Rows)
            {
                Menu menu = new Menu(row);
                listMenu.Add(menu);
            }
            return listMenu;
        }

        public List<Menu> GetListMenuAdmin() 
        {
            string query = "SELECT * FROM Menu";
            SqlCommand cmd = new SqlCommand(query);
            DataTable dt = DataProvider.Instance.ExecuteQuery(cmd);
            List<Menu> listMenu = new List<Menu>();
            foreach (DataRow row in dt.Rows)
            {
                Menu menu = new Menu(row);
                menu.Active = row["Active"].ToString();
                listMenu.Add(menu);
            }
            return listMenu;
        }

        public List<string> GetNameOfMenu()
        {
            string query = "SELECT TenMenu FROM Menu";
            SqlCommand cmd = new SqlCommand(query);
            DataTable dt = DataProvider.Instance.ExecuteQuery(cmd);
            List<string> listNameMenu = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                string name = row["TenMenu"].ToString();
                listNameMenu.Add(name);
            }
            return listNameMenu;
        }

        public Menu GetMenuById(int id)
        {
            string query = "SELECT * FROM Menu WHERE id = @id";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@id", id);
            DataTable dt = DataProvider.Instance.ExecuteQuery(cmd);

            Menu menu = null;
            foreach (DataRow row in dt.Rows)
            {
                menu = new Menu(row);
            }
            return menu;
        }

        public bool UpdateMenuById(Menu menu)
        {
            string query = "UPDATE Menu SET TenMenu = @name, Active = @status WHERE id = @id";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@id", menu.ID);
            cmd.Parameters.AddWithValue("@name", menu.Name);
            cmd.Parameters.AddWithValue("@status", menu.Active);

            int result = DataProvider.Instance.ExecuteNonQuery(cmd);

            return result > 0;
        }

        public void DeactiveFoodBelongToMenuId(int menuId)
        {
            string query = """
                UPDATE MonAn SET Active = @status WHERE MenuID = @menuId
                """;
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@status", "Ngừng bán");
            cmd.Parameters.AddWithValue("@menuId", menuId);

            DataProvider.Instance.ExecuteNonQuery(cmd);
            Console.WriteLine($"Deactivate food belong to {menuId}");
        }

        public void ActiveFoodBelongToMenuId(int menuId)
        {
            string query = """
                UPDATE MonAn SET Active = @status WHERE MenuID = @menuId
                """;
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@status", "Đang bán");
            cmd.Parameters.AddWithValue("@menuId", menuId);

            DataProvider.Instance.ExecuteNonQuery(cmd);
            Console.WriteLine($"Activate food belong to {menuId}");
        }

        public Menu CreateMenu(string name)
        {
            string query = "INSERT INTO Menu (TenMenu) OUTPUT Inserted.id VALUES (@name)";

            SqlCommand cmd = new SqlCommand(query);

            cmd.Parameters.AddWithValue("@name", name);
           
            int idMenu= (int)DataProvider.Instance.ExecuteScalar(cmd);
            Console.WriteLine($"new menu id {idMenu}");
            Menu newMenu = new Menu(idMenu, name);

            return newMenu;
        }
    }
}
